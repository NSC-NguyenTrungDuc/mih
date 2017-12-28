package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsoOCS1003P01CheckXHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01CheckXRequest, OcsoServiceProto.OcsoOCS1003P01CheckXResponse>{
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01CheckXHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01CheckXResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01CheckXRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01CheckXResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01CheckXResponse.newBuilder();
		Double pkOut1001 = CommonUtils.parseDouble(request.getNaewonKey());
		String result = out1001Repository.getOcsoOCS1003P01CheckX(getHospitalCode(vertx, sessionId), request.getActionDoctor(), request.getBunho(), pkOut1001);
		if(!StringUtils.isEmpty(result)){
			response.setXValue(result);
		}
		return response.build();
	}

}
