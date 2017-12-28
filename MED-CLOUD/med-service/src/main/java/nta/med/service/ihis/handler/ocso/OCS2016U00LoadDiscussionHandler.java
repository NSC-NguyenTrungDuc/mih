package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0702Repository;
import nta.med.data.model.ihis.ocso.OCS2016U00LoadDiscussionInfo;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCS2016U00LoadDiscussionRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.OCS2016U00LoadDiscussionResponse;

@Service                                                                                                          
@Scope("prototype")
public class OCS2016U00LoadDiscussionHandler extends ScreenHandler<OcsoServiceProto.OCS2016U00LoadDiscussionRequest, OcsoServiceProto.OCS2016U00LoadDiscussionResponse>{

	private static final Log LOGGER = LogFactory.getLog(OCS2016U00GrdQuestionHandler.class);
	
	@Resource
	private Ocs0702Repository ocs0702Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS2016U00LoadDiscussionResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2016U00LoadDiscussionRequest request) throws Exception {
		
		OcsoServiceProto.OCS2016U00LoadDiscussionResponse.Builder response = OcsoServiceProto.OCS2016U00LoadDiscussionResponse.newBuilder();
		if(StringUtils.isEmpty(request.getGrpQuestionId())){
			return response.build();
		}
		
		Long qId = CommonUtils.parseLong(request.getGrpQuestionId());
		
		List<OCS2016U00LoadDiscussionInfo> listItem = ocs0702Repository.getOCS2016U00LoadDiscussionInfo(qId);
		for (OCS2016U00LoadDiscussionInfo item : listItem) {
			OcsoModelProto.OCS2016U00LoadDiscussionInfo.Builder info = OcsoModelProto.OCS2016U00LoadDiscussionInfo.newBuilder();
			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
			response.addItemDiscussionInfo(info);
		}
		
		return response.build();
	}

	
}
