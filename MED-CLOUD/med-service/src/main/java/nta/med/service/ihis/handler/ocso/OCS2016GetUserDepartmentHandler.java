package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0503Repository;
import nta.med.data.model.ihis.ocso.OCS2016GetUserDepartmentInfo;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCS2016GetUserDepartmentRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.OCS2016GetUserDepartmentResponse;

@Service
@Scope("prototype")
public class OCS2016GetUserDepartmentHandler extends ScreenHandler<OcsoServiceProto.OCS2016GetUserDepartmentRequest, OcsoServiceProto.OCS2016GetUserDepartmentResponse>{

	@Resource
	private Ocs0503Repository ocs0503Repository;
	
	@Override
	public OCS2016GetUserDepartmentResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2016GetUserDepartmentRequest request) throws Exception {
		
		OcsoServiceProto.OCS2016GetUserDepartmentResponse.Builder response = OcsoServiceProto.OCS2016GetUserDepartmentResponse.newBuilder();
		List<OCS2016GetUserDepartmentInfo> listItem = ocs0503Repository.getOCS2016GetUserDepartmentInfo(request.getHospCode(), getUserId(vertx, sessionId), getLanguage(vertx, sessionId));
		for (OCS2016GetUserDepartmentInfo item : listItem) {
			OcsoModelProto.OCS2016GetUserDepartmentInfo.Builder info = OcsoModelProto.OCS2016GetUserDepartmentInfo.newBuilder();
			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
			response.addDepartmentInfo(info);
		}
		
		return response.build();
	}

	
}
