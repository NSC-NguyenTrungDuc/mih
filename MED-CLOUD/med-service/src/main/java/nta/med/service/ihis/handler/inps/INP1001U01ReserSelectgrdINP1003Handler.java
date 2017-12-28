package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.INP1001U01ReserSelectgrdINP1003Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01ReserSelectgrdINP1003Request;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01ReserSelectgrdINP1003Response;

@Service
@Scope("prototype")
public class INP1001U01ReserSelectgrdINP1003Handler extends
		ScreenHandler<InpsServiceProto.INP1001U01ReserSelectgrdINP1003Request, InpsServiceProto.INP1001U01ReserSelectgrdINP1003Response> {

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public INP1001U01ReserSelectgrdINP1003Response handle(Vertx vertx, String clientId, String sessionId,
			long contextId, INP1001U01ReserSelectgrdINP1003Request request) throws Exception {
		InpsServiceProto.INP1001U01ReserSelectgrdINP1003Response.Builder response = InpsServiceProto.INP1001U01ReserSelectgrdINP1003Response
				.newBuilder();

		String offset = request.getOffset();
		List<INP1001U01ReserSelectgrdINP1003Info> lstInfo = inp1001Repository.getINP1001U01ReserSelectgrdINP1003Info(
				getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(),
				CommonUtils.parseInteger(offset));

		if (CollectionUtils.isEmpty(lstInfo)) {
			return response.build();
		}

		for (INP1001U01ReserSelectgrdINP1003Info info : lstInfo) {
			InpsModelProto.INP1001U01ReserSelectgrdINP1003Info.Builder protoInfo = InpsModelProto.INP1001U01ReserSelectgrdINP1003Info
					.newBuilder();
			BeanUtils.copyProperties(info, protoInfo, getLanguage(vertx, sessionId));
			response.addGrd1003(protoInfo);
		}

		return response.build();
	}

}
