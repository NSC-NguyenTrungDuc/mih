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
import nta.med.data.dao.medi.ocs.Ocs0101Repository;
import nta.med.data.model.ihis.ocsi.OCS2004U00layTabItemInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2004U00layTabItemRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2004U00layTabItemResponse;

@Service
@Scope("prototype")
public class OCS2004U00layTabItemHandler extends ScreenHandler<OcsiServiceProto.OCS2004U00layTabItemRequest , OcsiServiceProto.OCS2004U00layTabItemResponse>{
	@Resource
	private Ocs0101Repository ocs0101Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2004U00layTabItemResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2004U00layTabItemRequest request) throws Exception {
		
		OcsiServiceProto.OCS2004U00layTabItemResponse.Builder response = OcsiServiceProto.OCS2004U00layTabItemResponse.newBuilder();

		List<OCS2004U00layTabItemInfo> comboList = ocs0101Repository.getOCS2004U00layTabItem();
		if(!CollectionUtils.isEmpty(comboList)){
			for(OCS2004U00layTabItemInfo item : comboList){
				OcsiModelProto.OCS2004U00layTabItemInfo.Builder info = OcsiModelProto.OCS2004U00layTabItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayTab(info);
			}
		}
		return response.build();
	}

}
