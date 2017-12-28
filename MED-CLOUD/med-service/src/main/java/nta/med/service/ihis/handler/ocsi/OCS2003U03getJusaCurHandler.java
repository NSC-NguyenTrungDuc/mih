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
import nta.med.data.model.ihis.ocsi.OCS2003U03getJusaCurInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03getJusaCurRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03getJusaCurResponse;

@Service
@Scope("prototype")
public class OCS2003U03getJusaCurHandler extends ScreenHandler<OcsiServiceProto.OCS2003U03getJusaCurRequest, OcsiServiceProto.OCS2003U03getJusaCurResponse>{
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2003U03getJusaCurResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U03getJusaCurRequest request) throws Exception {
		OcsiServiceProto.OCS2003U03getJusaCurResponse.Builder response = OcsiServiceProto.OCS2003U03getJusaCurResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<OCS2003U03getJusaCurInfo> layList = ocs2003Repository.getOCS2003U03getJusaCurInfo(hospCode, language, request.getJubsuDate(), request.getDrgBunho());
		
		if(!CollectionUtils.isEmpty(layList)){
			for(OCS2003U03getJusaCurInfo item : layList){
				OcsiModelProto.OCS2003U03getJusaCurInfo.Builder info = OcsiModelProto.OCS2003U03getJusaCurInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListJusacur(info);
			}
		}
		return response.build();
	}
}
