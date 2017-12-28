package nta.med.service.ihis.handler.schs;

import javax.annotation.Resource;

import nta.med.data.dao.medi.sch.Sch0108Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0109U00LayDupMRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0109U00LayDupMResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH0109U00LayDupMHandler 
	extends ScreenHandler<SchsServiceProto.SCH0109U00LayDupMRequest, SchsServiceProto.SCH0109U00LayDupMResponse> {
	
	@Resource
	private Sch0108Repository sch0108Repository;
	
	@Override
	@Transactional(readOnly=true)
	public SCH0109U00LayDupMResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, SCH0109U00LayDupMRequest request)
			throws Exception {
        SchsServiceProto.SCH0109U00LayDupMResponse.Builder response = SchsServiceProto.SCH0109U00LayDupMResponse.newBuilder();
    	String retVal = sch0108Repository.getSCH0109U00LayDupM(getHospitalCode(vertx, sessionId), request.getCodeType(), getLanguage(vertx, sessionId));
    	if (!StringUtils.isEmpty(retVal)) {
    		response.setRetValue(retVal);
		}
        return response.build();	
	}
}
