package nta.med.service.ihis.handler.ocsa.composite;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U13CboListHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U13FormLoadHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U13GrdSangyongOrderListHandler;
import nta.med.service.ihis.handler.system.GetNextGroupSerHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;

/**
 * 
 * @author DEV-HuanLT
 *
 */
@Service
@Scope("prototype")
public class OCS0103U13OpenScreenHandler extends
		ScreenHandler<OcsaServiceProto.OCS0103U13OpenScreenRequest, OcsaServiceProto.OCS0103U13OpenScreenResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(OCS0103U13OpenScreenHandler.class);

	@Resource
	private OCS0103U13CboListHandler ocs0103U13CboListHandler;

	@Resource
	private OCS0103U13FormLoadHandler ocs0103U13FormLoadHandler;

	@Resource
	private OCS0103U13GrdSangyongOrderListHandler ocs0103U13GrdSangyongOrderListHandler;
	
	@Resource
	private GetNextGroupSerHandler getNextGroupSerHandler;

	@Override
	@Transactional
	public OcsaServiceProto.OCS0103U13OpenScreenResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OcsaServiceProto.OCS0103U13OpenScreenRequest request) throws Exception {
		OcsaServiceProto.OCS0103U13OpenScreenResponse.Builder response = OcsaServiceProto.OCS0103U13OpenScreenResponse.newBuilder();

		// 1296 
		LOGGER.info("1 OCS0103U13OpenScreenHandler: " + System.currentTimeMillis());
		if (request.hasOcs0103U13CboList()) {
			response.setOcs0103U13CboList(ocs0103U13CboListHandler.handle(vertx, clientId, sessionId, contextId,
					request.getOcs0103U13CboList()));
		}
		// 1317 21
		LOGGER.info("2 OCS0103U13OpenScreenHandler: " + System.currentTimeMillis());
		if(request.hasOcs0103U13FormLoad()){
			response.setOcs0103U13FormLoad(ocs0103U13FormLoadHandler.handle(vertx, clientId, sessionId, contextId,
					request.getOcs0103U13FormLoad()));
		}
		// 2159 842
		LOGGER.info("3 OCS0103U13OpenScreenHandler: " + System.currentTimeMillis());
		if(request.getOcs0103U14GrdSangyongOrderListList() != null){
			for (OcsaServiceProto.OCS0103U13GrdSangyongOrderListRequest item : request.getOcs0103U14GrdSangyongOrderListList()) {
				response.addOcs0103U14GrdSangyongOrderList(ocs0103U13GrdSangyongOrderListHandler.handle(vertx, clientId, sessionId, contextId, item));
			}
		}
		// 2269 110
		LOGGER.info("4 OCS0103U13OpenScreenHandler: " + System.currentTimeMillis());
		if(request.hasGetNextGroupSer()){
			response.setGetNextGroupSer(getNextGroupSerHandler.handle(vertx, clientId, sessionId, contextId,
					request.getGetNextGroupSer()));
		}
		// 2432 163
		LOGGER.info("5 OCS0103U13OpenScreenHandler: " + System.currentTimeMillis());
		return response.build();
	}
}
