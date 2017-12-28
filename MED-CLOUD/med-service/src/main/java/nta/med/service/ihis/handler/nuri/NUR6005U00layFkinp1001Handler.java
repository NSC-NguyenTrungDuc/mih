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
import nta.med.service.ihis.proto.NuriServiceProto.NUR6005U00layFkinp1001Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR6005U00layFkinp1001Response;

@Service
@Scope("prototype")
public class NUR6005U00layFkinp1001Handler extends
		ScreenHandler<NuriServiceProto.NUR6005U00layFkinp1001Request, NuriServiceProto.NUR6005U00layFkinp1001Response> {

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR6005U00layFkinp1001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR6005U00layFkinp1001Request request) throws Exception {
		NuriServiceProto.NUR6005U00layFkinp1001Response.Builder response = NuriServiceProto.NUR6005U00layFkinp1001Response
				.newBuilder();
		
		String pk = inp1001Repository.getNUR1020U00Pkinp1001(getHospitalCode(vertx, sessionId), request.getBunho());
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue(pk);
		response.addLayItem(info);
		
		return response.build();
	}

}
