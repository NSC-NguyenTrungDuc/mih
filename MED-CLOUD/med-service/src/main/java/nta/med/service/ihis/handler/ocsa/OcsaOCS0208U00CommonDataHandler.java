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
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.dao.medi.ocs.Ocs0208Repository;
import nta.med.data.model.ihis.ocsa.OcsaOCS0208U00GrdOCS0208U00ListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0208U00CommonDataRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0208U00CommonDataResponse;

@Service
@Scope("prototype")
public class OcsaOCS0208U00CommonDataHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0208U00CommonDataRequest, OcsaServiceProto.OcsaOCS0208U00CommonDataResponse> {
    
	@Resource
    private Ocs0208Repository ocs0208Repository;
    
	@Resource
    private Drg0120Repository drg0120Repository;
    
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OcsaOCS0208U00CommonDataRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
    @Transactional(readOnly = true)
	public OcsaOCS0208U00CommonDataResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OcsaOCS0208U00CommonDataRequest request) throws Exception {
            OcsaServiceProto.OcsaOCS0208U00CommonDataResponse.Builder response = OcsaServiceProto.OcsaOCS0208U00CommonDataResponse.newBuilder();
        	List<OcsaOCS0208U00GrdOCS0208U00ListInfo> listOcsaOCS0208U00GrdOCS0208U00ListInfo = ocs0208Repository.getOcsaOCS0208U00GrdOCS0208U00List(request.getHospCode(), request.getDoctor(), request.getBunryu1(), getLanguage(vertx, sessionId));
             if (!CollectionUtils.isEmpty(listOcsaOCS0208U00GrdOCS0208U00ListInfo)) {
                 for (OcsaOCS0208U00GrdOCS0208U00ListInfo item : listOcsaOCS0208U00GrdOCS0208U00ListInfo) {
                 	OcsaModelProto.OcsaOCS0208U00GrdOCS0208U00ListInfo.Builder info = OcsaModelProto.OcsaOCS0208U00GrdOCS0208U00ListInfo.newBuilder();
                 	if (!StringUtils.isEmpty(item.getDoctor())) {
                 		info.setDoctor(item.getDoctor());
                 	}
                 	if (item.getSeq() != null) {
                 		info.setSeq(String.format("%.0f",item.getSeq()));
                 	}
                 	if (!StringUtils.isEmpty(item.getBogyongCode())) {
                 		info.setBogyongCode(item.getBogyongCode());
                 	}
                 	if (!StringUtils.isEmpty(item.getBogyongName())) {
                 		info.setBogyongName(item.getBogyongName());
                 	}
                 	if (!StringUtils.isEmpty(item.getBunryu1())) {
                 		info.setBunryu1(item.getBunryu1());
                 	}
                     response.addListItem(info);
                 }
             }
         return response.build();
	}
}
