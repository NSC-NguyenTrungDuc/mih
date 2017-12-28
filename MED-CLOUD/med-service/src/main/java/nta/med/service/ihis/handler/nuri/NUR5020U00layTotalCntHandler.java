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
import nta.med.data.model.ihis.nuri.NUR5020U00layTotalCntInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00layTotalCntRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00layTotalCntResponse;

@Service
@Scope("prototype")
public class NUR5020U00layTotalCntHandler extends
		ScreenHandler<NuriServiceProto.NUR5020U00layTotalCntRequest, NuriServiceProto.NUR5020U00layTotalCntResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR5020U00layTotalCntResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR5020U00layTotalCntRequest request) throws Exception {
		NuriServiceProto.NUR5020U00layTotalCntResponse.Builder response = NuriServiceProto.NUR5020U00layTotalCntResponse
				.newBuilder();

		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR5020U00layTotalCntInfo> items = inp1001Repository.getNUR5020U00layTotalCntInfo(hospCode,
				request.getHoDong(), request.getDate());
		for (NUR5020U00layTotalCntInfo item : items) {
			NuriModelProto.NUR5020U00layTotalCntInfo.Builder info = NuriModelProto.NUR5020U00layTotalCntInfo
					.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addLayItem(info);
		}

		return response.build();
	}

}
