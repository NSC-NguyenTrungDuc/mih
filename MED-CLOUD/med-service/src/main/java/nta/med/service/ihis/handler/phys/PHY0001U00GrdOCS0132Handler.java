package nta.med.service.ihis.handler.phys;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.phys.PHY0001U00GrdOCS0132Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY0001U00GrdOCS0132Request;
import nta.med.service.ihis.proto.PhysServiceProto.PHY0001U00GrdOCS0132Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype") 
public class PHY0001U00GrdOCS0132Handler
	extends ScreenHandler<PhysServiceProto.PHY0001U00GrdOCS0132Request, PhysServiceProto.PHY0001U00GrdOCS0132Response> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override  
	@Transactional(readOnly=true)
	public PHY0001U00GrdOCS0132Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY0001U00GrdOCS0132Request request) throws Exception {                                                                   
                 
  	   	PhysServiceProto.PHY0001U00GrdOCS0132Response.Builder response = PhysServiceProto.PHY0001U00GrdOCS0132Response.newBuilder();                      
		List<PHY0001U00GrdOCS0132Info> listGrd = ocs0132Repository.getPHY0001U00GrdOCS0132Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeType());
		if(!CollectionUtils.isEmpty(listGrd)){
			for(PHY0001U00GrdOCS0132Info item : listGrd){
				PhysModelProto.PHY0001U00GrdOCS0132Info.Builder info= PhysModelProto.PHY0001U00GrdOCS0132Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
		        response.addGrdInfo(info);
			}
		}
		return response.build();
	}
}
