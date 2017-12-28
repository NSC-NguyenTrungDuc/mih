package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U11GrdSlipHangMogListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U11GrdSlipHangMogRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U11GrdSlipHangMogResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U11GrdSlipHangMogHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U11GrdSlipHangMogRequest, OcsaServiceProto.OCS0103U11GrdSlipHangMogResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U11GrdSlipHangMogHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override       
	@Transactional(readOnly = true)
	public OCS0103U11GrdSlipHangMogResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U11GrdSlipHangMogRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U11GrdSlipHangMogResponse.Builder response = OcsaServiceProto.OCS0103U11GrdSlipHangMogResponse.newBuilder();                      
    	List<OCS0103U11GrdSlipHangMogListItemInfo> listGrdSlip=ocs0103Repository.getOCS0103U11GrdSlipHangMog(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
    			request.getSlipCode(),request.getSearchWord(), DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD));
    	if(!CollectionUtils.isEmpty(listGrdSlip)){
    		for(OCS0103U11GrdSlipHangMogListItemInfo item: listGrdSlip){
    			OcsaModelProto.OCS0103U11GrdSlipHangMogListItemInfo.Builder info= OcsaModelProto.OCS0103U11GrdSlipHangMogListItemInfo.newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListInfo(info);
    		}
    	}
    	return response.build();
	}
}