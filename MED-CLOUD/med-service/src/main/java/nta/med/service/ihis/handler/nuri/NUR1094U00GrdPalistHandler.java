package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.nuri.NUR1094U00GrdPalistInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1094U00GrdPalistRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1094U00GrdPalistResponse;

@Service
@Scope("prototype")
public class NUR1094U00GrdPalistHandler extends
		ScreenHandler<NuriServiceProto.NUR1094U00GrdPalistRequest, NuriServiceProto.NUR1094U00GrdPalistResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR1094U00GrdPalistResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1094U00GrdPalistRequest request) throws Exception {
		NuriServiceProto.NUR1094U00GrdPalistResponse.Builder response = NuriServiceProto.NUR1094U00GrdPalistResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR1094U00GrdPalistInfo> items = inp1001Repository.getNUR1094U00GrdPalistInfo(hospCode,
				request.getHoDong(), request.getDate(), request.getAValue(), request.getBValue(), request.getCValue(),
				request.getDValue());

		for (NUR1094U00GrdPalistInfo item : items) {
			NuriModelProto.NUR1094U00GrdPalistInfo.Builder info = NuriModelProto.NUR1094U00GrdPalistInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdLst(info);
		}

		return response.build();
	}

}
