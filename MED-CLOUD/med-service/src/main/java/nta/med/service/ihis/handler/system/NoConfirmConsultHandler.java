package nta.med.service.ihis.handler.system;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0503Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.NoConfirmConsultInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.NoConfirmConsultRequest;
import nta.med.service.ihis.proto.SystemServiceProto.NoConfirmConsultResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NoConfirmConsultHandler
	extends ScreenHandler<SystemServiceProto.NoConfirmConsultRequest, SystemServiceProto.NoConfirmConsultResponse> {                     
	@Resource                                                                                                       
	private Ocs0503Repository ocs0503Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NoConfirmConsultResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, NoConfirmConsultRequest request)
			throws Exception {                                                                 
      	   	SystemServiceProto.NoConfirmConsultResponse.Builder response = SystemServiceProto.NoConfirmConsultResponse.newBuilder();
		NoConfirmConsultInfo info = request.getConsultInfo();
		Date naewonDate = DateUtil.toDate(info.getNaewondate(), DateUtil.PATTERN_YYMMDD);
		String result = ocs0503Repository.getNoConfirmConsult(getHospitalCode(vertx, sessionId), info.getBunho(), naewonDate, info.getGwa(),
				info.getDoctor(), info.getIoGubun());
		if(!StringUtils.isEmpty(result)){
			response.setRetval(result);
		}
		return response.build();
	}
}
