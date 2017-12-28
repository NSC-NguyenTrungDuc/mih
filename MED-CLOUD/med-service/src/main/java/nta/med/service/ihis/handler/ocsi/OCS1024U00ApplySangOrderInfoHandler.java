package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00ApplySangOrderInfoRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00ApplySangOrderInfoResponse;

@Service
@Scope("prototype")
public class OCS1024U00ApplySangOrderInfoHandler extends ScreenHandler<OcsiServiceProto.OCS1024U00ApplySangOrderInfoRequest , OcsiServiceProto.OCS1024U00ApplySangOrderInfoResponse>{
	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS1024U00ApplySangOrderInfoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS1024U00ApplySangOrderInfoRequest request) throws Exception {
		OcsiServiceProto.OCS1024U00ApplySangOrderInfoResponse.Builder response = OcsiServiceProto.OCS1024U00ApplySangOrderInfoResponse.newBuilder();
		String result = ocs0132Repository.callFnOcsLoadCodeName(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "ORD_DANUI", request.getOrdDanui());
		if(!StringUtils.isEmpty(result)){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				info.setDataValue(result);
				response.setSangItem(info);
		}
		return response.build();
	}
	

}
