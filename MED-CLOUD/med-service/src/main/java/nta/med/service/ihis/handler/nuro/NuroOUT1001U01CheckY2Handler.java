package nta.med.service.ihis.handler.nuro;

import java.math.BigDecimal;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
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
public class NuroOUT1001U01CheckY2Handler extends ScreenHandler<NuroServiceProto.NuroOUT1001U01CheckY2Request, NuroServiceProto.NuroOUT1001U01CheckYResponse>{
	private static final Log logger = LogFactory.getLog(NuroOUT1001U01CheckY2Handler.class);
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroOUT1001U01CheckY2Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroOUT1001U01CheckYResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01CheckY2Request request) throws Exception {
		BigDecimal jubsuNo = new BigDecimal(request.getJubsuNo());
		NuroServiceProto.NuroOUT1001U01CheckYResponse.Builder response = NuroServiceProto.NuroOUT1001U01CheckYResponse.newBuilder();
        String result = out1001Repository.getNuroOUT1001U01CheckY2(getHospitalCode(vertx, sessionId), request.getBunho(), DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD), request.getGwa(), request.getDoctor(), request.getNaewonType(), jubsuNo);
        if(!StringUtils.isEmpty(result)) {
        	response.setYValue(result);
        }
		return response.build();
	}
	
}
