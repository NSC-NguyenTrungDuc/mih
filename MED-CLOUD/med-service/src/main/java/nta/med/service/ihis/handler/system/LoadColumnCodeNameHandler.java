package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.helper.OrderBizHelper;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.LoadColumnCodeNameRequest;
import nta.med.service.ihis.proto.SystemServiceProto.LoadColumnCodeNameResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class LoadColumnCodeNameHandler
	extends ScreenHandler<SystemServiceProto.LoadColumnCodeNameRequest, SystemServiceProto.LoadColumnCodeNameResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;     
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	@Transactional(readOnly = true)
	public LoadColumnCodeNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, LoadColumnCodeNameRequest request)
			throws Exception {                                                                
      	   	SystemServiceProto.LoadColumnCodeNameResponse.Builder response = SystemServiceProto.LoadColumnCodeNameResponse.newBuilder();                      
		String relVal = OrderBizHelper.getLoadColumnCodeName(getHospitalCode(vertx, sessionId),getLanguage(vertx, sessionId), request.getRequestValue());
		if(!StringUtils.isEmpty(relVal)){
			response.setRetVal(relVal);
		}
		return response.build();
	}
}