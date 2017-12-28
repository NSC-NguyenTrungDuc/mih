package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0503Repository;
import nta.med.data.model.ihis.ocso.OCS2016GetLinkingDepartmentInfo;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCS2016GetLinkingDepartmentRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.OCS2016GetLinkingDepartmentResponse;

@Service
@Scope("prototype")
public class OCS2016GetLinkingDepartmentHandler extends
		ScreenHandler<OcsoServiceProto.OCS2016GetLinkingDepartmentRequest, OcsoServiceProto.OCS2016GetLinkingDepartmentResponse> {

	@Resource
	private Ocs0503Repository ocs0503Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS2016GetLinkingDepartmentResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2016GetLinkingDepartmentRequest request) throws Exception {
		
		OcsoServiceProto.OCS2016GetLinkingDepartmentResponse.Builder response = OcsoServiceProto.OCS2016GetLinkingDepartmentResponse.newBuilder();
		String hospCode = request.getHospCode();
		String language = getLanguage(vertx, sessionId);
		String find1 = request.getFind1();
		
		List<OCS2016GetLinkingDepartmentInfo> listOCS2016GetLinkingDepartmentInfo = ocs0503Repository.getListOCS2016GetLinkingDepartmentInfo(hospCode, language, find1);
		for (OCS2016GetLinkingDepartmentInfo item : listOCS2016GetLinkingDepartmentInfo) {
			OcsoModelProto.OCS2016GetLinkingDepartmentInfo.Builder info = OcsoModelProto.OCS2016GetLinkingDepartmentInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addDepartmentInfo(info);
		}
		
		return response.build();
	}

}
