package nta.med.service.ihis.handler.inps;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp2001Repository;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP2001U02ProcessJunipRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP2001U02ProcessJunipResponse;

@Service
@Scope("prototype")
public class INP2001U02ProcessJunipHandler extends
		ScreenHandler<InpsServiceProto.INP2001U02ProcessJunipRequest, InpsServiceProto.INP2001U02ProcessJunipResponse> {

	@Resource
	private Inp2001Repository inp2001Repository;
	
	@Override
	@Transactional
	public INP2001U02ProcessJunipResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP2001U02ProcessJunipRequest request) throws Exception {
		
		InpsServiceProto.INP2001U02ProcessJunipResponse.Builder response = InpsServiceProto.INP2001U02ProcessJunipResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String jobGubun = request.getInput1();
		Double pkInp1001 = CommonUtils.parseDouble(request.getInput2());
		Double pkOcs1003 = CommonUtils.parseDouble(request.getInput3());
		String userId = request.getInput4();
		
		String result = inp2001Repository.callPrOcsTransOrder(hospCode, jobGubun, pkInp1001, pkOcs1003, userId);
		
		response.setOutlist(result);
		return response.build();
	}

}
