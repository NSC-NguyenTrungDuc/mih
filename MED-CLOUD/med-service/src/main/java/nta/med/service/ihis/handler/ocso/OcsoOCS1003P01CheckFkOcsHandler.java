package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.phy.Phy8002Repository;
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
public class OcsoOCS1003P01CheckFkOcsHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01CheckFkOcsRequest, OcsoServiceProto.OcsoOCS1003P01CheckFkOcsResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01CheckFkOcsHandler.class);
	
	@Resource
	private Phy8002Repository phy8002Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01CheckFkOcsResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01CheckFkOcsRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01CheckFkOcsResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01CheckFkOcsResponse.newBuilder();
		Double fkOcs = CommonUtils.parseDouble(request.getFkOcs());
		Double result = phy8002Repository.getOCS0103U11GetFkOcs(getHospitalCode(vertx, sessionId), fkOcs);
		if(result != null){
			response.setFkOcs(result + "");
		} else {
			response.setFkOcs("");
		}
		return response.build();
	}
}
