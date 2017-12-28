package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0108U00CheckItemGrdDetailRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0108U00CheckItemGrdDetailResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class CPL0108U00CheckItemGrdDetailHandler extends ScreenHandler<CplsServiceProto.CPL0108U00CheckItemGrdDetailRequest, CplsServiceProto.CPL0108U00CheckItemGrdDetailResponse> {
	private static final Log LOGGER = LogFactory.getLog(CPL0108U00CheckItemGrdDetailHandler.class);
	@Resource
	private Cpl0109Repository cpl0109Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL0108U00CheckItemGrdDetailResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL0108U00CheckItemGrdDetailRequest request) throws Exception {
		CplsServiceProto.CPL0108U00CheckItemGrdDetailResponse.Builder response = CplsServiceProto.CPL0108U00CheckItemGrdDetailResponse.newBuilder();
		String result = cpl0109Repository.getCheckItemGrdDetail(getHospitalCode(vertx, sessionId), request.getCode(), request.getCodeType(), getLanguage(vertx, sessionId));
		if(result != null && !result.isEmpty()){
			response.setCheckItem(result);
		}
		return response.build();
	}
}
