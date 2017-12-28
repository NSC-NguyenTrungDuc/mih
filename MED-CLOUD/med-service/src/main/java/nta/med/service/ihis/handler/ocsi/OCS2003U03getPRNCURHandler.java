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
import nta.med.data.model.ihis.ocsi.OCS2003U03getPRNCURInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03getPRNCURRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03getPRNCURResponse;

@Service
@Scope("prototype")
public class OCS2003U03getPRNCURHandler extends ScreenHandler<OcsiServiceProto.OCS2003U03getPRNCURRequest, OcsiServiceProto.OCS2003U03getPRNCURResponse>{
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2003U03getPRNCURResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U03getPRNCURRequest request) throws Exception {
		OcsiServiceProto.OCS2003U03getPRNCURResponse.Builder response = OcsiServiceProto.OCS2003U03getPRNCURResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<OCS2003U03getPRNCURInfo> layList = ocs2003Repository.getOCS2003U03getPRNCURInfo(hospCode, language, request.getJubsuDate(), request.getDrgBunho());
		
		if(!CollectionUtils.isEmpty(layList)){
			for(OCS2003U03getPRNCURInfo item : layList){
				OcsiModelProto.OCS2003U03getPRNCURInfo.Builder info = OcsiModelProto.OCS2003U03getPRNCURInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListPRNCUR(info);
			}
		}
		return response.build();
	}
}
