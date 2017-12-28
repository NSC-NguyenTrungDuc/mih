package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0108Repository;
import nta.med.data.model.ihis.ocsa.OCS0108U00grdOCS0108ItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0108U00grdOCS0108Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0108U00grdOCS0108Response;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0108U00grdOCS0108Handler extends ScreenHandler<OcsaServiceProto.OCS0108U00grdOCS0108Request, OcsaServiceProto.OCS0108U00grdOCS0108Response> {                             
	
	private static final Log LOGGER = LogFactory.getLog(OCS0108U00grdOCS0108Handler.class);                                        
	
	@Resource                                                                                                       
	private Ocs0108Repository ocs0108Repository; 
	
	@Override
	public boolean isValid(OCS0108U00grdOCS0108Request request, Vertx vertx,
			String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getHangmogStartDate()) && DateUtil.toDate(request.getHangmogStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0108U00grdOCS0108Request request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override          
	@Transactional(readOnly = true)
	public OCS0108U00grdOCS0108Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0108U00grdOCS0108Request request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0108U00grdOCS0108Response.Builder response = OcsaServiceProto.OCS0108U00grdOCS0108Response.newBuilder();                      
    	List<OCS0108U00grdOCS0108ItemInfo> listGrd = ocs0108Repository.getOCS0108U00grdOCS0108ItemInfo(request.getHospCode(),
    			DateUtil.toDate(request.getHangmogStartDate(), DateUtil.PATTERN_YYMMDD),request.getHangmogCode());
    	if(!CollectionUtils.isEmpty(listGrd)){
    		for(OCS0108U00grdOCS0108ItemInfo item: listGrd){
    			OcsaModelProto.OCS0108U00grdOCS0108ItemInfo.Builder info= OcsaModelProto.OCS0108U00grdOCS0108ItemInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addGrdOcs0108(info);
    		}	
    	}
    	return response.build();
    }
}