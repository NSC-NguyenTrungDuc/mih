package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs6010Repository;
import nta.med.data.model.ihis.ocsi.OCS6010U10LayQueryLayoutInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10LayQueryLayoutRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10LayQueryLayoutResponse;

@Service
@Scope("prototype")
public class OCS6010U10LayQueryLayoutHandler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10LayQueryLayoutRequest, OcsiServiceProto.OCS6010U10LayQueryLayoutResponse> {

	@Resource
	private Ocs6010Repository ocs6010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS6010U10LayQueryLayoutResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10LayQueryLayoutRequest request) throws Exception {
		
		OcsiServiceProto.OCS6010U10LayQueryLayoutResponse.Builder response = OcsiServiceProto.OCS6010U10LayQueryLayoutResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<OCS6010U10LayQueryLayoutInfo> listInfo = ocs6010Repository.getOCS6010U10LayQueryLayoutInfo(hospCode
				, language
				, request.getBunho()
				, CommonUtils.parseDouble(request.getFkinp1001())
				, DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD)
				, request.getQueryGubun()
				, request.getInputDoctor()
				, request.getInputGubun());
		
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (OCS6010U10LayQueryLayoutInfo info : listInfo) {
			OcsiModelProto.OCS6010U10LayQueryLayoutInfo.Builder pInfo = OcsiModelProto.OCS6010U10LayQueryLayoutInfo.newBuilder();
			BeanUtils.copyProperties(info, pInfo, language);
			response.addLayList(pInfo);
		}
		
		return response.build();
	}

	
	
}
