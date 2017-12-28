package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0802;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0802Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0802U00cmdTextRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0802U00cmdTextResponse;

@Service
@Scope("prototype")
public class NUR0802U00cmdTextHandler
		extends ScreenHandler<NuriServiceProto.NUR0802U00cmdTextRequest, NuriServiceProto.NUR0802U00cmdTextResponse> {

	@Resource
	private Nur0802Repository nur0802Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR0802U00cmdTextResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0802U00cmdTextRequest request) throws Exception {
		NuriServiceProto.NUR0802U00cmdTextResponse.Builder response = NuriServiceProto.NUR0802U00cmdTextResponse.newBuilder();
		
		List<Nur0802> items = nur0802Repository.findByHospCodeNeedTypeNeedGubunNeedAsmtCode(
				getHospitalCode(vertx, sessionId), request.getNeedType(), request.getNeedGubun(), request.getNeedAsmtCode());
		
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder()
				.setDataValue(CollectionUtils.isEmpty(items) ? "" : "Y");
		
		response.setCmditem(info);
		return response.build();
	}

}
