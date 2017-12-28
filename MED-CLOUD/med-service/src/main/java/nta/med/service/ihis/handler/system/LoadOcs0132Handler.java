package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.system.LoadOcs0132Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.LoadOcs0132Request;
import nta.med.service.ihis.proto.SystemServiceProto.LoadOcs0132Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class LoadOcs0132Handler 
	extends ScreenHandler<SystemServiceProto.LoadOcs0132Request, SystemServiceProto.LoadOcs0132Response> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                  
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public LoadOcs0132Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId, LoadOcs0132Request request)
			throws Exception {                                                                  
      	   	SystemServiceProto.LoadOcs0132Response.Builder response = SystemServiceProto.LoadOcs0132Response.newBuilder();                      
		List<LoadOcs0132Info> listItem= ocs0132Repository.getLoadOcs0132Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeType(), request.getCode());
		if(!CollectionUtils.isEmpty(listItem)){
			for(LoadOcs0132Info item : listItem){
				SystemModelProto.LoadOcs0132Info.Builder info =SystemModelProto.LoadOcs0132Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLoadOcs0132Info(info);
			}
		}
		return response.build();
	}
}
