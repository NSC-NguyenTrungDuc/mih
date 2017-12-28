package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

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
public class NuroOUT1001U01GetOut1001SeqHandler extends ScreenHandler<NuroServiceProto.NuroOUT1001U01GetOut1001SeqRequest, NuroServiceProto.NuroOUT1001U01GetOut1001SeqResponse>{
private static final Log logger = LogFactory.getLog(NuroOUT1001U01GetOut1001SeqHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	@Transactional
	public NuroServiceProto.NuroOUT1001U01GetOut1001SeqResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01GetOut1001SeqRequest request) throws Exception {
		NuroServiceProto.NuroOUT1001U01GetOut1001SeqResponse.Builder response = NuroServiceProto.NuroOUT1001U01GetOut1001SeqResponse.newBuilder();
		String result = out1001Repository.getNuroOUT1001U01GetOut1001Seq("OUT1001_SEQ");
		if(!StringUtils.isEmpty(result)){
			response.setOut1001SeqValue(result);
		}
		return response.build();
	}

}
