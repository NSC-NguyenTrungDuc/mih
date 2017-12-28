package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur0803Repository;
import nta.med.data.model.ihis.nuri.NUR8003U03SetFindWorkerInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003U03SetFindWorkerRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003U03SetFindWorkerResponse;

@Service
@Scope("prototype")
public class NUR8003U03SetFindWorkerHandler extends
		ScreenHandler<NuriServiceProto.NUR8003U03SetFindWorkerRequest, NuriServiceProto.NUR8003U03SetFindWorkerResponse> {

	@Resource
	private Nur0803Repository nur0803Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR8003U03SetFindWorkerResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8003U03SetFindWorkerRequest request) throws Exception {
		NuriServiceProto.NUR8003U03SetFindWorkerResponse.Builder response = NuriServiceProto.NUR8003U03SetFindWorkerResponse
				.newBuilder();

		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR8003U03SetFindWorkerInfo> items = nur0803Repository.getNUR8003U03SetFindWorkerInfo(hospCode,
				request.getNeedGubun(), request.getNeedAsmtCode(),
				DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD), request.getNeedResultCode());

		for (NUR8003U03SetFindWorkerInfo item : items) {
			NuriModelProto.NUR8003U03SetFindWorkerInfo.Builder info = NuriModelProto.NUR8003U03SetFindWorkerInfo
					.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addFwList(info);
		}

		return response.build();
	}

}
