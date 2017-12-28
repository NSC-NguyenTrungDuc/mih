package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur0803Repository;
import nta.med.data.model.ihis.nuri.NUR0812U00GrdDetailInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0812U00GrdDetailRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0812U00GrdDetailResponse;

@Service
@Scope("prototype")
public class NUR0812U00GrdDetailHandler extends
		ScreenHandler<NuriServiceProto.NUR0812U00GrdDetailRequest, NuriServiceProto.NUR0812U00GrdDetailResponse> {

	@Resource
	private Nur0803Repository nur0803Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR0812U00GrdDetailResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0812U00GrdDetailRequest request) throws Exception {
		NuriServiceProto.NUR0812U00GrdDetailResponse.Builder response = NuriServiceProto.NUR0812U00GrdDetailResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		
		List<NUR0812U00GrdDetailInfo> infos = nur0803Repository.getNUR0812U00GrdDetailInfo(hospCode, language,
				request.getCodeType(), request.getNeedHType(), startNum, CommonUtils.parseInteger(offset));

		for (NUR0812U00GrdDetailInfo info : infos) {
			NuriModelProto.NUR0812U00GrdDetailInfo.Builder pInfo = NuriModelProto.NUR0812U00GrdDetailInfo.newBuilder();
			BeanUtils.copyProperties(info, pInfo, language);
			response.addGrdDetailInfo(pInfo);
		}
		
		return response.build();
	}

}
