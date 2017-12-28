package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U10GrdDrgOrderInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U10GrdDrgOrderRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U10GrdDrgOrderResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U10GrdDrgOrderHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U10GrdDrgOrderRequest, OcsaServiceProto.OCS0103U10GrdDrgOrderResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U10GrdDrgOrderHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly = true)
	public OCS0103U10GrdDrgOrderResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
		OCS0103U10GrdDrgOrderRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103U10GrdDrgOrderResponse.Builder response = OcsaServiceProto.OCS0103U10GrdDrgOrderResponse.newBuilder();
  	    String offset = request.getOffSet();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
    	List<OCS0103U10GrdDrgOrderInfo> listGrdOrder = ocs0103Repository.listOCS0103U10GrdDrgOrderInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
    			request.getMode(),request.getCode1(),request.getWonnaeDrgYn(), DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD),request.getSearchWord(), request.getProtocolId(), startNum, CommonUtils.parseInteger(offset));
    	if(!CollectionUtils.isEmpty(listGrdOrder)){
    		for(OCS0103U10GrdDrgOrderInfo item :listGrdOrder){
    			OcsaModelProto.OCS0103U10GrdDrgOrderInfo.Builder info =OcsaModelProto.OCS0103U10GrdDrgOrderInfo.newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDrgOrderItem(info);
    		}
    	}
    	return response.build();
	}

}