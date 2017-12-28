package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur7001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuriNUR7001U00GetMaxSeqInNUR7001Handler extends ScreenHandler<NuriServiceProto.NuriNUR7001U00GetMaxSeqInNUR7001Request, NuriServiceProto.NuriNUR7001U00GetMaxSeqInNUR7001Response> {
	private static final Log LOG = LogFactory.getLog(NuriNUR7001U00GetMaxSeqInNUR7001Handler.class);
	@Resource
	private Nur7001Repository nur7001Repository;
	
	@Override
	public boolean isValid(NuriServiceProto.NuriNUR7001U00GetMaxSeqInNUR7001Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getMeasureDate()) && DateUtil.toDate(request.getMeasureDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NuriNUR7001U00GetMaxSeqInNUR7001Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NuriNUR7001U00GetMaxSeqInNUR7001Request request) throws Exception {
		NuriServiceProto.NuriNUR7001U00GetMaxSeqInNUR7001Response.Builder response = NuriServiceProto.NuriNUR7001U00GetMaxSeqInNUR7001Response.newBuilder();
		String result = nur7001Repository.getNuriNUR7001U00GetMaxSeqInNUR7001(getHospitalCode(vertx, sessionId), request.getBunho(), request.getMeasureDate());
        response.setBunho(result);
		return response.build();
	}
	
}
