package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0118U00GrdOCS0118Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0118U00GrdOCS0118Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0118U00GrdOCS0118Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class OCS0118U00GrdOCS0118Handler extends ScreenHandler<OcsaServiceProto.OCS0118U00GrdOCS0118Request,OcsaServiceProto.OCS0118U00GrdOCS0118Response>  {                     
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override               
	@Transactional(readOnly = true)
	public OCS0118U00GrdOCS0118Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0118U00GrdOCS0118Request request) throws Exception {
  	   	OcsaServiceProto.OCS0118U00GrdOCS0118Response.Builder response = OcsaServiceProto.OCS0118U00GrdOCS0118Response.newBuilder();      
  	  List<OCS0118U00GrdOCS0118Info> list = ocs0103Repository.getOCS0118U00GrdOCS0118Info(getHospitalCode(vertx, sessionId), request.getHangmogNameInx());
  	  if(!CollectionUtils.isEmpty(list)){
  		  for(OCS0118U00GrdOCS0118Info item : list){
  			OcsaModelProto.OCS0118U00GrdOCS0118Info.Builder info = OcsaModelProto.OCS0118U00GrdOCS0118Info.newBuilder();
  			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
  			response.addGrdOCS0118Info(info);
  		  }
  	  }
	return response.build();
	}  

}
