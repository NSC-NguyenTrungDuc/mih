package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250U00FbxHoGradeValidatingRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250U00FbxHoGradeValidatingResponse;

@Service
@Scope("prototype")
public class BAS0250U00FbxHoGradeValidatingHandler extends
		ScreenHandler<BassServiceProto.BAS0250U00FbxHoGradeValidatingRequest, BassServiceProto.BAS0250U00FbxHoGradeValidatingResponse> {

	@Resource
	private Bas0250Repository bas0250Repository;

	@Override
	public BAS0250U00FbxHoGradeValidatingResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BAS0250U00FbxHoGradeValidatingRequest request) throws Exception {
		BassServiceProto.BAS0250U00FbxHoGradeValidatingResponse.Builder response = BassServiceProto.BAS0250U00FbxHoGradeValidatingResponse
				.newBuilder();

		String hospCode = getHospitalCode(vertx, sessionId);
		String hoGrade = request.getHoGrade();
		String hoGradeYmd = request.getHoGradeYmd();

		String hoGradeName = bas0250Repository.getBAS0250U00FbxHoGradeValidating(hospCode, hoGrade, hoGradeYmd);
		response.setHoGradeName(hoGradeName == null ? "" : hoGradeName);

		return response.build();
	}

}