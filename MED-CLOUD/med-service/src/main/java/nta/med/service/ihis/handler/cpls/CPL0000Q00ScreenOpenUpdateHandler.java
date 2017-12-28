package nta.med.service.ihis.handler.cpls;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.data.dao.medi.ocs.Ocs5010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00ScreenOpenUpdateRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class CPL0000Q00ScreenOpenUpdateHandler extends ScreenHandler<CplsServiceProto.CPL0000Q00ScreenOpenUpdateRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(CPL0000Q00ScreenOpenUpdateHandler.class);
	
	@Resource
	private Ocs5010Repository ocs5010Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL0000Q00ScreenOpenUpdateRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
    	Integer result = ocs5010Repository.updateOcs5010CPL0000Q00ScreenOpenUpdate(request.getUserId(), new Date(), getHospitalCode(vertx, sessionId),
    			request.getDoctor(), request.getBunho(), request.getJundalTable());
        if(result>0){
        	response.setResult(true);
        }else{
        	response.setResult(false);
        }
		return response.build();
	}
}
