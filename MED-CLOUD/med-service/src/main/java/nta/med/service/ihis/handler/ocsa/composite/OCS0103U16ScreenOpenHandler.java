package nta.med.service.ihis.handler.ocsa.composite;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U13CboListHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U14FormLoadHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U16GrdSangyongOrderHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U16SlipCodeTreeHandler;
import nta.med.service.ihis.handler.system.GetNextGroupSerHandler;
import nta.med.service.ihis.handler.system.LoadSearchOrder2Handler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U16ScreenOpenRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U16ScreenOpenResponse;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class OCS0103U16ScreenOpenHandler extends ScreenHandler<OcsaServiceProto.OCS0103U16ScreenOpenRequest, OcsaServiceProto.OCS0103U16ScreenOpenResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS0103U16ScreenOpenHandler.class);
	@Resource
	private OCS0103U13CboListHandler oCS0103U13CboListHandler;
	@Resource
    private OCS0103U14FormLoadHandler oCS0103U14FormLoadHandler;
	@Resource
    private LoadSearchOrder2Handler loadSearchOrder2Handler;
	@Resource
    private OCS0103U16GrdSangyongOrderHandler oCS0103U16GrdSangyongOrderHandler;
	@Resource
	private OCS0103U16SlipCodeTreeHandler oCS0103U16SlipCodeTreeHandler;
	@Resource
    private GetNextGroupSerHandler getNextGroupSerHandler;
	
	@Override
	@Transactional
	public OCS0103U16ScreenOpenResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS0103U16ScreenOpenRequest request) throws Exception {
		OcsaServiceProto.OCS0103U16ScreenOpenResponse.Builder response = OcsaServiceProto.OCS0103U16ScreenOpenResponse.newBuilder();
		OcsaServiceProto.OCS0103U14FormLoadResponse formLoadRes = null;
		
//		 response.setCboLstResItem(oCS0103U13CboListHandler.handle(vertx, clientId, sessionId, contextId, request.getCboLstReqItem()));
		
		 formLoadRes = oCS0103U14FormLoadHandler.handle(vertx, clientId, sessionId, contextId, request.getFormLoadReqItem());
		 response.setFormLoadResItem(formLoadRes);
		 
		 for (SystemServiceProto.LoadSearchOrder2Request item : request.getLoadSearchOrder2ReqItemList()) {
			 response.addLoadSearchOrder2ResItem(loadSearchOrder2Handler.handle(vertx, clientId, sessionId, contextId, item));
	     }
		 OcsaServiceProto.OCS0103U16GrdSangyongOrderRequest sangYongOderReq = request.getGrdSangyongOrderReqItem();
		 if(formLoadRes != null){
			 if(!CollectionUtils.isEmpty(formLoadRes.getLoadOfterUsedTabResponseInfoList())){
				 String orderGubun = formLoadRes.getLoadOfterUsedTabResponseInfoList().get(0).getOrderGubun();
				 String codeYn = formLoadRes.getLoadOfterUsedTabResponseInfoList().get(0).getYnValue();
				 sangYongOderReq = sangYongOderReq.toBuilder()
				 			.setOrderGubun(StringUtils.isEmpty(orderGubun) ? "" : orderGubun)
				 			.setCodeYn(StringUtils.isEmpty(codeYn) ? "" : codeYn)
				 			.build();
			 }
		 }
		 
		 response.setGrdSangyongOrderResItem(oCS0103U16GrdSangyongOrderHandler.handle(vertx, clientId, sessionId, contextId, sangYongOderReq));
		 
		 response.setSlipCodeResItem(oCS0103U16SlipCodeTreeHandler.handle(vertx, clientId, sessionId, contextId, request.getSlipCodeReqItem()));
		 
		 if(!StringUtils.isEmpty(request.getNextGroupserReqItem().getBunho())){
			 response.setNextGroupserResItem(getNextGroupSerHandler.handle(vertx, clientId, sessionId, contextId, request.getNextGroupserReqItem())); 
		 }
		
		return response.build();
	}

}
