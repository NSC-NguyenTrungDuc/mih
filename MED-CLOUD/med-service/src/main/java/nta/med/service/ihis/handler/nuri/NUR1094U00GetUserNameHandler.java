package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1094U00GetUserNameRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR1094U00GetUserNameHandler
		extends ScreenHandler<NuriServiceProto.NUR1094U00GetUserNameRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Adm3200Repository adm3200Repository;

	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1094U00GetUserNameRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();

		List<String> unames = adm3200Repository.getUserNameList(getHospitalCode(vertx, sessionId), request.getUserId());
		response.setResult(CollectionUtils.isEmpty(unames) ? "" : unames.get(0));

		return response.build();
	}

}
