package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0208Repository;
import nta.med.data.model.ihis.ocsa.OCS0208Q01GrdOCS0208Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0208Q01GrdOCS0208Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0208Q01GrdOCS0208Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0208Q01GrdOCS0208Handler
	extends ScreenHandler<OcsaServiceProto.OCS0208Q01GrdOCS0208Request, OcsaServiceProto.OCS0208Q01GrdOCS0208Response> {                     
	@Resource                                                                                                       
	private Ocs0208Repository ocs0208Repository;                                                                    
	                                                                                                                
	@Override  
	@Transactional(readOnly = true)
	public OCS0208Q01GrdOCS0208Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0208Q01GrdOCS0208Request request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0208Q01GrdOCS0208Response.Builder response = OcsaServiceProto.OCS0208Q01GrdOCS0208Response.newBuilder();                      
		List<OCS0208Q01GrdOCS0208Info> listGrd=ocs0208Repository.getOCS0208Q01GrdOCS0208Info(getHospitalCode(vertx, sessionId),request.getDoctor(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listGrd)){
			for(OCS0208Q01GrdOCS0208Info item : listGrd){
				OcsaModelProto.OCS0208Q01GrdOCS0208Info.Builder info = OcsaModelProto.OCS0208Q01GrdOCS0208Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdOCS0208Info(info);
			}
		}
		return response.build();
	}

}