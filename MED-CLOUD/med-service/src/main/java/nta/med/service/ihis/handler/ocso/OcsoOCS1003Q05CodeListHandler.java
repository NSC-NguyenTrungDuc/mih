package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsoOCS1003Q05CodeListHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003Q05CodeListRequest, OcsoServiceProto.OcsoOCS1003Q05CodeListResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003Q05CodeListHandler.class);

	@Resource
	private Ocs0132Repository ocs0132Repository;

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003Q05CodeListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003Q05CodeListRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003Q05CodeListResponse.Builder response = OcsoServiceProto.OcsoOCS1003Q05CodeListResponse.newBuilder();
		List<String> listObject = ocs0132Repository.getOcsoOCS1003Q05CodeList(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId), request.getCodeType());
		if (listObject != null && !listObject.isEmpty()) {
			for (String obj : listObject) {
				response.addCode(obj);
			}
		}
		return response.build();
	}
}
