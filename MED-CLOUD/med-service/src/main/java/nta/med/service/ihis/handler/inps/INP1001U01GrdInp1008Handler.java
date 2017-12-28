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
import nta.med.data.dao.medi.out.Out0105Repository;
import nta.med.data.model.ihis.inps.INP1001U01GrdInp1008Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01GrdInp1008Request;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01GrdInp1008Response;

@Service
@Scope("prototype")
public class INP1001U01GrdInp1008Handler extends
		ScreenHandler<InpsServiceProto.INP1001U01GrdInp1008Request, InpsServiceProto.INP1001U01GrdInp1008Response> {

	@Resource
	private Out0105Repository out0105Repository;
	
	@Override
	@Transactional(readOnly = true)
	public INP1001U01GrdInp1008Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01GrdInp1008Request request) throws Exception {
		
		InpsServiceProto.INP1001U01GrdInp1008Response.Builder response = InpsServiceProto.INP1001U01GrdInp1008Response.newBuilder();
		String language = getLanguage(vertx, sessionId);
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<INP1001U01GrdInp1008Info> lstInfo = out0105Repository.getINP1001U01GrdInp1008Info(
				getHospitalCode(vertx, sessionId), language, request.getBunho(), request.getGubun(),
				request.getPkinp1002(), request.getGubunIpwonDate(), request.getIpwonDate(), startNum, offset);
		
		if(CollectionUtils.isEmpty(lstInfo)){
			return response.build();
		}
		
		for (INP1001U01GrdInp1008Info info : lstInfo) {
			InpsModelProto.INP1001U01GrdInp1008Info.Builder protoInfo = InpsModelProto.INP1001U01GrdInp1008Info.newBuilder();
			BeanUtils.copyProperties(info, protoInfo, language);
			response.addGrdInfo(protoInfo);
		}
		
		return response.build();
	}

}
