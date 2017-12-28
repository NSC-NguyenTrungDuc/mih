package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
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
public class OUTSANGU00GetGwaNameHandler extends ScreenHandler<OcsoServiceProto.OUTSANGU00GetGwaNameRequest, OcsoServiceProto.OUTSANGU00GetGwaNameResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OUTSANGU00GetGwaNameHandler.class);                                    
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    
	                                                                                                                
	@Override
	public boolean isValid(OcsoServiceProto.OUTSANGU00GetGwaNameRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OUTSANGU00GetGwaNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OUTSANGU00GetGwaNameRequest request) throws Exception {
		OcsoServiceProto.OUTSANGU00GetGwaNameResponse.Builder response = OcsoServiceProto.OUTSANGU00GetGwaNameResponse.newBuilder();
		String result = bas0260Repository.getOUTSANGU00GwaName(getHospitalCode(vertx, sessionId), DateUtil.toDate(request.getStartDate(), 
				DateUtil.PATTERN_YYMMDD), request.getFind1(), getLanguage(vertx, sessionId));
		if(!StringUtils.isEmpty(result)){
			response.setGwaName(result);
		}
		return response.build();
	}                                                                                                                 
}