package nta.med.service.ihis.handler.xrts;

import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Transactional
@Service
@Scope("prototype")
public class XRT7001Q01CboPartHandler extends ScreenHandler<XrtsServiceProto.XRT7001Q01CboPartRequest, XrtsServiceProto.XRT7001Q01CboPartResponse> {
	private static final Log LOGGER = LogFactory.getLog(XRT7001Q01CboPartHandler.class);
	@Resource
	private Ocs0132Repository ocs0132Repository;

	@Override
	public XrtsServiceProto.XRT7001Q01CboPartResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT7001Q01CboPartRequest request) throws Exception {
		//TODO
		return null;
	}
}
