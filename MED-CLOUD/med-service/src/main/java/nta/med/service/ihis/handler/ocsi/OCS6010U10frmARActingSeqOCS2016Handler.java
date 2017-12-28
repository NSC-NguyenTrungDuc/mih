package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2016Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10frmARActingSeqOCS2016Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS6010U10frmARActingSeqOCS2016Handler extends ScreenHandler<OcsiServiceProto.OCS6010U10frmARActingSeqOCS2016Request, SystemServiceProto.StringResponse> {
	@Resource
	private Ocs2016Repository ocs2016Repository;
	
	@Override
	@Transactional(readOnly=true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10frmARActingSeqOCS2016Request request) throws Exception {
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		Double fkocs2015 = CommonUtils.parseDouble(request.getFFkocs2005());	// fkocs2005 is fkocs2015 ==> wrong name
		
		String strData = ocs2016Repository.getOCS6010U10frmARActingSeqOCS2016(hospCode, fkocs2015);
		
		strData = StringUtils.isEmpty(strData) ? "" : strData;

		if (!StringUtils.isEmpty(strData)) {
			response.setResult(strData);
		}
			
		return response.build();
	}

}
