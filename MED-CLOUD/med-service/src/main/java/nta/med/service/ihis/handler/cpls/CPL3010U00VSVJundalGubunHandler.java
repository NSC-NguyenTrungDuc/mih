package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00VSVJundalGubunRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00VSVJundalGubunResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3010U00VSVJundalGubunHandler extends ScreenHandler <CplsServiceProto.CPL3010U00VSVJundalGubunRequest,CplsServiceProto.CPL3010U00VSVJundalGubunResponse> {
	@Resource
	private Cpl0109Repository cpl0109Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3010U00VSVJundalGubunResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3010U00VSVJundalGubunRequest request) throws Exception {
        CplsServiceProto.CPL3010U00VSVJundalGubunResponse.Builder response = CplsServiceProto.CPL3010U00VSVJundalGubunResponse.newBuilder();
    	String codeName = cpl0109Repository.getCPL3010U00VSVJundalGubun(getHospitalCode(vertx, sessionId), 
    			getLanguage(vertx, sessionId), request.getCodeType(), request.getCode());
        if(!StringUtils.isEmpty(codeName)) {
        	response.setCodeName(codeName);
        }
        return response.build();
	}
}
