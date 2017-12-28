package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0101Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U15LaySlipCodeTreeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U15LaySlipCodeTreeRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U15LaySlipCodeTreeResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class OCS0103U15LaySlipCodeTreeHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U15LaySlipCodeTreeRequest, OcsaServiceProto.OCS0103U15LaySlipCodeTreeResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U15LaySlipCodeTreeHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0101Repository ocs0101Repository;                                                                    
	                                                                                                                
	@Override   
	@Transactional(readOnly = true)
	public OCS0103U15LaySlipCodeTreeResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U15LaySlipCodeTreeRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U15LaySlipCodeTreeResponse.Builder response = OcsaServiceProto.OCS0103U15LaySlipCodeTreeResponse.newBuilder();                      
		List<OCS0103U15LaySlipCodeTreeInfo> listGrd = ocs0101Repository.getOCS0103U15LaySlipCodeTreeInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listGrd)){
			for(OCS0103U15LaySlipCodeTreeInfo item : listGrd){
				OcsaModelProto.OCS0103U15LaySlipCodeTreeInfo.Builder info = OcsaModelProto.OCS0103U15LaySlipCodeTreeInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListItem(info);
			}
		}
		
		return response.build();
	}

}
