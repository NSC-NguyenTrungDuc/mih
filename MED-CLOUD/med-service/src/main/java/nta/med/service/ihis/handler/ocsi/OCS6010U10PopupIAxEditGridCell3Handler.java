package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur0115Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupIAxEditGridCell3Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupIAxEditGridCell3Response;

@Service
@Scope("prototype")
public class OCS6010U10PopupIAxEditGridCell3Handler extends ScreenHandler<OcsiServiceProto.OCS6010U10PopupIAxEditGridCell3Request, OcsiServiceProto.OCS6010U10PopupIAxEditGridCell3Response> {
	@Resource
	private Nur0115Repository nur0115Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS6010U10PopupIAxEditGridCell3Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupIAxEditGridCell3Request request) throws Exception {
		
		OcsiServiceProto.OCS6010U10PopupIAxEditGridCell3Response.Builder response = OcsiServiceProto.OCS6010U10PopupIAxEditGridCell3Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String nurGrCode = request.getNurGrCode();
		String nurMdCode = request.getNurMdCode();
		
        List<ComboListItemInfo> listInfo = nur0115Repository.getOCS6010U10PopupIAxEditGridCell3(hospCode, nurGrCode, nurMdCode);
		if (!CollectionUtils.isEmpty(listInfo)) {
			for (ComboListItemInfo item : listInfo) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addXeditItem(info);
			}
		}
        return response.build();
	}

}
