package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0001U00GrdChangeRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0001U00GrdChangeResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL0001U00GrdChangeHandler extends ScreenHandler<CplsServiceProto.CPL0001U00GrdChangeRequest, CplsServiceProto.CPL0001U00GrdChangeResponse> {
	
	@Resource
	private Cpl0001Repository cpl0001Repository;

	@Override
	@Transactional(readOnly = true)
	public CPL0001U00GrdChangeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL0001U00GrdChangeRequest request)
			throws Exception {
		CPL0001U00GrdChangeResponse.Builder response = CPL0001U00GrdChangeResponse.newBuilder();
		String result = cpl0001Repository.getCPL0101U00FbxSlipCodeName(getHospitalCode(vertx, sessionId), request.getFSlipCode());
		if(!StringUtils.isEmpty(result)){
			response.setY("Y");
		}
		
		return response.build();
	}
}
