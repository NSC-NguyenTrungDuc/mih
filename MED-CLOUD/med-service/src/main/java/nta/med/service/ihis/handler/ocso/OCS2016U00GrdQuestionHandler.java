package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0701Repository;
import nta.med.data.model.ihis.ocso.OCS2016U00GrdQuestionInfo;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCS2016U00GrdQuestionRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.OCS2016U00GrdQuestionResponse;

@Service                                                                                                          
@Scope("prototype")
public class OCS2016U00GrdQuestionHandler extends ScreenHandler<OcsoServiceProto.OCS2016U00GrdQuestionRequest, OcsoServiceProto.OCS2016U00GrdQuestionResponse>{
	
	private static final Log LOGGER = LogFactory.getLog(OCS2016U00GrdQuestionHandler.class);
	
	@Resource
	private Ocs0701Repository ocs0701Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS2016U00GrdQuestionResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2016U00GrdQuestionRequest request) throws Exception {
		
		OcsoServiceProto.OCS2016U00GrdQuestionResponse.Builder response = OcsoServiceProto.OCS2016U00GrdQuestionResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String reqDoctor = getUserId(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String reqDate = request.getDatetime();
		String gwa = request.getGwa();
		String questionType = request.getQuestionType();
		
		List<OCS2016U00GrdQuestionInfo> listItem = ocs0701Repository.getListOCS2016U00GrdQuestionInfo(hospCode, reqDoctor, reqDate, questionType, gwa, language);
		for (OCS2016U00GrdQuestionInfo item : listItem) {
			OcsoModelProto.OCS2016U00GrdQuestionInfo.Builder info = OcsoModelProto.OCS2016U00GrdQuestionInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addListQuestionInfo(info);
		}
		
		return response.build();
	}
	
}
