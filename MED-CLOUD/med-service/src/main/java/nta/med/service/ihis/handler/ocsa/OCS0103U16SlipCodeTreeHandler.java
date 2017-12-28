package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0102Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U16SlipCodeTreeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U16SlipCodeTreeRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U16SlipCodeTreeResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U16SlipCodeTreeHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U16SlipCodeTreeRequest, OcsaServiceProto.OCS0103U16SlipCodeTreeResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U16SlipCodeTreeHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0102Repository ocs0102Repository;                                                                    
	                                                                                                                
	@Override      
	@Transactional(readOnly = true)
	public OCS0103U16SlipCodeTreeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U16SlipCodeTreeRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103U16SlipCodeTreeResponse.Builder response = OcsaServiceProto.OCS0103U16SlipCodeTreeResponse.newBuilder();                      
		List<OCS0103U16SlipCodeTreeInfo> listSlipCode= ocs0102Repository.getOCS0103U16SlipCodeTree(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listSlipCode)){
			for(OCS0103U16SlipCodeTreeInfo item:listSlipCode){
				OcsaModelProto.OCS0103U16SlipCodeTreeInfo.Builder info= OcsaModelProto.OCS0103U16SlipCodeTreeInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addSlipCodeTreeItem(info);
			}
		}
		return response.build();
	}

}