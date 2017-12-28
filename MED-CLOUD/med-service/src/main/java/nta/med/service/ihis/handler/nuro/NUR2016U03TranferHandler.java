 package nta.med.service.ihis.handler.nuro;

import java.math.BigDecimal;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.concurrent.TimeUnit;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.common.remoting.rpc.message.RpcMessageParser;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.ifs.Ifs0003;
import nta.med.core.domain.ocs.Ocs1003;
import nta.med.core.domain.out.Out1001;
import nta.med.core.domain.out.Out1003;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.glossary.OrderStatus;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.OrcaUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.orca.OrcaReceptionRepositoty;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.data.dao.medi.out.Out0105Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.out.Out1003Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.nuro.CompanyInsurance;
import nta.med.data.model.ihis.nuro.DiseaseInfo;
import nta.med.data.model.ihis.nuro.MedicalInfo;
import nta.med.data.model.ihis.nuro.MedicalInfoExt;
import nta.med.data.model.ihis.nuro.NUR2016U02TranferSgCodeInfo;
import nta.med.data.model.ihis.nuro.NuroORDERTRANSUpdateOCS1003SelectToInsert;
import nta.med.data.model.ihis.nuro.PublicInsurance;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroModelProto.NUR2016U02TranferInfo;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.NUR2016U03TranferRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype")
public class NUR2016U03TranferHandler extends ScreenHandler<NuroServiceProto.NUR2016U03TranferRequest, SystemServiceProto.UpdateResponse>{
	private static final Log LOGGER = LogFactory.getLog(NUR2016U03TranferHandler.class);
	
	private RpcMessageParser parser = new RpcMessageParser(NuroServiceProto.class);
	
	@Resource                                                                                                       
	private OutsangRepository outsangRepository;    
	
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository; 
	
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Resource
	private Ocs0103Repository ocs0103Repository;
	
	@Resource
	private OrcaReceptionRepositoty orcaReceptionRepositoty;
	
	@Resource
	Ifs0003Repository ifs0003Repository;
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Resource
	private Out0102Repository out0102Repository;
	
	@Resource
	private Out0105Repository out0105Repository;
	
	@Resource
	private Out1003Repository out1003Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	@Transactional(readOnly = false)
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2016U03TranferRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		List<Bas0102> bas0102List = bas0102Repository.findByHospCodeAndCodeType(hospCode, AccountingConfig.ACCT_TYPE.getValue());
		if (CollectionUtils.isEmpty(bas0102List)
				|| !AccountingConfig.ACCCT_TYPE_ORCA.getValue().equalsIgnoreCase(bas0102List.get(0).getCode())) {
			LOGGER.info("Hospital " + hospCode + " does not use ORCA !!!");
			response.setResult(false);
			return response.build();
		}
		
		List<NUR2016U02TranferInfo> transferInfos =  request.getListItemList();
		if(CollectionUtils.isEmpty(transferInfos)){
			response.setResult(false);
			return response.build();
		}
		
		Date performDate = Calendar.getInstance().getTime();
		String strPerformDate = new SimpleDateFormat("YYYY-MM-dd").format(performDate);
		
		for (NUR2016U02TranferInfo transferInfo : transferInfos) {
			String bunho = transferInfo.getBunho();
			BigDecimal pkout1001Temp = CommonUtils.parseBigDecimal(transferInfo.getPkout1001());
			Double pkout1001 = CommonUtils.parseDouble(transferInfo.getPkout1001());
			
			List<Ocs1003> ocs1003List = ocs1003Repository.findByHospCodePkout1001OrderStatus(hospCode, pkout1001Temp, OrderStatus.TRANFER_SUCCESS.getValue());
			String clazz = CollectionUtils.isEmpty(ocs1003List) ? "01" : "04";
			List<NUR2016U02TranferSgCodeInfo> listSgCode =  ocs1003Repository.getNUR2016U02TranferInfoExt(hospCode, bunho);
			List<Double> pkOcsList = new ArrayList<>();
			for (NUR2016U02TranferSgCodeInfo info : listSgCode) {
				pkOcsList.add(info.getPkocs1003());
			}
			
			List<String> sangCodeTranfered = new ArrayList<>();
			NuroServiceProto.OrderTranferRequest rq = toApiRequest(hospCode, bunho, pkout1001, clazz, listSgCode, strPerformDate, sangCodeTranfered);
			
			NuroServiceProto.OrderTranferResponse r = null;
			try {
				FutureEx<NuroServiceProto.OrderTranferResponse> res = send(vertx, parser, rq, hospCode);
				r = res.get(30, TimeUnit.SECONDS);
			} catch (Exception e) {
				LOGGER.info("Auto transfer order to ORCA fail: hosp_code = " + hospCode + ", bunho = " + bunho + ", pkout1001 = " + pkout1001);
				updateFailOrderTransfer(hospCode, bunho, pkout1001, pkOcsList, clazz);
				response.setResult(false);
				return response.build();
			}
			
			String orderStatus = "";
			boolean diseaseSentYn = false;
			if (Arrays.asList("00", "21").contains(r.getApiResult())
					&& !Arrays.asList("01", "03", "10").contains(r.getMedicalResult())) {
				
				orderStatus = OrderStatus.TRANFER_SUCCESS.getValue();
				if(clazz.equals("01")){
					diseaseSentYn = !Arrays.asList("01", "02", "11", "12", "13").contains(r.getDiseaseResult());
				}
				response.setResult(true);
			} else {
				updateFailOrderTransfer(hospCode, bunho, pkout1001, pkOcsList, clazz);
				response.setResult(false);
				return response.build();
			}
			
			kcckHandler(hospCode, bunho, pkout1001, pkOcsList, orderStatus, performDate, sangCodeTranfered, diseaseSentYn, clazz);
		}
		
		return response.build();
	}
	
	private NuroServiceProto.OrderTranferRequest toApiRequest(String hospCode, String patientCode, double pkOut1001,
			String clazz, List<NUR2016U02TranferSgCodeInfo> listSgCode, String performDate, List<String> sangCodeTranfered) {
		String performTime = new SimpleDateFormat("HH:mm:ss").format(Calendar.getInstance().getTime());
		Out1001 out1001 = out1001Repository.findByHospCodeAndPkOut1001(hospCode, pkOut1001);
		NuroServiceProto.OrderTranferRequest.Builder rq = NuroServiceProto.OrderTranferRequest.newBuilder();
		
		// [1] Setting common field
		rq.setId(System.currentTimeMillis());
		rq.setHospCode(hospCode);
		rq.setInOut("O");
		rq.setPatientId(patientCode);
		rq.setPerformDate(performDate);
		rq.setPerformTime(performTime);
		rq.setMedicalUid("");
		if(clazz.equals("01")){
			rq.setAction(NuroServiceProto.OrderTranferRequest.Action.SEND_ORDER_DISEASE);
		} else if(clazz.equals("04")){
			rq.setAction(NuroServiceProto.OrderTranferRequest.Action.RETRANSFER_ORDER);
		}
		
		// [2] Setting department and doctor
		NuroModelProto.DiagnosisInformation.Builder diBuilder = NuroModelProto.DiagnosisInformation.newBuilder();
		List<Ifs0003> depts = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode, AccountingConfig.IF_ORCA_GWA.getValue(), out1001.getGwa());
		String deparmentCode = CollectionUtils.isEmpty(depts) ? "" : depts.get(0).getIfCode();
		diBuilder.setDepartmentCode(deparmentCode);
		
		List<Ifs0003> doctors = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode, AccountingConfig.IF_ORCA_DOCTOR.getValue(), out1001.getDoctor().substring(2, out1001.getDoctor().length()));
		String doctor = CollectionUtils.isEmpty(doctors) ? "" : doctors.get(0).getIfCode();
		diBuilder.setPhysicianCode(doctor);
		
		// [3] Setting insurance
		NuroModelProto.HealthInsuranceInfo.Builder hiBuilder = NuroModelProto.HealthInsuranceInfo.newBuilder();
		
		// 	[3.1] Company insurance
		List<CompanyInsurance> cInsList = out0102Repository.getCompanyInsurance(hospCode, patientCode, pkOut1001);
		hiBuilder.setInsuranceCombinationRateAdmission("");
		hiBuilder.setInsuranceCombinationRateOutpatient("");
		hiBuilder.setHealthInsuredPersonAssistanceName("");
		hiBuilder.setInsuranceCheckDate("");
		hiBuilder.setInsuranceCombinationNumber("");
		hiBuilder.setInsuranceProviderWholeName("");
		hiBuilder.setHealthInsuredPersonContinuation("");
		hiBuilder.setHealthInsuredPersonAssistance("");
		hiBuilder.setHealthInsuredPersonWholeName("");
		
		if(!CollectionUtils.isEmpty(cInsList)){
			hiBuilder.setInsuranceProviderClass(OrcaUtils.getClassCodeByInsurCode(cInsList.get(0).getGubun()));
			hiBuilder.setInsuranceProviderNumber(cInsList.get(0).getJohap());
			hiBuilder.setHealthInsuredPersonSymbol(cInsList.get(0).getGaein());
			hiBuilder.setHealthInsuredPersonNumber(cInsList.get(0).getGaeinNo());
			hiBuilder.setRelationToInsuredPerson(cInsList.get(0).getBonGaGubun());
			hiBuilder.setCertificateStartDate(cInsList.get(0).getStartDate() == null ? "" : cInsList.get(0).getStartDate().replace("/", "-"));
			hiBuilder.setCertificateExpiredDate(cInsList.get(0).getEndDate() == null ? "" : cInsList.get(0).getEndDate().replace("/", "-"));
		} else {
			hiBuilder.setInsuranceProviderClass(OrcaUtils.getClassCodeByInsurCode("XX"));
			hiBuilder.setInsuranceProviderNumber("9999");
			hiBuilder.setHealthInsuredPersonSymbol("");
			hiBuilder.setHealthInsuredPersonNumber("");
			hiBuilder.setRelationToInsuredPerson("");
			hiBuilder.setCertificateStartDate(new SimpleDateFormat("yyyy-MM-dd").format(new Date()));
			hiBuilder.setCertificateExpiredDate("9999-12-31");
		}
		
		// 	[3.2] Public insurance
		List<PublicInsurance> publicInsList = out0105Repository.getPublicInsurance(hospCode, patientCode, pkOut1001);
		if(!CollectionUtils.isEmpty(publicInsList)){
			for (PublicInsurance pi : publicInsList) {
				NuroModelProto.PublicInsuranceInfo.Builder piBuilder = NuroModelProto.PublicInsuranceInfo.newBuilder();
				piBuilder.setPublicInsuranceClass(pi.getGongbiCode());
				piBuilder.setPublicInsuranceName("");
				piBuilder.setPublicInsurerNumber(pi.getBudamja());
				piBuilder.setPublicInsuredPersonNumber(pi.getSugubjaBunho());
				piBuilder.setCertificateIssuedDate(pi.getStartDate() == null ? "" : pi.getStartDate().replace("/", "-"));
				piBuilder.setCertificateExpiredDate(pi.getEndDate() == null ? "" : pi.getEndDate().replace("/", "-"));
				
				hiBuilder.addPublicInsurance(piBuilder);
			}
		}
		
		diBuilder.setHealthInsuranceInfo(hiBuilder);
		
		// [4] Setting medical information 
		if (!CollectionUtils.isEmpty(listSgCode)) {
			//	[4.1] Validate order
			List<String> hangmogList = new ArrayList<>();
			List<String> hangmogListTransfer = new ArrayList<>();
			Map<String, String> mapCodeName = new HashMap<>();
			for (NUR2016U02TranferSgCodeInfo info : listSgCode) {
				hangmogList.add(info.getHangmogCode());
				if (!mapCodeName.containsKey(info.getHangmogCode())){
					mapCodeName.put(info.getHangmogCode(), info.getHangmogName());
				}
			}
			
			List<Ifs0003> ifsList = ifs0003Repository.findByHospCodeMapGubunOcsCodeList(hospCode, "IF_ORCA_HANGMOG", hangmogList);
			for (Ifs0003 ifs0003 : ifsList) {
				hangmogListTransfer.add(ifs0003.getOcsCode());
			}
			
			//	[4.2] Generate examination fee in case send order/cancel order
			List<MedicalInfo> examFees = out1001Repository.getExaminationFee(hospCode, patientCode, pkOut1001);
			if(!CollectionUtils.isEmpty(examFees)){
				NuroModelProto.MedicalInformation.Builder miBuilder = NuroModelProto.MedicalInformation.newBuilder();
				miBuilder.setMedicalClass(examFees.get(0).getMedicalClass());
				miBuilder.setMedicalClassNumber(examFees.get(0).getMedicalClassNumber());
				
				NuroModelProto.MedicationInfo.Builder medicationBuilder = NuroModelProto.MedicationInfo.newBuilder();
				medicationBuilder.setMedicationCode(examFees.get(0).getMedicationCode());
				medicationBuilder.setMedicationNumber(examFees.get(0).getMedicationNumber());
				miBuilder.addMedicationInfo(medicationBuilder);
				
				diBuilder.addMedicalInformation(miBuilder);
			}
						
			//	[4.3] Get medical information
			if(!CollectionUtils.isEmpty(hangmogListTransfer)){
				List<MedicalInfoExt> miList = null; 
				miList = ocs1003Repository.getMedicalInfo(hospCode, patientCode, pkOut1001, hangmogListTransfer, false);
				
				if(!CollectionUtils.isEmpty(miList)){
					for (MedicalInfoExt info : miList) {
						NuroModelProto.MedicalInformation.Builder miBuilder = NuroModelProto.MedicalInformation.newBuilder();
						miBuilder.setMedicalClass(info.getMedicalClass());
						if (info.getMedicalClassNumber() != null)
							miBuilder.setMedicalClassNumber(info.getMedicalClassNumber().toString());
						
						NuroModelProto.MedicationInfo.Builder medicationBuilder = NuroModelProto.MedicationInfo.newBuilder();
						medicationBuilder.setMedicationCode(info.getMedicationCode());
						medicationBuilder.setMedicationNumber(info.getMedicationNumber());
						miBuilder.addMedicationInfo(medicationBuilder);
						
						diBuilder.addMedicalInformation(miBuilder);
					}
				}
			}
		}
		
		// [5] Setting disease information if need to send disease
		if (clazz.equals("01")) {
			List<DiseaseInfo> diseaseList = outsangRepository.getDiseaseInfo(hospCode, patientCode);
			if(!CollectionUtils.isEmpty(diseaseList)){
				for (DiseaseInfo diseaseInfo : diseaseList) {
					sangCodeTranfered.add(diseaseInfo.getDiseaseCode());
					NuroModelProto.DiseaseInformation.Builder diseaseBuilder = NuroModelProto.DiseaseInformation.newBuilder();
					diseaseBuilder.setDiseaseCode(diseaseInfo.getDiseaseCode());
					diseaseBuilder.setDiseaseName(diseaseInfo.getDiseaseName());
					diseaseBuilder.setDiseaseSuspectedFlag(diseaseInfo.getDiseaseSuspectedFlag());
					diseaseBuilder.setDiseaseStartDate(diseaseInfo.getDiseaseStartDate() == null ? "" : diseaseInfo.getDiseaseStartDate());
					diseaseBuilder.setDiseaseEndDate(diseaseInfo.getDiseaseEndDate() == null ? "" : diseaseInfo.getDiseaseEndDate());
					diseaseBuilder.setDiseaseOutCome(diseaseInfo.getDiseaseOutCome() == null ? "" : diseaseInfo.getDiseaseOutCome());
					
					diBuilder.addDiseaseInformation(diseaseBuilder.build());
				}
			}
		}
		
		rq.setDiagnosisInformation(diBuilder);
		return rq.build();
	}
	
	private boolean kcckHandler(String hospCode, String patientCode, double pkout1001, List<Double> pkOcs1003List,
			String orderStatus, Date performDate, List<String> sangCodeTranfered, boolean diseaseSentYn, String clazz) {
		try {
			List<NuroORDERTRANSUpdateOCS1003SelectToInsert> insertList = out1003Repository
					.getNuroORDERTRANSUpdateOCS1003SelectToInsert(hospCode, patientCode, pkout1001, false, false);
			
			// 1 SEND_ORDER_DISEASE
			if(clazz.equals("01")){
				Double pkout1003 = null;
				if(!CollectionUtils.isEmpty(insertList)){
					for(NuroORDERTRANSUpdateOCS1003SelectToInsert info : insertList){
						pkout1003 = CommonUtils.parseDouble(commonRepository.getNextVal("OUT1003_SEQ"));
						Out1003 out1003 = new Out1003();
						out1003.setHospCode(hospCode);
						out1003.setActingDate(info.getActingDate());
						out1003.setBunho(info.getBunho());
						out1003.setGubun(info.getGubun());
						out1003.setGwa(info.getGwa());
						out1003.setDoctor(info.getDoctor());
						out1003.setChojae(info.getChojae());
						out1003.setSeq(info.getSeq());
						out1003.setPkout1003(pkout1003);
						out1003.setFkout1001(pkout1001);
						out1003Repository.save(out1003);
					}
				}
				
				if(!CollectionUtils.isEmpty(pkOcs1003List)){
					for(Double pkocs1003 : pkOcs1003List){
						ocs1003Repository.updateOrderTransfer(performDate, pkout1003, pkocs1003, hospCode, orderStatus);
					}
				}
				
				if(diseaseSentYn && !CollectionUtils.isEmpty(sangCodeTranfered)){
					outsangRepository.updateDataSendYn("Y", new Date(), hospCode, patientCode, sangCodeTranfered);
				}
			}
			
			// 3 RETRANSFER_ORDER
			if(clazz.equals("04")){
				if(!CollectionUtils.isEmpty(pkOcs1003List) && OrderStatus.TRANFER_SUCCESS.getValue().equals(orderStatus)){
					ocs1003Repository.updateOrderStatusByPkOcs1003(hospCode, pkOcs1003List, OrderStatus.TRANFER_SUCCESS.getValue());
				}
			}
		} catch (Exception e) {
			LOGGER.error("TRANSFER ORDER: HOSP_CODE = " + hospCode + ", CLAZZ = " + clazz + ": Exception ", e);
			return false;
		}
		
		return true;
	}
	
	private boolean updateFailOrderTransfer(String hospCode, String patientCode, double pkout1001, List<Double> pkOcs1003List, String clazz){
		if(CollectionUtils.isEmpty(pkOcs1003List)) return true;
		if(clazz.equals("04")){
			return ocs1003Repository.updateOrderStatusByPkOcs1003(hospCode, pkOcs1003List, OrderStatus.TRANFER_FAIL.getValue()) > 0;
		}
		
		List<NuroORDERTRANSUpdateOCS1003SelectToInsert> insertList = out1003Repository
				.getNuroORDERTRANSUpdateOCS1003SelectToInsert(hospCode, patientCode, pkout1001, false, false);
		
		Double pkout1003 = null;
		if(!CollectionUtils.isEmpty(insertList)){
			for(NuroORDERTRANSUpdateOCS1003SelectToInsert info : insertList){
				pkout1003 = CommonUtils.parseDouble(commonRepository.getNextVal("OUT1003_SEQ"));
				Out1003 out1003 = new Out1003();
				out1003.setHospCode(hospCode);
				out1003.setActingDate(info.getActingDate());
				out1003.setBunho(info.getBunho());
				out1003.setGubun(info.getGubun());
				out1003.setGwa(info.getGwa());
				out1003.setDoctor(info.getDoctor());
				out1003.setChojae(info.getChojae());
				out1003.setSeq(info.getSeq());
				out1003.setPkout1003(pkout1003);
				out1003.setFkout1001(pkout1001);
				out1003Repository.save(out1003);
			}
		}
		
		return ocs1003Repository.updateFailTransferOrder(hospCode, pkOcs1003List, OrderStatus.TRANFER_FAIL.getValue(), pkout1003) > 0;
	}
	
}
