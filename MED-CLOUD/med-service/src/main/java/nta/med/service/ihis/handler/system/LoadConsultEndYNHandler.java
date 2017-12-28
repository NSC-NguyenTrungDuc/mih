package nta.med.service.ihis.handler.system;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0503Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.LoadConsultEndYNInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.LoadConsultEndYNRequest;
import nta.med.service.ihis.proto.SystemServiceProto.LoadConsultEndYNResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype") 
public class LoadConsultEndYNHandler 
	extends ScreenHandler<SystemServiceProto.LoadConsultEndYNRequest, SystemServiceProto.LoadConsultEndYNResponse>{                     
	@Resource                                                                                                       
	private Ocs0503Repository ocs0503Repository;
	
	@Override
	@Transactional(readOnly = true)
	public LoadConsultEndYNResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, LoadConsultEndYNRequest request)
			throws Exception {                                                                 
      	   	SystemServiceProto.LoadConsultEndYNResponse.Builder response = SystemServiceProto.LoadConsultEndYNResponse.newBuilder();                      
		LoadConsultEndYNInfo info = request.getLoadConsultEndYNInfo();
		Date maxReqDate = ocs0503Repository.getLoadConsultEndYN(getHospitalCode(vertx, sessionId), info.getBunho(), info.getReqDoctor());
		if(maxReqDate != null){
			response.setMaxReqDate(DateUtil.toString(maxReqDate, DateUtil.PATTERN_YYMMDD));
		}
		return response.build(); 
	}
}
