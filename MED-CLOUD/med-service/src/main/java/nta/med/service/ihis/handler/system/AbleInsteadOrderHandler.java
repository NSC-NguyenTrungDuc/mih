package nta.med.service.ihis.handler.system;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.AbleInsteadOrderRequest;
import nta.med.service.ihis.proto.SystemServiceProto.AbleInsteadOrderResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class AbleInsteadOrderHandler
	extends ScreenHandler<SystemServiceProto.AbleInsteadOrderRequest, SystemServiceProto.AbleInsteadOrderResponse> {                     
	@Resource                                                                                                       
	private Inp1003Repository inp1003Repository;
	
	@Override
	@Transactional(readOnly = true)
	public AbleInsteadOrderResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, AbleInsteadOrderRequest request)
			throws Exception {                                                             
  	   	SystemServiceProto.AbleInsteadOrderResponse.Builder response = SystemServiceProto.AbleInsteadOrderResponse.newBuilder();
		SystemModelProto.AbleInsteadOrderInfo info = request.getInfo1();
		Date naewonDate = DateUtil.toDate(info.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
		String result = inp1003Repository.getAbleInsteadOrder(getHospitalCode(vertx, sessionId), info.getBunho(), naewonDate);
		if(!StringUtils.isEmpty(result)){
			response.setRetVal(result);
		}
		return response.build();
	}
}
