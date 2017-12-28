package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01GetChuciInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
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
public class OcsoOCS1003P01GetChuciHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01GetChuciRequest, OcsoServiceProto.OcsoOCS1003P01GetChuciResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01GetChuciHandler.class);

	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01GetChuciResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01GetChuciRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01GetChuciResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01GetChuciResponse.newBuilder();
		List<OcsoOCS1003P01GetChuciInfo> listObject = ocs0132Repository.getOcsoOCS1003P01GetChuciInfo(getHospitalCode(vertx, sessionId), request.getCodeType(), request.getValuePoint());
		if (listObject != null && !listObject.isEmpty()) {
			for (OcsoOCS1003P01GetChuciInfo obj : listObject) {
				OcsoModelProto.OcsoOCS1003P01GetChuciInfo.Builder itemBuilder = OcsoModelProto.OcsoOCS1003P01GetChuciInfo.newBuilder();
				if (!StringUtils.isEmpty(obj.getCode())) {
					itemBuilder.setCode(obj.getCode());
				}
				if (!StringUtils.isEmpty(obj.getGroupKey())) {
					itemBuilder.setGroupKey(obj.getGroupKey());
				}
				response.addChuciItem(itemBuilder);
			}
		}
		return response.build();
	}
}
