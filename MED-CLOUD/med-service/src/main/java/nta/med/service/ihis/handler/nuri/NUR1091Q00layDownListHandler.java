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
import nta.med.data.dao.medi.nur.Nur1092Repository;
import nta.med.data.model.ihis.nuri.NUR1091Q00layDownListInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1091Q00layDownListRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1091Q00layDownListResponse;

@Service
@Scope("prototype")
public class NUR1091Q00layDownListHandler extends
		ScreenHandler<NuriServiceProto.NUR1091Q00layDownListRequest, NuriServiceProto.NUR1091Q00layDownListResponse> {

	@Resource
	private Nur1092Repository nur1092Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR1091Q00layDownListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1091Q00layDownListRequest request) throws Exception {
		NuriServiceProto.NUR1091Q00layDownListResponse.Builder response = NuriServiceProto.NUR1091Q00layDownListResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR1091Q00layDownListInfo> items = nur1092Repository.getNUR1091Q00layDownListInfo(hospCode,
				request.getCodeType(), DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD));
		
		for (NUR1091Q00layDownListInfo item : items) {
			NuriModelProto.NUR1091Q00layDownListInfo.Builder info = NuriModelProto.NUR1091Q00layDownListInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addLayDown(info);
		}
		
		return response.build();
	}

}
