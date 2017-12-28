package nta.med.service.orca.handler;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.oif.Oif4001Repository;
import nta.med.data.model.ihis.orca.ORCALibGetClaimOrderInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.orca.proto.OrcaModelProto;
import nta.med.service.orca.proto.OrcaServiceProto;
import nta.med.service.orca.proto.OrcaServiceProto.ORCALibGetClaimOrderRequest;
import nta.med.service.orca.proto.OrcaServiceProto.ORCALibGetClaimOrderResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ORCALibGetClaimOrderHandler extends ScreenHandler<OrcaServiceProto.ORCALibGetClaimOrderRequest, OrcaServiceProto.ORCALibGetClaimOrderResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(ORCALibGetClaimOrderHandler.class);                                    
	@Resource                                                                                                       
	private Oif4001Repository oif4001Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public ORCALibGetClaimOrderResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			ORCALibGetClaimOrderRequest request) throws Exception {
		OrcaServiceProto.ORCALibGetClaimOrderResponse.Builder response = OrcaServiceProto.ORCALibGetClaimOrderResponse.newBuilder();
		List<ORCALibGetClaimOrderInfo > listClaim = oif4001Repository.getORCALibGetClaimOrderInfo(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getFkoif1101()));
		if(!CollectionUtils.isEmpty(listClaim)){
			for(ORCALibGetClaimOrderInfo  item : listClaim){
				OrcaModelProto.ORCALibGetClaimOrderInfo .Builder info = OrcaModelProto.ORCALibGetClaimOrderInfo .newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addClaimOrderItem(info);
    		}
		}
		return response.build();
	}                                                                                                                 
}