package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U13PrOcsApplyNdayOrderRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U13PrOcsApplyNdayOrderResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U13PrOcsApplyNdayOrderHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U13PrOcsApplyNdayOrderRequest, OcsaServiceProto.OCS0103U13PrOcsApplyNdayOrderResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0103U13PrOcsApplyNdayOrderHandler.class);                                        
	@Resource                                                                                                       
	private Ocs2003Repository ocs2003Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional
	public OCS0103U13PrOcsApplyNdayOrderResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U13PrOcsApplyNdayOrderRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103U13PrOcsApplyNdayOrderResponse.Builder response = OcsaServiceProto.OCS0103U13PrOcsApplyNdayOrderResponse.newBuilder();                      
		String ioFlag= ocs2003Repository.callPrOcsApplyNdayOrderOCS0103U13(getHospitalCode(vertx, sessionId),request.getBunho(),DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD));
		if(!StringUtils.isEmpty(ioFlag)){
			response.setOutDataString(ioFlag);
			if(ioFlag.equals("0")){
				response.setResult(true);
			}else{
				response.setResult(false);
			}
		}
		return response.build();
	}

}