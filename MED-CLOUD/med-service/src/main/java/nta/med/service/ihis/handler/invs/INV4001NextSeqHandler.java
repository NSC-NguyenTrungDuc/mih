package nta.med.service.ihis.handler.invs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV4001NextSeqRequest;
import nta.med.service.ihis.proto.InvsServiceProto.INV4001NextSeqResponse;

@Service
@Scope("prototype")
@Transactional
public class INV4001NextSeqHandler extends ScreenHandler<InvsServiceProto.INV4001NextSeqRequest, InvsServiceProto.INV4001NextSeqResponse> {
	
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	public INV4001NextSeqResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INV4001NextSeqRequest request) throws Exception {
		InvsServiceProto.INV4001NextSeqResponse.Builder response = InvsServiceProto.INV4001NextSeqResponse.newBuilder();
		String result = commonRepository.getNextVal("INV4001_SEQ");
		if(!StringUtils.isEmpty(result)){
			response.setNextVal(result);
		}
		return response.build();
	}

}
