package nta.med.service.ihis.handler.nuro;

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
public class NuroOUT1001U01CheckNaewonYnHandler  extends ScreenHandler<NuroServiceProto.NuroOUT1001U01CheckNaewonYnRequest, NuroServiceProto.NuroOUT1001U01CheckNaewonYnResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroOUT1001U01CheckNaewonYnHandler.class);
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroOUT1001U01CheckNaewonYnRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroOUT1001U01CheckNaewonYnResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01CheckNaewonYnRequest request) throws Exception {
		String  nuroOUT1001U01CheckNaewonYn = out1001Repository.getNuroOUT1001U01CheckNaewonYn(request.getBunho(), request.getNaewonDate(),request.getGwa(),request.getDoctor(), request.getNaewonType(), request.getOldJubsuNo(), getHospitalCode(vertx, sessionId));
		NuroServiceProto.NuroOUT1001U01CheckNaewonYnResponse.Builder response = NuroServiceProto.NuroOUT1001U01CheckNaewonYnResponse.newBuilder();
		if(!StringUtils.isEmpty(nuroOUT1001U01CheckNaewonYn)){
			response.setValueCheckNaewon(nuroOUT1001U01CheckNaewonYn);
		}
		return response.build();
	}
}
