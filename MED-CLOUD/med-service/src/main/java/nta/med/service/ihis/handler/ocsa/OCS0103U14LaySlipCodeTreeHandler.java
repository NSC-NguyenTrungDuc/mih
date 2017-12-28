package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0300Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U14LaySlipCodeTreeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U14LaySlipCodeTreeRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U14LaySlipCodeTreeResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U14LaySlipCodeTreeHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U14LaySlipCodeTreeRequest, OcsaServiceProto.OCS0103U14LaySlipCodeTreeResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U14LaySlipCodeTreeHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0300Repository ocs0300Repository;                                                                    
	                                                                                                                
	@Override      
	@Transactional(readOnly = true)
	public OCS0103U14LaySlipCodeTreeResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U14LaySlipCodeTreeRequest request) throws Exception {
                                                                  
  	   	OcsaServiceProto.OCS0103U14LaySlipCodeTreeResponse.Builder response = OcsaServiceProto.OCS0103U14LaySlipCodeTreeResponse.newBuilder();                      
		List<OCS0103U14LaySlipCodeTreeInfo> listLaySlipCode=ocs0300Repository.getOCS0103U14LaySlipCodeTreeInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getUser());
		if(!CollectionUtils.isEmpty(listLaySlipCode)){
			for(OCS0103U14LaySlipCodeTreeInfo item: listLaySlipCode){
				OcsaModelProto.OCS0103U14LaySlipCodeTreeInfo.Builder info= OcsaModelProto.OCS0103U14LaySlipCodeTreeInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addSlipCodeTreeItem(info);
			}
		}
		return response.build();
	}

}