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
import nta.med.data.dao.medi.bas.Bas0253Repository;
import nta.med.data.model.ihis.bass.BAS0250U00GrdBAS0253Info;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250U00GrdBAS0253Request;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250U00GrdBAS0253Response;

@Service
@Scope("prototype")
public class BAS0250U00GrdBAS0253Handler extends
		ScreenHandler<BassServiceProto.BAS0250U00GrdBAS0253Request, BassServiceProto.BAS0250U00GrdBAS0253Response> {

	@Resource
	private Bas0253Repository bas0253Repository;
	
	@Override
	@Transactional(readOnly = true)
	public BAS0250U00GrdBAS0253Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BAS0250U00GrdBAS0253Request request) throws Exception {
		
		BassServiceProto.BAS0250U00GrdBAS0253Response.Builder response = BassServiceProto.BAS0250U00GrdBAS0253Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<BAS0250U00GrdBAS0253Info> lstInfo = bas0253Repository.getBAS0250U00GrdBAS0253InfoList(
				hospCode, request.getHoDong(), request.getHoCode(), startNum, offset);

		if(CollectionUtils.isEmpty(lstInfo)){
			return response.build();
		}
		
		for (BAS0250U00GrdBAS0253Info info : lstInfo) {
			BassModelProto.BAS0250U00GrdBAS0253Info.Builder protoInfo = BassModelProto.BAS0250U00GrdBAS0253Info.newBuilder();
			BeanUtils.copyProperties(info, protoInfo, language);
			response.addGrdList(protoInfo);
		}
		
		return response.build();
	}

}
