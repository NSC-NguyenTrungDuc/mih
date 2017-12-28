package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.model.ihis.system.CFFormUnevenPrescribeLayDRG0120Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CFFormUnevenPrescribeLayDRG0120Handler extends ScreenHandler<SystemServiceProto.CFFormUnevenPrescribeLayDRG0120Request, SystemServiceProto.CFFormUnevenPrescribeLayDRG0120Response>{                  
	private static final Log LOGGER = LogFactory.getLog(CFFormUnevenPrescribeLayDRG0120Handler.class);                                    
	@Resource                                                                                                       
	private Drg0120Repository drg0120Repository; 
	
	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.CFFormUnevenPrescribeLayDRG0120Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SystemServiceProto.CFFormUnevenPrescribeLayDRG0120Request request) throws Exception {
		SystemServiceProto.CFFormUnevenPrescribeLayDRG0120Response.Builder response = SystemServiceProto.CFFormUnevenPrescribeLayDRG0120Response.newBuilder();
		 List<CFFormUnevenPrescribeLayDRG0120Info> listResult = drg0120Repository.getCFFormUnevenPrescribeLayDRG0120(getHospitalCode(vertx, sessionId), request.getBogyongCode(), getLanguage(vertx, sessionId));
		 if(!CollectionUtils.isEmpty(listResult)){
				for(CFFormUnevenPrescribeLayDRG0120Info info : listResult){
					SystemModelProto.CFFormUnevenPrescribeLayDRG0120Info.Builder builder = SystemModelProto.CFFormUnevenPrescribeLayDRG0120Info.newBuilder();
					BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
					response.addLayDrgItem(builder);
				}
			}
			return response.build();
	}                                                                                                                 
}