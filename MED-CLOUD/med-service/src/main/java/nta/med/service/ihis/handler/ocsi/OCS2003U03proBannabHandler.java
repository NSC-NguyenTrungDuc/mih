package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03proBannabRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS2003U03proBannabHandler extends ScreenHandler<OcsiServiceProto.OCS2003U03proBannabRequest, SystemServiceProto.StringResponse>{
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U03proBannabRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String result = ocs2003Repository.callPrOcsiProcessBannabNew(getHospitalCode(vertx, sessionId), request.getWorkGubun(), request.getBunho(), request.getFkInp1001(), request.getPkOcs2003(), request.getStopDate(), request.getStopDate2(), request.getDoctor(), request.getUserId(), request.getGubun(), request.getBannab(), request.getBogyongCode(), request.getToiwonDv(), request.getToiwonBogyong());
		if (!StringUtils.isEmpty(result))
			response.setResult(result);
		return response.build();
	}

}
