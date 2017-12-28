package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0253Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U01GetSubConfirmData2Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U01GetSubConfirmData2Response;

@Service
@Scope("prototype")
public class NUR2004U01GetSubConfirmData2Handler extends
		ScreenHandler<NuriServiceProto.NUR2004U01GetSubConfirmData2Request, NuriServiceProto.NUR2004U01GetSubConfirmData2Response> {
	
	@Resource
	private Bas0253Repository bas0253Repository;

	@Override
	@Transactional
	public NUR2004U01GetSubConfirmData2Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U01GetSubConfirmData2Request request) throws Exception {
		
		NuriServiceProto.NUR2004U01GetSubConfirmData2Response.Builder response = NuriServiceProto.NUR2004U01GetSubConfirmData2Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String result = bas0253Repository.getNUR2004U01GetSubConfirmData2(hospCode, request.getToHoDong1(), request.getToHoCode1(), request.getToBedNo());
		
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
		info.setDataValue(result);
		response.setRtnValue(info);

		return response.build();
	}

}
