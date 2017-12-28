package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0804Repository;
import nta.med.data.model.ihis.ocsa.OCS0803U00grdOCS0804ItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0803U00grdOCS0804Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0803U00grdOCS0804Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0803U00grdOCS0804Handler
	extends ScreenHandler<OcsaServiceProto.OCS0803U00grdOCS0804Request, OcsaServiceProto.OCS0803U00grdOCS0804Response> {                     
	@Resource                                                                                                       
	private Ocs0804Repository ocs0804Repository;                                                                    
	                                                                                                                
	@Override              
	@Transactional(readOnly = true)
	public OCS0803U00grdOCS0804Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0803U00grdOCS0804Request request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0803U00grdOCS0804Response.Builder response = OcsaServiceProto.OCS0803U00grdOCS0804Response.newBuilder();                      
		List<OCS0803U00grdOCS0804ItemInfo> listGrd=ocs0804Repository.getOCS0803U00grdOCS0804(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),request.getPatStatusGr());
		if(!CollectionUtils.isEmpty(listGrd)){
			for(OCS0803U00grdOCS0804ItemInfo item:listGrd){
				OcsaModelProto.OCS0803U00grdOCS0804ItemInfo.Builder info =OcsaModelProto.OCS0803U00grdOCS0804ItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addItemInfo(info);
			}
		}
		return response.build();
	}
}