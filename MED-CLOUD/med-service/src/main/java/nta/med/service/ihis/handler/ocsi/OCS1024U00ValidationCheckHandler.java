package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.drg.Drg0120;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00ValidationCheckRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00ValidationCheckResponse;

@Service
@Scope("prototype")
public class OCS1024U00ValidationCheckHandler extends ScreenHandler<OcsiServiceProto.OCS1024U00ValidationCheckRequest , OcsiServiceProto.OCS1024U00ValidationCheckResponse>{
	@Resource
	private Drg0120Repository drg0120Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS1024U00ValidationCheckResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS1024U00ValidationCheckRequest request) throws Exception {
		OcsiServiceProto.OCS1024U00ValidationCheckResponse.Builder response = OcsiServiceProto.OCS1024U00ValidationCheckResponse.newBuilder();
		List<Drg0120> drg0120s = drg0120Repository.getObjectOBGetBogyongInfo(getHospitalCode(vertx, sessionId), request.getBogyongCode(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(drg0120s)){
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(StringUtils.isEmpty(drg0120s.get(0).getBogyongGubun()) ? "" : drg0120s.get(0).getBogyongGubun());
			response.setValItem(info);
		}
		return response.build();
	}

}
