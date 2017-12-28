package nta.med.service.ihis.handler.nuri;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur7002;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur7002Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00btnPreChuchiClickRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR1020U00btnPreChuchiClickHandler
		extends ScreenHandler<NuriServiceProto.NUR1020U00btnPreChuchiClickRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Nur7002Repository nur7002Repository;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020U00btnPreChuchiClickRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		Date fDate = DateUtil.increaseDate(DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD), -1);
		
		List<Nur7002> items = nur7002Repository.findByFkinp1001BunhoHangmogGubunYmd(getHospitalCode(vertx, sessionId)
				, CommonUtils.parseDouble(request.getFkinp1001())
				, request.getBunho()
				, "SYO"
				, fDate);
		
		response.setResult(CollectionUtils.isEmpty(items) ? ""
				: (items.get(0).getHangmogValue() == null ? "" : items.get(0).getHangmogValue()));
		return response.build();
	}

}
