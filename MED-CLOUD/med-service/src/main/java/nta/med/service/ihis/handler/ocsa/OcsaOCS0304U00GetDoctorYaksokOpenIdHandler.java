package nta.med.service.ihis.handler.ocsa;


import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0130Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0304U00GetDoctorYaksokOpenIdRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0304U00GetDoctorYaksokOpenIdResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsaOCS0304U00GetDoctorYaksokOpenIdHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0304U00GetDoctorYaksokOpenIdRequest, OcsaServiceProto.OcsaOCS0304U00GetDoctorYaksokOpenIdResponse> {
	
    @Resource
    private Ocs0130Repository  ocs0130Repository;
    @Override
    @Transactional(readOnly = true)
    public OcsaOCS0304U00GetDoctorYaksokOpenIdResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OcsaOCS0304U00GetDoctorYaksokOpenIdRequest request)
			throws Exception {
         String result = ocs0130Repository.getOCS0304U00GetDoctorYaksokOpenId(getHospitalCode(vertx, sessionId),request.getDoctor());
         OcsaServiceProto.OcsaOCS0304U00GetDoctorYaksokOpenIdResponse.Builder response = OcsaServiceProto.OcsaOCS0304U00GetDoctorYaksokOpenIdResponse.newBuilder();
         if (result != null && !result.isEmpty()) {
             response.setYaksokOpenId(result);
         }
         return response.build();
    }
}
