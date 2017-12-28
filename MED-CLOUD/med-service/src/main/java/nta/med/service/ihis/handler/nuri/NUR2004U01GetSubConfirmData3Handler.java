package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U01GetSubConfirmData3Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U01GetSubConfirmData3Response;

@Service
@Scope("prototype")
public class NUR2004U01GetSubConfirmData3Handler extends
		ScreenHandler<NuriServiceProto.NUR2004U01GetSubConfirmData3Request, NuriServiceProto.NUR2004U01GetSubConfirmData3Response> {
	
	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional
	public NUR2004U01GetSubConfirmData3Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U01GetSubConfirmData3Request request) throws Exception {
		
		NuriServiceProto.NUR2004U01GetSubConfirmData3Response.Builder response = NuriServiceProto.NUR2004U01GetSubConfirmData3Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String result = inp1001Repository.getNUR2004U01GetSubConfirmData3(hospCode, request.getToHoDong1(), request.getToHoCode1(),
				request.getToBedNo(), request.getBunho(), request.getChangeGubun());
		
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
		info.setDataValue(result);
		response.setRtnValue(info);
		
		return response.build();
	}

}
