package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsoOCS1003P01GetPkSeq2Handler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01GetPkSeq2Request, OcsoServiceProto.OcsoOCS1003P01GetPkSeqResponse> {
private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01GetPkSeq2Handler.class);
	
	@Resource
	private OutsangRepository outsangRepository;

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01GetPkSeqResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01GetPkSeq2Request request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01GetPkSeqResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01GetPkSeqResponse.newBuilder();
		String result = outsangRepository.getOcsoOCS1003P01GetPkSeq2(getHospitalCode(vertx, sessionId), request.getBunho());
		if(!StringUtils.isEmpty(result)){
			response.setPkSeqValue(result);
		}
		return response.build();
	}
}
