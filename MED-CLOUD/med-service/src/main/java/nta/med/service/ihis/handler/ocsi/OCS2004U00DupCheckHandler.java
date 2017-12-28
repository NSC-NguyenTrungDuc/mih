package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.data.model.ihis.ocsi.OCS2004U00DupCheckInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2004U00DupCheckRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2004U00DupCheckResponse;

@Service
@Scope("prototype")
public class OCS2004U00DupCheckHandler extends ScreenHandler<OcsiServiceProto.OCS2004U00DupCheckRequest, OcsiServiceProto.OCS2004U00DupCheckResponse>{
	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2004U00DupCheckResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2004U00DupCheckRequest request) throws Exception {
		
		OcsiServiceProto.OCS2004U00DupCheckResponse.Builder response = OcsiServiceProto.OCS2004U00DupCheckResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String bunho = request.getBunho();
		String fkinp1001 = request.getFkinp1001();
		String inputGubun = request.getInputGubun();
		String directGubun = request.getDirectGubun();
		String directCode = request.getDirectCode();
		String fromDate = request.getFromDate();
		String toDate = request.getToDate();

		List<OCS2004U00DupCheckInfo> comboList = ocs2005Repository.getOCS2004U00DupCheck(hospCode, bunho, fkinp1001, inputGubun, directGubun, directCode, fromDate, toDate);
		if(!CollectionUtils.isEmpty(comboList)){
			for(OCS2004U00DupCheckInfo item : comboList){
				OcsiModelProto.OCS2004U00DupCheckInfo.Builder info = OcsiModelProto.OCS2004U00DupCheckInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListDupcheck(info);
			}
		}
		return response.build();
	}

}
