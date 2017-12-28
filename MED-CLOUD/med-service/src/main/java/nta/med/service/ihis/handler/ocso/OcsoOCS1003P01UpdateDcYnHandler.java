package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
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
public class OcsoOCS1003P01UpdateDcYnHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01UpdateDcYnRequest, OcsoServiceProto.OcsoOCS1003P01UpdateDcYnResponse> {
		private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01UpdateDcYnHandler.class);
		
		@Resource
		private Ocs1003Repository ocs1003Repository;

		@Override
		@Transactional
		public OcsoServiceProto.OcsoOCS1003P01UpdateDcYnResponse handle(Vertx vertx, String clientId,
				String sessionId, long contextId,
				OcsoServiceProto.OcsoOCS1003P01UpdateDcYnRequest request) throws Exception {
			OcsoServiceProto.OcsoOCS1003P01UpdateDcYnResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01UpdateDcYnResponse.newBuilder();
			Double sourcePkOcs = CommonUtils.parseDouble(request.getSourcePkOcs());
	        String result = ocs1003Repository.callPrOcsUpdateDcYn(getHospitalCode(vertx, sessionId), request.getIoGubun(), sourcePkOcs);
	        response.setIoFlagResult(result);
			return response.build();
		}
}
