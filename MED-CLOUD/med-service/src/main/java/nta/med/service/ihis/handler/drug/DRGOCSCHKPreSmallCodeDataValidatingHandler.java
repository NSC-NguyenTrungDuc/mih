package nta.med.service.ihis.handler.drug;

import javax.annotation.Resource;

import nta.med.data.dao.medi.drg.Drg0140Repository;
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
public class DRGOCSCHKPreSmallCodeDataValidatingHandler extends ScreenHandler<DrugServiceProto.DRGOCSCHKPreSmallCodeDataValidatingRequest, DrugServiceProto.DRGOCSCHKPreSmallCodeDataValidatingResponse> {
	private static final Log LOG = LogFactory.getLog(DRGOCSCHKPreSmallCodeDataValidatingHandler.class);
	@Resource
	private Drg0140Repository drg0140Repository;

	@Override
	@Transactional(readOnly = true)
	public DrugServiceProto.DRGOCSCHKPreSmallCodeDataValidatingResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			DrugServiceProto.DRGOCSCHKPreSmallCodeDataValidatingRequest request) throws Exception {
		DrugServiceProto.DRGOCSCHKPreSmallCodeDataValidatingResponse.Builder response = DrugServiceProto.DRGOCSCHKPreSmallCodeDataValidatingResponse.newBuilder();
		String result = drg0140Repository.getDRGOCSCHKPreSmallCodeDataValidating(getHospitalCode(vertx, sessionId), request.getCode(), getLanguage(vertx, sessionId));
        if(!StringUtils.isEmpty(result)) {
    		response.setCodeName(result);
        }
		return response.build();
	}
}
