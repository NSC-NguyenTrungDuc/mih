package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0104Repository;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.RES1001U00CheckJinryoYnRequest;
import nta.med.service.ihis.proto.NuroServiceProto.RES1001U00CheckJinryoYnResponse;

@Service                                                                                                          
@Scope("prototype") 
public class RES1001U00CheckJinryoYnHandler  extends ScreenHandler<NuroServiceProto.RES1001U00CheckJinryoYnRequest, NuroServiceProto.RES1001U00CheckJinryoYnResponse>{ 
	private static final Log LOGGER = LogFactory.getLog(RES1001U00CheckJinryoYnHandler.class);                                    
	@Resource                                                                                                       
	private Res0104Repository res0104Repository;
	
	@Override
	@Transactional(readOnly = true)
	public RES1001U00CheckJinryoYnResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			RES1001U00CheckJinryoYnRequest request) throws Exception {
		NuroServiceProto.RES1001U00CheckJinryoYnResponse.Builder response = NuroServiceProto.RES1001U00CheckJinryoYnResponse.newBuilder();
		String jinryoYn = res0104Repository.getRES1001U00CheckJinryoYn(request.getHospCode(), request.getDoctor(), DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD), request.getJubsuTime());
		if(!StringUtils.isEmpty(jinryoYn)){
			response.setJinryoYn(jinryoYn);
		}
		return response.build();
	}
}
