package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.core.glossary.OrderMode;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetOrderKeyRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetOrderKeyResponse;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class GetOrderKeyHandler
	extends ScreenHandler<SystemServiceProto.GetOrderKeyRequest, SystemServiceProto.GetOrderKeyResponse> {                     
	@Resource                                                                                                       
	private CommonRepository commonRepository;
	private static final Log LOGGER = LogFactory.getLog(GetOrderKeyHandler.class);
	@Override
	@Transactional
	public GetOrderKeyResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, GetOrderKeyRequest request)
			throws Exception {
		LOGGER.info("GetOrderKeyHandler get orderMode:" + request.getMode());
  	   	SystemServiceProto.GetOrderKeyResponse.Builder response = SystemServiceProto.GetOrderKeyResponse.newBuilder();
		String retVal = null;
		if(OrderMode.InpOrder.getValue().equalsIgnoreCase(request.getMode())|| OrderMode.OutOrder.getValue().equalsIgnoreCase(request.getMode())) {
			retVal = commonRepository.getNextVal("OCSKEY_SEQ");
		}else if(OrderMode.CpOrder.getValue().equalsIgnoreCase(request.getMode())){
			retVal = commonRepository.getNextVal("OCS6013_SEQ");
		}else if(OrderMode.SetOrder.getValue().equalsIgnoreCase(request.getMode())){
			retVal = commonRepository.getNextVal("OCS0303_SEQ");
		}else if(OrderMode.CpSetOrder.getValue().equalsIgnoreCase(request.getMode())){
			retVal = commonRepository.getNextVal("OCS6003_SEQ");
		}
		if(!StringUtils.isEmpty(retVal)){
			response.setOrderKeyValue(retVal);
		}
		return response.build();
	}
}
