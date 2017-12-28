package nta.med.kcck.api.socket.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.stereotype.Component;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.kcck.api.rpc.proto.PatientModelProto;
import nta.med.kcck.api.rpc.proto.PatientServiceProto;
import nta.med.kcck.api.rpc.service.patient.PatientApiService;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

/**
 * @author dainguyen.
 */
@Component("createPatientHandler")
public class CreatePatientHandler extends ScreenHandler<NuroServiceProto.CreatePatientRequest, NuroServiceProto.CreatePatientResponse> {

    @Resource
    private PatientApiService patientApiService;

    @Override
    public NuroServiceProto.CreatePatientResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, NuroServiceProto.CreatePatientRequest request) throws Exception {
        PatientServiceProto.CreatePatientResponse res = patientApiService.createPatient(toApiEvent(request));
        NuroServiceProto.CreatePatientResponse.Builder r = NuroServiceProto.CreatePatientResponse.newBuilder();
        r.setId(res.getId());
        r.setHospCode(res.getHospCode());
        r.setNewPatientCode(res.getNewPatientCode());
        r.setMessageCode(res.getMessageCode());
        
        if(res.getResult() == PatientServiceProto.CreatePatientResponse.Result.SUCCESS){
        	r.setResult(NuroServiceProto.CreatePatientResponse.Result.SUCCESS);
        } else if(res.getResult() == PatientServiceProto.CreatePatientResponse.Result.SERVICE_TIMEOUT){
        	r.setResult(NuroServiceProto.CreatePatientResponse.Result.SERVICE_TIMEOUT);
        } else if(res.getResult() == PatientServiceProto.CreatePatientResponse.Result.SERVICE_UNAVAILABLE){
        	r.setResult(NuroServiceProto.CreatePatientResponse.Result.SERVICE_UNAVAILABLE);
        } else {
        	r.setResult(NuroServiceProto.CreatePatientResponse.Result.INTERNAL_ERROR);
        }
        
        return r.build();
    }

    private PatientServiceProto.CreatePatientRequest toApiEvent(NuroServiceProto.CreatePatientRequest request) {
        PatientServiceProto.CreatePatientRequest.Builder r = PatientServiceProto.CreatePatientRequest.newBuilder();
        r.setId(request.getId()).setHospCode(request.getHospCode());
        if(request.hasModKey()) r.setModKey(request.getModKey());
        
        PatientModelProto.PatientProfile.Builder profileBuilder = PatientModelProto.PatientProfile.newBuilder();
        BeanUtils.copyProperties(request.getPatientProfile(), profileBuilder, Language.JAPANESE.toString());
        r.setProfile(profileBuilder.build());

        List<NuroModelProto.NuroOUT0101U02GridBoheomInfo> publicInsList = request.getPublicInsuranceList();
        for (NuroModelProto.NuroOUT0101U02GridBoheomInfo info : publicInsList) {
            PatientModelProto.PublicInsurance.Builder item = PatientModelProto.PublicInsurance.newBuilder();
            BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
            r.addPublicInsurance(item.build());
        }

        List<NuroModelProto.NuroOUT0101U02GridGongbiListInfo>  privateInsList = request.getPrivateInsuranceList();
        for (NuroModelProto.NuroOUT0101U02GridGongbiListInfo info : privateInsList) {
            PatientModelProto.PrivateInsurance.Builder item = PatientModelProto.PrivateInsurance.newBuilder();
            BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
            r.addPrivateInsurance(item);
        }
        
        return r.build();
    }
}
