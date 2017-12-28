package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0108Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0108U00CheckItemGrdMasterRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0108U00CheckItemGrdMasterResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL0108U00CheckItemGrdMasterHandler extends ScreenHandler<CplsServiceProto.CPL0108U00CheckItemGrdMasterRequest, CplsServiceProto.CPL0108U00CheckItemGrdMasterResponse> {
	private static final Log LOGGER = LogFactory.getLog(CPL0108U00CheckItemGrdMasterHandler.class);
	@Resource
	private Cpl0108Repository cpl0108Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL0108U00CheckItemGrdMasterResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL0108U00CheckItemGrdMasterRequest request) throws Exception {
		CplsServiceProto.CPL0108U00CheckItemGrdMasterResponse.Builder response = CplsServiceProto.CPL0108U00CheckItemGrdMasterResponse.newBuilder();
		String result = cpl0108Repository.getCheckItemGrdMaster(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeType());
		if(result != null && !result.isEmpty()){
			response.setCheckItem(result);
		}
		return response.build();
	}
}
