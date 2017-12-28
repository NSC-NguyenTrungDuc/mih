package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0131Repository;
import nta.med.data.model.ihis.system.LoadOcs0131Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.LoadOcs0131Request;
import nta.med.service.ihis.proto.SystemServiceProto.LoadOcs0131Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class LoadOcs0131Handler 
	extends ScreenHandler<SystemServiceProto.LoadOcs0131Request, SystemServiceProto.LoadOcs0131Response> {                     
	@Resource                                                                                                       
	private Ocs0131Repository ocs0131Repository;                                                                  
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public LoadOcs0131Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId, LoadOcs0131Request request)
			throws Exception {                                                                
      	   	SystemServiceProto.LoadOcs0131Response.Builder response = SystemServiceProto.LoadOcs0131Response.newBuilder();                      
		List<LoadOcs0131Info> listItem= ocs0131Repository.getLoadOcs0131Info(request.getCodeType(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listItem)){
			for(LoadOcs0131Info item : listItem){
				SystemModelProto.LoadOcs0131Info.Builder info =SystemModelProto.LoadOcs0131Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addOcs0131Info(info);
			}
		}
		return response.build();
	}
}
