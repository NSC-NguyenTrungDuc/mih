package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00getHogradeRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00getHogradeResponse;

@Service
@Scope("prototype")
public class NUR2004U00getHogradeHandler
		extends ScreenHandler<NuriServiceProto.NUR2004U00getHogradeRequest, NuriServiceProto.NUR2004U00getHogradeResponse> {

	@Resource
	private Bas0250Repository bas0250Repository;

	@Override
	public NUR2004U00getHogradeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00getHogradeRequest request) throws Exception {

		String hospCode = getHospitalCode(vertx, sessionId);
		String toHoDong1 = request.getToHoDong1();
		String toHoCode1 = request.getToHoCode1();
		String junpyoDate = request.getJunpyoDate();
		
		NuriServiceProto.NUR2004U00getHogradeResponse.Builder response = NuriServiceProto.NUR2004U00getHogradeResponse.newBuilder();
		List<DataStringListItemInfo> listInfo = bas0250Repository.getNUR2004U00getHograde(hospCode, toHoDong1, toHoCode1, junpyoDate);
		if (!CollectionUtils.isEmpty(listInfo)) {
			for (DataStringListItemInfo item : listInfo) {
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue(item.getItem());
				response.addHoGrade(info);
			}
		}

		return response.build();
	}
}
