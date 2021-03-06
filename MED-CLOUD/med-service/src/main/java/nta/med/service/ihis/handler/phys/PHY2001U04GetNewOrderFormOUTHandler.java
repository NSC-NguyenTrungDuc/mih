package nta.med.service.ihis.handler.phys;

import java.math.BigInteger;
import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04GetNewOrderFormOUTRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04StringResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY2001U04GetNewOrderFormOUTHandler
	extends ScreenHandler<PhysServiceProto.PHY2001U04GetNewOrderFormOUTRequest, PhysServiceProto.PHY2001U04StringResponse> {                     
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;                                                                    
	                                                                                                                
	@Override      
	@Transactional(readOnly=true)
	public PHY2001U04StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY2001U04GetNewOrderFormOUTRequest request) throws Exception {                                                             
  	   	PhysServiceProto.PHY2001U04StringResponse.Builder response = PhysServiceProto.PHY2001U04StringResponse.newBuilder();                      
    	Date orderDate = DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD);
    	BigInteger getCount = ocs1003Repository.getNewOrderFormOUT(getHospitalCode(vertx, sessionId), orderDate, request.getTimeHour(), request.getTimeMin(), request.getTimeSec());
		if(getCount != null){
			response.setResStr(String.valueOf(getCount));
		}
		return response.build();
	}
}