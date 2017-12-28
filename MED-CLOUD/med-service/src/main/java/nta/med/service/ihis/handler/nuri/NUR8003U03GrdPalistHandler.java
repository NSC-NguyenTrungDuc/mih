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
import nta.med.data.model.ihis.nuri.NUR8003U03GrdPalistInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003U03GrdPalistRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003U03GrdPalistResponse;

@Service
@Scope("prototype")
public class NUR8003U03GrdPalistHandler extends
		ScreenHandler<NuriServiceProto.NUR8003U03GrdPalistRequest, NuriServiceProto.NUR8003U03GrdPalistResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR8003U03GrdPalistResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8003U03GrdPalistRequest request) throws Exception {
		NuriServiceProto.NUR8003U03GrdPalistResponse.Builder response = NuriServiceProto.NUR8003U03GrdPalistResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR8003U03GrdPalistInfo> items = inp1001Repository.getNUR8003U03GrdPalistInfo(hospCode,
				request.getHoDong(), request.getDate(), request.getAValue(), request.getBValue(), request.getCValue(),
				request.getDValue());

		for (NUR8003U03GrdPalistInfo item : items) {
			NuriModelProto.NUR8003U03GrdPalistInfo.Builder info = NuriModelProto.NUR8003U03GrdPalistInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdList(info);	
		}

		return response.build();
	}

}
