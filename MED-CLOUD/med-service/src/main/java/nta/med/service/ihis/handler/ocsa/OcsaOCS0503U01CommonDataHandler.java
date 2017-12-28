package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cht.Cht0110Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0503U01CommonDataRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0503U01CommonDataResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsaOCS0503U01CommonDataHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0503U01CommonDataRequest, OcsaServiceProto.OcsaOCS0503U01CommonDataResponse> {
	
    @Resource
    private Cht0110Repository cht0110Repository;
    
    @Override
    @Transactional(readOnly = true)
    public OcsaOCS0503U01CommonDataResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OcsaOCS0503U01CommonDataRequest request) throws Exception {
    	String hospCode = getHospitalCode(vertx, sessionId);
        String resultSangName = cht0110Repository.getSangName(hospCode, request.getFCode());
        String resultGwaName = cht0110Repository.getGwaName(hospCode, getLanguage(vertx, sessionId), request.getFCode());
        String resultDoctorName = cht0110Repository.getDoctorName(hospCode, request.getFCode());
        OcsaServiceProto.OcsaOCS0503U01CommonDataResponse.Builder response = OcsaServiceProto.OcsaOCS0503U01CommonDataResponse.newBuilder();
        if(resultSangName != null && !resultSangName.isEmpty()){
        	response.setSangName(resultSangName);
        }
        if(resultGwaName != null && !resultGwaName.isEmpty()){
        	response.setGwaName(resultGwaName);
        }
        if(resultDoctorName != null && !resultDoctorName.isEmpty()){
        	response.setDoctorName(resultDoctorName);
        }
        return response.build();
    }
}
