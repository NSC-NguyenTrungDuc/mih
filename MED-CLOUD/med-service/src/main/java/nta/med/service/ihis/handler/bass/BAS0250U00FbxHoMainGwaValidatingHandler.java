package nta.med.service.ihis.handler.bass;

import java.util.Date;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250U00FbxHoMainGwaValidatingRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250U00FbxHoMainGwaValidatingResponse;

@Service
@Scope("prototype")
public class BAS0250U00FbxHoMainGwaValidatingHandler extends
		ScreenHandler<BassServiceProto.BAS0250U00FbxHoMainGwaValidatingRequest, BassServiceProto.BAS0250U00FbxHoMainGwaValidatingResponse> {

	@Resource
	private Bas0260Repository bas0260Repository;

	@Override
	@Transactional(readOnly = true)
	public BAS0250U00FbxHoMainGwaValidatingResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, BAS0250U00FbxHoMainGwaValidatingRequest request) throws Exception {

		BassServiceProto.BAS0250U00FbxHoMainGwaValidatingResponse.Builder response = BassServiceProto.BAS0250U00FbxHoMainGwaValidatingResponse.newBuilder();
		Date buseoDate = DateUtil.toDate(request.getBuseoYmd(), DateUtil.PATTERN_YYMMDD);
		String gwaName = bas0260Repository.getGwaNameItemInfo(getHospitalCode(vertx, sessionId), request.getGwa(), buseoDate);
		
		response.setGwaName(gwaName == null ? "" : gwaName);
		return response.build();
	}

}
