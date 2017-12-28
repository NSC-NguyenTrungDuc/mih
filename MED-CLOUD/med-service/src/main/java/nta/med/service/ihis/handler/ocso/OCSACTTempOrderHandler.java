package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCSACTTempOrderHandler extends ScreenHandler<OcsoServiceProto.OCSACTTempOrderRequest, OcsoServiceProto.OCSACTSingleStringResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTTempOrderHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCSACTSingleStringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCSACTTempOrderRequest request) throws Exception {
		OcsoServiceProto.OCSACTSingleStringResponse.Builder response = OcsoServiceProto.OCSACTSingleStringResponse.newBuilder(); 
		List<String> listCode = ocs0132Repository.getGroupKeyFromVwOcsDummyOrderMaster(request.getHangmogCode());
		if(!CollectionUtils.isEmpty(listCode)){
			String code = listCode.get(0);
			if(!StringUtils.isEmpty(code)){
				response.setResponseStr(code);
			}
		}
		return response.build();
	}                                                                                                                 
}