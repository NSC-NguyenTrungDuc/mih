package nta.med.service.ihis.handler.adma;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm4100Repository;
import nta.med.data.model.ihis.adma.ADM107ULayDownListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;

@Service
@Scope("prototype")
public class Adm107ULayDownListHandler extends ScreenHandler<AdmaServiceProto.Adm107ULayDownListRequest, AdmaServiceProto.Adm107ULayDownListResponse> {
    
	private static final Log LOGGER = LogFactory.getLog(Adm107ULayDownListHandler.class);
    
    @Resource
    private Adm4100Repository adm4100Repository;

    @Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.Adm107ULayDownListRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
    
    @Override
    @Transactional(readOnly = true)
    public AdmaServiceProto.Adm107ULayDownListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.Adm107ULayDownListRequest request) throws Exception {
        AdmaServiceProto.Adm107ULayDownListResponse.Builder response = AdmaServiceProto.Adm107ULayDownListResponse.newBuilder();
        List<ADM107ULayDownListInfo> listLayDown = adm4100Repository.getAdm107uLayDownListInfo(request.getHospCode(), getLanguage(vertx, sessionId), request.getUserId(), request.getSysId(), request.getUpprMenu());
        if (!CollectionUtils.isEmpty(listLayDown)) {
            for (ADM107ULayDownListInfo item : listLayDown) {
                AdmaModelProto.Adm107ULayDownListInfo.Builder info = AdmaModelProto.Adm107ULayDownListInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                if (item.getTrSeq() != null) {
                    info.setTrSeq(String.format("%.0f", item.getTrSeq()));
                }
                response.addLayDownListItem(info);
            }
        }
        return response.build();
    }
}