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
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupIAbtnListRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupIAbtnListResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupIAbtnListHandler extends ScreenHandler<OcsiServiceProto.OCS6010U10PopupIAbtnListRequest, OcsiServiceProto.OCS6010U10PopupIAbtnListResponse> {
	@Resource
	private Ocs2015Repository ocs2015Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS6010U10PopupIAbtnListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupIAbtnListRequest request) throws Exception {
		
		OcsiServiceProto.OCS6010U10PopupIAbtnListResponse.Builder response = OcsiServiceProto.OCS6010U10PopupIAbtnListResponse.newBuilder();
		String hospCode = request.getHospCode();
		String language = getLanguage(vertx, sessionId);
		
		String bunho = request.getBunho();
		String orderDate = request.getOrderDate();
		
        List<ComboListItemInfo> listInfo = ocs2015Repository.getOCS6010U10PopupIAbtnList(hospCode, bunho, orderDate);
		if (!CollectionUtils.isEmpty(listInfo)) {
			for (ComboListItemInfo item : listInfo) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addDtItems(info);
			}
		}
        return response.build();
	}

}
