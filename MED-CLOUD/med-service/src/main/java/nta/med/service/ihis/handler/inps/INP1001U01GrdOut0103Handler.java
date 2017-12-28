package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.INP1001U01GrdOut0103Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01GrdOut0103Request;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01GrdOut0103Response;

@Service
@Scope("prototype")
public class INP1001U01GrdOut0103Handler extends
		ScreenHandler<InpsServiceProto.INP1001U01GrdOut0103Request, InpsServiceProto.INP1001U01GrdOut0103Response> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	public INP1001U01GrdOut0103Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01GrdOut0103Request request) throws Exception {
		
		InpsServiceProto.INP1001U01GrdOut0103Response.Builder response = InpsServiceProto.INP1001U01GrdOut0103Response.newBuilder();
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);        
		
		List<INP1001U01GrdOut0103Info> lstResult = inp1001Repository.getINP1001U01GrdOut0103Info(
				getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(), startNum,
				CommonUtils.parseInteger(offset));
		
		if(CollectionUtils.isEmpty(lstResult)){
			return response.build();
		}
		
		for (INP1001U01GrdOut0103Info info : lstResult) {
			InpsModelProto.INP1001U01GrdOut0103Info.Builder protoInfo = InpsModelProto.INP1001U01GrdOut0103Info.newBuilder();
			BeanUtils.copyProperties(info, protoInfo, getLanguage(vertx, sessionId));
			response.addGrdList(protoInfo);
		}
		
		return response.build();
	}

}
