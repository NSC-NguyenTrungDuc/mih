package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301U00SeqRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301U00SeqResponse;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class OCS0301U00SeqHandler
	extends ScreenHandler<OcsaServiceProto.OCS0301U00SeqRequest, OcsaServiceProto.OCS0301U00SeqResponse> {                     
	
	@Resource                                                                                                       
	private CommonRepository commonRepository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0301U00SeqRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override                                                                                                       
	public OCS0301U00SeqResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0301U00SeqRequest request)
			throws Exception {                                                                
  	   	OcsaServiceProto.OCS0301U00SeqResponse.Builder response = OcsaServiceProto.OCS0301U00SeqResponse.newBuilder();                      
		String seq = commonRepository.getNextVal("OCS0301_SEQ");
		if(!StringUtils.isEmpty(seq)) {
			response.setSeq(seq);
		}
		return response.build();
	}
}