package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.data.model.ihis.nuri.NUR0802U00grdDetailInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0802U00grdDetailRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0802U00grdDetailResponse;

@Service
@Scope("prototype")
public class NUR0802U00grdDetailHandler extends
		ScreenHandler<NuriServiceProto.NUR0802U00grdDetailRequest, NuriServiceProto.NUR0802U00grdDetailResponse> {

	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR0802U00grdDetailResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0802U00grdDetailRequest request) throws Exception {
		NuriServiceProto.NUR0802U00grdDetailResponse.Builder response = NuriServiceProto.NUR0802U00grdDetailResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR0802U00grdDetailInfo> items = nur0102Repository.getNUR0802U00grdDetailInfo(hospCode, language,
				request.getNeedType(), request.getCodeType(), startNum, offset);
		
		for (NUR0802U00grdDetailInfo item : items) {
			NuriModelProto.NUR0802U00grdDetailInfo.Builder info = NuriModelProto.NUR0802U00grdDetailInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdMasterItem(info);
		}
		
		return response.build();
	}

}
