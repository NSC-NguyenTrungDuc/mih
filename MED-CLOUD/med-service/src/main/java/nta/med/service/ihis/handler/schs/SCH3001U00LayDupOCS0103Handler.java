package nta.med.service.ihis.handler.schs;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00LayDupOCS0103Request;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00LayDupOCS0103Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH3001U00LayDupOCS0103Handler 
	extends ScreenHandler<SchsServiceProto.SCH3001U00LayDupOCS0103Request, SchsServiceProto.SCH3001U00LayDupOCS0103Response> {
	
	@Resource
	private Ocs0103Repository ocs0103Repository;
	
	
	@Override
	@Transactional(readOnly=true)
	public SCH3001U00LayDupOCS0103Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH3001U00LayDupOCS0103Request request) throws Exception {
        SchsServiceProto.SCH3001U00LayDupOCS0103Response.Builder response = SchsServiceProto.SCH3001U00LayDupOCS0103Response.newBuilder();
    	String result = ocs0103Repository.getLayDupOCS0103(getHospitalCode(vertx, sessionId), request.getJundalPart());
    	if(!StringUtils.isEmpty(result)){
    		CommonModelProto.DataStringListItemInfo.Builder builder =  CommonModelProto.DataStringListItemInfo.newBuilder();
    		builder.setDataValue(result);
    		response.addItemInfo(builder);
    	}
    	return response.build();
	}
}