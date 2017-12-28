package nta.med.service.ihis.handler.system;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.KensaReserInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.KensaReserRequest;
import nta.med.service.ihis.proto.SystemServiceProto.KensaReserResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class KensaReserHandler 
	extends ScreenHandler<SystemServiceProto.KensaReserRequest, SystemServiceProto.KensaReserResponse> {                     
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;
	
	@Override
	@Transactional(readOnly = true)
	public KensaReserResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, KensaReserRequest request)
			throws Exception {                                                              
      	   	SystemServiceProto.KensaReserResponse.Builder response = SystemServiceProto.KensaReserResponse.newBuilder();
		KensaReserInfo info = request.getReserInfo();
		Date hopeDate = DateUtil.toDate(info.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
		//String result = ocs1003Repository.getKensaReser(getHospitalCode(vertx, sessionId), info.getBunho(), hopeDate);
		String resultYN = ocs1003Repository.callFnOcsIsNextKensaReser(getHospitalCode(vertx, sessionId), info.getBunho(), hopeDate);
		if(!StringUtils.isEmpty(resultYN)){
			response.setRetVal(resultYN);
		}
		return response.build();
	}
}
