package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsoOCS1003P01GetGubunHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01GetGubunRequest, OcsoServiceProto.OcsoOCS1003P01GetGubunResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01GetGubunHandler.class);

	@Resource
	private Ocs0132Repository ocs0132Repository;

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01GetGubunResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01GetGubunRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01GetGubunResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01GetGubunResponse.newBuilder();
		List<ComboListItemInfo> listObject = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(getHospitalCode(vertx, sessionId), request.getCode(), request.getCodeType(),getLanguage(vertx, sessionId));
		if (listObject != null && !listObject.isEmpty()) {
			for (ComboListItemInfo obj : listObject) {
				OcsoModelProto.OcsoOCS1003P01GetGubunInfo.Builder info = OcsoModelProto.OcsoOCS1003P01GetGubunInfo.newBuilder();
				BeanUtils.copyProperties(obj, info, getLanguage(vertx, sessionId));
				response.addGubunItem(info);
			}
		}
		return response.build();
	}
}
