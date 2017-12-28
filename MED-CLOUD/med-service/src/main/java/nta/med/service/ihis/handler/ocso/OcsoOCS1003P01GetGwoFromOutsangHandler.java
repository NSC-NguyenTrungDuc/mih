package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.OutsangRepository;
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
public class OcsoOCS1003P01GetGwoFromOutsangHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01GetGwoFromOutsangRequest, OcsoServiceProto.OcsoOCS1003P01GetGwoFromOutsangResponse> {
private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01GetGwoFromOutsangHandler.class);
	
	@Resource
	private OutsangRepository outsangRepository;

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01GetGwoFromOutsangResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01GetGwoFromOutsangRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01GetGwoFromOutsangResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01GetGwoFromOutsangResponse.newBuilder();
		String result = getOcsoOCS1003P01GetGwoFromOutsang(request, getHospitalCode(vertx, sessionId));
		if(!StringUtils.isEmpty(result)){
			response.setGwa(result);
		}
		return response.build();
	}
	
	public String getOcsoOCS1003P01GetGwoFromOutsang(OcsoServiceProto.OcsoOCS1003P01GetGwoFromOutsangRequest request, String hospCode){
		Double pkoutsang = CommonUtils.parseDouble(request.getPkOutSang());
		String result = outsangRepository.getOcsoOCS1003P01GetGwoFromOutsang(hospCode, pkoutsang);
		return result;
	}
}
