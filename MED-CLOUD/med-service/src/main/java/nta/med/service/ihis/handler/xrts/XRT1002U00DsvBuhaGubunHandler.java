package nta.med.service.ihis.handler.xrts;

import nta.med.data.dao.medi.cpl.Cpl0108Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class XRT1002U00DsvBuhaGubunHandler extends ScreenHandler<XrtsServiceProto.XRT1002U00DsvBuhaGubunRequest, XrtsServiceProto.XRT0201U00OcsCommonResponse> {
	private static final Log LOGGER = LogFactory.getLog(XRT1002U00DsvBuhaGubunHandler.class);                                    
	@Resource                                                                                                       
	private Cpl0108Repository cpl0108Repository;

	@Override
	@Transactional(readOnly = true)
	public XrtsServiceProto.XRT0201U00OcsCommonResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT1002U00DsvBuhaGubunRequest request) throws Exception {
		//TODO
		return null;
	}
}