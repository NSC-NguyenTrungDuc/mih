package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur5022Repository;
import nta.med.data.model.ihis.nuri.NUR5020U00layNurCntInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00layNurCntRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00layNurCntResponse;

@Service
@Scope("prototype")
public class NUR5020U00layNurCntHandler extends
		ScreenHandler<NuriServiceProto.NUR5020U00layNurCntRequest, NuriServiceProto.NUR5020U00layNurCntResponse> {

	@Resource
	private Nur5022Repository nur5022Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR5020U00layNurCntResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR5020U00layNurCntRequest request) throws Exception {
		NuriServiceProto.NUR5020U00layNurCntResponse.Builder response = NuriServiceProto.NUR5020U00layNurCntResponse
				.newBuilder();

		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR5020U00layNurCntInfo> items = nur5022Repository.getNUR5020U00layNurCntInfo(hospCode, language);
		for (NUR5020U00layNurCntInfo item : items) {
			NuriModelProto.NUR5020U00layNurCntInfo.Builder info = NuriModelProto.NUR5020U00layNurCntInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addLayItem(info);
		}

		return response.build();
	}

}
