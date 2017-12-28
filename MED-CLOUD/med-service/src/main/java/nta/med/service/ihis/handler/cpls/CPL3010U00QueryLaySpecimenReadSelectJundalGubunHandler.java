package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00QueryLaySpecimenReadSelectJundalGubunRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00QueryLaySpecimenReadSelectJundalGubunResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3010U00QueryLaySpecimenReadSelectJundalGubunHandler extends ScreenHandler<CplsServiceProto.CPL3010U00QueryLaySpecimenReadSelectJundalGubunRequest, CplsServiceProto.CPL3010U00QueryLaySpecimenReadSelectJundalGubunResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3010U00QueryLaySpecimenReadSelectJundalGubunResponse handle(
			Vertx vertx, String clientId, String sessionId, long contextId,
			CPL3010U00QueryLaySpecimenReadSelectJundalGubunRequest request)
			throws Exception {
        CplsServiceProto.CPL3010U00QueryLaySpecimenReadSelectJundalGubunResponse.Builder response = CplsServiceProto.CPL3010U00QueryLaySpecimenReadSelectJundalGubunResponse.newBuilder();
        List<String> listResult = cpl2010Repository.getCPL3010U00QueryLaySpecimenReadSelectJundalGubun(getHospitalCode(vertx, sessionId), request.getSpecimenSer());
        if(!CollectionUtils.isEmpty(listResult)) {
        	for(String item : listResult) {
        		response.setJundalGubun(item);
        	}
		}
        return response.build();
	}
}
