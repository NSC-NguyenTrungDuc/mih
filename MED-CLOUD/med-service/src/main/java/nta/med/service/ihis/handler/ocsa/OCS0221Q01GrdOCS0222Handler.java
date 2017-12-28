package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0222Repository;
import nta.med.data.model.ihis.ocsa.OCS0221Q01GrdOCS0222Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0221Q01GrdOCS0222Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0221Q01GrdOCS0222Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0221Q01GrdOCS0222Handler
	extends ScreenHandler<OcsaServiceProto.OCS0221Q01GrdOCS0222Request, OcsaServiceProto.OCS0221Q01GrdOCS0222Response> {                     
	@Resource                                                                                                       
	private Ocs0222Repository ocs0222Repository;                                                                    
	                                                                                                                
	@Override        
	@Transactional(readOnly = true)
	public OCS0221Q01GrdOCS0222Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0221Q01GrdOCS0222Request request) throws Exception {                                                                
  	   	OcsaServiceProto.OCS0221Q01GrdOCS0222Response.Builder response = OcsaServiceProto.OCS0221Q01GrdOCS0222Response.newBuilder();                      
		List<OCS0221Q01GrdOCS0222Info> list = ocs0222Repository.getOCS0221Q01GrdOCS0222Info(getHospitalCode(vertx, sessionId), request.getMemb(), request.getSeq());
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS0221Q01GrdOCS0222Info item:list) {
				OcsaModelProto.OCS0221Q01GrdOCS0222Info.Builder info = OcsaModelProto.OCS0221Q01GrdOCS0222Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdOCS0222Info(info);
			}
		}
		return response.build();
	}

}