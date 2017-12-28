package nta.med.service.ihis.handler.inps;

import java.util.Date;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp2001Repository;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP2001U02setIconRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP2001U02setIconResponse;

@Service
@Scope("prototype")
public class INP2001U02setIconHandler
		extends ScreenHandler<InpsServiceProto.INP2001U02setIconRequest, InpsServiceProto.INP2001U02setIconResponse> {

	@Resource
	private Inp2001Repository inp2001Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP2001U02setIconResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP2001U02setIconRequest request) throws Exception {
		
		InpsServiceProto.INP2001U02setIconResponse.Builder response = InpsServiceProto.INP2001U02setIconResponse.newBuilder();
		
		Double pkout1001 = CommonUtils.parseDouble(request.getPkOut1001());
		Date ipwonDate = DateUtil.toDate(request.getIpwonDate(),DateUtil.PATTERN_YYMMDD);
		String cnt = inp2001Repository.getINP2001U02setIconCnt(getHospitalCode(vertx, sessionId), request.getBunho(), pkout1001, ipwonDate);
		
		response.setIcon(cnt);
		return response.build();
	}

}
