package nta.med.service.ihis.handler.adma;

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
import nta.med.data.dao.medi.clis.ClisSmoRepository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaServiceProto.ADM104UClisComboRequest;
import nta.med.service.ihis.proto.AdmaServiceProto.ADM104UClisComboResponse;
import nta.med.service.ihis.proto.CommonModelProto;

@Service
@Scope("prototype")
public class ADM104UClisComboHandler extends ScreenHandler<ADM104UClisComboRequest, ADM104UClisComboResponse>{
	
	@Resource
	private ClisSmoRepository clisSmoRepository;
	
	@Override
    @Transactional
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, ADM104UClisComboRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	@Transactional(readOnly = true)
	public ADM104UClisComboResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, ADM104UClisComboRequest request)
			throws Exception {
		ADM104UClisComboResponse.Builder response = ADM104UClisComboResponse.newBuilder();
		List<ComboListItemInfo> list = clisSmoRepository.getADM104UClisComboInfo(request.getHospCode());
		if(!CollectionUtils.isEmpty(list)){
			for(ComboListItemInfo item : list){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder(); 
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDt(info);
			}
		}
		return response.build();
	}
}
