package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1017Repository;
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
public class NuriNUR1017U00GetYHandler  extends ScreenHandler<NuriServiceProto.NuriNUR1017U00GetYRequest, NuriServiceProto.NuriNUR1017U00GetYResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuriNUR1017U00GetYHandler.class);
	
	@Resource
	private Nur1017Repository nur1017Repository;

	@Override
	public boolean isValid(NuriServiceProto.NuriNUR1017U00GetYRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NuriNUR1017U00GetYResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NuriNUR1017U00GetYRequest request) throws Exception {
		NuriServiceProto.NuriNUR1017U00GetYResponse.Builder response = NuriServiceProto.NuriNUR1017U00GetYResponse.newBuilder();
		String nuriGetY = nur1017Repository.getNuriNUR1017U00GetY(getHospitalCode(vertx, sessionId), request.getInfeCode(), request.getBunho(), request.getStartDate());
   	 	if(!StringUtils.isEmpty(nuriGetY)){
   	 		response.setYValue(nuriGetY);
   	 	}
		return response.build();
	}
}
