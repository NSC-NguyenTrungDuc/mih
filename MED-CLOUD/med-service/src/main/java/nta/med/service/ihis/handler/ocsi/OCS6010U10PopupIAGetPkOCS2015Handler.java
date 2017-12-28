package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupIAGetPkOCS2015Request;

@Service
@Scope("prototype")
public class OCS6010U10PopupIAGetPkOCS2015Handler extends ScreenHandler<OcsiServiceProto.OCS6010U10PopupIAGetPkOCS2015Request, OcsiServiceProto.OCS6010U10PopupIAGetPkOCS2015Response> {
	
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	@Transactional
	public OcsiServiceProto.OCS6010U10PopupIAGetPkOCS2015Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupIAGetPkOCS2015Request request) throws Exception {
		
		OcsiServiceProto.OCS6010U10PopupIAGetPkOCS2015Response.Builder response = OcsiServiceProto.OCS6010U10PopupIAGetPkOCS2015Response.newBuilder();
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
		info.setDataValue("");
		String seqNextVal;
		
		seqNextVal = commonRepository.getNextVal("OCS2015_SEQ");
		if (!StringUtils.isEmpty(seqNextVal)) {
			info.setDataValue(seqNextVal);
		}
		
		response.setGetItem(info);
		return response.build();
	}
}
