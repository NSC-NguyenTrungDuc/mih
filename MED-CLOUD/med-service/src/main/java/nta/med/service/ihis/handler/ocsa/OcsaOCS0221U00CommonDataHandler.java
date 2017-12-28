package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0001;
import nta.med.core.glossary.Language;
import nta.med.core.glossary.UserGroup;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.dao.medi.ocs.Ocs0221Repository;
import nta.med.data.model.ihis.ocsa.OcsaOCS0221U00GrdOCS0221ListInfo;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0221U00CommonDataRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0221U00CommonDataResponse;

@Service
@Scope("prototype")
public class OcsaOCS0221U00CommonDataHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0221U00CommonDataRequest, OcsaServiceProto.OcsaOCS0221U00CommonDataResponse> { 
	@Resource
    private Ocs0132Repository ocs0132Repository;  
	@Resource
    private Ocs0221Repository ocs0221Repository;
	@Resource Bas0001Repository bas0001Repository;	
    
	@Override
	@Transactional(readOnly = true)
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OcsaOCS0221U00CommonDataRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			List<Bas0001> bas0001s = bas0001Repository.findLatestByHospCode(request.getHospCode());
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001s.size() > 0 ? bas0001s.get(0).getHospCode() : getHospitalCode(vertx, sessionId),
					bas0001s.size() > 0 ? bas0001s.get(0).getLanguage() : getLanguage(vertx, sessionId), "", 1));
		}
    }
	
    @Override
    @Transactional(readOnly = true)
    public OcsaOCS0221U00CommonDataResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OcsaOCS0221U00CommonDataRequest request) throws Exception {
        OcsaServiceProto.OcsaOCS0221U00CommonDataResponse.Builder response = OcsaServiceProto.OcsaOCS0221U00CommonDataResponse.newBuilder();
	   List<OcsaOCS0221U00GrdOCS0221ListInfo> listOcsaOCS0221U00GrdOCS0221ListInfo = ocs0132Repository.getOcsaOCS0221U00GrdOCS0221List(request.getHospCode(), getLanguage(vertx, sessionId), request.getMemb());
       if (listOcsaOCS0221U00GrdOCS0221ListInfo != null && !listOcsaOCS0221U00GrdOCS0221ListInfo.isEmpty()) {
           for (OcsaOCS0221U00GrdOCS0221ListInfo item : listOcsaOCS0221U00GrdOCS0221ListInfo) {
		       OcsaModelProto.OcsaOCS0221U00GrdOCS0221ListInfo.Builder info = OcsaModelProto.OcsaOCS0221U00GrdOCS0221ListInfo.newBuilder();
		       BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
		       response.addGridItem(info);
           }
       }
       return response.build();
   }
    
    @Override
	public OcsaOCS0221U00CommonDataResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			OcsaOCS0221U00CommonDataRequest request, OcsaOCS0221U00CommonDataResponse response) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId,
					SessionUserInfo.setSessionUserInfoByUserGroup(UserGroup.NTA.getValue(), Language.JAPANESE.toString().toUpperCase(), "", 0));
		}	
		return response;
	}
    
}
