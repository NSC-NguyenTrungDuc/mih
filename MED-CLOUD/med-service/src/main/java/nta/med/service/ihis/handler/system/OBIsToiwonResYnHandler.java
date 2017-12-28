package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OBIsToiwonResYnRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OBIsToiwonResYnResponse;

@Service
@Scope("prototype")
public class OBIsToiwonResYnHandler
		extends ScreenHandler<SystemServiceProto.OBIsToiwonResYnRequest, SystemServiceProto.OBIsToiwonResYnResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public OBIsToiwonResYnResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OBIsToiwonResYnRequest request) throws Exception {
		
		SystemServiceProto.OBIsToiwonResYnResponse.Builder response = SystemServiceProto.OBIsToiwonResYnResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		Double fkinp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		
		List<String> rs = inp1001Repository.getOBIsToiwonResYn(hospCode, fkinp1001);
		if(CollectionUtils.isEmpty(rs)){
			return response.build();
		}
		
		response.setDecodeOut(rs.get(0));
		return response.build();
	}

	
}
