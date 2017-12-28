package nta.med.service.emr.handler;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.emr.EmrBookmarkRepository;
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
public class OCS2015U04EditBookmarkByPkout1001Handler extends ScreenHandler<EmrServiceProto.OCS2015U04EditBookmarkByPkout1001Request, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U04EditBookmarkByPkout1001Handler.class);                                    
	@Resource                                                                                                       
	private EmrBookmarkRepository emrBookmarkRepository;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U04EditBookmarkByPkout1001Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Integer result = emrBookmarkRepository.updateOCS2015U04EditBookmarkByPkout1001(
				request.getBookmarkText(), request.getUpdId(), CommonUtils.parseInteger(request.getEmrBookmarkId()),
				request.getUpdId(), CommonUtils.parseDouble(request.getPkout1001()));
		if (result!=null && result>0){
			response.setResult(true);
		} else {
			response.setResult(false);
		}
		return response.build();
	}
}