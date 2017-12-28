package nta.med.service.ihis.handler.system;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.DupCheckInputOutOrderRequest;
import nta.med.service.ihis.proto.SystemServiceProto.DupCheckInputOutOrderResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class DupCheckInputOutOrderHandler
	extends ScreenHandler<SystemServiceProto.DupCheckInputOutOrderRequest, SystemServiceProto.DupCheckInputOutOrderResponse> {                     
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;
	
	@Override
	@Transactional(readOnly = true)
	public DupCheckInputOutOrderResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			DupCheckInputOutOrderRequest request) throws Exception {                                                                 
  	   	SystemServiceProto.DupCheckInputOutOrderResponse.Builder response = SystemServiceProto.DupCheckInputOutOrderResponse.newBuilder();
		SystemModelProto.DupCheckInputOutOrderInfo info = request.getOutOrderInfo();
		Date naewonDate = DateUtil.toDate(info.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
		Date hopeDate = DateUtil.toDate(info.getHopeDate(), DateUtil.PATTERN_YYMMDD);
		String result = ocs1003Repository.getDupCheckInputOutOrder(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), info.getBunho(),
				naewonDate, info.getHangmogCode(), hopeDate);
		if(!StringUtils.isEmpty(result)){
			response.setOutOrder(result);
		}
		return response.build();
	}
}
