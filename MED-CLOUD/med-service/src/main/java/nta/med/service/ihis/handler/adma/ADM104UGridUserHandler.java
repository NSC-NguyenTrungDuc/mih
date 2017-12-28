package nta.med.service.ihis.handler.adma;

import java.math.BigDecimal;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.TrialFlg;
import nta.med.core.glossary.YesNo;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.adma.ADM104UGridUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;

@Service
@Scope("prototype")
public class ADM104UGridUserHandler extends ScreenHandler<AdmaServiceProto.ADM104UGridUserRequest, AdmaServiceProto.ADM104UGridUserResponse> {
    
	private static final Log LOGGER = LogFactory.getLog(ADM104UGridUserHandler.class);
    
	@Resource
    private Adm3200Repository adm3200Repository;

	@Override
    @Transactional
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM104UGridUserRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
    @Override
    @Transactional(readOnly = true)
    public AdmaServiceProto.ADM104UGridUserResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM104UGridUserRequest request) throws Exception {
        AdmaServiceProto.ADM104UGridUserResponse.Builder response = AdmaServiceProto.ADM104UGridUserResponse.newBuilder();
        List<ADM104UGridUserInfo> listItem = adm3200Repository.getADM104UGridUserInfo(request.getHospCode(), getLanguage(vertx, sessionId), request.getUserGroup(), request.getSearchWord(), request.getUserGubun());
        if (!CollectionUtils.isEmpty(listItem)) {
            for (ADM104UGridUserInfo item : listItem) {
                AdmaModelProto.ADM104UGridUserInfo.Builder builder = AdmaModelProto.ADM104UGridUserInfo.newBuilder();
                BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
                if("1".equals(builder.getLoginFlg())){
                	builder.setLoginFlg(TrialFlg.YES.getValue());
                }else{
                	builder.setLoginFlg(TrialFlg.NO.getValue());
                }
                if(BigDecimal.ONE.equals(item.getChangePwdFlg())){
                	builder.setChangePwdFlg(YesNo.YES.getValue());
            	}else if(BigDecimal.ZERO.equals(item.getChangePwdFlg())){
            		builder.setChangePwdFlg(YesNo.NO.getValue());
            	}
                response.addGridUserInfo(builder);
            }
        }
        return response.build();
    }
}
