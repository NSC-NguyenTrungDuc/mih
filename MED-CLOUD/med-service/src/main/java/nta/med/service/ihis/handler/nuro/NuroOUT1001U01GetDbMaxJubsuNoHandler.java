package nta.med.service.ihis.handler.nuro;


import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
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
public class NuroOUT1001U01GetDbMaxJubsuNoHandler  extends ScreenHandler<NuroServiceProto.NuroOUT1001U01GetDbMaxJubsuNoRequest, NuroServiceProto.NuroOUT1001U01GetDbMaxJubsuNoResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroOUT1001U01GetDbMaxJubsuNoHandler.class);
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroOUT1001U01GetDbMaxJubsuNoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01GetDbMaxJubsuNoRequest request) throws Exception {
		NuroServiceProto.NuroOUT1001U01GetDbMaxJubsuNoResponse.Builder response = NuroServiceProto.NuroOUT1001U01GetDbMaxJubsuNoResponse.newBuilder();
		String nuroOUT1001U01GetDbMaxJubsuNo = out1001Repository.getNuroOUT1001U01GetDbMaxJubsuNo(getHospitalCode(vertx, sessionId), request.getBunho(), request.getNaewonDate());
		if(!StringUtils.isEmpty(nuroOUT1001U01GetDbMaxJubsuNo)){
			response.setMaxJubsuNo(nuroOUT1001U01GetDbMaxJubsuNo);
		}
		return response.build();
	}
}
