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
import nta.med.data.model.ihis.ocsi.OCS2003Q11layQueryInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q11layQueryRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q11layQueryResponse;

@Service
@Scope("prototype")
public class OCS2003Q11layQueryHandler extends ScreenHandler<OcsiServiceProto.OCS2003Q11layQueryRequest, OcsiServiceProto.OCS2003Q11layQueryResponse>{
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2003Q11layQueryResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003Q11layQueryRequest request) throws Exception {
		OcsiServiceProto.OCS2003Q11layQueryResponse.Builder response = OcsiServiceProto.OCS2003Q11layQueryResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<OCS2003Q11layQueryInfo> layList = ocs2003Repository.getOCS2003Q11layQueryInfo(hospCode, language, request.getQueryDate()
				, request.getHoDong(), request.getHoTeam(), request.getA(), request.getB(), request.getC(), request.getD());
				
		if(!CollectionUtils.isEmpty(layList)){
			for(OCS2003Q11layQueryInfo item : layList){
				OcsiModelProto.OCS2003Q11layQueryInfo.Builder info = OcsiModelProto.OCS2003Q11layQueryInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayItem(info);
			}
		}
		return response.build();
	}
}
