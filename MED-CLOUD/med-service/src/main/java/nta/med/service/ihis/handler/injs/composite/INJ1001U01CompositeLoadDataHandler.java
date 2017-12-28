package nta.med.service.ihis.handler.injs.composite;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.handler.injs.InjsINJ1001U01XEditGridCell88Handler;
import nta.med.service.ihis.handler.injs.InjsINJ1001U01XEditGridCell89Handler;
import nta.med.service.ihis.handler.system.BuseoListHandler;
import nta.med.service.ihis.handler.system.FormEnvironInfoSysDateHandler;
import nta.med.service.ihis.proto.InjsServiceProto;
import nta.med.service.ihis.proto.InjsServiceProto.INJ1001U01CompositeLoadDataRequest;
import nta.med.service.ihis.proto.InjsServiceProto.INJ1001U01CompositeLoadDataResponse;

/**
 * @author DEV-NgocNV
 *
 */
@Service
@Scope("prototype")
public class INJ1001U01CompositeLoadDataHandler extends ScreenHandler<InjsServiceProto.INJ1001U01CompositeLoadDataRequest , InjsServiceProto.INJ1001U01CompositeLoadDataResponse> {
	private static final Log LOGGER = LogFactory.getLog(INJ1001U01CompositeLoadDataHandler.class);
	@Resource
    private BuseoListHandler buseoListHandler;
	@Resource
    private InjsINJ1001U01XEditGridCell88Handler injsINJ1001U01XEditGridCell88Handler;
	@Resource
    private InjsINJ1001U01XEditGridCell89Handler injsINJ1001U01XEditGridCell89Handler;
	@Resource
    private FormEnvironInfoSysDateHandler formEnvironInfoSysDateHandler;
	
	@Override
	@Transactional()
	public INJ1001U01CompositeLoadDataResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INJ1001U01CompositeLoadDataRequest request) throws Exception {	
		InjsServiceProto.INJ1001U01CompositeLoadDataResponse.Builder response = InjsServiceProto.INJ1001U01CompositeLoadDataResponse.newBuilder(); 
		
		response.setBuseo(buseoListHandler.handle(vertx, clientId, sessionId, contextId, request.getBuseo()));
		
		response.setGrdCell88(injsINJ1001U01XEditGridCell88Handler.handle(vertx, clientId, sessionId, contextId, request.getGrdCell88()));
		
		response.setGrdCell89(injsINJ1001U01XEditGridCell89Handler.handle(vertx, clientId, sessionId, contextId, request.getGrdCell89()));
		
		response.setResult(formEnvironInfoSysDateHandler.handle(vertx, clientId, sessionId, contextId, request.getInfoSysDate()));
		
		return response.build();
	}
}




