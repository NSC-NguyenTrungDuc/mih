package nta.med.service.ihis.handler.ocsa;


import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0304Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0304U00GetYaksokDirectNameRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0304U00GetYaksokDirectNameResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsaOCS0304U00GetYaksokDirectNameHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0304U00GetYaksokDirectNameRequest, OcsaServiceProto.OcsaOCS0304U00GetYaksokDirectNameResponse> {
	
    @Resource
    private Ocs0304Repository   ocs0304Repository;
    @Override
    @Transactional(readOnly = true)
    public OcsaOCS0304U00GetYaksokDirectNameResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OcsaOCS0304U00GetYaksokDirectNameRequest request) throws Exception {
         String result = ocs0304Repository.getOCS0304U00GetYaksokDirectName(getHospitalCode(vertx, sessionId),request.getMembGubun(),request.getCode(), request.getDoctor());
         OcsaServiceProto.OcsaOCS0304U00GetYaksokDirectNameResponse.Builder response = OcsaServiceProto.OcsaOCS0304U00GetYaksokDirectNameResponse.newBuilder();
         if (result != null && !result.isEmpty()) {
             response.setYaksokDirectName(result);
         }
         return response.build();
    }
}
