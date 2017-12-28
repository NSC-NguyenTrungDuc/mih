package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0270Repository;
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
public class OUTSANGU00GetDoctorNameHandler extends ScreenHandler<OcsoServiceProto.OUTSANGU00GetDoctorNameRequest, OcsoServiceProto.OUTSANGU00GetDoctorNameResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(OUTSANGU00GetDoctorNameHandler.class);                                    
	@Resource                                                                                                       
	private Bas0270Repository bas0270Repository;                                                                    
	                                                                                                                
	@Override
	public boolean isValid(OcsoServiceProto.OUTSANGU00GetDoctorNameRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OUTSANGU00GetDoctorNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OUTSANGU00GetDoctorNameRequest request) throws Exception {
		OcsoServiceProto.OUTSANGU00GetDoctorNameResponse.Builder response = OcsoServiceProto.OUTSANGU00GetDoctorNameResponse.newBuilder();
		String result = bas0270Repository.getOUTSANGU00DoctorName(getHospitalCode(vertx, sessionId), request.getGwa(),
				request.getFind1(),DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD));
		if(!StringUtils.isEmpty(result)){
			response.setDoctorName(result);
		}
		return response.build();
	}                                                                                                                 
}