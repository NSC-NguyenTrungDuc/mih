package nta.med.service.ihis.handler.cpls;
import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00LayCommonRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00LayCommonResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;


@Service
@Scope("prototype")
public class CPL3020U00LayCommonHandler extends ScreenHandler<CplsServiceProto.CPL3020U00LayCommonRequest, CplsServiceProto.CPL3020U00LayCommonResponse>{
	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3020U00LayCommonResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL3020U00LayCommonRequest request)
			throws Exception {
        CplsServiceProto.CPL3020U00LayCommonResponse.Builder response = CplsServiceProto.CPL3020U00LayCommonResponse.newBuilder();
    	String result = adm3200Repository.getCPL3020U00LayCommon(getHospitalCode(vertx, sessionId), "CPL", request.getUserId());
    	if(result != null && !result.isEmpty()){
    		response.setUserName(result);
    	}
    	return response.build();
	}
}
