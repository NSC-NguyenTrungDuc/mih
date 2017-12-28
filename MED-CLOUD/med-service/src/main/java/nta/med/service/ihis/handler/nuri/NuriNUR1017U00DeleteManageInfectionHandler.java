package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur1017Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class NuriNUR1017U00DeleteManageInfectionHandler extends ScreenHandler<NuriServiceProto.NuriNUR1017U00DeleteManageInfectionRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuriNUR1017U00DeleteManageInfectionHandler.class);
	@Resource
	private Nur1017Repository nur1017Repository;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NuriNUR1017U00DeleteManageInfectionRequest request) throws Exception {
	    SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
	    Double pkNur107 = CommonUtils.parseDouble(request.getPknur1017());
	    Integer result = nur1017Repository.deleteNuriNUR1017U00ManageInfection(request.getUserId(), getHospitalCode(vertx, sessionId), pkNur107);
	    response.setResult(result != null && result > 0);
		return response.build();
	}
}
