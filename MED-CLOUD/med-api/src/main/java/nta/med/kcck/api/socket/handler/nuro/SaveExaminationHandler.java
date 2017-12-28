package nta.med.kcck.api.socket.handler.nuro;

import javax.annotation.Resource;

import org.springframework.stereotype.Component;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.kcck.api.rpc.proto.PatientModelProto;
import nta.med.kcck.api.rpc.proto.PatientServiceProto;
import nta.med.kcck.api.rpc.service.patient.PatientApiService;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.SaveExaminationRequest;
import nta.med.service.ihis.proto.NuroServiceProto.SaveExaminationResponse;

@Component("saveExaminationHandler")
public class SaveExaminationHandler extends ScreenHandler<NuroServiceProto.SaveExaminationRequest, NuroServiceProto.SaveExaminationResponse> {

    @Resource
    private PatientApiService patientApiService;
	
	@Override
	public SaveExaminationResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			SaveExaminationRequest request) throws Exception {
		
		PatientServiceProto.SaveExaminationResponse res = patientApiService.saveExamination(toApiRequest(request));
		NuroServiceProto.SaveExaminationResponse.Builder r = NuroServiceProto.SaveExaminationResponse.newBuilder();
		r.setId(res.getId());
		r.setHospCode(res.getHospCode());
		r.setMessageCode(res.getMessageCode());
		r.setMessageDetail(res.getMessageDetail());
		r.setRefId(res.getRefId() == null ? "" : res.getRefId());
		
		if(res.getResult() == PatientServiceProto.SaveExaminationResponse.Result.SUCCESS){
        	r.setResult(NuroServiceProto.SaveExaminationResponse.Result.SUCCESS);
        } else if(res.getResult() == PatientServiceProto.SaveExaminationResponse.Result.FAIL){
        	r.setResult(NuroServiceProto.SaveExaminationResponse.Result.FAIL);
        } else {
        	r.setResult(NuroServiceProto.SaveExaminationResponse.Result.INTERNAL_ERROR);
        }
		
		return r.build();
	}

	private PatientServiceProto.SaveExaminationRequest toApiRequest(NuroServiceProto.SaveExaminationRequest request){
		PatientServiceProto.SaveExaminationRequest.Builder r = PatientServiceProto.SaveExaminationRequest.newBuilder();
		r.setId(request.getId());
		r.setHospCode(request.getHospCode());
		
		PatientModelProto.AcceptInformation.Builder acceptInfo = PatientModelProto.AcceptInformation.newBuilder();
		BeanUtils.copyProperties(request.getExamInfo(), acceptInfo, Language.JAPANESE.toString());
		acceptInfo.setPhysicianCode(request.getExamInfo().getDoctorCode());
		acceptInfo.setAcceptanceDate(request.getExamInfo().getComingDate());
		if(request.getExamInfo().getInsurCode() != null){
			acceptInfo.setInsuranceCode(request.getExamInfo().getInsurCode());
		}
		
		r.setExamInfo(acceptInfo);
		return r.build();
	}
	
}
