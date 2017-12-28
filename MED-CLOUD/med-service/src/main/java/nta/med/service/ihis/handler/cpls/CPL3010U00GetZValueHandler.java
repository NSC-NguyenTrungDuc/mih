package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00GetZValueRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00GetZValueResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3010U00GetZValueHandler extends ScreenHandler <CplsServiceProto.CPL3010U00GetZValueRequest, CplsServiceProto.CPL3010U00GetZValueResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3010U00GetZValueResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL3010U00GetZValueRequest request)
			throws Exception{
	    CplsServiceProto.CPL3010U00GetZValueResponse.Builder response = CplsServiceProto.CPL3010U00GetZValueResponse.newBuilder();
	    String result = cpl2010Repository.getCPL3010U00GetZValue(getHospitalCode(vertx, sessionId), request.getSpecimenSer());
		if (!StringUtils.isEmpty(result)) {
			response.setZValue(result);
		}
		return response.build();
	}
}
