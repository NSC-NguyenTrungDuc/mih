package nta.med.service.ihis.handler.injs;

import javax.annotation.Resource;

import nta.med.data.dao.medi.inj.Inj0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class INJ0101U00GrdMasterGridColumnChangedHandler extends ScreenHandler<InjsServiceProto.INJ0101U00GrdMasterGridColumnChangedRequest, InjsServiceProto.INJ0101U00GrdMasterGridColumnChangedResponse> {
	private static final Log LOG = LogFactory.getLog(INJ0101U00GrdMasterGridColumnChangedHandler.class);
	@Resource
	private Inj0101Repository inj0101Repository;

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ0101U00GrdMasterGridColumnChangedResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ0101U00GrdMasterGridColumnChangedRequest request) throws Exception {
		InjsServiceProto.INJ0101U00GrdMasterGridColumnChangedResponse.Builder response = InjsServiceProto.INJ0101U00GrdMasterGridColumnChangedResponse.newBuilder();
		String result = inj0101Repository.checkINJ0101U00GrdMasterGridColumnChanged(request.getCodeType(), getLanguage(vertx, sessionId));
        if (!StringUtils.isEmpty(result)) {
	            response.setYValue(result);
        }
		return response.build();
	}	
}
