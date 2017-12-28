package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03getResDateRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS2003U03getResDateHandler extends ScreenHandler<OcsiServiceProto.OCS2003U03getResDateRequest, SystemServiceProto.StringResponse>{
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U03getResDateRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String result = ocs2003Repository.getOCS2003U03getResDateinfo(getHospitalCode(vertx, sessionId), request.getBunho(), request.getPkOcs2003(), request.getKijunDate());
		if (!StringUtils.isEmpty(result)) {
			response.setResult(DateUtil.toString(DateUtil.toDate(result, DateUtil.PATTERN_YYMMDD), DateUtil.PATTERN_YYMMDD));
		} else {
			response.setResult("");
		}
		
		return response.build();
	}

}
