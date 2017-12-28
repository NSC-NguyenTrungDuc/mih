package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0108Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS1003Q09CheckOrdDanuiHandler extends ScreenHandler<OcsoServiceProto.OCS1003Q09CheckOrdDanuiRequest, OcsoServiceProto.OCS1003Q09CheckOrdDanuiResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS1003Q09CheckOrdDanuiHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0108Repository ocs0108Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCS1003Q09CheckOrdDanuiResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCS1003Q09CheckOrdDanuiRequest request) throws Exception {
		OcsoServiceProto.OCS1003Q09CheckOrdDanuiResponse.Builder response = OcsoServiceProto.OCS1003Q09CheckOrdDanuiResponse.newBuilder(); 
		String result = ocs0108Repository.callFnOcsExistsOrdDanui(getHospitalCode(vertx, sessionId), request.getHangmogCode(), request.getOrdDanui());
		if(!StringUtils.isEmpty(result)){
			response.setRetValue(result);
		}
		return response.build();
	}                                                                                                                 
}