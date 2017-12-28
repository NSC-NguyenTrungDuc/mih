package nta.med.service.emr.handler;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.emr.EmrRecordRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS2015U00EmrRecordUnlockHandler extends ScreenHandler<EmrServiceProto.OCS2015U00EmrRecordUnlockRequest, SystemServiceProto.UpdateResponse> {
	@Resource                                                                                                       
	private EmrRecordRepository emrRecordRepository;


	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U00EmrRecordUnlockRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Integer result = emrRecordRepository.updateOCS2015U44ReleaseLock(CommonUtils.parseInteger(request.getRecordId()), request.getUpdId());
		if(result != null && result > 0){
			response.setResult(true);
		}else{
			response.setResult(false);
		}
		return response.build();
	}
}