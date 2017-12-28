package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.clis.ClisProtocolRepository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00GetProtocolRequest;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;


@Service
@Scope("prototype")
public class OCS0103U00GetProtocolHandler extends ScreenHandler<OCS0103U00GetProtocolRequest, ComboResponse>{

	@Resource	
	private ClisProtocolRepository clisProtocolRepository;
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0103U00GetProtocolRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OCS0103U00GetProtocolRequest request)
			throws Exception {
		ComboResponse.Builder response = ComboResponse.newBuilder();
		List<ComboListItemInfo> list = clisProtocolRepository.getOCS0103U00GetProtocolInfo(request.getHospCode(), request.getFind1());
		if(!CollectionUtils.isEmpty(list)){
			for(ComboListItemInfo item : list){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder(); 
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}
		return response.build();
	}

}
