package nta.med.service.ihis.handler.injs;

import javax.annotation.Resource;

import nta.med.data.dao.medi.inj.Inj0102Repository;
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
public class INJ0101U00GrdDetailGridColumnChangedHandler extends ScreenHandler<InjsServiceProto.INJ0101U00GrdDetailGridColumnChangedRequest, InjsServiceProto.INJ0101U00GrdDetailGridColumnChangedResponse> {
	private static final Log LOG = LogFactory.getLog(INJ0101U00GrdDetailGridColumnChangedHandler.class);
	@Resource
	private Inj0102Repository inj0102Repository;
	
	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ0101U00GrdDetailGridColumnChangedResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ0101U00GrdDetailGridColumnChangedRequest request) throws Exception {
		 InjsServiceProto.INJ0101U00GrdDetailGridColumnChangedResponse.Builder response = InjsServiceProto.INJ0101U00GrdDetailGridColumnChangedResponse.newBuilder();
		 String result = inj0102Repository.checkINJ0101U00GrdDetailGridColumnChanged(getHospitalCode(vertx, sessionId), request.getCodeType(), request.getCode(), getLanguage(vertx, sessionId));
         if (!StringUtils.isEmpty(result)) {
		      response.setYValue(result);
         }
		return response.build();
	}
}
