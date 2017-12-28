package nta.med.service.ihis.handler.adma;

import nta.med.core.glossary.UserRole;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0200Repository;
import nta.med.data.model.ihis.adma.ADM101UgrdSystemItemInfo;
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
public class ADM101UGrdSystemHandler extends ScreenHandler<AdmaServiceProto.ADM101UGrdSystemRequest, AdmaServiceProto.ADM101UGrdSystemResponse> {
	private static final Log LOGGER = LogFactory.getLog(ADM101UGrdSystemHandler.class);                                    
	@Resource                                                                                                       
	private Adm0200Repository adm0200Repository;
	@Override
	public boolean isAuthorized(Vertx vertx, String sessionId){

		return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
	}
	@Override
	@Transactional(readOnly = true)
	public AdmaServiceProto.ADM101UGrdSystemResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM101UGrdSystemRequest request) throws Exception {
		AdmaServiceProto.ADM101UGrdSystemResponse.Builder response = AdmaServiceProto.ADM101UGrdSystemResponse.newBuilder();
		List<ADM101UgrdSystemItemInfo> listItem = adm0200Repository.getADM101UgrdSystemItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getGrpId());
		if (!CollectionUtils.isEmpty(listItem)) {
			for (ADM101UgrdSystemItemInfo item : listItem) {
				AdmaModelProto.ADM101UgrdSystemItemInfo.Builder builder = AdmaModelProto.ADM101UgrdSystemItemInfo.newBuilder();
				BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
				response.addItemInfo(builder);
			}
		}
		return response.build();
	}
}
