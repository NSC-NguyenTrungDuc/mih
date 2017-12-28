package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0102Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U11LaySlipCodeTreeListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U11LaySlipCodeTreeRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U11LaySlipCodeTreeResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U11LaySlipCodeTreeHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U11LaySlipCodeTreeRequest, OcsaServiceProto.OCS0103U11LaySlipCodeTreeResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U11LaySlipCodeTreeHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0102Repository ocs0102Repository;                                                                    
	                                                                                                                
	@Override              
	@Transactional(readOnly = true)
	public OCS0103U11LaySlipCodeTreeResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U11LaySlipCodeTreeRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103U11LaySlipCodeTreeResponse.Builder response = OcsaServiceProto.OCS0103U11LaySlipCodeTreeResponse.newBuilder();                      
		List<OCS0103U11LaySlipCodeTreeListItemInfo> listLaySlipCode=ocs0102Repository.getOCS0103U11LaySlipCodeTreeList(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listLaySlipCode)){
			for(OCS0103U11LaySlipCodeTreeListItemInfo item:listLaySlipCode){
				OcsaModelProto.OCS0103U11LaySlipCodeTreeListItemInfo.Builder info=OcsaModelProto.OCS0103U11LaySlipCodeTreeListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListInfo(info);
			}
		}
		return response.build();
	}

}