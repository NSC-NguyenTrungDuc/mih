package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs1003Repository;
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
public class OcsoOCS1003P01GetOcsKeySeqHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01GetOcsKeySeqRequest, OcsoServiceProto.OcsoOCS1003P01GetOcsKeySeqResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01GetOcsKeySeqHandler.class);
	
	@Resource
	private Ocs1003Repository ocs1003Repository;

	@Override
	@Transactional
	public OcsoServiceProto.OcsoOCS1003P01GetOcsKeySeqResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01GetOcsKeySeqRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01GetOcsKeySeqResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01GetOcsKeySeqResponse.newBuilder();
		String result = ocs1003Repository.getOcsoOCS1003P01GetOcsKeySeq();
		if(!StringUtils.isEmpty(result)){
			response.setOcsKeyValue(result);
		}
		return response.build();
	}
}
