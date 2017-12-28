package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0133Repository;
import nta.med.data.model.ihis.ocsa.OCS0133U00grdOCS0133ItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0133U00grdOCS0133ItemRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0133U00grdOCS0133ItemResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0133U00grdOCS0133ItemHandler
	extends ScreenHandler<OcsaServiceProto.OCS0133U00grdOCS0133ItemRequest, OcsaServiceProto.OCS0133U00grdOCS0133ItemResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0133U00grdOCS0133ItemHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0133Repository ocs0133Repository;                                                                    
	                                                                                                                
	@Override      
	@Transactional(readOnly = true)
	public OCS0133U00grdOCS0133ItemResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0133U00grdOCS0133ItemRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0133U00grdOCS0133ItemResponse.Builder response = OcsaServiceProto.OCS0133U00grdOCS0133ItemResponse.newBuilder();                      
		List<OCS0133U00grdOCS0133ItemInfo> listGrdOcs0133 = ocs0133Repository.getOCS0133U00grdOCS0133ItemInfo(getHospitalCode(vertx, sessionId),request.getInputControl().trim(),request.getUserInfo(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listGrdOcs0133)){
			for(OCS0133U00grdOCS0133ItemInfo item:listGrdOcs0133){
				OcsaModelProto.OCS0133U00grdOCS0133ItemInfo.Builder info = OcsaModelProto.OCS0133U00grdOCS0133ItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdOcs0133(info);
			}
		}
		return response.build();
	}

}