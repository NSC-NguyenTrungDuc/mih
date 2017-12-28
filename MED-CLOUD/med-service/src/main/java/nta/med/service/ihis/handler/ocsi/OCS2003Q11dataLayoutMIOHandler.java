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
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.ocsi.OCS2003Q11dataLayoutMIOInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q11dataLayoutMIORequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q11dataLayoutMIOResponse;

@Service
@Scope("prototype")
public class OCS2003Q11dataLayoutMIOHandler extends ScreenHandler<OcsiServiceProto.OCS2003Q11dataLayoutMIORequest, OcsiServiceProto.OCS2003Q11dataLayoutMIOResponse>{
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2003Q11dataLayoutMIOResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003Q11dataLayoutMIORequest request) throws Exception {
		OcsiServiceProto.OCS2003Q11dataLayoutMIOResponse.Builder response = OcsiServiceProto.OCS2003Q11dataLayoutMIOResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<OCS2003Q11dataLayoutMIOInfo> layList = ocs2003Repository.getOCS2003Q11dataLayoutMIOInfo(hospCode, language, request.getHoDong(), request.getSession(), request.getHoTeam()
				, DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD));
		
		if(!CollectionUtils.isEmpty(layList)){
			for(OCS2003Q11dataLayoutMIOInfo item : layList){
				OcsiModelProto.OCS2003Q11dataLayoutMIOInfo.Builder info = OcsiModelProto.OCS2003Q11dataLayoutMIOInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDatalayoutItem(info);
			}
		}
		return response.build();
	}
}
