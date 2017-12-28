package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.bas.Bas0102;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OUTSANGU00getCodeNameHandler extends ScreenHandler<OcsoServiceProto.OUTSANGU00getCodeNameRequest, OcsoServiceProto.OUTSANGU00getCodeNameResponse> {
	private static final Log LOGGER = LogFactory.getLog(OUTSANGU00getCodeNameHandler.class);

	@Resource
	private Bas0102Repository  bas0102Repository;

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OUTSANGU00getCodeNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OUTSANGU00getCodeNameRequest request) throws Exception {
		OcsoServiceProto.OUTSANGU00getCodeNameResponse.Builder response = OcsoServiceProto.OUTSANGU00getCodeNameResponse.newBuilder();
		List<Bas0102> result = bas0102Repository.getByCodeAndCodeType(getHospitalCode(vertx, sessionId), request.getCode(), request.getSangEndSayU(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null && result.get(0).getCodeName() != null){
			response.setCodeName(result.get(0).getCodeName());
		}
		return response.build();
	}

}
