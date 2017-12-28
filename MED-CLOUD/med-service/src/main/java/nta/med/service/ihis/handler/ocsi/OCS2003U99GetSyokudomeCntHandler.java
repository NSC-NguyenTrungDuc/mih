package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0101Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U99GetSyokudomeCntRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS2003U99GetSyokudomeCntHandler extends ScreenHandler<OcsiServiceProto.OCS2003U99GetSyokudomeCntRequest, SystemServiceProto.StringResponse> {
	@Resource
	private Ocs0101Repository ocs0101Repository;
	
	@Override
	@Transactional(readOnly=true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U99GetSyokudomeCntRequest request) throws Exception {
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String fkinp1001 = request.getFkinp1001();
		String kijunDate = request.getKijunDate();
		
		String strData = ocs0101Repository.getOCS2003U99GetSyokudomeCnt(hospCode, fkinp1001, kijunDate);
		
		if (!StringUtils.isEmpty(strData)) {
			response.setResult(strData);
		}

		return response.build();
	}
	

}
