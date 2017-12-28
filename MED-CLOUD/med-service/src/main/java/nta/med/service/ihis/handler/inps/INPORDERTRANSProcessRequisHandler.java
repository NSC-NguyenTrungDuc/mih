package nta.med.service.ihis.handler.inps;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.inp.Inp1002Repository;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSProcessRequisRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
@Transactional
public class INPORDERTRANSProcessRequisHandler extends ScreenHandler<InpsServiceProto.INPORDERTRANSProcessRequisRequest, SystemServiceProto.UpdateResponse>{
	@Resource
	private Inp1001Repository inp1001Repository;
	@Resource
	private Inp1002Repository inp1002Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPORDERTRANSProcessRequisRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		Double pk1001 = CommonUtils.parseDouble(request.getPkINP1001());
		Integer updateInp1001 = inp1001Repository.oRDERTRANProcessRequiUpdateInp1001(hospCode, pk1001);
		if(updateInp1001 < 0){
			response.setMsg("Not found item on inp1001");
			response.setResult(false);
			throw new ExecutionException(response.build());
		}
		Integer updateInp1002 = inp1002Repository.oRDERTRANProcessRequiUpdateInp1002(hospCode, request.getGubun(), pk1001, request.getPkinp1002());
		if(updateInp1002 < 0){
			response.setMsg("Not found item on inp1002");
			response.setResult(false);
			throw new ExecutionException(response.build());
		}
		response.setResult(true);
		return response.build();
	}

}
