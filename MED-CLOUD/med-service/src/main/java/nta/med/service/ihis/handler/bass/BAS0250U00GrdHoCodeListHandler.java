package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.data.model.ihis.bass.BAS0250U00GrdHoCodeListInfo;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250U00GrdHoCodeListRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250U00GrdHoCodeListResponse;

@Service
@Scope("prototype")
public class BAS0250U00GrdHoCodeListHandler extends
		ScreenHandler<BassServiceProto.BAS0250U00GrdHoCodeListRequest, BassServiceProto.BAS0250U00GrdHoCodeListResponse> {

	@Resource
	private Bas0250Repository bas0250Repository;
	
	@Override
	@Transactional(readOnly = true)
	public BAS0250U00GrdHoCodeListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BAS0250U00GrdHoCodeListRequest request) throws Exception {
		
		BassServiceProto.BAS0250U00GrdHoCodeListResponse.Builder response = BassServiceProto.BAS0250U00GrdHoCodeListResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<BAS0250U00GrdHoCodeListInfo> listInfo = bas0250Repository.getBAS0250U00GrdHoCodeListInfoList(hospCode, language, request.getJukyongDate(),request.getHoDong(), startNum, offset);
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (BAS0250U00GrdHoCodeListInfo info : listInfo) {
			BassModelProto.BAS0250U00GrdHoCodeListInfo.Builder protoInfo = BassModelProto.BAS0250U00GrdHoCodeListInfo.newBuilder();
			BeanUtils.copyProperties(info, protoInfo, language);
			response.addGrdList(protoInfo);
		}
		
		return response.build();
	}
	
}