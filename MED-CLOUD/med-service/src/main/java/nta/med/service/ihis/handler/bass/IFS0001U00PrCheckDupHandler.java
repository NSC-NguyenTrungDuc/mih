package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ifs.Ifs0001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.IFS0001U00PrCheckDupRequest;
import nta.med.service.ihis.proto.BassServiceProto.IFS0001U00PrCheckDupResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class IFS0001U00PrCheckDupHandler extends ScreenHandler<BassServiceProto.IFS0001U00PrCheckDupRequest, BassServiceProto.IFS0001U00PrCheckDupResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(IFS0001U00PrCheckDupHandler.class);                                    
	@Resource                                                                                                       
	private Ifs0001Repository ifs0001Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional
	public IFS0001U00PrCheckDupResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			IFS0001U00PrCheckDupRequest request) throws Exception {
  	   	BassServiceProto.IFS0001U00PrCheckDupResponse.Builder response = BassServiceProto.IFS0001U00PrCheckDupResponse.newBuilder();                      
		String result = ifs0001Repository.checkGrdDetailColumnChanged(request.getMasterCheck(), getHospitalCode(vertx, sessionId), request.getCodeType(), request.getCode());
		if(!StringUtils.isEmpty(result)){
			response.setDupYn(result);
		}
		return response.build();
	}                                                                                                                 
}