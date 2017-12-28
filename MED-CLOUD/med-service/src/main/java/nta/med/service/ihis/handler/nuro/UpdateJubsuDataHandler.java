package nta.med.service.ihis.handler.nuro;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;

import java.math.BigDecimal;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;
import java.util.concurrent.TimeUnit;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.logging.log4j.util.Strings;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.common.remoting.rpc.message.RpcMessageParser;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.ifs.Ifs0003;
import nta.med.core.domain.out.Out0101;
import nta.med.core.domain.out.Out1001;
import nta.med.core.domain.out.Out1002;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.ExamStatus;
import nta.med.core.glossary.MonitorKey;
import nta.med.core.infrastructure.MonitorLog;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.bas.Bas0212Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.data.dao.medi.nur.OrcaReceptionRepository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.out.Out1002Repository;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
@Transactional
public class UpdateJubsuDataHandler extends ScreenHandler<NuroServiceProto.UpdateJubsuDataRequest, SystemServiceProto.UpdateResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(UpdateJubsuDataHandler.class);
	
	private RpcMessageParser parser = new RpcMessageParser(NuroServiceProto.class);

	@Resource
	private Out0101Repository out0101Repository;
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Resource
	private Out1002Repository out1002Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Resource
	private Bas0212Repository bas0212Repository;
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Resource
	Ifs0003Repository ifs0003Repository;
	
	@Resource
	private OrcaReceptionRepository orcaReceptionRepository;

	@Resource
	private Bas0260Repository bas0260Repository;
	@Override
	@Route(global = true)
	public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, NuroServiceProto.UpdateJubsuDataRequest request) throws Exception  {
		boolean isOrcaRequest = request.getIsOrca();
		if(isOrcaRequest){
			List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getOrcaGigwanCode());
			LOGGER.info("UpdateJubsuDataHandler preHandle has session Id" +sessionId);
			if(!CollectionUtils.isEmpty(bas0001List)){
				setSessionInfo(vertx, sessionId,
						SessionUserInfo.setSessionUserInfoByUserGroup(bas0001List.get(0).getHospCode(), bas0001List.get(0).getLanguage(), "", 1, ""));
				LOGGER.info("UpdateJubsuDataHandler preHandle has hosp code" + bas0001List.get(0).getHospCode());
			} else{
				LOGGER.info("UpdateJubsuDataHandler preHandle not found hosp code");
			}
		}
	}
	
	@Override
	@Route(global = false)
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.UpdateJubsuDataRequest request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		response = updateJubsuData(vertx, request, getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		
		if(!response.getResult()){
			response.setResult(false);
			throw new ExecutionException(response.build());
		}
		
		MonitorLog.writeMonitorLog(MonitorKey.REG_RECEPTION, "New reception have been successfully registered");
		return response.build();
	}
	
	public SystemServiceProto.UpdateResponse.Builder updateJubsuData(Vertx vertx, NuroServiceProto.UpdateJubsuDataRequest request, String hospCode, String language) throws Exception{
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<NuroModelProto.UpdateJubsuDataInfo> listJubsu = request.getDataInfoList();

    	for(NuroModelProto.UpdateJubsuDataInfo itemJubsu : listJubsu){

    		// check is reception 
    		if(!request.getIsOrca() && StringUtils.isEmpty(itemJubsu.getDataRowState())){	// Is MISA request
    			String codeName = bas0102Repository.getCodeNameByCodeTypeAndCode(hospCode, language, "JUBSU_GUBUN", itemJubsu.getReceptionType());
    			if(StringUtils.isEmpty(codeName)){
    				response.setResult(true);
        			LOGGER.info("Not reception: Reception Type from client = " + itemJubsu.getReceptionType() + ", hospCode = " + hospCode);
        			return response;
    			}
    		}
    		
    		String nuroOUT1001U01GetDbMaxJubsuNo = null;
    		Integer receptionNoOrca = null;
    		String dataRowState = "";
    		BigDecimal receptionNo = null;
    		String arriveTime = "";		
    		Double fkout1001 = 0.0;
    		String extMsgCode = "";
    		String refId = null;
    		
    		if(!request.getIsOrca()){
    			// request from KCCK/MISA
    			if(!StringUtils.isEmpty(itemJubsu.getReceptionNo())){
    				receptionNo = new BigDecimal(itemJubsu.getReceptionNo());
    			}
    			
    			dataRowState = itemJubsu.getDataRowState();
    			if(StringUtils.isEmpty(itemJubsu.getDataRowState())){ // from MISA
    				String leftPadBunho = org.apache.commons.lang3.StringUtils.leftPad(itemJubsu.getPatientCode(), 9, "0");
    				List<String> departmentCodes = bas0270Repository.getGwaBySabunAndHospCode(hospCode, itemJubsu.getDoctorCode());
    				String departmentCode = CollectionUtils.isEmpty(departmentCodes) ? "" : departmentCodes.get(0);

    				List<String> lstCheck = out1001Repository.checkIfBunhoExistByBunhoAndHospCode(hospCode, leftPadBunho);
    				String examStatus = "1";
    				examStatus = (!CollectionUtils.isEmpty(lstCheck) && lstCheck.size() == 1) ? "3" : "4";
    				
    	    		List<Double> listPK = out1001Repository.findPK(hospCode, leftPadBunho, 
        					DateUtil.toDate(itemJubsu.getComingDate(), DateUtil.PATTERN_YYMMDD), itemJubsu.getReceptionTime());
    				if(CollectionUtils.isEmpty(listPK)){
    					dataRowState = DataRowState.ADDED.getValue();
    				} else {
    					dataRowState = DataRowState.MODIFIED.getValue();
    					fkout1001 = listPK.get(0);
    				}
    	    		
    				if(StringUtils.isEmpty(itemJubsu.getReceptionNo())){
    					nuroOUT1001U01GetDbMaxJubsuNo = out1001Repository.getNuroOUT1001U01GetDbMaxJubsuNo(hospCode, leftPadBunho, itemJubsu.getComingDate());
						receptionNo = !StringUtils.isEmpty(nuroOUT1001U01GetDbMaxJubsuNo)
								? new BigDecimal(CommonUtils.parseInteger(nuroOUT1001U01GetDbMaxJubsuNo) + 1) : new BigDecimal(1);
    				}
    				
    				itemJubsu = itemJubsu.toBuilder()
    							.setPatientCode(leftPadBunho)
    							.setDepartmentCode(departmentCode)
    							.setDoctorCode(departmentCode + itemJubsu.getDoctorCode())
    							.setExamStatus(examStatus)
    							.setDataRowState(dataRowState)
    							.setReceptionNo(receptionNo.toString())
    							.build();
    			}
    		}else{
    			// Request from ORCA-GATEWAY			
    			
    			// [1] Setting reception no
    			nuroOUT1001U01GetDbMaxJubsuNo = out1001Repository.getNuroOUT1001U01GetDbMaxJubsuNo(hospCode, itemJubsu.getPatientCode(), itemJubsu.getComingDate());
    			receptionNoOrca = !StringUtils.isEmpty(nuroOUT1001U01GetDbMaxJubsuNo) ? CommonUtils.parseInteger(nuroOUT1001U01GetDbMaxJubsuNo) + 1 : 1;
	    		receptionNo =  new BigDecimal(receptionNoOrca);
	    		
	    		// [2] String department code and doctor code
	    		String departmentCode = "";
    			List<Ifs0003> listIfs0003Gwa = ifs0003Repository.findByHospCodeAndMapGubunAndIfCode(hospCode, AccountingConfig.IF_ORCA_GWA.getValue(), itemJubsu.getDepartmentCode());
    			if(!CollectionUtils.isEmpty(listIfs0003Gwa)){
    				departmentCode = listIfs0003Gwa.get(0).getOcsCode() == null? "" : listIfs0003Gwa.get(0).getOcsCode();
    			}
    			
    			String doctorCode = "";
    			List<Ifs0003> listIfs0003Doctor = ifs0003Repository.findByHospCodeAndMapGubunAndIfCode(hospCode, AccountingConfig.IF_ORCA_DOCTOR.getValue(), itemJubsu.getDoctorCode());
    			if(!CollectionUtils.isEmpty(listIfs0003Doctor)){
    				doctorCode = listIfs0003Doctor.get(0).getOcsCode() == null ? "" : listIfs0003Doctor.get(0).getOcsCode();
    				doctorCode = departmentCode + doctorCode;
    			}
	    		
	    		// [3] Setting data row state
	    		List<Out1001> receptionList = out1001Repository.findByHospCodeNaewonDateBunhoRefReceptId(hospCode,
						DateUtil.toDate(itemJubsu.getComingDate(), DateUtil.PATTERN_YYMMDD),
						itemJubsu.getPatientCode(), itemJubsu.getReceptRefId());
	    		if(!CollectionUtils.isEmpty(receptionList)){
	    			dataRowState = DataRowState.MODIFIED.getValue();
    				fkout1001 = receptionList.get(0).getPkout1001();
	    		} else{
	    			if((!itemJubsu.hasHasAppointment()) || (itemJubsu.hasHasAppointment() && !"Y".equals(itemJubsu.getHasAppointment()))){
	    				dataRowState = DataRowState.ADDED.getValue();
	    			} else {
	    				List<Out1001> reserList = out1001Repository.findReservation(hospCode,
								DateUtil.toDate(itemJubsu.getComingDate(), DateUtil.PATTERN_YYMMDD),
								itemJubsu.getPatientCode(), itemJubsu.getReceptionTime(), doctorCode, departmentCode, "Y");
						
						if(CollectionUtils.isEmpty(reserList)){
							dataRowState = DataRowState.ADDED.getValue(); // have to set reser_yn = Y, arrive_time, naewon_yn = Y
						} else {
							dataRowState = DataRowState.MODIFIED.getValue();
							fkout1001 = reserList.get(0).getPkout1001();
						}
	    			}
	    		}
	    		
	    		// [4] Setting exam status
	    		String examStatus = "1";
	    		List<Out1001> pts = out1001Repository.findByHospCodeAndBunho(hospCode, itemJubsu.getPatientCode());
	    		if(CollectionUtils.isEmpty(pts)){
	    			examStatus = "1";
	    		} else {
	    			DateFormat df = new SimpleDateFormat("yyyy-MM-dd");
	    			String currentDate = df.format(new Date());
	    			
	    			for (Out1001 pt : pts) {
	    				if(pt.getNaewonDate() != null){
	    					if(currentDate.equals(DateUtil.toString(pt.getNaewonDate(), DateUtil.PATTERN_YYYY_MM_DD))){
	    						examStatus = "4";
	            				break;
	    					}
	    				}
					}
	    			
	    			if(!"4".equals(examStatus)){
	    				examStatus = "3";
	    			}
	    		}
	    		
    			List<String> patientExist = out1001Repository.checkIfBunhoExistByBunhoAndHospCode(hospCode, itemJubsu.getPatientCode());
    			if(CollectionUtils.isEmpty(patientExist)){
    				examStatus = "1";
    			}else{
    				examStatus = ExamStatus.FIRST.getValue().equals(itemJubsu.getExamStatus())? "3" : "4";
    			}
    			
    			// [5] Setting reception type
    			String receptionType = bas0102Repository.getCodeByCodeTypeAndCodeName(hospCode, "JUBSU_GUBUN", language, itemJubsu.getReceptionType());
    			receptionType = receptionType == null ? "" : receptionType;
    			
    			if(StringUtils.isEmpty(receptionType)){
    				receptionType = itemJubsu.getReceptionType();
    			}
    			
				itemJubsu = itemJubsu.toBuilder()
						.setReceptionType(receptionType)
						.setExamStatus(examStatus)
						.setDepartmentCode(departmentCode)
						.setDoctorCode(doctorCode)
						.build();
    		}
    		
    		// External accounting process
        	if(!request.getIsOrca()){
        		List<Bas0102> bas0102List = bas0102Repository.findByHospCodeAndCodeType(hospCode, AccountingConfig.ACCT_TYPE.getValue());
        		if(!CollectionUtils.isEmpty(bas0102List) && AccountingConfig.ACCCT_TYPE_ORCA.getValue().equalsIgnoreCase(bas0102List.get(0).getCode())){
        			List<Ifs0003> gwaLst = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode, AccountingConfig.IF_ORCA_GWA.getValue(), itemJubsu.getDepartmentCode());
					List<Ifs0003> doctorLst = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode, AccountingConfig.IF_ORCA_DOCTOR.getValue(), itemJubsu.getDoctorCode().substring(2, itemJubsu.getDoctorCode().length()));
					String dept = !CollectionUtils.isEmpty(gwaLst) ? gwaLst.get(0).getIfCode() : "";
					String doctor = !CollectionUtils.isEmpty(doctorLst) ? doctorLst.get(0).getIfCode() : "";
					
        			if (DataRowState.ADDED.getValue().equals(itemJubsu.getDataRowState()) 
        					|| DataRowState.DELETED.getValue().equals(itemJubsu.getDataRowState())) {
        				
        				// add or delete reception
    					NuroServiceProto.SaveExaminationRequest.Builder saveReqbuilder = NuroServiceProto.SaveExaminationRequest
    							.newBuilder().setId(System.currentTimeMillis()).setHospCode(hospCode)
    							.setExamInfo(itemJubsu.toBuilder().setDepartmentCode(dept).setDoctorCode(doctor));
    					
    					FutureEx<NuroServiceProto.SaveExaminationResponse> res = send(vertx, parser, saveReqbuilder.build(), hospCode);
    					NuroServiceProto.SaveExaminationResponse r = res.get(30, TimeUnit.SECONDS);
    					
    					if(r != null) LOGGER.info("response from remote gateway: " + format(r));
    					if(r == null || r.getResult() != NuroServiceProto.SaveExaminationResponse.Result.SUCCESS){
    						response.setMsg(r == null ? "" : r.getMessageCode());
    						response.setResult(false);
    						return response;
    					}
    					
    					// delete appointment
    					if(DataRowState.DELETED.getValue().equals(itemJubsu.getDataRowState())){
    						Out1001 out1001 = out1001Repository.findByHospCodeAndPkOut1001(hospCode, CommonUtils.parseDouble(itemJubsu.getPkout1001()));
    						if(out1001 != null && "Y".equals(out1001.getReserYn())){
    							NuroServiceProto.BookingExaminationRequest.Builder builder = NuroServiceProto.BookingExaminationRequest
    									.newBuilder()
    									.setHospCode(hospCode)
    									.setDepartmentCode(dept)
    									.setDoctorCode(doctor)
    									.setReservationDate(DateUtil.toString(out1001.getNaewonDate(), DateUtil.PATTERN_YYMMDD))
    									.setReservationTime(out1001.getJubsuTime())
    									.setPatientCode(out1001.getBunho())
    									.setPatientNameKanji("")
    									.setPatientNameKana("")
    									.setPatientTel("")
    									.setPatientSex("")
    									.setPatientBirthday("")
    									.setLocale("")
    									.setPatientType("")
    									.setType("")
    									.setUserId("")
    									.setReservationCode("")
    									.setAction(NuroServiceProto.BookingExaminationRequest.Action.CANCEL_BOOKING);
    							
    							FutureEx<NuroServiceProto.BookingExaminationResponse> resCancel = send(vertx, parser, builder.build(), hospCode);
    							NuroServiceProto.BookingExaminationResponse rCancel = resCancel.get(30, TimeUnit.SECONDS);
    						}
    					}
    					
						if(r.hasMessageCode()) extMsgCode = r.getMessageCode();
						refId = r.getRefId();
						response.setMsg(extMsgCode);
						response.setResult(r.getResult() == NuroServiceProto.SaveExaminationResponse.Result.SUCCESS);
						
    				} else if(DataRowState.MODIFIED.getValue().equals(itemJubsu.getDataRowState())){
    					Out1001 out1001 = out1001Repository.findByHospCodeAndPkOut1001(hospCode, CommonUtils.parseDouble(itemJubsu.getPkout1001()));
    					if("Y".equals(out1001.getReserYn())){
    						if(!"Y".equals(out1001.getNaewonYn()) && "Y".equals(itemJubsu.getCheckComing())){
    							// tiep nhan hen kham
    							NuroServiceProto.SaveExaminationRequest.Builder saveReqbuilder = NuroServiceProto.SaveExaminationRequest
    	    							.newBuilder()
    	    							.setId(System.currentTimeMillis())
    	    							.setHospCode(hospCode)
    	    							.setExamInfo(itemJubsu.toBuilder()
    	    									.setDepartmentCode(dept)
    	    									.setDoctorCode(doctor)
    	    									.setDataRowState(DataRowState.ADDED.getValue()));
    	    					
    	    					FutureEx<NuroServiceProto.SaveExaminationResponse> res = send(vertx, parser, saveReqbuilder.build(), hospCode);
    	    					NuroServiceProto.SaveExaminationResponse r = res.get(30, TimeUnit.SECONDS);
    	    					
    	    					if(r == null || r.getResult() != NuroServiceProto.SaveExaminationResponse.Result.SUCCESS){
    	    						response.setMsg(r == null ? "" : r.getMessageCode());
        	    					response.setResult(false);
        	    					return response;
    	    					}
    	    					
    	    					response.setMsg(extMsgCode);
        						response.setResult(r.getResult() == NuroServiceProto.SaveExaminationResponse.Result.SUCCESS);
        						refId = r.getRefId();
    						} else if("Y".equals(out1001.getNaewonYn()) && !"Y".equals(itemJubsu.getCheckComing())){
    							// huy tiep nhan hen kham
    							NuroServiceProto.SaveExaminationRequest.Builder saveReqbuilder = NuroServiceProto.SaveExaminationRequest
    	    							.newBuilder()
    	    							.setId(System.currentTimeMillis())
    	    							.setHospCode(hospCode)
    	    							.setExamInfo(itemJubsu.toBuilder()
    	    									.setDepartmentCode(dept)
    	    									.setDoctorCode(doctor)
    	    									.setReceptRefId(out1001.getReceptRefId() == null ? "" : out1001.getReceptRefId())
    	    									.setDataRowState(DataRowState.DELETED.getValue()));
    	    					
    	    					FutureEx<NuroServiceProto.SaveExaminationResponse> res = send(vertx, parser, saveReqbuilder.build(), hospCode);
    	    					NuroServiceProto.SaveExaminationResponse r = res.get(30, TimeUnit.SECONDS);
    	    					
    	    					if(r == null || r.getResult() != NuroServiceProto.SaveExaminationResponse.Result.SUCCESS){
    	    						response.setMsg(r == null ? "" : r.getMessageCode());
        	    					response.setResult(false);
        	    					return response;
    	    					}
    	    					
    	    					response.setMsg(extMsgCode);
        						response.setResult(r.getResult() == NuroServiceProto.SaveExaminationResponse.Result.SUCCESS);
        						refId = "";
    						} else {
    							// update tiep nhan hen kham
    							// dirty code !!! need to refactor code after
    							
    							// delete old reception
        						NuroServiceProto.SaveExaminationRequest.Builder delReqbuilder = NuroServiceProto.SaveExaminationRequest
            							.newBuilder()
            							.setId(System.currentTimeMillis())
            							.setHospCode(hospCode)
            							.setExamInfo(itemJubsu.toBuilder().setDepartmentCode(dept).setDoctorCode(doctor).setDataRowState(DataRowState.DELETED.getValue()));
            					
            					FutureEx<NuroServiceProto.SaveExaminationResponse> delRes = send(vertx, parser, delReqbuilder.build(), hospCode);
            					NuroServiceProto.SaveExaminationResponse r1 = delRes.get(30, TimeUnit.SECONDS);
            					if(r1 == null || r1.getResult() != NuroServiceProto.SaveExaminationResponse.Result.SUCCESS){
            						response.setMsg(r1 == null ? "" : r1.getMessageCode());
            						response.setResult(false);
            						return response;
            					}
            					
            					// create new reception
            					NuroServiceProto.SaveExaminationRequest.Builder createReqbuilder = NuroServiceProto.SaveExaminationRequest
            							.newBuilder().setId(System.currentTimeMillis()).setHospCode(hospCode)
            							.setExamInfo(itemJubsu.toBuilder().setDepartmentCode(dept).setDoctorCode(doctor).setDataRowState(DataRowState.ADDED.getValue()));
            					
            					FutureEx<NuroServiceProto.SaveExaminationResponse> createRes = send(vertx, parser, createReqbuilder.build(), hospCode);
            					NuroServiceProto.SaveExaminationResponse r2 = createRes.get(30, TimeUnit.SECONDS);
            					if(r2 == null || r2.getResult() != NuroServiceProto.SaveExaminationResponse.Result.SUCCESS){
            						response.setMsg(r2 == null ? "" : r2.getMessageCode());
            						response.setResult(false);
            						return response;
            					}
            					
            					// update new ref_id
            					refId = r2.getRefId();
    						}
    					} else {
    						// delete old reception
    						NuroServiceProto.SaveExaminationRequest.Builder delReqbuilder = NuroServiceProto.SaveExaminationRequest
        							.newBuilder()
        							.setId(System.currentTimeMillis())
        							.setHospCode(hospCode)
        							.setExamInfo(itemJubsu.toBuilder().setDepartmentCode(dept).setDoctorCode(doctor).setDataRowState(DataRowState.DELETED.getValue()));
        					
        					FutureEx<NuroServiceProto.SaveExaminationResponse> delRes = send(vertx, parser, delReqbuilder.build(), hospCode);
        					NuroServiceProto.SaveExaminationResponse r1 = delRes.get(30, TimeUnit.SECONDS);
        					if(r1 == null || r1.getResult() != NuroServiceProto.SaveExaminationResponse.Result.SUCCESS){
        						response.setMsg(r1 == null ? "" : r1.getMessageCode());
        						response.setResult(false);
        						return response;
        					}
        					
        					// create new reception
        					NuroServiceProto.SaveExaminationRequest.Builder createReqbuilder = NuroServiceProto.SaveExaminationRequest
        							.newBuilder().setId(System.currentTimeMillis()).setHospCode(hospCode)
        							.setExamInfo(itemJubsu.toBuilder().setDepartmentCode(dept).setDoctorCode(doctor).setDataRowState(DataRowState.ADDED.getValue()));
        					
        					FutureEx<NuroServiceProto.SaveExaminationResponse> createRes = send(vertx, parser, createReqbuilder.build(), hospCode);
        					NuroServiceProto.SaveExaminationResponse r2 = createRes.get(30, TimeUnit.SECONDS);
        					if(r2 == null || r2.getResult() != NuroServiceProto.SaveExaminationResponse.Result.SUCCESS){
        						response.setMsg(r2 == null ? "" : r2.getMessageCode());
        						response.setResult(false);
        						return response;
        					}
        					
        					// update new ref_id
        					refId = r2.getRefId();
    					}
    				}
        		}
        	}
    		
    		if(DataRowState.ADDED.getValue().equals(dataRowState)){
    			fkout1001 = insertOut1001(itemJubsu, hospCode, receptionNo, refId);
    			String pkout1001 = String.valueOf(fkout1001);;
//    			if(request.getIsOrca()){
//    				pkout1001 = String.valueOf(fkout1001);
//    			} else {
//    				pkout1001 = itemJubsu.getPkout1001();
//    			}
    			
    			response = addedProcess(hospCode, itemJubsu, receptionNo, pkout1001);
    		}else if(DataRowState.MODIFIED.getValue().equals(dataRowState)){
    			arriveTime = request.getIsOrca() ? commonRepository.getFormEnvironSysDateTimePATTERNHHMM() : itemJubsu.getArriveTime(); 
    			response = modifiedProcess(hospCode, itemJubsu, arriveTime, request.getIsOrca(), fkout1001, receptionNo, refId);
    		} else if(DataRowState.DELETED.getValue().equals(dataRowState)){
    			response = deletedProcess(hospCode, itemJubsu, extMsgCode);
    		}
    		
			if (!response.getResult()) return response;
    		
        	//publishPatientEvent(vertx, hospCode, itemJubsu, fkout1001, language);
			publishBookingEvent(vertx, hospCode, itemJubsu, fkout1001, language);
    	}
    	
    	// sync prescription event
    	publishPrescriptionEvent(vertx, hospCode, listJubsu);
		
    	response.setResult(true);
		return response;
	}
	
	
	private void publishPatientEvent(Vertx vertx, String hospCode, NuroModelProto.UpdateJubsuDataInfo itemJubsu, Double fkout1001, String language){
		LOGGER.info("UpdateJubsuDataHandler throw patient event: bunho = " + itemJubsu.getPatientCode()
				+ ", departmentCode = " + itemJubsu.getDepartmentCode() + ", hospcode = " + hospCode);

		List<Out0101> out0101List = out0101Repository.getByBunho(hospCode, itemJubsu.getPatientCode());
		LOGGER.info("UpdateJubsuDataHandler out0101List: " + out0101List);
		if(!CollectionUtils.isEmpty(out0101List))
		{
			NuroModelProto.UpdateJubsuDataInfo.Builder itemJubsuUpdate = itemJubsu.toBuilder();
			itemJubsuUpdate.setPkout1001(fkout1001 != null ? fkout1001.toString() : "");
			NuroServiceProto.PatientEvent.Builder builder = NuroServiceProto.PatientEvent.newBuilder()
					.setHospCode(hospCode).setPatientCode(itemJubsu.getPatientCode());
			if(!Strings.isEmpty(itemJubsu.getDepartmentCode())){
				String gwaName = bas0260Repository.getBasLoadGwaName(itemJubsu.getDepartmentCode(),
						DateUtil.toString(new Date(), DateUtil.PATTERN_YYMMDD), hospCode, language);
				LOGGER.info("UpdateJubsuDataHandler gwaName: "+gwaName);
				itemJubsuUpdate.setDepartmentName(gwaName);
			}
			
			LOGGER.info("UpdateJubsuDataHandlerPrepare NuroModelProto");
			NuroModelProto.NuroOUT0101U02GridPatientInfo.Builder patientProfile = NuroModelProto.NuroOUT0101U02GridPatientInfo.newBuilder();
			patientProfile.setSuname(out0101List.get(0).getSuname());
			patientProfile.setPass(out0101List.get(0).getPwd() == null ? "" : out0101List.get(0).getPwd());
			builder.setPatientProfile(patientProfile);
			builder.setAcceptInfo(itemJubsuUpdate);
			LOGGER.info("UpdateJubsuDataHandler Publish");
			publish(vertx, builder.build());
		}
	}
	
	private void publishBookingEvent(Vertx vertx, String hospCode, NuroModelProto.UpdateJubsuDataInfo itemJubsu, Double fkout1001, String language){
		LOGGER.info("Publish booking event...");
		List<Out0101> out0101List = out0101Repository.getByBunho(hospCode, itemJubsu.getPatientCode());
		if(CollectionUtils.isEmpty(out0101List)){
			LOGGER.info("Could not find patient " + itemJubsu.getPatientCode() + ", hosp_code = " + hospCode);
			return;
		}
		Out0101 patient = out0101List.get(0);
		
		NuroModelProto.BookingExamInfo.Builder bookingExamIfo = NuroModelProto.BookingExamInfo.newBuilder();
		bookingExamIfo.setIsMssRequest(false);
		bookingExamIfo.setPatientCode(itemJubsu.getPatientCode());
		bookingExamIfo.setPatientName(patient.getSuname() == null ? "" : patient.getSuname());
		bookingExamIfo.setReservationCode(String.valueOf(fkout1001));
		//bookingExamIfo.setAction();
		bookingExamIfo.setHospCode(hospCode);
		bookingExamIfo.setDepartmentCode(itemJubsu.getDepartmentCode());
		if(!Strings.isEmpty(itemJubsu.getDepartmentCode())){
			String gwaName = bas0260Repository.getBasLoadGwaName(itemJubsu.getDepartmentCode(),
					DateUtil.toString(new Date(), DateUtil.PATTERN_YYMMDD), hospCode, language);
			bookingExamIfo.setDepartmentName(gwaName);
		}
		
		bookingExamIfo.setDoctorCode(itemJubsu.getDoctorCode());
		bookingExamIfo.setPatientPwd(patient.getPwd() == null ? "" : patient.getPwd());
		bookingExamIfo.setReservationDate(itemJubsu.getComingDate());
		bookingExamIfo.setReservationTime(itemJubsu.getReceptionTime());
		bookingExamIfo.setReserYn("N");
		
		NuroServiceProto.BookingEvent.Builder message = NuroServiceProto.BookingEvent.newBuilder()
				.setPatientCode(itemJubsu.getPatientCode())
				.setPatientName(patient.getSuname() == null ? "" : patient.getSuname())
				.setBookingExamInfo(bookingExamIfo)
				.setHospCode(hospCode);
		publish(vertx, message.build());
	}
	
	private void publishPrescriptionEvent(Vertx vertx, String hospCode, List<NuroModelProto.UpdateJubsuDataInfo> listJubsu){
		if(CollectionUtils.isEmpty(listJubsu))
			return;
		
		LOGGER.info("Sync prescription throw PATIENT_EVENT!!! hospCode=" + hospCode + ", patientCode=" + listJubsu.get(0).getPatientCode());
		NuroServiceProto.PatientEvent.Builder builder = NuroServiceProto.PatientEvent.newBuilder()
				.setHospCode(hospCode).setPatientCode(listJubsu.get(0).getPatientCode());
		List<Out1001> out1001List = out1001Repository.findByHospCodeAndBunho(hospCode, listJubsu.get(0).getPatientCode());
		if(!CollectionUtils.isEmpty(out1001List)){
			for (Out1001 out1001 : out1001List) {
    			NuroModelProto.SyncPrescription.Builder item = NuroModelProto.SyncPrescription.newBuilder();
    			item.setDatetimeRecord(DateUtil.toString(out1001.getNaewonDate(), DateUtil.PATTERN_YYYY_MM_DD) + " " + out1001.getJubsuTime());
    			item.setPrescriptionName(CommonUtils.parseString(out1001.getPkout1001()));
    			item.setSyncId(out1001.getId());
    			builder.addPrescriptionInfo(item);
			}
		} else {
			builder.setDeletedAllPrescription(true);
		}
		
		LOGGER.info("Sync prescription Publish!!!");
		publish(vertx, builder.build());
	}
	
	private SystemServiceProto.UpdateResponse.Builder addedProcess(String hospCode
			, NuroModelProto.UpdateJubsuDataInfo itemJubsu
			, BigDecimal receptionNo
			, String pkout1001){
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String retVal1 = out1001Repository.getNuroOUT1001U01CheckY2(hospCode, itemJubsu.getPatientCode(), DateUtil.toDate(itemJubsu.getComingDate(), DateUtil.PATTERN_YYMMDD) , 
				itemJubsu.getDepartmentCode(), itemJubsu.getDoctorCode(), itemJubsu.getComingType(), receptionNo);
		if("Y".equals(retVal1)){
			response.setResult(false);
			response.setMsg("OUT1001U01_TEXT020");
			return response;
		}
		
		String retVal2 = out1001Repository.getNuroOUT1001U01CheckY3(hospCode, itemJubsu.getPatientCode(),
				DateUtil.toDate(itemJubsu.getComingDate(), DateUtil.PATTERN_YYMMDD), receptionNo);
		if("Y".equals(retVal2)){
			response.setResult(false);
			response.setMsg("OUT1001U01_TEXT021");
			return response;
		}
		
		if(itemJubsu.getInsurCode1().length() > 0){
			if(!insertTableOUT1002(itemJubsu.getSysId(), itemJubsu.getUpdId(), pkout1001, 
					itemJubsu.getInsurCode1(), itemJubsu.getPatientCode(), itemJubsu.getPriority1(), hospCode)){
				response.setResult(false);
				response.setMsg("OUT1002-1 Insert Error");
				return response;
			}
		}
		
		if(itemJubsu.getInsurCode2().length() > 0){
			if(!insertTableOUT1002(itemJubsu.getSysId(), itemJubsu.getUpdId(), pkout1001, 
					itemJubsu.getInsurCode2(), itemJubsu.getPatientCode(), itemJubsu.getPriority2(), hospCode)){
				response.setResult(false);
				response.setMsg("OUT1002-2 Insert Error");
				return response;
			}
		}
		
		if(itemJubsu.getInsurCode3().length() > 0){
			if(!insertTableOUT1002(itemJubsu.getSysId(), itemJubsu.getUpdId(), pkout1001, 
					itemJubsu.getInsurCode3(), itemJubsu.getPatientCode(), itemJubsu.getPriority3(), hospCode)){
				response.setResult(false);
				response.setMsg("OUT1002-3 Insert Error");
				return response;
			}
		}
		
		if(itemJubsu.getInsurCode4().length() > 0){
			if(!insertTableOUT1002(itemJubsu.getSysId(), itemJubsu.getUpdId(), pkout1001, 
					itemJubsu.getInsurCode4(), itemJubsu.getPatientCode(), itemJubsu.getPriority4(), hospCode)){
				response.setResult(false);
				response.setMsg("OUT1002-4 Insert Error");
				return response;
			}
		}
		
		response.setResult(true);
		return response;
	}
	
	private SystemServiceProto.UpdateResponse.Builder modifiedProcess(String hospCode
			, NuroModelProto.UpdateJubsuDataInfo itemJubsu
			, String arriveTime
			, Boolean isOrca
			, Double fkout1001
			, BigDecimal receptionNo
			, String refId){
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String retVal = out1001Repository.getNuroOUT1001U01GetGubunName(itemJubsu.getInsurCode(), itemJubsu.getComingDate(), itemJubsu.getPatientCode(), hospCode);
		
		if(retVal == null && !StringUtils.isEmpty(itemJubsu.getInsurCode())){
			LOGGER.debug("Can not find GUBUN_NAME with param: InsurCode = " + itemJubsu.getInsurCode() 
				+ ", ComingDate = " + itemJubsu.getComingDate() 
				+ ", PatientCode = " + itemJubsu.getPatientCode()
				+ ", hospCode = " + hospCode);
			
			response.setResult(false);
			response.setMsg("OUT1001U01_TEXT024");
			return response;
		}
		    			
		Double pkout1001 = isOrca? fkout1001 : CommonUtils.parseDouble(itemJubsu.getPkout1001());
		if(pkout1001 == null || pkout1001 == 0.0){
			pkout1001 = fkout1001;
		}
		
		if(isOrca){
			Out1001 out = out1001Repository.findByHospCodeAndPkOut1001(hospCode, pkout1001);
			String chkComming = itemJubsu.getCheckComing();
			if("E".equals(out.getNaewonYn())) chkComming = "E";
			
			int rowUpdated = out1001Repository.updateOUT1001(itemJubsu.getSysId(), new Date(),
					itemJubsu.getDoctorCode(), itemJubsu.getExamStatus(), receptionNo, itemJubsu.getInsurCode(),
					itemJubsu.getReceptionTime(), arriveTime, itemJubsu.getReceptionType(), chkComming,
					itemJubsu.getDepartmentCode(), itemJubsu.getReceptRefId(), hospCode, pkout1001);
			
			if(rowUpdated  <= 0){
				response.setResult(false);
				response.setMsg("OUT1001 UPDATE Error");
				return response;
			}
		} else {
			String receptionRefId = StringUtils.isEmpty(itemJubsu.getReceptRefId()) ? refId : itemJubsu.getReceptRefId();
			if( out1001Repository.updateTableOUT1001(itemJubsu.getSysId(), new Date(), itemJubsu.getDoctorCode(), itemJubsu.getExamStatus(), receptionNo,
					itemJubsu.getInsurCode(), itemJubsu.getReceptionTime(), arriveTime, itemJubsu.getReceptionType(),
					itemJubsu.getCheckComing(), receptionRefId, hospCode, pkout1001) <= 0){
				
				response.setResult(false);
				response.setMsg("OUT1001 UPDATE Error");
				return response;
			}
		}
		
		out1002Repository.deleteOut1002ById(hospCode, String.valueOf(pkout1001));
		
		if(itemJubsu.getInsurCode1().length() > 0){
			if(!insertTableOUT1002(itemJubsu.getSysId(), itemJubsu.getUpdId(), String.valueOf(pkout1001), 
					itemJubsu.getInsurCode1(), itemJubsu.getPatientCode(), itemJubsu.getPriority1(), hospCode)){
				response.setResult(false);
				response.setMsg("OUT1002-1 Insert Error");
				return response;
			}
		}
		
		if(itemJubsu.getInsurCode2().length() > 0){
			if(!insertTableOUT1002(itemJubsu.getSysId(), itemJubsu.getUpdId(), String.valueOf(pkout1001), 
					itemJubsu.getInsurCode2(), itemJubsu.getPatientCode(), itemJubsu.getPriority2(), hospCode)){
				response.setResult(false);
				response.setMsg("OUT1002-2 Insert Error");
				return response;
			}
		}
		
		if(itemJubsu.getInsurCode3().length() > 0){
			if(!insertTableOUT1002(itemJubsu.getSysId(), itemJubsu.getUpdId(), String.valueOf(pkout1001), 
					itemJubsu.getInsurCode3(), itemJubsu.getPatientCode(), itemJubsu.getPriority3(), hospCode)){
				response.setResult(false);
				response.setMsg("OUT1002-3 Insert Error");
				return response;
			}
		}
		
		if(itemJubsu.getInsurCode4().length() > 0){
			if(!insertTableOUT1002(itemJubsu.getSysId(), itemJubsu.getUpdId(), String.valueOf(pkout1001), 
					itemJubsu.getInsurCode4(), itemJubsu.getPatientCode(), itemJubsu.getPriority4(), hospCode)){
				response.setResult(false);
				response.setMsg("OUT1002-4 Insert Error");
				return response;
			}
		}
		
		response.setResult(true);
		return response;
	}
	
	private SystemServiceProto.UpdateResponse.Builder deletedProcess(String hospCode, NuroModelProto.UpdateJubsuDataInfo itemJubsu, String extMsgCode){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		if(!StringUtils.isEmpty(extMsgCode)) response.setMsg(extMsgCode);
		
		String  retVal = out1001Repository.getNuroOUT1001U01CheckNaewonYn(itemJubsu.getPatientCode(), itemJubsu.getComingDate(),
				itemJubsu.getDepartmentCode(), itemJubsu.getDoctorCode(), itemJubsu.getComingType(), itemJubsu.getReceptionNo(), hospCode);
		if("E".equalsIgnoreCase(retVal)){
			response.setResult(false);
			response.setMsg("OUT1001U01_TEXT018");
			return response;
		}
		
		String retVal1 = out1001Repository.getNuroOUT1001U01CheckY(hospCode, CommonUtils.parseDouble(itemJubsu.getPkout1001()));
		if("Y".equalsIgnoreCase(retVal1)){
			if(out1001Repository.deleteOut1001ById(hospCode, CommonUtils.parseDouble(itemJubsu.getPkout1001())) <= 0){
				response.setResult(false);
				return response;
			}
		}
		
		response.setResult(true);
		return response;
	}
	
	private Double insertOut1001(NuroModelProto.UpdateJubsuDataInfo itemJubsu, String hospCode, BigDecimal receptionNo, String refId){
		Double fkOut1001 = null;
		Out1001 out1001 = new Out1001(); 
		out1001.setSysDate(new Date());
		out1001.setSysId(itemJubsu.getSysId());
		out1001.setUpdDate(new Date());
		out1001.setUpdId(itemJubsu.getUpdId());
		out1001.setHospCode(hospCode);
		String seq = commonRepository.getNextVal("OUT1001_SEQ");
		Double seqNumber = CommonUtils.parseDouble(seq);
		out1001.setPkout1001(seqNumber);
		if(!StringUtils.isEmpty(itemJubsu.getComingDate())) {
			out1001.setNaewonDate(DateUtil.toDate(itemJubsu.getComingDate(), DateUtil.PATTERN_YYMMDD));
		}
		out1001.setBunho(itemJubsu.getPatientCode());
		out1001.setGwa(itemJubsu.getDepartmentCode());
		out1001.setGubun(itemJubsu.getInsurCode());
		out1001.setDoctor(itemJubsu.getDoctorCode());
		out1001.setChojae(itemJubsu.getExamStatus());
		out1001.setJubsuTime(itemJubsu.getReceptionTime());
		out1001.setNaewonYn(itemJubsu.getComingStatus());
		out1001.setNaewonType(itemJubsu.getComingType());
		out1001.setSunnabYn(itemJubsu.getSunnabStatus());
		out1001.setJubsuGubun(itemJubsu.getReceptionType());
		out1001.setInpTransYn(itemJubsu.getInpTransStatus());
		out1001.setBigo(itemJubsu.getBigo());
		out1001.setJubsuNo(receptionNo);
		if(!StringUtils.isEmpty(itemJubsu.getSujinNo())) {
			out1001.setSujinNo(new BigDecimal(itemJubsu.getSujinNo()));
		}
		out1001.setWonyoiOrderYn(itemJubsu.getWonyoiOrderStatus());
		if(itemJubsu.getReceptRefId() != null){
			out1001.setReceptRefId(itemJubsu.getReceptRefId());
		}
		
		out1001.setReceptRefId(StringUtils.isEmpty(refId) ? itemJubsu.getReceptRefId() : refId);
		
		out1001Repository.save(out1001);
		fkOut1001 = out1001.getPkout1001();
		return fkOut1001;
	}
	
	private boolean insertTableOUT1002(String userId, String updId, String pkout1001, String gongbiCode, String bunho, String priority, String hospCode) {
		Out1002 out1002 = new Out1002(); 
		out1002.setSysDate(new Date());
		out1002.setSysId(userId);
		out1002.setUpdDate(new Date());
		out1002.setUpdId(updId);
		out1002.setHospCode(hospCode);
		out1002.setFkout1001(pkout1001);
		out1002.setGongbiCode(gongbiCode);
		out1002.setBunho(bunho);
		if(!StringUtils.isEmpty(priority)) {
			out1002.setPriority(CommonUtils.parseDouble(priority));
		}
		
		out1002Repository.save(out1002);
		return true;
	}
}
