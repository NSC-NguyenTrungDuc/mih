package nta.med.service.ihis.handler.nuts;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.service.ihis.proto.NutsServiceProto;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001U00cbxSiksaChangeYNCRequest;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001U00cbxSiksaChangeYNCResponse;

@Service
@Scope("prototype")
public class NUT9001U00cbxSiksaChangeYNCHandler extends
		ScreenHandler<NutsServiceProto.NUT9001U00cbxSiksaChangeYNCRequest, NutsServiceProto.NUT9001U00cbxSiksaChangeYNCResponse> {

	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional
	public NUT9001U00cbxSiksaChangeYNCResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUT9001U00cbxSiksaChangeYNCRequest request) throws Exception {
		NutsServiceProto.NUT9001U00cbxSiksaChangeYNCResponse.Builder response = NutsServiceProto.NUT9001U00cbxSiksaChangeYNCResponse.newBuilder();
		
		ocs0132Repository.updatePHY0001U00SaveLayout(request.getValue()
				, getHospitalCode(vertx, sessionId)
				, getLanguage(vertx, sessionId)
				, "NUT_FINAL_MAGAM_ACTION"
				, request.getCode());
		
		return response.build();
	}

}
