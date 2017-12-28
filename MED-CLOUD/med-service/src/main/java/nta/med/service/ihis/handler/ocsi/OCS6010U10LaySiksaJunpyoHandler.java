package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs6010Repository;
import nta.med.data.model.ihis.ocsi.OCS6010U10LaySiksaJunpyoInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10LaySiksaJunpyoRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10LaySiksaJunpyoResponse;

@Service
@Scope("prototype")
public class OCS6010U10LaySiksaJunpyoHandler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10LaySiksaJunpyoRequest, OcsiServiceProto.OCS6010U10LaySiksaJunpyoResponse> {

	@Resource
	private Ocs6010Repository ocs6010Repository;
	
	@Override
	public OCS6010U10LaySiksaJunpyoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10LaySiksaJunpyoRequest request) throws Exception {
		OcsiServiceProto.OCS6010U10LaySiksaJunpyoResponse.Builder response = OcsiServiceProto.OCS6010U10LaySiksaJunpyoResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<OCS6010U10LaySiksaJunpyoInfo> listInfo = ocs6010Repository.getOCS6010U10LaySiksaJunpyoInfo(hospCode
				, language
				, request.getBunho()
				, DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD)
				, DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD)
				, CommonUtils.parseDouble(request.getFkinp1001())
				, request.getInputGubun()
				, CommonUtils.parseDouble(request.getPkSeq()));
		
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (OCS6010U10LaySiksaJunpyoInfo info : listInfo) {
			OcsiModelProto.OCS6010U10LaySiksaJunpyoInfo.Builder pInfo = OcsiModelProto.OCS6010U10LaySiksaJunpyoInfo.newBuilder();
			BeanUtils.copyProperties(info, pInfo, language);
			response.addLayList(pInfo);
		}
		
		return response.build();
	}

}
