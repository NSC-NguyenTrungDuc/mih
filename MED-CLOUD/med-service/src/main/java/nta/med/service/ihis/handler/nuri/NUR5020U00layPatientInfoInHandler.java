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
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.nuri.NUR5020U00layPatientInfoInInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00layPatientInfoInRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00layPatientInfoInResponse;

@Service
@Scope("prototype")
public class NUR5020U00layPatientInfoInHandler extends
		ScreenHandler<NuriServiceProto.NUR5020U00layPatientInfoInRequest, NuriServiceProto.NUR5020U00layPatientInfoInResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR5020U00layPatientInfoInResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR5020U00layPatientInfoInRequest request) throws Exception {
		NuriServiceProto.NUR5020U00layPatientInfoInResponse.Builder response = NuriServiceProto.NUR5020U00layPatientInfoInResponse
				.newBuilder();

		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR5020U00layPatientInfoInInfo> items = inp1001Repository.getNUR5020U00layPatientInfoInInfoCase2(hospCode,
				request.getBunho(), DateUtil.toDate(request.getNurWrdt(), DateUtil.PATTERN_YYMMDD));

		for (NUR5020U00layPatientInfoInInfo item : items) {
			NuriModelProto.NUR5020U00layPatientInfoInInfo.Builder info = NuriModelProto.NUR5020U00layPatientInfoInInfo
					.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addLayItem(info);
		}

		return response.build();
	}

}
