package nta.med.service.ihis.handler.inps;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0250;
import nta.med.core.domain.bas.Bas0260;
import nta.med.core.domain.inp.Inp1001;
import nta.med.core.domain.inp.Inp1004;
import nta.med.core.domain.out.Out1001;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.data.dao.medi.bas.Bas0253Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.dao.medi.inp.Inp1004Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.out.Out1003Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class INP1001U01SaveLayoutHandler
		extends ScreenHandler<InpsServiceProto.INP1001U01SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(INP1001U01SaveLayoutHandler.class);  
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Resource
	private Inp1004Repository inp1004Repository;
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Resource
	private Bas0250Repository bas0250Repository;
	
	@Resource
	private Bas0253Repository bas0253Repository;
	
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Resource
    private CommonRepository commonRepository;
	
	@Resource
	private Out1003Repository out1003Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01SaveLayoutRequest request) throws Exception {

		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		response.setResult(true);
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String userId = request.getUserId();
		
		List<InpsModelProto.INP1001U01GrdInp1004Info> lstInp1004 = request.getGrdInp1004ListList();
		List<InpsModelProto.INP1001U01GrdInp1001Info> lstInp1001 = request.getGrdInp1001ListList();
		List<CommonModelProto.DataStringListItemInfo> lstInputProc = request.getInputProcList();
		
		// 1. Insert/Update/Delete INP1004
		if(!CollectionUtils.isEmpty(lstInp1004)){
			LOGGER.info(String.format("[START] IUD INP1004, hosp_code = %s, bunho = %s", hospCode, lstInp1004.get(0).getBunho()));
			for (InpsModelProto.INP1001U01GrdInp1004Info info : lstInp1004) {
				if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
					Double seq = inp1004Repository.getNextSeqInp1004ByBunho(hospCode, info.getBunho());
					if(seq == null){
						LOGGER.info(String.format("Could not get SEQ INP1004 hosp_code = %s, bunho = %s", hospCode, info.getBunho()));
						throw new ExecutionException(response.setResult(false).setMsg("9696").build());
					}
					
					Inp1004 inp1004 = insertInp1004(hospCode, seq, info, userId);
					if(inp1004 == null || inp1004.getId() == null){
						LOGGER.info("Insert INP1004 fail !!!");
						throw new ExecutionException(response.setResult(false).build());
					}
				} else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
					boolean updResult = updateInp1004(hospCode, info, userId); 
					if(!updResult){
						LOGGER.info("Update INP1004 fail !!!");
						throw new ExecutionException(response.setResult(false).build());
					} 
				} else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
					boolean delResult = deleteInp1004(hospCode, info);
					if(!delResult){
						LOGGER.info("Delete INP1004 fail !!!");
						throw new ExecutionException(response.setResult(false).build());
					}
				}
			}
			LOGGER.info(String.format("[END] IUD INP1004, hosp_code = %s, bunho = %s", hospCode, lstInp1004.get(0).getBunho()));
		}
		
		// 2. Execute procedure PR_INP_UPDATE_OUT0103
		LOGGER.info(String.format("[START] Execute procedure PR_INP_UPDATE_OUT0103, hosp_code = %s", hospCode));
		if(CollectionUtils.isEmpty(lstInputProc) || lstInputProc.size() < 11){
			LOGGER.info(String.format("Do not enought param to execure PR_INP_UPDATE_OUT0103, hospCode = %s", hospCode));
		} else {
			String strProcResult = out1003Repository.callPrInpUpdateOut0103(
					  hospCode
					, lstInputProc.get(0).getDataValue()
					, DateUtil.toDate(lstInputProc.get(1).getDataValue(), DateUtil.PATTERN_YYMMDD)
					, lstInputProc.get(2).getDataValue()
					, lstInputProc.get(3).getDataValue()
					, lstInputProc.get(4).getDataValue()
					, lstInputProc.get(5).getDataValue()
					, lstInputProc.get(6).getDataValue()
					, lstInputProc.get(7).getDataValue()
					, CommonUtils.parseInteger(lstInputProc.get(8).getDataValue())
					, lstInputProc.get(9).getDataValue()
					, DateUtil.toDate(lstInputProc.get(10).getDataValue(), DateUtil.PATTERN_YYMMDD));
			LOGGER.info(String.format("Execute proc PR_INP_UPDATE_OUT0103, IO_FLAG = %s", strProcResult == null ? "" : strProcResult));
		}
		
		LOGGER.info(String.format("[END] Execute procedure PR_INP_UPDATE_OUT0103, hosp_code = %s", hospCode));
		
		// 3. Insert/Update/Delete INP1001
		if(!CollectionUtils.isEmpty(lstInp1001)){
			LOGGER.info(String.format("[START] IUD INP1001, hosp_code = %s", hospCode));
			response = iudInp1001(hospCode, language, userId, lstInp1001);
			if(!response.getResult()){
				LOGGER.info("IUD INP1001 was fail !!!");
				throw new ExecutionException(response.setResult(false).build());
			}
			
			LOGGER.info(String.format("[END] IUD INP1001, hosp_code = %s", hospCode));
		}
		
		response.setResult(true);
		return response.build();
	}
	
	private UpdateResponse.Builder iudInp1001(String hospCode, String language, String userId, List<InpsModelProto.INP1001U01GrdInp1001Info> lstInp1001){
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		for (InpsModelProto.INP1001U01GrdInp1001Info info : lstInp1001) {
			
			if(!StringUtils.isEmpty(info.getFkout1001())){
				LOGGER.info(String.format("Check OUT1001 hosp_code = %s, PKOUT1001 = %s", hospCode, info.getFkout1001()));
				Out1001 out1001 = out1001Repository.findByHospCodeAndPkOut1001(hospCode,
						CommonUtils.parseDouble(info.getFkout1001()));
				
				if(out1001 == null){
					LOGGER.info(String.format("Could not find OUT1001, hosp_code = %s, PKOUT1001 = %s", hospCode, info.getFkout1001()));
					response.setResult(false);
					return response;
				}
				
				if(out1001.getNaewonYn() != null && !"E".equals(out1001.getNaewonYn())){
					LOGGER.info(String.format("Do not fnish exam, PKOUT1001 = %s", info.getFkout1001()));
					response.setMsg("6969");
					response.setResult(false);
					return response;
				}
			}
			
			if("Y".equals(info.getRetrieveYn())){
				LOGGER.info("Check RetrieveYn was not pass !!!");
				response.setResult(false);
				return response;
			}
			
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				// check patient is currently in hospital
				if("0".equals(info.getIpwonType())){
					List<ComboListItemInfo> lstPatientInps = inp1001Repository.getInfoToCheckPatientInHospital(hospCode, info.getBunho(), DateUtil.toDate(info.getIpwonDate(), DateUtil.PATTERN_YYMMDD));
					if(!CollectionUtils.isEmpty(lstPatientInps)){
						LOGGER.info(String.format("Patient %s is currently in hospital, message = 293", info.getBunho()));
						response.setResult(false);
						response.setMsg("293");
						return response;
					}
				}
				
				// check first visit code
				if(StringUtils.isEmpty(info.getChojae())){
					LOGGER.info(String.format("Patient %s, message = 3278: Chojae can not be null", info.getBunho()));
					response.setResult(false);
					response.setMsg("3278");
					return response;
				}
				
				// check ipwon_gwa
				List<Bas0260> bas0260s = bas0260Repository.findByHospCodeGwaFDate(hospCode, language, info.getIpwonGwa(), info.getIpwonDate());
				if(CollectionUtils.isEmpty(bas0260s)){
					LOGGER.info(String.format("Patient %s, message = 297: ipwon_gwa was not valid", info.getBunho()));
					response.setResult(false);
					response.setMsg("297");
					return response;
				}
				
				// check doctor
				List<String> bas0270s = bas0270Repository.findByHospCodeDoctorGwaDoctorFDate(hospCode, info.getIpwonGwa(), info.getDoctor(), info.getIpwonDate());
				if(CollectionUtils.isEmpty(bas0270s)){
					LOGGER.info(String.format("Patient %s, message = 298: doctor was not valid", info.getBunho()));
					response.setResult(false);
					response.setMsg("298");
					return response;
				}
				
				// check ipwon_date
				if(StringUtils.isEmpty(info.getIpwonDate())){
					LOGGER.info(String.format("Patient %s, message = 327: ipwon_date was not valid", info.getBunho()));
					response.setResult(false);
					response.setMsg("327");
					return response;
				}
				
				// check ipwon_time
				if(StringUtils.isEmpty(info.getIpwonTime()) || StringUtils.isEmpty(info.getIpwonTime().replace(":", ""))){
					LOGGER.info(String.format("Patient %s, message = 328: ipwon_time was not valid", info.getBunho()));
					response.setResult(false);
					response.setMsg("328");
					return response;
				}
				
				// check ipwon_type
				if(StringUtils.isEmpty(info.getIpwonType())){
					LOGGER.info(String.format("Patient %s, message = 330: ipwon_type was not valid", info.getBunho()));
					response.setResult(false);
					response.setMsg("330");
					return response;
				}
				
				if(!"2".equals(info.getIpwonType()) && !"3".equals(info.getIpwonType())){
					// check ho_dong1
					List<Bas0260> bas0260sByHoDong = bas0260Repository.findByHospCodeGwaFDate(hospCode, language, info.getHoDong1(), info.getIpwonDate());
					if(CollectionUtils.isEmpty(bas0260sByHoDong)){
						LOGGER.info(String.format("Patient %s, message = 3317: ho_dong1 was not valid", info.getBunho()));
						response.setResult(false);
						response.setMsg("3317");
						return response;
					}
					
					// check ho_code1
					List<Bas0250> bas0250s = bas0250Repository.findByHoCodeHoDongFDate(hospCode, info.getHoCode1(), info.getHoDong1(), info.getIpwonDate());
					if(CollectionUtils.isEmpty(bas0250s)){
						LOGGER.info(String.format("Patient %s, message = 3318: ho_code1 was not valid", info.getBunho()));
						response.setResult(false);
						response.setMsg("3318");
						return response;
					}
					
					// check bed_no
					String strCheck = bas0253Repository.checkExistByHospCodeHoDongHoCodeBedNoIpwonDate(hospCode, info.getHoDong1(), info.getHoCode1(), info.getBedNo(), info.getIpwonDate());
					if(StringUtils.isEmpty(strCheck)){
						LOGGER.info(String.format("Patient %s, message = 3319: bed_no was not valid", info.getBunho()));
						response.setResult(false);
						response.setMsg("3319");
						return response;
					}
					
					// check ho_dong1, ho_code1, bed_no
					if(StringUtils.isEmpty(info.getHoDong1()) || StringUtils.isEmpty(info.getHoCode1()) || StringUtils.isEmpty(info.getBedNo())){
						LOGGER.info(String.format("Patient %s, message = 331: ho_dong1, ho_code1, bed_no can not be empty", info.getBunho()));
						response.setResult(false);
						response.setMsg("331");
						return response;
					}
					
					// check INP1001
					List<Inp1001> lstCheckInp1001 = inp1001Repository.findByHospCodeHoDong1HoCode1BedNo(hospCode, info.getHoDong1(), info.getHoCode1(), info.getBedNo());
					if(!CollectionUtils.isEmpty(lstCheckInp1001)){
						LOGGER.info(String.format("Patient %s, message = 295: ho_dong1 = %s, ho_code1 = %s, bed_no = %s", info.getBunho(), info.getHoDong1(), info.getHoCode1(), info.getBedNo()));
						response.setResult(false);
						response.setMsg("295");
						return response;
					}
					
					// check hospital bed is possible
					String strCheckBed = bas0250Repository.checkHospitalBedIsPossible(hospCode, info.getHoCode1(), info.getBedNo(), info.getHoDong1(), info.getIpwonDate());
					if("Y".equals(strCheckBed)){
						LOGGER.info(String.format(
								"Patient %s, message = 296: ho_dong1 = %s, ho_code1 = %s, bed_no = %s, ipwon_date",
								info.getBunho(), info.getHoDong1(), info.getHoCode1(), info.getBedNo(), info.getIpwonDate()));
						response.setResult(false);
						response.setMsg("296");
						return response;
					}
				}
				
				// check order
				if (StringUtils.isEmpty(info.getFkinp1003())
						|| !StringUtils.isEmpty(info.getFkinp1003()) && StringUtils.isEmpty(info.getPkinp1001())) {
					String strCheckOrder = inp1003Repository.checkExistOrderInp1003ByHospCodeBunho(hospCode, info.getBunho());
					if("Y".equals(strCheckOrder)){
						LOGGER.info(String.format("Patient %s, message = 3443", info.getBunho()));
						response.setResult(false);
						response.setMsg("3443");
						return response;
					}
				}
				
				// get INP1001_SEQ
				Double pkinp1001 = null;
				if(StringUtils.isEmpty(info.getPkinp1001())){
					String seq = commonRepository.getNextVal("INP1001_SEQ");
					if(StringUtils.isEmpty(pkinp1001)){
						LOGGER.info("INP1001_SEQ.NEXTVAL Error");
						response.setResult(false);
						response.setMsg("321");
						return response;
					}
					pkinp1001 = CommonUtils.parseDouble(seq);
				} else {
					pkinp1001 = CommonUtils.parseDouble(info.getPkinp1001());
				}
				
				// get FK_INP_KEY
				Double fkInpKey = null;
				if(!"2".equals(info.getIpwonType())){
					fkInpKey = pkinp1001;
				} else {
					List<Inp1001> inpsList = inp1001Repository.findByHospCodeBunhoJaewonFlagIpwonType(hospCode, info.getBunho(), "Y", "0");
					if(!CollectionUtils.isEmpty(inpsList)){
						fkInpKey = inpsList.get(0).getPkinp1001();
					}
				}
				
				Inp1001 inp1001 = insertInp1001(hospCode, userId, info, pkinp1001, fkInpKey);
				if(inp1001 == null || inp1001.getId() == null){
					LOGGER.info("Insert INP1001 was fail");
					response.setResult(false);
					return response;
				}
				
				Integer jubsuCnt = inp1001Repository.checkJubsuCnt(hospCode, info.getBunho(), DateUtil.toDate(info.getIpwonDate(), DateUtil.PATTERN_YYMMDD));
				if(jubsuCnt == null){
					LOGGER.info(String.format("FN_OUT_CHECK_JUBSU_CNT Error, hosp_code = %s, bunho = %s, ipwon_date = %s", hospCode, info.getBunho(), info.getIpwonDate()));
					response.setResult(false);
					return response;
				}
			}if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				if(StringUtils.isEmpty(info.getPkinp1001())){
					LOGGER.info(String.format("MODIFIED INP1001: pkinp1001 was empty, hosp_code = %s, bunho = %s", hospCode, info.getBunho()));
					response.setResult(false);
					response.setMsg("321");
					return response;
				}
				
				if(StringUtils.isEmpty(info.getBunho())){
					LOGGER.info(String.format("MODIFIED INP1001: bunho was empty, hosp_code = %s", hospCode));
					response.setResult(false);
					response.setMsg("283");
					return response;
				}
				
				Inp1001 updInp1001 = updateInp1001(hospCode, userId, info);
				if(updInp1001 == null || updInp1001.getId() == null){
					LOGGER.info(String.format("MODIFIED INP1001: update fail, hosp_code = %s, bunho = %s", hospCode, info.getBunho()));
					response.setResult(false);
					return response;
				}
				
			}if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				// do nothing
			}
		}
		
		response.setResult(true);
		return response;
	}
	
	private Inp1004 insertInp1004(String hospCode, Double seq, InpsModelProto.INP1001U01GrdInp1004Info info, String userId){
		Inp1004 inp1004 = new Inp1004();
		Date sysDate = new Date();
		
		inp1004.setSysDate(sysDate);
		inp1004.setSysId(userId);
		inp1004.setUpdDate(sysDate);
		inp1004.setUpdId(userId);
		inp1004.setHospCode(hospCode);
		inp1004.setSeq(seq);
		inp1004.setBunho(info.getBunho());
		inp1004.setName(info.getName());
		inp1004.setZipCode1(info.getZipCode1());
		inp1004.setZipCode2(info.getZipCode2());
		inp1004.setAddress1(info.getAddress1());
		inp1004.setAddress2(info.getAddress2());
		inp1004.setTel1(info.getTel1());
		inp1004.setTel2(info.getTel2());
		inp1004.setBigo(info.getBigo());
		inp1004.setBoninGubun(info.getBoninGubun());
		inp1004.setTel3(info.getTel3());
		inp1004.setTelGubun(info.getTelGubun());
		inp1004.setTelGubun2(info.getTelGubun2());
		inp1004.setTelGubun3(info.getTelGubun3());
		inp1004.setName2(info.getName2());
		inp1004.setPriority(CommonUtils.parseDouble(info.getPriority()));
		inp1004.setBirth(DateUtil.toDate(info.getBirth(), DateUtil.PATTERN_YYMMDD));
		inp1004.setWithYn(info.getWithYn());
		inp1004.setLiveYn(info.getLiveYn());
		
		inp1004Repository.save(inp1004);
		return inp1004;
	}
	
	private boolean updateInp1004(String hospCode, InpsModelProto.INP1001U01GrdInp1004Info info, String userId){
		Integer updResult = inp1004Repository.updateInp1004ByBunhoSeq(userId
				, info.getName()
				, info.getZipCode1()
				, info.getZipCode2()
				, info.getAddress1()
				, info.getAddress2()
				, info.getTel1()
				, info.getTel2()
				, info.getBigo()
				, info.getBoninGubun()
				, info.getTel3()
				, info.getTelGubun()
				, info.getTelGubun2()
				, info.getTelGubun3()
				, info.getName2()
				, CommonUtils.parseDouble(info.getPriority())
				, info.getBirth()
				, info.getWithYn()
				, info.getLiveYn()
				, hospCode
				, info.getBunho()
				, CommonUtils.parseDouble(info.getSeq2()));
		
		LOGGER.info("Update INP1004, result = " + updResult);
		return updResult != null && updResult > 0;
	}
	
	private boolean deleteInp1004(String hospCode, InpsModelProto.INP1001U01GrdInp1004Info info){
		return inp1004Repository.deleteInp1004ByBunhoSeq(hospCode, info.getBunho(), CommonUtils.parseDouble(info.getSeq2())) > 0;
	}
	
	private Inp1001 insertInp1001(String hospCode, String userId, InpsModelProto.INP1001U01GrdInp1001Info info, Double pkinp1001, Double fkInpKey){
		Inp1001 inp1001 = new Inp1001();
		Date sysDate = new Date();
		inp1001.setSysDate(sysDate);
		inp1001.setSysId(userId);
		inp1001.setUpdDate(sysDate);
		inp1001.setUpdId(userId);
		inp1001.setHospCode(hospCode);
		inp1001.setPkinp1001(pkinp1001);
		inp1001.setBunho(info.getBunho());
		inp1001.setIpwonDate(DateUtil.toDate(info.getIpwonDate(), DateUtil.PATTERN_YYMMDD));
		inp1001.setIpwonType(info.getIpwonType());
		inp1001.setIpwonTime(StringUtils.isEmpty(info.getIpwonTime()) ? "" : info.getIpwonTime().replace(":", ""));
		inp1001.setIpwonGwa(info.getIpwonGwa());
		inp1001.setGwa(info.getGwa());
		inp1001.setDoctor(info.getDoctor());
		inp1001.setResident(info.getResident());
		inp1001.setHoCode1(info.getHoCode1());
		inp1001.setHoDong1(info.getHoDong1());
		inp1001.setHoCode2(info.getHoCode2());
		inp1001.setHoDong2(info.getHoDong2());
		inp1001.setIpwonRtn2(info.getIpwonRtn2());
		inp1001.setIpwonRtn2Remark(info.getIpwonRtn2Remark());
		inp1001.setChojae(info.getChojae());
		inp1001.setBabyStatus(info.getBabyStatus());
		inp1001.setInpTransYn(info.getInpTransYn());
		inp1001.setFkout1001(info.getFkout1001());
		inp1001.setJaewonFlag(info.getJaewonFlag());
		inp1001.setToiwonGojiYn(info.getToiwonGojiYn());
		inp1001.setToiwonResDate(DateUtil.toDate(info.getToiwonResDate(), DateUtil.PATTERN_YYMMDD));
		inp1001.setToiwonResTime(null);
		inp1001.setGaToiwonDate(DateUtil.toDate(info.getGaToiwonDate(), DateUtil.PATTERN_YYMMDD));
		inp1001.setToiwonDate(DateUtil.toDate(info.getToiwonDate(), DateUtil.PATTERN_YYMMDD));
		inp1001.setToiwonTime(info.getToiwonTime());
		inp1001.setResult(info.getResult());
		inp1001.setSigiMagamYn(info.getSigiMagamYn());
		inp1001.setSimsaMagamGubun(info.getSimsaMagamYn());
		inp1001.setCancelDate(DateUtil.toDate(info.getCancelDate(), DateUtil.PATTERN_YYMMDD));
		inp1001.setCancelUser(info.getCancelUser());
		inp1001.setCancelYn(info.getCancelYn());
		inp1001.setFkinp1003(CommonUtils.parseDouble(info.getFkinp1003()));
		inp1001.setTeam(info.getTeam());
		inp1001.setSimsaMagamja(null);
		inp1001.setSimsaMagamDate(null);
		inp1001.setSimsaMagamTime(null);
		inp1001.setGisanIpwonDate(DateUtil.toDate(info.getIpwonDate(), DateUtil.PATTERN_YYMMDD));
		inp1001.setBedNo(info.getBedNo());
		inp1001.setGisanJaewonIlsu(CommonUtils.parseDouble(info.getGisanJaewonIlsu()));
		inp1001.setJisiDoctor(info.getJisiDoctor());
		inp1001.setFkInpKey(fkInpKey);
		inp1001.setHoGrade1(info.getHoGrade1());
		inp1001.setEmergencyGubun(info.getEmergencyGubun());
		inp1001.setEmergencyDetail(info.getEmergencyDetail());
		inp1001.setKaikeiHodong(info.getKaikeiHodong());
		inp1001.setKaikeiHocode(info.getKaikeiHocode());
		
		inp1001Repository.save(inp1001);
		return inp1001;
	}
	
	private Inp1001 updateInp1001(String hospCode, String userId, InpsModelProto.INP1001U01GrdInp1001Info info){
		List<Inp1001> inpPatiens = inp1001Repository.findByHospCodeBunhoPkinp1001(hospCode, info.getBunho(), CommonUtils.parseDouble(info.getPkinp1001()));
		if(CollectionUtils.isEmpty(inpPatiens)){
			LOGGER.info(String.format("Could not find inp patient: hosp_code = %s, bunho = %s, pkinp1001 = %s", hospCode, info.getBunho(), info.getPkinp1001()));
			return null;
		}
		
		Inp1001 inp1001 = inpPatiens.get(0);
		Date sysDate = new Date();
		inp1001.setUpdDate(sysDate);
		inp1001.setUpdId(userId);
		inp1001.setIpwonTime(StringUtils.isEmpty(info.getIpwonTime()) ? "" : info.getIpwonTime().replace(":", ""));
		inp1001.setIpwonGwa(info.getIpwonGwa());
		inp1001.setGwa(info.getGwa());
		inp1001.setDoctor(info.getDoctor());
		inp1001.setResident(info.getResident());
		inp1001.setHoCode1(info.getHoCode1());
		inp1001.setHoDong1(info.getHoDong1());
		inp1001.setHoCode2(info.getHoCode2());
		inp1001.setHoDong2(info.getHoDong2());
		inp1001.setIpwonRtn2(info.getIpwonRtn2());
		inp1001.setIpwonRtn2Remark(info.getIpwonRtn2Remark());
		inp1001.setChojae(info.getChojae());
		inp1001.setBabyStatus(info.getBabyStatus());
		inp1001.setInpTransYn(info.getInpTransYn());
		inp1001.setFkout1001(info.getFkout1001());
		inp1001.setJaewonFlag(info.getJaewonFlag());
		inp1001.setToiwonGojiYn(info.getToiwonGojiYn());
		inp1001.setToiwonResDate(DateUtil.toDate(info.getToiwonResDate(), DateUtil.PATTERN_YYMMDD));
		inp1001.setToiwonResTime(null);
		inp1001.setGaToiwonDate(DateUtil.toDate(info.getGaToiwonDate(), DateUtil.PATTERN_YYMMDD));
		inp1001.setToiwonDate(DateUtil.toDate(info.getToiwonDate(), DateUtil.PATTERN_YYMMDD));
		inp1001.setToiwonTime(info.getToiwonTime());
		inp1001.setResult(info.getResult());
		inp1001.setSigiMagamYn(info.getSigiMagamYn());
		inp1001.setSimsaMagamGubun(info.getSimsaMagamYn());
		inp1001.setCancelDate(DateUtil.toDate(info.getCancelDate(), DateUtil.PATTERN_YYMMDD));
		inp1001.setCancelUser(info.getCancelUser());
		inp1001.setCancelYn(info.getCancelYn());
		inp1001.setFkinp1003(CommonUtils.parseDouble(info.getFkinp1003()));
		inp1001.setTeam(info.getTeam());
		inp1001.setSimsaMagamja(null);
		inp1001.setSimsaMagamDate(null);
		inp1001.setSimsaMagamTime(null);
		inp1001.setGisanIpwonDate(DateUtil.toDate(info.getIpwonDate(), DateUtil.PATTERN_YYMMDD));
		inp1001.setBedNo(info.getBedNo());
		inp1001.setGisanJaewonIlsu(CommonUtils.parseDouble(info.getGisanJaewonIlsu()));
		inp1001.setJisiDoctor(info.getJisiDoctor());
		inp1001.setIpwonType(info.getIpwonType());
		inp1001.setHoGrade1(info.getHoGrade1());
		inp1001.setEmergencyGubun(info.getEmergencyGubun());
		inp1001.setEmergencyDetail(info.getEmergencyDetail());
		inp1001.setKaikeiHodong(info.getKaikeiHodong());
		inp1001.setKaikeiHocode(info.getKaikeiHocode());
		
		inp1001Repository.save(inp1001);
		return inp1001;
	}
}
