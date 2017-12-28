package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UserNameListRequest;
import nta.med.service.ihis.proto.SystemServiceProto.UserNameListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class UserNameListHandler extends ScreenHandler <SystemServiceProto.UserNameListRequest, SystemServiceProto.UserNameListResponse>{
	@Resource
    private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional(readOnly = true)
	public UserNameListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, UserNameListRequest request)
			throws Exception{
	    List<String> listItems = adm3200Repository.getUserNameByUserId(getHospitalCode(vertx, sessionId), request.getUserId());
	    SystemServiceProto.UserNameListResponse.Builder response = SystemServiceProto.UserNameListResponse.newBuilder();
	    if (listItems != null && !listItems.isEmpty()) {
	        for (String obj : listItems) {
	            if(!StringUtils.isEmpty(obj)) {
	            	response.addUserNm(obj);
	            }
	        }
	    }
	    return response.build();
	}
}
