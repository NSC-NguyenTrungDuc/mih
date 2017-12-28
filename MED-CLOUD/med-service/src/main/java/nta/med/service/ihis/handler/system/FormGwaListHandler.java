package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.system.FormGwaItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.FormGwaListRequest;
import nta.med.service.ihis.proto.SystemServiceProto.FormGwaListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class FormGwaListHandler
	extends ScreenHandler<SystemServiceProto.FormGwaListRequest, SystemServiceProto.FormGwaListResponse> {
	@Resource
	private Bas0260Repository bas0260Repository;
	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional(readOnly = true)
	public FormGwaListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, FormGwaListRequest request)
			throws Exception {
        SystemServiceProto.FormGwaListResponse.Builder response = SystemServiceProto.FormGwaListResponse.newBuilder();
        //TODO remove when change to new way to get session
//        List<String> listHosp = adm3200Repository.getHospCodeFwUserInfoChangePsw(request.getUserId());
//        String hospCode = null;
//        if(!CollectionUtils.isEmpty(listHosp)){
//        	hospCode = listHosp.get(0);
//        }
        
        String hospCode = getHospitalCode(vertx, sessionId);
        
    	List<FormGwaItemInfo> listCombo = bas0260Repository.getFormGwaItemInfo(hospCode, getLanguage(vertx, sessionId), request.getUserId(), true);
    	if(!CollectionUtils.isEmpty(listCombo)){
    		for(FormGwaItemInfo item : listCombo){
    			SystemModelProto.FormGwaItemInfo.Builder builder = SystemModelProto.FormGwaItemInfo.newBuilder();
    			BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
    			response.addItemInfo(builder);
    		}
    	}
    	return response.build(); 
	}
}
