package nta.med.service.ihis.handler.invs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inv.Inv6002Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV6002U00GrdINV6002LoadCbxJaeryoGubunRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class INV6002U00GrdINV6002LoadCbxJaeryoGubunHandler extends ScreenHandler<InvsServiceProto.INV6002U00GrdINV6002LoadCbxJaeryoGubunRequest, SystemServiceProto.ComboResponse>{
	private static final Log LOGGER = LogFactory.getLog(INV6002U00GrdINV6002LoadCbxJaeryoGubunHandler.class);
	@Resource
    private Inv6002Repository inv6002Repository;

	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, INV6002U00GrdINV6002LoadCbxJaeryoGubunRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		List<ComboListItemInfo> listComboInfos = inv6002Repository.getINV6002U00GrdINV6002LoadcbxActorInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listComboInfos)){
			for (ComboListItemInfo item : listComboInfos) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}else
		{
			LOGGER.info("INV6002U00GrdINV6002LoadCbxJaeryoGubunHandler handler not found list of ComboListItemInfo");
		}
		return response.build();
	}
	
}
