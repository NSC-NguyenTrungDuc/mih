package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang3.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.model.ihis.inps.INP1003U01grdINP1003Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U01grdINP1003Request;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U01grdINP1003Response;

@Service
@Scope("prototype")
public class INP1003U01grdINP1003Handler extends ScreenHandler<InpsServiceProto.INP1003U01grdINP1003Request, InpsServiceProto.INP1003U01grdINP1003Response>{
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP1003U01grdINP1003Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U01grdINP1003Request request) throws Exception {
		InpsServiceProto.INP1003U01grdINP1003Response.Builder response = InpsServiceProto.INP1003U01grdINP1003Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<INP1003U01grdINP1003Info> listInfo = inp1003Repository.getINP1003U01grdINP1003Info(hospCode, request.getBunho(), language, offset, startNum);
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (INP1003U01grdINP1003Info info : listInfo) {
			InpsModelProto.INP1003U01grdINP1003Info.Builder infoProto = InpsModelProto.INP1003U01grdINP1003Info.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addGrdINP(infoProto);
		}
		
		return response.build();
	}
}
