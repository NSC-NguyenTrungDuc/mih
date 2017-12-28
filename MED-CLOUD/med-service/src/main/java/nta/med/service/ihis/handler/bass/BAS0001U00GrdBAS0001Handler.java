package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.bass.BAS0001U00GrdBAS0001Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0001U00GrdBAS0001Request;
import nta.med.service.ihis.proto.BassServiceProto.BAS0001U00GrdBAS0001Response;

@Service                                                                                                          
@Scope("prototype")     
public class BAS0001U00GrdBAS0001Handler extends ScreenHandler<BassServiceProto.BAS0001U00GrdBAS0001Request, BassServiceProto.BAS0001U00GrdBAS0001Response> {                             
	private static final Log LOGGER = LogFactory.getLog(BAS0001U00GrdBAS0001Handler.class);   
	
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, BAS0001U00GrdBAS0001Request request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override       
	@Transactional(readOnly = true)
	public BAS0001U00GrdBAS0001Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0001U00GrdBAS0001Request request) throws Exception {                                                                   
  	   	BassServiceProto.BAS0001U00GrdBAS0001Response.Builder response = BassServiceProto.BAS0001U00GrdBAS0001Response.newBuilder();
		List<BAS0001U00GrdBAS0001Info> listItem = bas0001Repository.getBAS0001U00GrdBAS0001Info(request.getHospCode(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listItem)){
			for(BAS0001U00GrdBAS0001Info item : listItem){
				BassModelProto.BAS0001U00GrdBAS0001Info.Builder info = BassModelProto.BAS0001U00GrdBAS0001Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addItemInfo(info);
			}
		}
	    return response.build();
	}                                                                                                                                                   

}																																						
