package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.bas.Bas0123;
import nta.med.data.dao.medi.bas.Bas0123Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

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
public class OUT0101U04TxtZipCode2DataValidatingHandler extends ScreenHandler<NuroServiceProto.OUT0101U04TxtZipCode2DataValidatingRequest, NuroServiceProto.OUT0101U04TxtZipCode2DataValidatingResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OUT0101U04TxtZipCode2DataValidatingHandler.class);                                    
	@Resource                                                                                                       
	private Bas0123Repository bas0123Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OUT0101U04TxtZipCode2DataValidatingResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT0101U04TxtZipCode2DataValidatingRequest request) throws Exception {
		NuroServiceProto.OUT0101U04TxtZipCode2DataValidatingResponse.Builder response = NuroServiceProto.OUT0101U04TxtZipCode2DataValidatingResponse.newBuilder();
		String zipCode = request.getZipCode1().concat(request.getZipCode2());
		List<Bas0123> listItem = bas0123Repository.getBAS0001U00ControlDataValidating(zipCode);
		if (!CollectionUtils.isEmpty(listItem)) {
			String layCom = listItem.get(0).getZipName1().concat(listItem.get(0).getZipName2()).concat(listItem.get(0).getZipName3());
			if(!StringUtils.isEmpty(layCom)){
				response.setRetVal(layCom);
			}
		}
		return response.build();
	}                                                                                                                 
}