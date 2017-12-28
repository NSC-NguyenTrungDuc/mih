package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.ocsi.OCS1024U00xEditGridCell20Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00xEditGridCell20Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00xEditGridCell20Response;

@Service
@Scope("prototype")
public class OCS1024U00xEditGridCell20Handler  extends ScreenHandler<OcsiServiceProto.OCS1024U00xEditGridCell20Request , OcsiServiceProto.OCS1024U00xEditGridCell20Response>{
	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS1024U00xEditGridCell20Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS1024U00xEditGridCell20Request request) throws Exception {
		OcsiServiceProto.OCS1024U00xEditGridCell20Response.Builder response = OcsiServiceProto.OCS1024U00xEditGridCell20Response.newBuilder();
		List<OCS1024U00xEditGridCell20Info> gridList = ocs0132Repository.getOCS1024U00xEditGridCell20Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(gridList)) {
			for(OCS1024U00xEditGridCell20Info item : gridList){
				OcsiModelProto.OCS1024U00xEditGridCell20Info.Builder info = OcsiModelProto.OCS1024U00xEditGridCell20Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addXEditGridCell20(info);
			}
		}
		return response.build();
	}

}
