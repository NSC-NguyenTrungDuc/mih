package nta.med.service.ihis.handler.system;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.GetOrderCountInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetOrderCountRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetOrderCountResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class GetOrderCountHandler
	extends ScreenHandler <SystemServiceProto.GetOrderCountRequest, SystemServiceProto.GetOrderCountResponse> {                     
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;
	
	@Override 
	@Transactional(readOnly = true)
	public GetOrderCountResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, GetOrderCountRequest request)
			throws Exception {                                                                 
  	   	SystemServiceProto.GetOrderCountResponse.Builder response = SystemServiceProto.GetOrderCountResponse.newBuilder();
		GetOrderCountInfo info = request.getOrderCountInfo();
		Date orderDate = DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD);
		Integer result = ocs1003Repository.getOrderCount(getHospitalCode(vertx, sessionId), info.getIoGubun(), info.getBunho(), orderDate);
		if( result != null){
			response.setOrderCout(result.toString());
		}
		return response.build();
	}
}
