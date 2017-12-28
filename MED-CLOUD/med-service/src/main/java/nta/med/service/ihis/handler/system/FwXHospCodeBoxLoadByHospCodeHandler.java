package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;
import nta.med.service.ihis.proto.SystemServiceProto.FwXHospCodeBoxLoadByHospCodeRequest;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class FwXHospCodeBoxLoadByHospCodeHandler extends ScreenHandler<SystemServiceProto.FwXHospCodeBoxLoadByHospCodeRequest, SystemServiceProto.ComboResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(FwXHospCodeBoxLoadByHospCodeHandler.class);                                    
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;                                                                     
	                                                                                                                
	@Override
	@Transactional
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, FwXHospCodeBoxLoadByHospCodeRequest request)
					throws Exception {
  	   	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                      
//				ComboListItemInfo item =  bas0001Repository.getHospital(request.getHospCode(), getLanguage());
//				if(item != null){
//					CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
//					BeanUtils.copyProperties(item, info);
//					response.addComboItem(info);
//				}
		return response.build();
	}                                                                                                                 
}