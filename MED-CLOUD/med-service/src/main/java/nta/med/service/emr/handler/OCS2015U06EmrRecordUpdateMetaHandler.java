package nta.med.service.emr.handler;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.emr.EmrRecordRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class OCS2015U06EmrRecordUpdateMetaHandler extends ScreenHandler<EmrServiceProto.OCS2015U06EmrRecordUpdateMetaRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U06EmrRecordUpdateMetaHandler.class);                                    
	@Resource                                                                                                       
	private EmrRecordRepository emrRecordRepository;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U06EmrRecordUpdateMetaRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Integer result = emrRecordRepository.updateOCS2015U04FieldMetadata(request.getFMeta(), CommonUtils.parseInteger(request.getFRecordId()));
		response.setResult(result != null && result > 0);
		return response.build();
	}
}