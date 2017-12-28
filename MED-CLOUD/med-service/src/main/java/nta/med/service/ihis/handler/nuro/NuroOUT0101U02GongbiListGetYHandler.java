package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0105Repository;
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
public class NuroOUT0101U02GongbiListGetYHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02GongbiListGetYRequest, NuroServiceProto.NuroOUT0101U02GongbiListGetYResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroOUT0101U02GongbiListGetYHandler.class);
	@Resource
	private Out0105Repository out0105Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroOUT0101U02GongbiListGetYRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOUT0101U02GongbiListGetYResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02GongbiListGetYRequest request) throws Exception {
		String result = out0105Repository.getNuroOUT0101U02GongbiListGetY(getHospitalCode(vertx, sessionId), request.getGongbiCode(), request.getPatientCode(), DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD));
        NuroServiceProto.NuroOUT0101U02GongbiListGetYResponse.Builder response = NuroServiceProto.NuroOUT0101U02GongbiListGetYResponse.newBuilder();
        if(!StringUtils.isEmpty(result)) {
        	response.setYValue(result);
        }
		return response.build();
	}
}
