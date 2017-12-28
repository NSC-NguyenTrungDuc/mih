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
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.ocsi.OCS2003Q02grdNotActingInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q02grdNotActingRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q02grdNotActingResponse;

@Service
@Scope("prototype")
public class OCS2003Q02grdNotActingHandler extends
		ScreenHandler<OcsiServiceProto.OCS2003Q02grdNotActingRequest, OcsiServiceProto.OCS2003Q02grdNotActingResponse> {

	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional
	public OCS2003Q02grdNotActingResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003Q02grdNotActingRequest request) throws Exception {
		
		OcsiServiceProto.OCS2003Q02grdNotActingResponse.Builder response = OcsiServiceProto.OCS2003Q02grdNotActingResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<OCS2003Q02grdNotActingInfo> listInfo = ocs2003Repository.getOCS2003Q02grdNotActingInfo(hospCode, language,
				request.getBunho(), request.getHoDong(), request.getGwa(), request.getDoctor(), request.getTimeGubun(), request.getOrderDate(),
				request.getInputGubun(), request.getOrderGubun());
		
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (OCS2003Q02grdNotActingInfo info : listInfo) {
			OcsiModelProto.OCS2003Q02grdNotActingInfo.Builder pInfo = OcsiModelProto.OCS2003Q02grdNotActingInfo.newBuilder();
			BeanUtils.copyProperties(info, pInfo, language);
			response.addGrdMasterItem(pInfo);
		}
		
		return response.build();
	}

	
}
