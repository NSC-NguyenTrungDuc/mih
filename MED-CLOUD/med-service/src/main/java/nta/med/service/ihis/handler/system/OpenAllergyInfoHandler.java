package nta.med.service.ihis.handler.system;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1016Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OpenAllergyInfoRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OpenAllergyInfoResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class OpenAllergyInfoHandler extends ScreenHandler <SystemServiceProto.OpenAllergyInfoRequest, SystemServiceProto.OpenAllergyInfoResponse>{                     
	@Resource                                                                                                       
	private Nur1016Repository nur1016Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OpenAllergyInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OpenAllergyInfoRequest request)
			throws Exception {                                                                   
      	   	SystemServiceProto.OpenAllergyInfoResponse.Builder response = SystemServiceProto.OpenAllergyInfoResponse.newBuilder();
				SystemModelProto.OpenAllergyInfo info = request.getInfo1();
				Date appDate = DateUtil.toDate(info.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
				String result = nur1016Repository.getOpenAllergyInfo(getHospitalCode(vertx, sessionId), info.getBunho(), appDate);
				if(!StringUtils.isEmpty(result)){
					response.setRetval(result);
				}
				return response.build();
	}
}
