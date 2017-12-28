package nta.med.service.ihis.handler.nuro;

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
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ifs.Ifs0003;
import nta.med.core.domain.ocs.Ocs1003;
import nta.med.core.domain.out.Out1001;
import nta.med.core.domain.out.Out1003;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.glossary.OrderStatus;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.core.utils.OrcaUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.data.dao.medi.out.Out0105Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.out.Out1003Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.nuro.CompanyInsurance;
import nta.med.data.model.ihis.nuro.DiseaseInfo;
import nta.med.data.model.ihis.nuro.MedicalInfo;
import nta.med.data.model.ihis.nuro.MedicalInfoExt;
import nta.med.data.model.ihis.nuro.NuroORDERTRANSUpdateOCS1003SelectToInsert;
import nta.med.data.model.ihis.nuro.ORDERTRANSAPIHangmogInfo;
import nta.med.data.model.ihis.nuro.PublicInsurance;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service
@Scope("prototype")
public class ORDERTRANSAPITransferOrdersHandler extends
		ScreenHandler<NuroServiceProto.ORDERTRANSAPITransferOrdersRequest, NuroServiceProto.ORDERTRANSAPITransferOrdersResponse> {

	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSAPITransferOrdersHandler.class);
	private RpcMessageParser parser = new RpcMessageParser(NuroServiceProto.class);

	@Resource
	private Out1001Repository out1001Repository;
	
	@Resource
	private Out0102Repository out0102Repository;
	
	@Resource
	private Out0105Repository out0105Repository;
	
	@Resource
	private Ifs0003Repository ifs0003Repository;
	
	@Resource
	private OutsangRepository outsangRepository;
	
	@Resource
	private Ocs1003Repository ocs1003Repository;
	
	@Resource                                                                                                       
	private Out1003Repository out1003Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	@Transactional
	public NuroServiceProto.ORDERTRANSAPITransferOrdersResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, NuroServiceProto.ORDERTRANSAPITransferOrdersRequest request) throws Exception {
		LOGGER.info("TRANSFER ORDER: HOSP_CODE = " + getHospitalCode(vertx, sessionId) + ", ACTION = " + request.getAction());
		
		NuroServiceProto.ORDERTRANSAPITransferOrdersResponse.Builder response = NuroServiceProto.ORDERTRANSAPITransferOrdersResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String patientCode = request.getBunho();
		double pkout1001 = CommonUtils.parseDouble(request.getPkout1001());
		Date performDate = DateUtil.toDate(request.getPerformDate(), DateUtil.PATTERN_YYMMDD);
		
		if(NuroModelProto.TransferType.SEND_ORDER_DISEASE == request.getAction()){
			// Check status of all orders per each examination
			List<String> listStatus = ocs1003Repository.checkOrderStatus(hospCode, patientCode, pkout1001);
			if(CollectionUtils.isEmpty(listStatus)){
				NuroModelProto.ORDERTRANSAPIMsgInfo.Builder info = NuroModelProto.ORDERTRANSAPIMsgInfo
						.newBuilder()
						.setErrCode("01");
				response.setMsgItem(info);
				return response.build();
			}
		}
		
		// Send request to MED-GATEWAY
		List<ORDERTRANSAPIHangmogInfo> errHangmogList = new ArrayList<>();
		List<String> strErrorHangmogList = new ArrayList<>();
		List<String> sangCodeTranfered = new ArrayList<>();
		NuroServiceProto.OrderTranferRequest rq = toApiRequest(hospCode, request, errHangmogList, sangCodeTranfered);
		if(!CollectionUtils.isEmpty(errHangmogList) && NuroModelProto.TransferType.SEND_ORDER_DISEASE == request.getAction()){
			for (ORDERTRANSAPIHangmogInfo errInfo : errHangmogList) {
				NuroModelProto.ORDERTRANSAPIHangmogInfo.Builder errBuilder = NuroModelProto.ORDERTRANSAPIHangmogInfo.newBuilder();
				errBuilder.setHangmogCode(errInfo.getHangmogCode());
				errBuilder.setHangmogName(errInfo.getHangmogName());
				response.addHangmogErrItem(errBuilder);
				strErrorHangmogList.add(errInfo.getHangmogCode());
			}
		}
		
		if(strErrorHangmogList.size() > 0 && strErrorHangmogList.size() == request.getHangmogItemCount()){
			NuroModelProto.ORDERTRANSAPIMsgInfo.Builder info = NuroModelProto.ORDERTRANSAPIMsgInfo
					.newBuilder()
					.setErrCode("");
			response.setMsgItem(info);
			return response.build();
		}
		
		NuroServiceProto.OrderTranferResponse r = null;
		try {
			FutureEx<NuroServiceProto.OrderTranferResponse> res = send(vertx, parser, rq, hospCode);
			r = res.get(30, TimeUnit.SECONDS);
		} catch (Exception e) {
			LOGGER.warn("Fail to request to ORCA: ", e);
			r = null;
		}
		
		List<NuroModelProto.ORDERTRANSAPIHangmogInfo> hangmogList = request.getHangmogItemList();
		List<Double> pkOcs1003List = new ArrayList<>();
		for (NuroModelProto.ORDERTRANSAPIHangmogInfo info : hangmogList) {
			if(!strErrorHangmogList.contains(info.getHangmogCode())){
				pkOcs1003List.add(CommonUtils.parseDouble(info.getPkocs1003()));
			}
		}
		
		if(r == null){
			updateFailOrderTransfer(hospCode, pkOcs1003List);
			return response.build();
		}
		
		String orderStatus = "";
		boolean diseaseSentYn = false;
		if (NuroModelProto.TransferType.SEND_ORDER_DISEASE == request.getAction()
				|| NuroModelProto.TransferType.RETRANSFER_ORDER == request.getAction()
				|| NuroModelProto.TransferType.CANCEL_ORDER == request.getAction()) {
			
			if (Arrays.asList("00", "21").contains(r.getApiResult())
					&& !Arrays.asList("01", "03", "10").contains(r.getMedicalResult())) {
				
				orderStatus = OrderStatus.TRANFER_SUCCESS.getValue();
				diseaseSentYn = !Arrays.asList("01", "02", "11", "12", "13").contains(r.getDiseaseResult());
			} else {
				orderStatus = OrderStatus.TRANFER_FAIL.getValue();
			}
		} else if(NuroModelProto.TransferType.SEND_DISEASE_ONLY == request.getAction()){
			diseaseSentYn = Arrays.asList("00", "20").contains(r.getApiResult()) && !Arrays.asList("01", "02", "11", "12", "13").contains(r.getDiseaseResult());
		}
		
		// Process on KCCK
		boolean kcckResult = kcckHandler(hospCode, patientCode, pkout1001, pkOcs1003List, orderStatus, performDate, sangCodeTranfered, diseaseSentYn, request.getAction());
		if(!kcckResult){
			NuroModelProto.ORDERTRANSAPIMsgInfo.Builder msgBuilder = NuroModelProto.ORDERTRANSAPIMsgInfo.newBuilder();
			response.setMsgItem(msgBuilder);
			throw new ExecutionException(response.build());
		}
		
		NuroModelProto.ORDERTRANSAPIMsgInfo.Builder msgBuilder = NuroModelProto.ORDERTRANSAPIMsgInfo.newBuilder();
		if(r.hasApiResult()) msgBuilder.setApiResult(r.getApiResult());
		if(r.hasMedicalResult()) msgBuilder.setMedicalResult(r.getMedicalResult());
		if(r.hasDiseaseResult()) msgBuilder.setDiseaseResult(r.getDiseaseResult());
		response.setMsgItem(msgBuilder);
		
		return response.build();
	}
	
	private NuroServiceProto.OrderTranferRequest toApiRequest(String hospCode,
			NuroServiceProto.ORDERTRANSAPITransferOrdersRequest request, 
			List<ORDERTRANSAPIHangmogInfo> errHangmogList,
			List<String> sangCodeTranfered) {
		
		String patientCode = request.getBunho();
		String performDate = request.getPerformDate().replace("/", "-");
		String performTime = new SimpleDateFormat("HH:mm:ss").format(Calendar.getInstance().getTime());
		double pkOut1001 = CommonUtils.parseDouble(request.getPkout1001());
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
		if(NuroModelProto.TransferType.SEND_ORDER_DISEASE == request.getAction()){
			List<Ocs1003> ocs1003List = ocs1003Repository.findByHospCodePkout1001OrderStatus(hospCode, CommonUtils.parseBigDecimal(request.getPkout1001()), OrderStatus.TRANFER_SUCCESS.getValue());
			if(CollectionUtils.isEmpty(ocs1003List)){
				rq.setAction(NuroServiceProto.OrderTranferRequest.Action.SEND_ORDER_DISEASE);
			} else {
				rq.setAction(NuroServiceProto.OrderTranferRequest.Action.RETRANSFER_ORDER); // Add new order
			}
		} else if(NuroModelProto.TransferType.SEND_DISEASE_ONLY == request.getAction()){
			rq.setAction(NuroServiceProto.OrderTranferRequest.Action.SEND_DISEASE_ONLY);
		} else if(NuroModelProto.TransferType.RETRANSFER_ORDER == request.getAction()){
			rq.setAction(NuroServiceProto.OrderTranferRequest.Action.RETRANSFER_ORDER);
		} else if(NuroModelProto.TransferType.CANCEL_ORDER == request.getAction()){
			rq.setAction(NuroServiceProto.OrderTranferRequest.Action.CANCEL_ORDER);
		}
		
		// [2] Setting department and doctor
		NuroModelProto.DiagnosisInformation.Builder diBuilder = NuroModelProto.DiagnosisInformation.newBuilder();
		List<Ifs0003> depts = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode, AccountingConfig.IF_ORCA_GWA.getValue(), out1001.getGwa());
		String deparmentCode = CollectionUtils.isEmpty(depts) ? "" : depts.get(0).getIfCode();
		diBuilder.setDepartmentCode(deparmentCode);
		
		List<Ifs0003> doctors = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode, AccountingConfig.IF_ORCA_DOCTOR.getValue(), out1001.getDoctor().substring(2, out1001.getDoctor().length()));
		String doctor = CollectionUtils.isEmpty(doctors) ? "" : doctors.get(0).getIfCode();
		diBuilder.setPhysicianCode(doctor);//TODO need to check again
		
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
			hiBuilder.setInsuranceProviderNumber("");
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
		List<NuroModelProto.ORDERTRANSAPIHangmogInfo> hangmogListProto = request.getHangmogItemList();
		if (!CollectionUtils.isEmpty(hangmogListProto)
				&& NuroModelProto.TransferType.SEND_DISEASE_ONLY != request.getAction()) {
			
			//	[4.1] Validate order
			List<String> hangmogList = new ArrayList<>();
			List<String> hangmogListTransfer = new ArrayList<>();
			Map<String, String> mapCodeName = new HashMap<>();
			for (NuroModelProto.ORDERTRANSAPIHangmogInfo info : hangmogListProto) {
				hangmogList.add(info.getHangmogCode());
				if (!mapCodeName.containsKey(info.getHangmogCode())){
					mapCodeName.put(info.getHangmogCode(), info.getHangmogName());
				}
			}
			
			if(NuroModelProto.TransferType.SEND_ORDER_DISEASE == request.getAction() || NuroModelProto.TransferType.RETRANSFER_ORDER == request.getAction()){
				List<Ifs0003> ifsList = ifs0003Repository.findByHospCodeMapGubunOcsCodeList(hospCode, "IF_ORCA_HANGMOG", hangmogList);
				for (Ifs0003 ifs0003 : ifsList) {
					hangmogListTransfer.add(ifs0003.getOcsCode());
				}
				
				for (String hangmogCode : hangmogList) {
					if(!hangmogListTransfer.contains(hangmogCode)){
						errHangmogList.add(new ORDERTRANSAPIHangmogInfo(hangmogCode, mapCodeName.get(hangmogCode)));
					}
				}
			}
			
			//	[4.2] Generate examination fee in case send order/cancel order
			if (NuroModelProto.TransferType.SEND_ORDER_DISEASE == request.getAction()
					|| NuroModelProto.TransferType.CANCEL_ORDER == request.getAction()) {
				
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
			}
						
			//	[4.3] Get medical information
			if(!CollectionUtils.isEmpty(hangmogListTransfer)){
				List<MedicalInfoExt> miList = null; 
				if (NuroModelProto.TransferType.SEND_ORDER_DISEASE == request.getAction()
						|| NuroModelProto.TransferType.RETRANSFER_ORDER == request.getAction()) {
					
					miList = ocs1003Repository.getMedicalInfo(hospCode, patientCode, pkOut1001, hangmogListTransfer, false);
				} else if(NuroModelProto.TransferType.CANCEL_ORDER == request.getAction()){
					miList = ocs1003Repository.getMedicalInfo(hospCode, patientCode, pkOut1001, hangmogListTransfer, true);
				}
				
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
		if (NuroModelProto.TransferType.SEND_ORDER_DISEASE == request.getAction()
				|| NuroModelProto.TransferType.SEND_DISEASE_ONLY == request.getAction()) {
			
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
			String orderStatus, Date performDate, List<String> sangCodeTranfered, boolean diseaseSentYn, NuroModelProto.TransferType action) {
		
		try {
			List<NuroORDERTRANSUpdateOCS1003SelectToInsert> insertList = out1003Repository
					.getNuroORDERTRANSUpdateOCS1003SelectToInsert(hospCode, patientCode, pkout1001, false, false);
			
			// 1 SEND_ORDER_DISEASE
			if(action == NuroModelProto.TransferType.SEND_ORDER_DISEASE){
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
			}
			
			// 2 SEND_ORDER_DISEASE/SEND_DISEASE_ONLY
			if (action == NuroModelProto.TransferType.SEND_ORDER_DISEASE
					|| action == NuroModelProto.TransferType.SEND_DISEASE_ONLY) {
				
				if(diseaseSentYn && !CollectionUtils.isEmpty(sangCodeTranfered)){
					outsangRepository.updateDataSendYn("Y", new Date(), hospCode, patientCode, sangCodeTranfered);
				}
			}
			
			// 3 RETRANSFER_ORDER
			if(action == NuroModelProto.TransferType.RETRANSFER_ORDER){
				if(!CollectionUtils.isEmpty(pkOcs1003List) && OrderStatus.TRANFER_SUCCESS.getValue().equals(orderStatus)){
					ocs1003Repository.updateOrderStatusByPkOcs1003(hospCode, pkOcs1003List, OrderStatus.TRANFER_SUCCESS.getValue());
				}
			}
			
			// 4 CANCEL_ORDER
			if(action == NuroModelProto.TransferType.CANCEL_ORDER
					&& OrderStatus.TRANFER_SUCCESS.getValue().equals(orderStatus)
					&& !CollectionUtils.isEmpty(pkOcs1003List)){
				
				ocs1003Repository.updateOrderCanceled(hospCode, pkOcs1003List, null, "N", null, null, "N", null, null);
			}
		} catch (Exception e) {
			LOGGER.error("TRANSFER ORDER: HOSP_CODE = " + hospCode + ", ACTION = " + action + ": Exception ", e);
			return false;
		}
		
		return true;
	}
	
	private boolean updateFailOrderTransfer(String hospCode, List<Double> pkOcs1003List){
		if(CollectionUtils.isEmpty(pkOcs1003List)){
			return true;
		}
		
		return ocs1003Repository.updateOrderStatusByPkOcs1003(hospCode, pkOcs1003List, OrderStatus.TRANFER_FAIL.getValue()) > 0;
	}
	
}
