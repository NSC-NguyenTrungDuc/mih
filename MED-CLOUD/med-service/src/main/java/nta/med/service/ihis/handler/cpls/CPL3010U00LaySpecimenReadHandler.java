package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00LaySpecimenReadRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00LaySpecimenReadResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3010U00LaySpecimenReadHandler extends ScreenHandler <CplsServiceProto.CPL3010U00LaySpecimenReadRequest, CplsServiceProto.CPL3010U00LaySpecimenReadResponse> {
	@Resource
	private Cpl0101Repository cpl0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3010U00LaySpecimenReadResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3010U00LaySpecimenReadRequest request) throws Exception {
	    CplsServiceProto.CPL3010U00LaySpecimenReadResponse.Builder response = CplsServiceProto.CPL3010U00LaySpecimenReadResponse.newBuilder();
		String yValue = cpl0101Repository.getCPL3010U00InitializeYValue(getHospitalCode(vertx, sessionId), request.getSpecimenSer());
	    if(!StringUtils.isEmpty(yValue)) {
	    	response.setYValue(yValue);
	    }
	    return response.build();
	}
}
