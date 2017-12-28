package nta.med.service.ihis.handler.nuri;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.nuri.NUR5020U00grdGwaInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00grdGwaRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00grdGwaResponse;

@Service
@Scope("prototype")
public class NUR5020U00grdGwaHandler
		extends ScreenHandler<NuriServiceProto.NUR5020U00grdGwaRequest, NuriServiceProto.NUR5020U00grdGwaResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR5020U00grdGwaResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR5020U00grdGwaRequest request) throws Exception {
		NuriServiceProto.NUR5020U00grdGwaResponse.Builder response = NuriServiceProto.NUR5020U00grdGwaResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String queryNumber = request.getQueryNumber();

		List<NUR5020U00grdGwaInfo> items = new ArrayList<>();

		if ("1".equals(queryNumber)) {
			items = inp1001Repository.getNUR5020U00grdGwaInfoCase1(hospCode, request.getHoDong());
		} else if ("2".equals(queryNumber)) {
			items = inp1001Repository.getNUR5020U00grdGwaInfoCase2(hospCode, request.getHoDong(),
					DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD));
		}

		for (NUR5020U00grdGwaInfo item : items) {
			NuriModelProto.NUR5020U00grdGwaInfo.Builder info = NuriModelProto.NUR5020U00grdGwaInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdMasterItem(info);
		}

		return response.build();
	}

}
