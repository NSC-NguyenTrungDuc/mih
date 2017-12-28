package nta.med.service.ihis.handler.adma;

import nta.med.core.common.annotation.Route;
import nta.med.core.glossary.UserRole;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0100Repository;
import nta.med.data.model.ihis.adma.ADM101UGrdGroupItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.List;

@Service                                                                                                          
@Scope("prototype")
public class ADM101UGrdGroupHandler extends ScreenHandler<AdmaServiceProto.ADM101UGrdGroupRequest, AdmaServiceProto.ADM101UGrdGroupResponse> {
	private static final Log LOGGER = LogFactory.getLog(ADM101UGrdGroupHandler.class);           
	
	@Resource                                                                                                       
	private Adm0100Repository adm0100Repository;
	
	@Override
	public boolean isAuthorized(Vertx vertx, String sessionId){

		return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
	}
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = true)
	public AdmaServiceProto.ADM101UGrdGroupResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM101UGrdGroupRequest request) throws Exception {
		AdmaServiceProto.ADM101UGrdGroupResponse.Builder response = AdmaServiceProto.ADM101UGrdGroupResponse.newBuilder();
		List<ADM101UGrdGroupItemInfo> listItem = adm0100Repository.getADM101UGrdGroupItemInfo(getLanguage(vertx, sessionId), request.getGrpId(), request.getGrpNm());
		if (!CollectionUtils.isEmpty(listItem)) {
			for (ADM101UGrdGroupItemInfo item : listItem) {
				AdmaModelProto.ADM101UGrdGroupItemInfo.Builder builder = AdmaModelProto.ADM101UGrdGroupItemInfo.newBuilder();
				BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
				response.addItemInfo(builder);
			}
		}
		
		return response.build();
	}
}
