package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.ocsa.OCS0103Q00CreateOrderGubunInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103Q00CreateOrderGubunRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103Q00CreateOrderGubunResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class OCS0103Q00CreateOrderGubunHandler extends ScreenHandler<OcsaServiceProto.OCS0103Q00CreateOrderGubunRequest, OcsaServiceProto.OCS0103Q00CreateOrderGubunResponse                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    > {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103Q00CreateOrderGubunHandler.class);        
	
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override           
	@Transactional(readOnly = true)
	public OCS0103Q00CreateOrderGubunResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103Q00CreateOrderGubunRequest request) throws Exception {                                                                
  	   	OcsaServiceProto.OCS0103Q00CreateOrderGubunResponse.Builder response = OcsaServiceProto.OCS0103Q00CreateOrderGubunResponse.newBuilder();                      
		List<OCS0103Q00CreateOrderGubunInfo> listItem = ocs0132Repository.getOCS0103Q00CreateOrderGubun(getHospitalCode(vertx, sessionId), request.getInputTab());
		if(!CollectionUtils.isEmpty(listItem)){
    		for(OCS0103Q00CreateOrderGubunInfo item :listItem){
    			OcsaModelProto.OCS0103Q00CreateOrderGubunInfo.Builder info =OcsaModelProto.OCS0103Q00CreateOrderGubunInfo.newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addOrderGubunInfo(info);
    		}
    	}
		return response.build();
	}

}
