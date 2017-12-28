package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0803;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur0803Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0803U01grdMasterRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR0803U01grdMasterHandler
		extends ScreenHandler<NuriServiceProto.NUR0803U01grdMasterRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Nur0803Repository nur0803Repository;

	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0803U01grdMasterRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();

		List<Nur0803> items = nur0803Repository.findByHospCodeNeedGubunNeedAsmtCodeFDate(
				getHospitalCode(vertx, sessionId), request.getNeedGubun(), request.getNeedAsmtCode(),
				DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD));
		
		response.setResult(CollectionUtils.isEmpty(items) ? "" : "Y");
		return response.build();
	}

}
