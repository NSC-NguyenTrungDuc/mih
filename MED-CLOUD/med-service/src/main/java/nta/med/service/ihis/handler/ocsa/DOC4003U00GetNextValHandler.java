package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.CommonRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto.DOC4003U00GetNextValRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.DOC4003U00GetNextValResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class DOC4003U00GetNextValHandler extends ScreenHandler<DOC4003U00GetNextValRequest, DOC4003U00GetNextValResponse>{

	@Resource
	private CommonRepository commonRepository;
	@Override
	@Transactional
	public DOC4003U00GetNextValResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			DOC4003U00GetNextValRequest request) throws Exception {
		DOC4003U00GetNextValResponse.Builder response = DOC4003U00GetNextValResponse.newBuilder();
		String result = commonRepository.getNextVal("DOC4003_SEQ");
		if(!StringUtils.isEmpty(result)){
			response.setNextVal(result);
		}
		return response.build();
	}

}
