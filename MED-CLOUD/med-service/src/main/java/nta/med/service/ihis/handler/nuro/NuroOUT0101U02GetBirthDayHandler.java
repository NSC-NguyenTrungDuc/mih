package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.data.dao.medi.out.Out0101Repository;
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
public class NuroOUT0101U02GetBirthDayHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02GetBirthDayRequest, NuroServiceProto.NuroOUT0101U02GetBirthDayResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroOUT0101U02GetBirthDayHandler.class);
	@Resource
	private Out0101Repository out0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroOUT0101U02GetBirthDayResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02GetBirthDayRequest request) throws Exception {
		NuroServiceProto.NuroOUT0101U02GetBirthDayResponse.Builder response = NuroServiceProto.NuroOUT0101U02GetBirthDayResponse.newBuilder();
		String nuroOUT0101U02GetBirthDay = out0101Repository.getNuroOUT0101U02GetBirthDay(request.getSysDate(), request.getBirth());
        if(nuroOUT0101U02GetBirthDay != null && !nuroOUT0101U02GetBirthDay.isEmpty()){
        	response.setBirthDay(StringUtils.isEmpty(nuroOUT0101U02GetBirthDay) ? "" : nuroOUT0101U02GetBirthDay);
        }
		return response.build();
	}
}
