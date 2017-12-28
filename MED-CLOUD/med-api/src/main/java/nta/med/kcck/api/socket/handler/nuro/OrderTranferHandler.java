package nta.med.kcck.api.socket.handler.nuro;

import javax.annotation.Resource;

import org.springframework.stereotype.Component;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.kcck.api.rpc.proto.OrderModelProto;
import nta.med.kcck.api.rpc.proto.OrderServiceProto;
import nta.med.kcck.api.rpc.service.order.OrderApiService;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

@Component("orderTranferHandler")
public class OrderTranferHandler
		extends ScreenHandler<NuroServiceProto.OrderTranferRequest, NuroServiceProto.OrderTranferResponse> {

    @Resource
    private OrderApiService orderApiService;
	
	@Override
	public NuroServiceProto.OrderTranferResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuroServiceProto.OrderTranferRequest request) throws Exception {
		OrderServiceProto.OrderTranferResponse res = orderApiService.orderTranfer(toApiRequest(request));
		NuroServiceProto.OrderTranferResponse.Builder r = NuroServiceProto.OrderTranferResponse.newBuilder();
		r.setId(res.getId());
		r.setHospCode(res.getHospCode());
		r.setResult(res.getResult());
		
		if(res.hasApiResult()) r.setApiResult(res.getApiResult());
		if(res.hasApiResultMessage()) r.setApiResultMessage(res.getApiResultMessage());
		if(res.hasMedicalUid()) r.setMedicalUid(res.getMedicalUid());
		if(res.hasMedicalResult()) r.setMedicalResult(res.getMedicalResult());
		if(res.hasMedicalResultMessage()) r.setMedicalResultMessage(res.getMedicalResultMessage());
		if(res.hasDiseaseResult()) r.setDiseaseResult(res.getDiseaseResult());
		if(res.hasDiseaseResultMessage()) r.setDiseaseResultMessage(res.getDiseaseResultMessage());
		
		return r.build();
	}
	
	private OrderServiceProto.OrderTranferRequest toApiRequest(NuroServiceProto.OrderTranferRequest request){
		OrderServiceProto.OrderTranferRequest.Builder r = OrderServiceProto.OrderTranferRequest.newBuilder();
		r.setId(request.getId());
		r.setHospCode(request.getHospCode());
		
		if (request.hasInOut()){
			r.setInOut(request.getInOut());
		}
		
		if(request.hasPatientId()) {
			r.setPatientId(request.getPatientId());
		}
		
		if(request.hasPerformDate()) {
			r.setPerformDate(request.getPerformDate());
		}
		
		if(request.hasPerformTime()) {
			r.setPerformTime(request.getPerformTime());
		}
		
		if(request.hasMedicalUid()) {
			r.setMedicalUid(request.getMedicalUid());
		}
		
		if(request.hasDiagnosisInformation()){
			OrderModelProto.DiagnosisInformation.Builder diApiBuilder = OrderModelProto.DiagnosisInformation.newBuilder();
			NuroModelProto.DiagnosisInformation diKcck = request.getDiagnosisInformation();
			
			if(diKcck.hasDepartmentCode()){
				diApiBuilder.setDepartmentCode(diKcck.getDepartmentCode());
			}
			
			if(diKcck.hasPhysicianCode()) {
				diApiBuilder.setPhysicianCode(diKcck.getPhysicianCode());
			}
			
			if(diKcck.hasHealthInsuranceInfo()){
				NuroModelProto.HealthInsuranceInfo hiKcck = diKcck.getHealthInsuranceInfo();
				OrderModelProto.HealthInsuranceInfo.Builder hiApiBuilder = OrderModelProto.HealthInsuranceInfo.newBuilder();
				if(hiKcck.hasInsuranceCombinationRateAdmission()){
					hiApiBuilder.setInsuranceCombinationRateAdmission(hiKcck.getInsuranceCombinationRateAdmission());
				}
				
				if(hiKcck.hasInsuranceCombinationRateOutpatient()){
					hiApiBuilder.setInsuranceCombinationRateOutpatient(hiKcck.getInsuranceCombinationRateOutpatient());
				}
				
				if(hiKcck.hasHealthInsuredPersonAssistanceName()){
					hiApiBuilder.setHealthInsuredPersonAssistanceName(hiKcck.getHealthInsuredPersonAssistanceName());
				}
				
				if(hiKcck.hasInsuranceCheckDate()){
					hiApiBuilder.setInsuranceCheckDate(hiKcck.getInsuranceCheckDate());
				}
				
				if(hiKcck.hasInsuranceCombinationNumber()){
					hiApiBuilder.setInsuranceCombinationNumber(hiKcck.getInsuranceCombinationNumber());
				}
				
				if(hiKcck.hasInsuranceProviderClass()){
					hiApiBuilder.setInsuranceProviderClass(hiKcck.getInsuranceProviderClass());
				}
				
				if(hiKcck.hasInsuranceProviderNumber()){
					hiApiBuilder.setInsuranceProviderNumber(hiKcck.getInsuranceProviderNumber());
				}
				
				if(hiKcck.hasInsuranceProviderWholeName()){
					hiApiBuilder.setInsuranceProviderWholeName(hiKcck.getInsuranceProviderWholeName());
				}
				
				if(hiKcck.hasHealthInsuredPersonSymbol()){
					hiApiBuilder.setHealthInsuredPersonSymbol(hiKcck.getHealthInsuredPersonSymbol());
				}
				
				if(hiKcck.hasHealthInsuredPersonNumber()){
					hiApiBuilder.setHealthInsuredPersonNumber(hiKcck.getHealthInsuredPersonNumber());
				}
				
				if(hiKcck.hasHealthInsuredPersonContinuation()){
					hiApiBuilder.setHealthInsuredPersonContinuation(hiKcck.getHealthInsuredPersonContinuation());
				}
				
				if(hiKcck.hasHealthInsuredPersonAssistance()){
					hiApiBuilder.setHealthInsuredPersonAssistance(hiKcck.getHealthInsuredPersonAssistance());
				}
				
				if(hiKcck.hasRelationToInsuredPerson()){
					hiApiBuilder.setRelationToInsuredPerson(hiKcck.getRelationToInsuredPerson());
				}
				
				if(hiKcck.hasHealthInsuredPersonWholeName()){
					hiApiBuilder.setHealthInsuredPersonWholeName(hiKcck.getHealthInsuredPersonWholeName());
				}
				
				if(hiKcck.hasCertificateStartDate()){
					hiApiBuilder.setCertificateStartDate(hiKcck.getCertificateStartDate());
				}
				
				if(hiKcck.hasCertificateStartDate()){
					hiApiBuilder.setCertificateStartDate(hiKcck.getCertificateStartDate());
				}
				
				if(hiKcck.hasCertificateExpiredDate()){
					hiApiBuilder.setCertificateExpiredDate(hiKcck.getCertificateExpiredDate());
				}
				
				if(!CollectionUtils.isEmpty(hiKcck.getPublicInsuranceList())){
					for (NuroModelProto.PublicInsuranceInfo piKcck : hiKcck.getPublicInsuranceList()) {
						OrderModelProto.PublicInsuranceInfo.Builder piApiBuilder = OrderModelProto.PublicInsuranceInfo.newBuilder();
						BeanUtils.copyProperties(piKcck, piApiBuilder, Language.JAPANESE.toString());
						hiApiBuilder.addPublicInsurance(piApiBuilder.build());
					}
				}
				
				diApiBuilder.setHealthInsuranceInfo(hiApiBuilder.build());
			}
			
			if(!CollectionUtils.isEmpty(diKcck.getMedicalInformationList())){
				for (NuroModelProto.MedicalInformation miKcck : diKcck.getMedicalInformationList()) {
					OrderModelProto.MedicalInformation.Builder miApiBuilder = OrderModelProto.MedicalInformation.newBuilder();
					if(miKcck.hasMedicalClass()){
						miApiBuilder.setMedicalClass(miKcck.getMedicalClass());
					}
					
					if(miKcck.hasMedicalClassName()){
						miApiBuilder.setMedicalClassName(miKcck.getMedicalClassName());
					}
					
					if(miKcck.hasMedicalClassNumber()){
						miApiBuilder.setMedicalClassNumber(miKcck.getMedicalClassNumber());
					}
					
					if(!CollectionUtils.isEmpty(miKcck.getMedicationInfoList())){
						for (NuroModelProto.MedicationInfo medicationKcck : miKcck.getMedicationInfoList()) {
							OrderModelProto.MedicationInfo.Builder medicationApiBuilder = OrderModelProto.MedicationInfo.newBuilder();
							BeanUtils.copyProperties(medicationKcck, medicationApiBuilder, Language.JAPANESE.toString());
							miApiBuilder.addMedicationInfo(medicationApiBuilder);
						}
					}
					
					diApiBuilder.addMedicalInformation(miApiBuilder.build());
				}
			}
			
			if(!CollectionUtils.isEmpty(diKcck.getDiseaseInformationList())){
				for (NuroModelProto.DiseaseInformation diseaseKcck : diKcck.getDiseaseInformationList()) {
					OrderModelProto.DiseaseInformation.Builder diseaseApiBuilder = OrderModelProto.DiseaseInformation.newBuilder();
					BeanUtils.copyProperties(diseaseKcck, diseaseApiBuilder, Language.JAPANESE.toString());
					diApiBuilder.addDiseaseInformation(diseaseApiBuilder.build());
				}
			}
			
			r.setDiagnosisInformation(diApiBuilder.build());
		}
		
		if(request.getAction() == NuroServiceProto.OrderTranferRequest.Action.SEND_ORDER_DISEASE){
			r.setAction(OrderServiceProto.OrderTranferRequest.Action.SEND_ORDER_DISEASE);
		} else if(request.getAction() == NuroServiceProto.OrderTranferRequest.Action.SEND_DISEASE_ONLY){
			r.setAction(OrderServiceProto.OrderTranferRequest.Action.SEND_DISEASE_ONLY);
		} else if(request.getAction() == NuroServiceProto.OrderTranferRequest.Action.RETRANSFER_ORDER){
			r.setAction(OrderServiceProto.OrderTranferRequest.Action.RETRANSFER_ORDER);
		} else if(request.getAction() == NuroServiceProto.OrderTranferRequest.Action.CANCEL_ORDER){
			r.setAction(OrderServiceProto.OrderTranferRequest.Action.CANCEL_ORDER);
		}
		
		return r.build();
	}
}
