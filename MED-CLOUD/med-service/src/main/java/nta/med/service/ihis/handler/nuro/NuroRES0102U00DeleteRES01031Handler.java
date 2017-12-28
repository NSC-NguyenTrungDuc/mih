package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class NuroRES0102U00DeleteRES01031Handler extends ScreenHandler<NuroServiceProto.NuroRES0102U00DeleteRES0103Req1Request, SystemServiceProto.UpdateResponse>{
	private static final Log logger = LogFactory.getLog(NuroRES0102U00DeleteRES01031Handler.class);
	
	@Resource
	private Res0103Repository res0103Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroRES0102U00DeleteRES0103Req1Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getJinryoPreDate()) && DateUtil.toDate(request.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00DeleteRES0103Req1Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = deleteRES0103(request, getHospitalCode(vertx, sessionId));
		response.setResult(result);
		return response.build();
	}
	
	private boolean deleteRES0103(NuroServiceProto.NuroRES0102U00DeleteRES0103Req1Request request, String hospCode){
		if( res0103Repository.deleteRES0104Request1(hospCode, request.getDoctor(), request.getJinryoPreDate()) > 0)
			return true;
		return false;
	}
}
