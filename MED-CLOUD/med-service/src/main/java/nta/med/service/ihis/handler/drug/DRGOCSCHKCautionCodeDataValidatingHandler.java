package nta.med.service.ihis.handler.drug;

import javax.annotation.Resource;

import nta.med.data.dao.medi.drg.Drg0130Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrugServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class DRGOCSCHKCautionCodeDataValidatingHandler extends ScreenHandler<DrugServiceProto.DRGOCSCHKCautionCodeDataValidatingRequest, DrugServiceProto.DRGOCSCHKCautionCodeDataValidatingResponse> {
	private static final Log LOG = LogFactory.getLog(DRGOCSCHKCautionCodeDataValidatingHandler.class);
	@Resource
	private Drg0130Repository drg0130Repository;

	@Override
	@Transactional(readOnly = true)
	public DrugServiceProto.DRGOCSCHKCautionCodeDataValidatingResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			DrugServiceProto.DRGOCSCHKCautionCodeDataValidatingRequest request) throws Exception {
		 DrugServiceProto.DRGOCSCHKCautionCodeDataValidatingResponse.Builder response = DrugServiceProto.DRGOCSCHKCautionCodeDataValidatingResponse.newBuilder();
		 String result = drg0130Repository.getDRGOCSCHKCautionCodeDataValidating(request.getCautionCode(), getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
         if(!StringUtils.isEmpty(result)) {
     		response.setCautionName(result);
         }
		return response.build();
	}
}
