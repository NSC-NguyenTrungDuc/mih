package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.phy.Phy8003Repository;
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
public class OcsoOCS1003P01CheckUsedSangHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01CheckUsedSangRequest, OcsoServiceProto.OcsoOCS1003P01CheckUsedSangResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01CheckUsedSangHandler.class);
	
	@Resource
	private Phy8003Repository phy8003Repository;
	
	public String getOcsoOCS1003P01CheckUsedSang(OcsoServiceProto.OcsoOCS1003P01CheckUsedSangRequest request, String hospCode){
			Double fkoutsang = CommonUtils.parseDouble(request.getFkOutSang());
			String result = phy8003Repository.getOcsoOCS1003P01CheckUsedSang(hospCode, fkoutsang);
			return result;
	}
	
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01CheckUsedSangResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01CheckUsedSangRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01CheckUsedSangResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01CheckUsedSangResponse.newBuilder();
		String result = getOcsoOCS1003P01CheckUsedSang(request, getHospitalCode(vertx, sessionId));
		if(!StringUtils.isEmpty(result)){
			response.setResult(result);
		}
		return response.build();
	}

}
