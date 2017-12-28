package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0212Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0212U00LaydupCheckRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0212U00LaydupCheckResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0212U00LaydupCheckHandler extends ScreenHandler<BassServiceProto.BAS0212U00LaydupCheckRequest, BassServiceProto.BAS0212U00LaydupCheckResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0212U00LaydupCheckHandler.class);                                    
	@Resource                                                                                                       
	private Bas0212Repository bas0212Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public BAS0212U00LaydupCheckResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0212U00LaydupCheckRequest request) throws Exception {
		BassServiceProto.BAS0212U00LaydupCheckResponse.Builder response = BassServiceProto.BAS0212U00LaydupCheckResponse.newBuilder(); 
	   List<String> listResult = bas0212Repository.getYByGongbiCodeAnDateBetWeen(request.getCode(),request.getStartDate(), getLanguage(vertx, sessionId));
	   if(!CollectionUtils.isEmpty(listResult)){
		   if(!StringUtils.isEmpty(listResult.get(0))){
			   response.setLayDupResult(listResult.get(0));
		   }
	   }
		return response.build();
	}                                                                                                                 
}