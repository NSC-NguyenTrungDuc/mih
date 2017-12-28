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
import nta.med.data.model.ihis.inps.INP1001U01GrdInp1001Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01GrdInp1001Request;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01GrdInp1001Response;

@Service
@Scope("prototype")
public class INP1001U01GrdInp1001Handler extends
		ScreenHandler<InpsServiceProto.INP1001U01GrdInp1001Request, InpsServiceProto.INP1001U01GrdInp1001Response> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public INP1001U01GrdInp1001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01GrdInp1001Request request) throws Exception {
		
		InpsServiceProto.INP1001U01GrdInp1001Response.Builder response = InpsServiceProto.INP1001U01GrdInp1001Response.newBuilder();
		Double pkinp1001 = CommonUtils.parseDouble(request.getPkinp1001());
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);        
		List<INP1001U01GrdInp1001Info> lstInfo = inp1001Repository.getINP1001U01GrdInp1001Info(
				getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), pkinp1001, startNum,
				CommonUtils.parseInteger(offset));
		
		if(CollectionUtils.isEmpty(lstInfo)){
			return response.build();
		}
		
		for (INP1001U01GrdInp1001Info info : lstInfo) {
			InpsModelProto.INP1001U01GrdInp1001Info.Builder protoInfo = InpsModelProto.INP1001U01GrdInp1001Info.newBuilder();
			BeanUtils.copyProperties(info, protoInfo, getLanguage(vertx, sessionId));
			response.addGrdList(protoInfo);
		}
		
		return response.build();
	}
	
}
