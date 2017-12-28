package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00getBogyongNameRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00getBogyongNameResponse;

@Service
@Scope("prototype")
public class OCS1024U00getBogyongNameHandler extends ScreenHandler<OcsiServiceProto.OCS1024U00getBogyongNameRequest , OcsiServiceProto.OCS1024U00getBogyongNameResponse>{
	@Resource
	private Drg0120Repository drg0120Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS1024U00getBogyongNameResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS1024U00getBogyongNameRequest request) throws Exception {
		OcsiServiceProto.OCS1024U00getBogyongNameResponse.Builder response = OcsiServiceProto.OCS1024U00getBogyongNameResponse.newBuilder();
		String result = drg0120Repository.callFnDrgLoadBogyongName(getHospitalCode(vertx, sessionId), request.getBogyongCode());
		if(!StringUtils.isEmpty(result)){
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(result);
			response.setBoItem(info);
	}
		return response.build();
	}

}
