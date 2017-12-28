package nta.med.service.ihis.handler.inps;

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
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.model.ihis.inps.INP1003Q00grdINP1003Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003Q00grdINP1003Request;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003Q00grdINP1003Response;

@Service
@Scope("prototype")
public class INP1003Q00grdINP1003Handler extends ScreenHandler<InpsServiceProto.INP1003Q00grdINP1003Request, InpsServiceProto.INP1003Q00grdINP1003Response> {
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP1003Q00grdINP1003Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003Q00grdINP1003Request request) throws Exception {
		InpsServiceProto.INP1003Q00grdINP1003Response.Builder response = InpsServiceProto.INP1003Q00grdINP1003Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<INP1003Q00grdINP1003Info> listInfo = inp1003Repository.getINP1003Q00grdINP1003Info(hospCode, language, request.getReserEndType()
						, request.getReserDate(), request.getHoDong(), offset, startNum);
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (INP1003Q00grdINP1003Info info : listInfo) {
			InpsModelProto.INP1003Q00grdINP1003Info.Builder infoProto = InpsModelProto.INP1003Q00grdINP1003Info.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addGrdMasterItem(infoProto);
		}
		
		return response.build();
	}
}
