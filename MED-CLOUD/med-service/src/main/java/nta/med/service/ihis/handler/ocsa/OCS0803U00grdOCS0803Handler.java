package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0803Repository;
import nta.med.data.model.ihis.ocsa.OCS0803U00grdOCS0803ItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0803U00grdOCS0803Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0803U00grdOCS0803Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0803U00grdOCS0803Handler
	extends ScreenHandler<OcsaServiceProto.OCS0803U00grdOCS0803Request, OcsaServiceProto.OCS0803U00grdOCS0803Response> {                     
	@Resource                                                                                                       
	private Ocs0803Repository ocs0803Repository;                                                                    
	                                                                                                                
	@Override         
	@Transactional(readOnly = true)
	public OCS0803U00grdOCS0803Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0803U00grdOCS0803Request request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0803U00grdOCS0803Response.Builder response = OcsaServiceProto.OCS0803U00grdOCS0803Response.newBuilder();                      
		List<OCS0803U00grdOCS0803ItemInfo> listGrd=ocs0803Repository.getOCS0803U00grdOCS0803(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listGrd)){
			for(OCS0803U00grdOCS0803ItemInfo item:listGrd){
				OcsaModelProto.OCS0803U00grdOCS0803ItemInfo.Builder info =OcsaModelProto.OCS0803U00grdOCS0803ItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addItemInfo(info);
			}
		}
		return response.build();
	}
}