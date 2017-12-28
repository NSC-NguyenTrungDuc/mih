package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.helper.OrderBizHelper;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetFindWorkerRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetFindWorkerResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
public class GetFindWorkerHandler
	extends ScreenHandler<SystemServiceProto.GetFindWorkerRequest, SystemServiceProto.GetFindWorkerResponse> {                     
	@Resource                                                                                                       
	private Out1001Repository  out1001Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public GetFindWorkerResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, GetFindWorkerRequest request)
			throws Exception {                                                                 
  	   	SystemServiceProto.GetFindWorkerResponse.Builder response = SystemServiceProto.GetFindWorkerResponse.newBuilder();
  	   	CommonModelProto.GetFindWorkerRequestInfo info = request.getInfo1();
		response = OrderBizHelper.getFindWorker(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), info);
		return response.build();
	}
}
