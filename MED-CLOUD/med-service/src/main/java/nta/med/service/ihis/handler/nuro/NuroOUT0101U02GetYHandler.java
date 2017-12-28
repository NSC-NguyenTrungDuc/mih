package nta.med.service.ihis.handler.nuro;


import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;


@Service
@Scope("prototype")
public class NuroOUT0101U02GetYHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02GetYRequest, NuroServiceProto.NuroOUT0101U02GetYResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroOUT0101U02GetYHandler.class);
	@Resource
	private Out0102Repository out0102Repository;

	@Override
	public boolean isValid(NuroServiceProto.NuroOUT0101U02GetYRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOUT0101U02GetYResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02GetYRequest request) throws Exception {
		NuroServiceProto.NuroOUT0101U02GetYResponse.Builder response = NuroServiceProto.NuroOUT0101U02GetYResponse.newBuilder();
		String  nuroOUT0101U02GetY = out0102Repository.getNuroOUT0101U02GetY(getHospitalCode(vertx, sessionId), request.getPatientCode(), 
				request.getType(), DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD));
		if(nuroOUT0101U02GetY != null && !nuroOUT0101U02GetY.isEmpty()){
			response.setY(nuroOUT0101U02GetY);
		}
		return response.build();
	}

}
