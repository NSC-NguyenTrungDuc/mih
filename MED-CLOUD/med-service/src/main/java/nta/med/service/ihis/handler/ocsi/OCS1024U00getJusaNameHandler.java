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
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00getJusaNameRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00getJusaNameResponse;

@Service
@Scope("prototype")
public class OCS1024U00getJusaNameHandler extends ScreenHandler<OcsiServiceProto.OCS1024U00getJusaNameRequest , OcsiServiceProto.OCS1024U00getJusaNameResponse>{
	@Resource
	private Drg0120Repository drg0120Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS1024U00getJusaNameResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS1024U00getJusaNameRequest request) throws Exception {
		OcsiServiceProto.OCS1024U00getJusaNameResponse.Builder response = OcsiServiceProto.OCS1024U00getJusaNameResponse.newBuilder();
		String result = drg0120Repository.callFnDrgLoadBogyongJusaName(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "B", request.getJusaCode());
		if(!StringUtils.isEmpty(result)){
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(result);
			response.setJuItem(info);
		}
		return response.build();
	}

}
