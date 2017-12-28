package nta.med.service.ihis.handler.schs;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00VsvUserNameRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00VsvUserNameResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH3001U00VsvUserNameHandler 
	extends ScreenHandler<SchsServiceProto.SCH3001U00VsvUserNameRequest, SchsServiceProto.SCH3001U00VsvUserNameResponse> {
	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional(readOnly=true)
	public SCH3001U00VsvUserNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH3001U00VsvUserNameRequest request) throws Exception {
        SchsServiceProto.SCH3001U00VsvUserNameResponse.Builder response = SchsServiceProto.SCH3001U00VsvUserNameResponse.newBuilder();
    	String result = adm3200Repository.getSCH3001U00VsvUserName(getHospitalCode(vertx, sessionId), request.getCode());
    	if(!StringUtils.isEmpty(result)){
				response.setUserName(result);
    	}
    	return response.build();
	}
}
