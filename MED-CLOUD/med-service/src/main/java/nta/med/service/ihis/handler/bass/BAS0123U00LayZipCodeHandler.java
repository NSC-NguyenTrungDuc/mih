package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.bas.Bas0123;
import nta.med.data.dao.medi.bas.Bas0123Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0123U00LayZipCodeRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0123U00LayZipCodeResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0123U00LayZipCodeHandler extends ScreenHandler<BassServiceProto.BAS0123U00LayZipCodeRequest, BassServiceProto.BAS0123U00LayZipCodeResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0123U00LayZipCodeHandler.class);                                    
	@Resource                                                                                                       
	private Bas0123Repository bas0123Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public BAS0123U00LayZipCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0123U00LayZipCodeRequest request) throws Exception {                                                                   
  	   	BassServiceProto.BAS0123U00LayZipCodeResponse.Builder response = BassServiceProto.BAS0123U00LayZipCodeResponse.newBuilder();                      
		List<Bas0123> listItem = bas0123Repository.getByZipCode(request.getCode());
		if (!CollectionUtils.isEmpty(listItem)) {
			for (Bas0123 item : listItem) {
				String info = item.getZipName1() + item.getZipName2() + item.getZipName3();
				response.setInfo(info);
			}
		}
		return response.build();
	}
}