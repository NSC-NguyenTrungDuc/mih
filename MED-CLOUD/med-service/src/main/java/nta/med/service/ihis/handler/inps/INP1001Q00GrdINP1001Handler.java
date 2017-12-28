package nta.med.service.ihis.handler.inps;

import java.util.Date;
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
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.INP1001Q00grdINP1001Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001Q00grdINP1001Request;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001Q00grdINP1001Response;

@Service
@Scope("prototype")
public class INP1001Q00GrdINP1001Handler extends
		ScreenHandler<InpsServiceProto.INP1001Q00grdINP1001Request, InpsServiceProto.INP1001Q00grdINP1001Response> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP1001Q00grdINP1001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001Q00grdINP1001Request request) throws Exception {
		InpsServiceProto.INP1001Q00grdINP1001Response.Builder response = InpsServiceProto.INP1001Q00grdINP1001Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Date fromDate = DateUtil.toDate(request.getFromDate(),DateUtil.PATTERN_YYMMDD);
		Date toDate = DateUtil.toDate(request.getToDate(),DateUtil.PATTERN_YYMMDD);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<INP1001Q00grdINP1001Info> listInfo = inp1001Repository.getINP1001Q00grdINP1001Info(hospCode, request.getBunho(),fromDate,toDate,language, startNum, offset);
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (INP1001Q00grdINP1001Info info : listInfo) {
			InpsModelProto.INP1001Q00grdINP1001Info.Builder infoProto = InpsModelProto.INP1001Q00grdINP1001Info.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addGrdMasterItem(infoProto);
		}
		
		return response.build();
	}	
}
