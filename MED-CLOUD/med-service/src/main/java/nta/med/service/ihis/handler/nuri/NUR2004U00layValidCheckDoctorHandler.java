package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00layValidCheckDoctorRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00layValidCheckDoctorResponse;

@Service
@Scope("prototype")
public class NUR2004U00layValidCheckDoctorHandler extends
		ScreenHandler<NuriServiceProto.NUR2004U00layValidCheckDoctorRequest, NuriServiceProto.NUR2004U00layValidCheckDoctorResponse> {
	@Resource
	private Bas0270Repository bas0270Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR2004U00layValidCheckDoctorResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00layValidCheckDoctorRequest request) throws Exception {
		NuriServiceProto.NUR2004U00layValidCheckDoctorResponse.Builder response = NuriServiceProto.NUR2004U00layValidCheckDoctorResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);

		String date = request.getDate();
		String gwa = request.getGwa();
		String code = request.getCode();

		List<DataStringListItemInfo> listInfo = bas0270Repository.getNUR2004U00layValidCheckDoctor(hospCode, gwa, code,
				date);
		if (!CollectionUtils.isEmpty(listInfo)) {
			for (DataStringListItemInfo item : listInfo) {
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo
						.newBuilder().setDataValue(item.getItem());
				response.addDoctorName(info);
			}
		}

		return response.build();
	}

}
