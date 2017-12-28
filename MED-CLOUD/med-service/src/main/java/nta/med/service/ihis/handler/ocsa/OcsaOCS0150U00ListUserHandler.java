package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.ocsa.OcsaOCS0204U00MembListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0150U00ListUserRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0150U00ListUserResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsaOCS0150U00ListUserHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0150U00ListUserRequest, OcsaServiceProto.OcsaOCS0150U00ListUserResponse> {
	
    @Resource
    private Adm3200Repository adm3200Repository;
    
    @Override
    @Transactional(readOnly = true)
    public OcsaOCS0150U00ListUserResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
		OcsaOCS0150U00ListUserRequest request) throws Exception {
        List<OcsaOCS0204U00MembListInfo> listItem = adm3200Repository.getOcsaOCS0204U00MembListOcsaOCS0204U00FindWorkerList(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getFFind1(), true);
        OcsaServiceProto.OcsaOCS0150U00ListUserResponse.Builder response = OcsaServiceProto.OcsaOCS0150U00ListUserResponse.newBuilder();
        if (listItem != null && !listItem.isEmpty()) {
        	for (OcsaOCS0204U00MembListInfo item : listItem) {
            	OcsaModelProto.OcsaOCS0150U00ListUserInfo.Builder info = OcsaModelProto.OcsaOCS0150U00ListUserInfo.newBuilder();
            	if (!StringUtils.isEmpty(item.getUserId())) {
            		info.setUserId(item.getUserId());
            	}
            	if (!StringUtils.isEmpty(item.getUserNm())) {
            		info.setUserNm(item.getUserNm());
            	}
                response.addUserListItem(info);
            }
        }
        return response.build();
    }
}
