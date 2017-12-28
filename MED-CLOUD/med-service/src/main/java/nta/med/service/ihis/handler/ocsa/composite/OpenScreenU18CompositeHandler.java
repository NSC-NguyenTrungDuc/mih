package nta.med.service.ihis.handler.ocsa.composite;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.annotation.Resource;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U12GrdSangyongOrderHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U12MakeSangyongTabHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U18InitializeScreenHandler;
import nta.med.service.ihis.handler.system.GetNextGroupSerHandler;
import nta.med.service.ihis.handler.system.LoadComboDataSourceHandler;
import nta.med.service.ihis.handler.system.OcsOrderBizGetUserOptionHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OpenScreenU18CompositeRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OpenScreenU18CompositeResponse;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class OpenScreenU18CompositeHandler extends ScreenHandler<OcsaServiceProto.OpenScreenU18CompositeRequest, OcsaServiceProto.OpenScreenU18CompositeResponse> {
	private static final Log LOGGER = LogFactory.getLog(OpenScreenU18CompositeHandler.class);  
	
	@Resource
    private LoadComboDataSourceHandler loadComboDataSourceHandler;
	
	@Resource
    private OCS0103U18InitializeScreenHandler oCS0103U18InitializeScreenHandler;
	
	@Resource
    private OCS0103U12MakeSangyongTabHandler oCS0103U12MakeSangyongTabHandler;
	
	@Resource
    private OCS0103U12GrdSangyongOrderHandler oCS0103U12GrdSangyongOrderHandler;
	
	@Resource
    private GetNextGroupSerHandler getNextGroupSerHandler;

	@Resource
    private OcsOrderBizGetUserOptionHandler ocsOrderBizGetUserOptionHandler;
	
	@Override
	@Transactional
	public OpenScreenU18CompositeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OpenScreenU18CompositeRequest request) throws Exception {
		OcsaServiceProto.OpenScreenU18CompositeResponse.Builder response = OcsaServiceProto.OpenScreenU18CompositeResponse.newBuilder();
		
		List<OcsaServiceProto.OCS0103U12GrdSangyongOrderRequest> sangYongOderReq = request.getSangyongOrderList();
		OcsaServiceProto.OCS0103U12MakeSangyongTabResponse sangYongTabRes = null;
		
		Map<Integer, String> mapOrderGubun = new HashMap<Integer, String>();
		Integer mapKey = 0;
		for (SystemServiceProto.LoadComboDataSourceRequest item : request.getLoadComboDataList()) {
            response.addLoadComboData(loadComboDataSourceHandler.handle(vertx, clientId, sessionId, contextId, item));
        }
		
		for (OcsaServiceProto.OCS0103U18InitializeScreenRequest item : request.getInitializeScreenList()) {
            response.addInitializeScreen(oCS0103U18InitializeScreenHandler.handle(vertx, clientId, sessionId, contextId, item));
        }
		
		for (OcsaServiceProto.OCS0103U12MakeSangyongTabRequest item : request.getSangyongTabList()) {
			sangYongTabRes = oCS0103U12MakeSangyongTabHandler.handle(vertx, clientId, sessionId, contextId, item);
            response.addSangyongTab(sangYongTabRes);
            if(!CollectionUtils.isEmpty(sangYongTabRes.getResultList())){
            	mapOrderGubun.put(mapKey, sangYongTabRes.getResultList().get(0).getOrderGubun());
            }else{
            	mapOrderGubun.put(mapKey, null);
            }
            mapKey = mapKey + 1;
        }
		
		LOGGER.info("OpenScreenU18CompositeHandler OCS0103U12GrdSangyongOrderRequest Size : " + sangYongOderReq.size());
        LOGGER.info("OpenScreenU18CompositeHandler mapOrderGubun Size : " + mapOrderGubun.size());
		
		Integer i = 0;
		if(mapOrderGubun.size() == sangYongOderReq.size()){
			for (OcsaServiceProto.OCS0103U12GrdSangyongOrderRequest item : sangYongOderReq) {
				if(!StringUtils.isEmpty(mapOrderGubun.get(i)) && !mapOrderGubun.get(i).equals(item.getOrderGubun())){
        			item = item.toBuilder()
        					.setOrderGubun(mapOrderGubun.get(i))
        					.build();
        		}
	            response.addSangyongOrder(oCS0103U12GrdSangyongOrderHandler.handle(vertx, clientId, sessionId, contextId, item));
	            i = i + 1;
	        }
		}
		
		
		for (SystemServiceProto.GetNextGroupSerRequest item : request.getNextGroupSerList()) {
            response.addNextGroupSer(getNextGroupSerHandler.handle(vertx, clientId, sessionId, contextId, item));
        }
		
		for (SystemServiceProto.OcsOrderBizGetUserOptionRequest item : request.getUserOptionList()) {
            response.addUserOption(ocsOrderBizGetUserOptionHandler.handle(vertx, clientId, sessionId, contextId, item));
        }
		
		return response.build();
	}  

}
