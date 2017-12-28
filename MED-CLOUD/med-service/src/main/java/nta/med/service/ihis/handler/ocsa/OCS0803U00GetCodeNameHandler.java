package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0801Repository;
import nta.med.data.dao.medi.ocs.Ocs0802Repository;
import nta.med.data.dao.medi.ocs.Ocs0803Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0803U00GetCodeNameRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0803U00GetCodeNameResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0803U00GetCodeNameHandler
	extends ScreenHandler<OcsaServiceProto.OCS0803U00GetCodeNameRequest, OcsaServiceProto.OCS0803U00GetCodeNameResponse> {                     
	@Resource                                                                                                       
	private Ocs0803Repository ocs0803Repository;      
	@Resource
	private Ocs0801Repository ocs0801Repository;
	@Resource
	private Ocs0802Repository ocs0802Repository;
	                                                                                                                
	@Override       
	@Transactional(readOnly = true)
	public OCS0803U00GetCodeNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0803U00GetCodeNameRequest request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0803U00GetCodeNameResponse.Builder response = OcsaServiceProto.OCS0803U00GetCodeNameResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		String codeName = null;
		switch (request.getCodeMode()) {
		case "pat_status_gr":
			codeName = ocs0803Repository.getOCS0803U00GetCodeNameCasePatStatusGr(hospCode, request.getCode(), language);
			break;
		case "pat_status":
			codeName = ocs0801Repository.getOCS0803U00GetCodeNameCasePatStatus(language, request.getCode());
			break;
		case "break_pat_status_code":
			codeName = ocs0802Repository.getOCS0803U00GetCodeNameCaseBreakPatStatusCode(hospCode, language, request.getPatStatus(), request.getCode());
			break;
		}
		if(!StringUtils.isEmpty(codeName)){
			response.setCodeName(codeName);
		}
		return response.build();
	}

}