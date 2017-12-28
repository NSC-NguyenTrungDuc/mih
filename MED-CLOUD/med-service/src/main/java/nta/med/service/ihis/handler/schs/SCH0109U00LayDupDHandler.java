package nta.med.service.ihis.handler.schs;

import javax.annotation.Resource;

import nta.med.data.dao.medi.sch.Sch0109Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0109U00LayDupDRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0109U00LayDupDResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH0109U00LayDupDHandler 
	extends ScreenHandler <SchsServiceProto.SCH0109U00LayDupDRequest, SchsServiceProto.SCH0109U00LayDupDResponse> {
	
	@Resource
	private Sch0109Repository sch0109Repository;
	
	@Override
	@Transactional(readOnly=true)
	public SCH0109U00LayDupDResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, SCH0109U00LayDupDRequest request)
			throws Exception {
        SchsServiceProto.SCH0109U00LayDupDResponse.Builder response = SchsServiceProto.SCH0109U00LayDupDResponse.newBuilder();
    	String retVal = sch0109Repository.getSCH0109U00LayDupD(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeType(), request.getCode());
    	if (!StringUtils.isEmpty(retVal)) {
    		response.setRetValue(retVal);
		}
        return response.build();	
	}
}
