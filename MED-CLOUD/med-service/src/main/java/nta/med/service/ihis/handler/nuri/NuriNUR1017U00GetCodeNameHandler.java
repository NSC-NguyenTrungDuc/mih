package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

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
public class NuriNUR1017U00GetCodeNameHandler extends ScreenHandler<NuriServiceProto. NuriNUR1017U00GetCodeNameRequest, NuriServiceProto. NuriNUR1017U00GetCodeNameResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuriNUR1017U00GetCodeNameHandler.class);
	
	@Resource
	private Nur1017Repository nur1017Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto. NuriNUR1017U00GetCodeNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto. NuriNUR1017U00GetCodeNameRequest request) throws Exception {
		NuriServiceProto. NuriNUR1017U00GetCodeNameResponse.Builder response = NuriServiceProto.NuriNUR1017U00GetCodeNameResponse.newBuilder();
		String nuriGetCodeName = nur1017Repository.getNuriNUR1017U00GetCodeName(getHospitalCode(vertx, sessionId), request.getCodeType(),request.getInfeCode(), getLanguage(vertx, sessionId));
		if(!StringUtils.isEmpty(nuriGetCodeName)){
			response.setCodeNameValue(nuriGetCodeName);
		}
		return response.build();
	}
}
