package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2004U00setFromDateRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2004U00setFromDateResponse;

@Service
@Scope("prototype")
public class OCS2004U00setFromDateHandler extends ScreenHandler<OcsiServiceProto.OCS2004U00setFromDateRequest, OcsiServiceProto.OCS2004U00setFromDateResponse> {
	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2004U00setFromDateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2004U00setFromDateRequest request) throws Exception {
		
		OcsiServiceProto.OCS2004U00setFromDateResponse.Builder response = OcsiServiceProto.OCS2004U00setFromDateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String pkocs2005 = request.getPkocs2005();
		String fkinp1001 = request.getFkinp1001();
		String kijunDate = request.getKijunDate();
		
		String directGubun = request.getDirectGubun();
		String directCode = request.getDirectCode();
		String kijunTime = request.getKijunTime();

		String strDate = ocs2005Repository.getOCS2004U00setFromDate(hospCode, pkocs2005, fkinp1001, kijunDate, directGubun, directCode, kijunTime);
		strDate = StringUtils.isEmpty(strDate) ? "" : strDate;
		
		if (!StringUtils.isEmpty(strDate)) {
			response.setDate(strDate);
		}
			
		return response.build();
	}

}
