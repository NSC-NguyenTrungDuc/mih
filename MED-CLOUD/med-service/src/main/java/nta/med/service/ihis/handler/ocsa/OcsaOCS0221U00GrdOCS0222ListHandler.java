package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.data.dao.medi.ocs.Ocs0222Repository;
import nta.med.data.model.ihis.ocsa.OcsaOCS0221U00GrdOCS0222ListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0221U00GrdOCS0222ListRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0221U00GrdOCS0222ListResponse;

@Service
@Scope("prototype")
public class OcsaOCS0221U00GrdOCS0222ListHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0221U00GrdOCS0222ListRequest, OcsaServiceProto.OcsaOCS0221U00GrdOCS0222ListResponse> {
	
    @Resource
    private Ocs0222Repository ocs0222Repository;
    
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OcsaOCS0221U00GrdOCS0222ListRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
    
    @Override
    @Transactional(readOnly = true)
    public OcsaOCS0221U00GrdOCS0222ListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OcsaOCS0221U00GrdOCS0222ListRequest request) throws Exception {
    	OcsaServiceProto.OcsaOCS0221U00GrdOCS0222ListResponse.Builder response = OcsaServiceProto.OcsaOCS0221U00GrdOCS0222ListResponse.newBuilder();
        List<OcsaOCS0221U00GrdOCS0222ListInfo> listItem = ocs0222Repository.getOcsaOCS0221U00GrdOCS0222List(request.getHospCode(), request.getMemb(), request.getSeq());
    	if (!CollectionUtils.isEmpty(listItem)) {
            for (OcsaOCS0221U00GrdOCS0222ListInfo item : listItem) {
            	OcsaModelProto.OcsaOCS0221U00GrdOCS0222ListInfo.Builder info = OcsaModelProto.OcsaOCS0221U00GrdOCS0222ListInfo.newBuilder();
            	if (!StringUtils.isEmpty(item.getMemb())) {
            		info.setMemb(item.getMemb());
            	}
            	if (item.getSeq() != null) {
            		info.setSeq(String.format("%.0f",item.getSeq()));
            	}
            	if (item.getSerial() != null) {
            		info.setSerial(String.format("%.0f",item.getSerial()));
            	}

            	if (!StringUtils.isEmpty(item.getCommentTitle())) {
            		info.setCommentTitle(item.getCommentTitle());
            	}
            	if (!StringUtils.isEmpty(item.getCommentText())) {
            		info.setCommentText(item.getCommentText());
            	}
                response.addGridItem(info);
            }
        }
    	return response.build();
	}
}
