package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetBogyongInfo3Request;
import nta.med.service.ihis.proto.SystemServiceProto.GetBogyongInfo3Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class GetBogyongInfo3Handler
	extends ScreenHandler<SystemServiceProto.GetBogyongInfo3Request, SystemServiceProto.GetBogyongInfo3Response> {                     
	@Resource                                                                                                       
	private Drg0120Repository drg0120Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public GetBogyongInfo3Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId, GetBogyongInfo3Request request)
			throws Exception {                                                                  
  	   	SystemServiceProto.GetBogyongInfo3Response.Builder response = SystemServiceProto.GetBogyongInfo3Response.newBuilder();                      
		List<ComboListItemInfo> listResult = drg0120Repository.getOcsLibBogyongInfo3(request.getBogyongCode(), getHospitalCode(vertx, sessionId), request.getBogyongGubun(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listResult)){
			for(ComboListItemInfo item : listResult){
				response.setBogyongName(item.getCode());
				response.setNvl(item.getCodeName());
			}
		}
		return response.build();
	}
}