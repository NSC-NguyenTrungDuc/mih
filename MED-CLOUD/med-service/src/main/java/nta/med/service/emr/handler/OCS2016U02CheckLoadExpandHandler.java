package nta.med.service.emr.handler;


import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.service.emr.proto.EmrServiceProto;

/**
 * @author DEV-NgocNV
 *
 */
@Service
@Scope("prototype")
public class OCS2016U02CheckLoadExpandHandler extends ScreenHandler<EmrServiceProto.OCS2016U02CheckLoadExpandRequest, EmrServiceProto.OCS2016U02CheckLoadExpandResponse>{
	private static final Log LOGGER = LogFactory.getLog(OCS2016U02CheckLoadExpandHandler.class);
	
	@Resource
	private Ocs0132Repository ocs0132Repository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2016U02CheckLoadExpandResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			EmrServiceProto.OCS2016U02CheckLoadExpandRequest request) throws Exception {
		EmrServiceProto.OCS2016U02CheckLoadExpandResponse.Builder response = EmrServiceProto.OCS2016U02CheckLoadExpandResponse.newBuilder();
		String result = ocs0132Repository.getOcsoOCS2016U02CheckY(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!StringUtils.isEmpty(result)){
			response.setResult(result);
		}
		return response.build();
	}

}

