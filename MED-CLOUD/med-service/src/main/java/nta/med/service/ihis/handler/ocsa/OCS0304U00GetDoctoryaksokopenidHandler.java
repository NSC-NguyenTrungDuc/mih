package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0130Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0304U00GetDoctoryaksokopenidRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0304U00GetDoctoryaksokopenidResponse;

@Service
@Scope("prototype")
public class OCS0304U00GetDoctoryaksokopenidHandler extends ScreenHandler<OcsaServiceProto.OCS0304U00GetDoctoryaksokopenidRequest, OcsaServiceProto.OCS0304U00GetDoctoryaksokopenidResponse>{
	private static final Log LOGGER = LogFactory.getLog(OCS0304U00GetDoctoryaksokopenidHandler.class);
	@Resource
	private Ocs0130Repository ocs0130Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS0304U00GetDoctoryaksokopenidResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OCS0304U00GetDoctoryaksokopenidRequest request) throws Exception {
		OcsaServiceProto.OCS0304U00GetDoctoryaksokopenidResponse.Builder response = OcsaServiceProto.OCS0304U00GetDoctoryaksokopenidResponse.newBuilder();
		String result = ocs0130Repository.getOCS0304U00GetDoctorYaksokOpenId(getHospitalCode(vertx, sessionId), request.getDoctor());
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
		info.setDataValue(result);
		response.addRetvalItem(info);
		return response.build();
	}

}
