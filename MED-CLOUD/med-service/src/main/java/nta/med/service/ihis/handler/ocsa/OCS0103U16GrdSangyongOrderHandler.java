package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U16GrdSangyongOrderInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U16GrdSangyongOrderRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U16GrdSangyongOrderResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U16GrdSangyongOrderHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U16GrdSangyongOrderRequest, OcsaServiceProto.OCS0103U16GrdSangyongOrderResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U16GrdSangyongOrderHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                               
	                                                                                                                
	@Override          
	@Transactional(readOnly = true)
	public OCS0103U16GrdSangyongOrderResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U16GrdSangyongOrderRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103U16GrdSangyongOrderResponse.Builder response = OcsaServiceProto.OCS0103U16GrdSangyongOrderResponse.newBuilder(); 
    	List<OCS0103U16GrdSangyongOrderInfo> listGrdSang=ocs0103Repository.getOCS0103U16GrdSangyongOrderInfo(getHospitalCode(vertx, sessionId),getLanguage(vertx, sessionId),
    			request.getCodeYn(),request.getUser(),request.getIoGubun(), 
    			DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD),request.getSearchWord(),request.getWonnaeDrgYn(),request.getOrderGubun(), request.getProtocolId());
    	if(!CollectionUtils.isEmpty(listGrdSang)){
    		for(OCS0103U16GrdSangyongOrderInfo item:listGrdSang){
    			OcsaModelProto.OCS0103U16GrdSangyongOrderInfo.Builder info = OcsaModelProto.OCS0103U16GrdSangyongOrderInfo.newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addSangyongOrderItem(info);
    		}
    	}
    	return response.build();
	}

}