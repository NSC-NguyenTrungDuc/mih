package nta.med.service.ihis.handler.inps;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.INP1001U01DoubleGrdINP1008Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01DoubleGrdINP1008Request;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01DoubleGrdINP1008Response;
@Service
@Scope("prototype")
public class INP1001U01DoubleGrdINP1008Handler extends ScreenHandler<InpsServiceProto.INP1001U01DoubleGrdINP1008Request, InpsServiceProto.INP1001U01DoubleGrdINP1008Response> {
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	public INP1001U01DoubleGrdINP1008Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01DoubleGrdINP1008Request request) throws Exception {
		
		InpsServiceProto.INP1001U01DoubleGrdINP1008Response.Builder response = InpsServiceProto.INP1001U01DoubleGrdINP1008Response.newBuilder();
		Double pkinp1002 = CommonUtils.parseDouble(request.getFkinp1002());
		String offset = request.getOffset();
       
		Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);        
        Date gubunIpwonDate = DateUtil.toDate(request.getGubunIpwonDate(),DateUtil.PATTERN_YYMMDD);
		Date ipwonDate = DateUtil.toDate(request.getIpwonDate(),DateUtil.PATTERN_YYMMDD);
		
        List<INP1001U01DoubleGrdINP1008Info> lstInfo = inp1001Repository.getINP1001U01DoubleGrdINP1008Info(getHospitalCode(vertx, sessionId),pkinp1002, getLanguage(vertx, sessionId), 
        		request.getBunho(), request.getGubun(),gubunIpwonDate,ipwonDate,startNum,offset);
		
		if(CollectionUtils.isEmpty(lstInfo)){
			return response.build();
		}
		
		for (INP1001U01DoubleGrdINP1008Info info : lstInfo) {
			InpsModelProto.INP1001U01DoubleGrdINP1008Info.Builder protoInfo = InpsModelProto.INP1001U01DoubleGrdINP1008Info.newBuilder();
			BeanUtils.copyProperties(info, protoInfo, getLanguage(vertx, sessionId));
			response.addGrdList(protoInfo);
		}
		
		return response.build();
	}

}
