package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ORDERTRANSExecPrOutCheckOrderEndHandler extends ScreenHandler<NuroServiceProto.ORDERTRANSExecPrOutCheckOrderEndRequest, SystemServiceProto.UpdateResponse> {                    
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSExecPrOutCheckOrderEndHandler.class);                                    
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository; 
	
	@Override
	public boolean isValid(NuroServiceProto.ORDERTRANSExecPrOutCheckOrderEndRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getActingDate()) && DateUtil.toDate(request.getActingDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	@Override
	@Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANSExecPrOutCheckOrderEndRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Date actingDate = DateUtil.toDate(request.getActingDate(), DateUtil.PATTERN_YYMMDD);
		String result = ocs1003Repository.callPrOutCheckOrderEnd(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), actingDate, request.getDoctor(), request.getBunho());
		if(!StringUtils.isEmpty(result)){
			response.setResult(true);
			response.setMsg(result);
		}else{
			response.setResult(false);
		}
		return response.build();
	}                                                                                                                 
}