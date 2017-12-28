package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0101Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U17LayHangwiGubunInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U17LayHangwiGubunRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U17LayHangwiGubunResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U17LayHangwiGubunHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U17LayHangwiGubunRequest, OcsaServiceProto.OCS0103U17LayHangwiGubunResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U17LayHangwiGubunHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0101Repository ocs0101Repository;                                                                    
	                                                                                                                
	@Override               
	@Transactional(readOnly = true)
	public OCS0103U17LayHangwiGubunResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U17LayHangwiGubunRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U17LayHangwiGubunResponse.Builder response = OcsaServiceProto.OCS0103U17LayHangwiGubunResponse.newBuilder();                      
		List<OCS0103U17LayHangwiGubunInfo> list = ocs0101Repository.getOCS0103U17LayHangwiGubunListItem(getHospitalCode(vertx, sessionId), request.getUserId(),"M","08", getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list)){
			for(OCS0103U17LayHangwiGubunInfo item : list){
				OcsaModelProto.OCS0103U17LayHangwiGubunInfo.Builder info = OcsaModelProto.OCS0103U17LayHangwiGubunInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayResult(info);
			}
		}
		return response.build();
	}

}