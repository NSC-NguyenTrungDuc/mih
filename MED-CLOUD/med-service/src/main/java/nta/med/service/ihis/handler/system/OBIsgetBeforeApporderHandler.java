package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OBIsgetBeforeApporderRequest;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OBIsgetBeforeApporderHandler extends ScreenHandler<SystemServiceProto.OBIsgetBeforeApporderRequest, SystemServiceProto.StringResponse>{
	@Resource
	private Ocs1003Repository ocs1003Repository;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OBIsgetBeforeApporderRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		Integer result = ocs1003Repository.callFnOcsGetBeforeApporder(getHospitalCode(vertx, sessionId)
								, request.getIoGubun()
								, request.getInsteadYn()
								, request.getApproveYn()
								, request.getDoctorId()
								, request.getKey());
		response.setResult(result == null ? "" : CommonUtils.parseString(result));
		return response.build();
	}

}
