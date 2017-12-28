package nta.med.service.ihis.handler.schs;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00VsvHangmogCodeRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00VsvHangmogCodeResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH3001U00VsvHangmogCodeHandler
	extends ScreenHandler<SchsServiceProto.SCH3001U00VsvHangmogCodeRequest, SchsServiceProto.SCH3001U00VsvHangmogCodeResponse> {
	@Resource
	private Ocs0103Repository ocs0103Repository;
	
	@Override
	@Transactional(readOnly=true)
	public SCH3001U00VsvHangmogCodeResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SCH3001U00VsvHangmogCodeRequest request) throws Exception {
        SchsServiceProto.SCH3001U00VsvHangmogCodeResponse.Builder response = SchsServiceProto.SCH3001U00VsvHangmogCodeResponse.newBuilder();
    	String result = ocs0103Repository.getSCH3001U00VsvHangmogCode(getHospitalCode(vertx, sessionId), request.getCode(),false);
    	if(!StringUtils.isEmpty(result)){
				response.setHangmogName(result);
		}
    	return response.build();
	}
}
