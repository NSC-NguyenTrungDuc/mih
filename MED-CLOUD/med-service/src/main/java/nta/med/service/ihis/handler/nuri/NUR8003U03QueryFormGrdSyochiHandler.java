package nta.med.service.ihis.handler.nuri;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur7002;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur7002Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003U03QueryFormGrdSyochiRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003U03QueryFormGrdSyochiResponse;

@Service
@Scope("prototype")
public class NUR8003U03QueryFormGrdSyochiHandler extends
		ScreenHandler<NuriServiceProto.NUR8003U03QueryFormGrdSyochiRequest, NuriServiceProto.NUR8003U03QueryFormGrdSyochiResponse> {

	@Resource
	private Nur7002Repository nur7002Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR8003U03QueryFormGrdSyochiResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8003U03QueryFormGrdSyochiRequest request) throws Exception {
		NuriServiceProto.NUR8003U03QueryFormGrdSyochiResponse.Builder response = NuriServiceProto.NUR8003U03QueryFormGrdSyochiResponse
				.newBuilder();
		Date toDate = DateUtil.toDate(request.getWriteDate(), DateUtil.PATTERN_YYMMDD);
		Date frDate = DateUtil.increaseDate(toDate, -1);

		List<Nur7002> items = nur7002Repository.findByFkinp1001BunhoHangmogGubunWriteDate(
				getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getFkinp1001()), request.getBunho(), "SYO",
				frDate, toDate);

		for (Nur7002 item : items) {
			NuriModelProto.NUR8003U03QueryFormGrdSyochiInfo.Builder info = NuriModelProto.NUR8003U03QueryFormGrdSyochiInfo.newBuilder()
					.setYmd(DateUtil.toString(item.getYmd(), DateUtil.PATTERN_YYMMDD))
					.setHangmogValue(item.getHangmogValue());
			response.addGrdList(info);
		}
		
		return response.build();
	}

}
