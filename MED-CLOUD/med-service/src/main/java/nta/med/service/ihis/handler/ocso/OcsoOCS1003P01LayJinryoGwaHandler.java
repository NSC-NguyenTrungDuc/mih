package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01LayJinryoGwaInfo;
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
public class OcsoOCS1003P01LayJinryoGwaHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01LayJinryoGwaRequest, OcsoServiceProto.OcsoOCS1003P01LayJinryoGwaResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01LayJinryoGwaHandler.class);

	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01LayJinryoGwaResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01LayJinryoGwaRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01LayJinryoGwaResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01LayJinryoGwaResponse.newBuilder();
		List<OcsoOCS1003P01LayJinryoGwaInfo> listObject = bas0260Repository.getOcsoOCS1003P01LayJinryoGwaInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if (listObject != null && !listObject.isEmpty()) {
			for (OcsoOCS1003P01LayJinryoGwaInfo obj : listObject) {
				OcsoModelProto.OcsoOCS1003P01LayJinryoGwaInfo.Builder itemBuilder = OcsoModelProto.OcsoOCS1003P01LayJinryoGwaInfo.newBuilder();
				if (!StringUtils.isEmpty(obj.getGwaName())) {
					itemBuilder.setGwaName(obj.getGwaName());
				}
				if (!StringUtils.isEmpty(obj.getGwa())) {
					itemBuilder.setGwa(obj.getGwa());
				}
				response.addLayJinryoGwaItem(itemBuilder);
			}
		}
		return response.build();
	}

}
