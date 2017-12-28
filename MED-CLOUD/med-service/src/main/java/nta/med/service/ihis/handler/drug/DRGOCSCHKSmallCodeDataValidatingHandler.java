package nta.med.service.ihis.handler.drug;

import javax.annotation.Resource;

import nta.med.data.dao.medi.drg.Drg0141Repository;
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
public class DRGOCSCHKSmallCodeDataValidatingHandler extends ScreenHandler<DrugServiceProto.DRGOCSCHKSmallCodeDataValidatingRequest, DrugServiceProto.DRGOCSCHKSmallCodeDataValidatingResponse> {
	private static final Log LOG = LogFactory.getLog(DRGOCSCHKSmallCodeDataValidatingHandler.class);
	@Resource
	private Drg0141Repository drg0141Repository;
	
	@Override
	@Transactional(readOnly = true)
	public DrugServiceProto.DRGOCSCHKSmallCodeDataValidatingResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			DrugServiceProto.DRGOCSCHKSmallCodeDataValidatingRequest request) throws Exception {
		DrugServiceProto.DRGOCSCHKSmallCodeDataValidatingResponse.Builder response = DrugServiceProto.DRGOCSCHKSmallCodeDataValidatingResponse.newBuilder();
		String result = drg0141Repository.getDRGOCSCHKSmallCodeDataValidating(request.getCode1(), getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!StringUtils.isEmpty(result)) {
    		response.setCodeName1(result);
        }
		return response.build();
	}

}
