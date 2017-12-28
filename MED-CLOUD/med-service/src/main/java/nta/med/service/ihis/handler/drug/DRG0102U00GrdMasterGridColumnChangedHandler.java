package nta.med.service.ihis.handler.drug;

import javax.annotation.Resource;

import nta.med.data.dao.medi.inv.Inv0101Repository;
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
public class DRG0102U00GrdMasterGridColumnChangedHandler extends ScreenHandler<DrugServiceProto.DRG0102U00GrdMasterGridColumnChangedRequest, DrugServiceProto.DRG0102U00GrdMasterGridColumnChangedResponse> {
	private static final Log LOG = LogFactory.getLog(DRG0102U00GrdMasterGridColumnChangedHandler.class);
	@Resource
	private Inv0101Repository inv0101Repository;

	@Override
	@Transactional(readOnly = true)
	public DrugServiceProto.DRG0102U00GrdMasterGridColumnChangedResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			DrugServiceProto.DRG0102U00GrdMasterGridColumnChangedRequest request) throws Exception {
		DrugServiceProto.DRG0102U00GrdMasterGridColumnChangedResponse.Builder response = DrugServiceProto.DRG0102U00GrdMasterGridColumnChangedResponse.newBuilder();
		String result = inv0101Repository.checkDRG0102U00GrdMasterGridColumnChanged(request.getCodeType(), getLanguage(vertx, sessionId));
        if(!StringUtils.isEmpty(result)) {
    		response.setX(result);
        }
		return response.build();
	}
}
