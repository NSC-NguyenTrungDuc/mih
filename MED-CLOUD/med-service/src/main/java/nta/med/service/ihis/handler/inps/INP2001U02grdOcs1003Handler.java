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
import nta.med.data.dao.medi.inp.Inp2001RepositoryCustom;
import nta.med.data.model.ihis.inps.INP2001U02grdOcs1003Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP2001U02grdOcs1003Request;
import nta.med.service.ihis.proto.InpsServiceProto.INP2001U02grdOcs1003Response;

@Service
@Scope("prototype")
public class INP2001U02grdOcs1003Handler extends 
			ScreenHandler<InpsServiceProto.INP2001U02grdOcs1003Request, InpsServiceProto.INP2001U02grdOcs1003Response>{

	@Resource
	private Inp2001RepositoryCustom inp2001Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP2001U02grdOcs1003Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP2001U02grdOcs1003Request request) throws Exception {
		InpsServiceProto.INP2001U02grdOcs1003Response.Builder response = InpsServiceProto.INP2001U02grdOcs1003Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		//Date ipwonDate = DateUtil.toDate(request.getIpWonDate(),DateUtil.PATTERN_YYMMDD);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<INP2001U02grdOcs1003Info> listInfo = inp2001Repository.getINP2001U02grdOcs1003Info(hospCode, request.getJubsuGubun(), request.getPkOut1001()
								, request.getIpWonDate(), request.getKaikeiYn(), request.getBunho(), language, startNum, offset);
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (INP2001U02grdOcs1003Info info : listInfo) {
			InpsModelProto.INP2001U02grdOcs1003Info.Builder infoProto = InpsModelProto.INP2001U02grdOcs1003Info.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addGrd1003(infoProto);
		}
		
		return response.build();
	}

	
}
