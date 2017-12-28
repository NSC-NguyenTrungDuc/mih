package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.data.dao.medi.res.Res0104Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class NuroRES0102U00UpdateRES0104Handler extends ScreenHandler<NuroServiceProto.NuroRES0102U00UpdateRES0104Request, SystemServiceProto.UpdateResponse>{
	private static final Log logger = LogFactory.getLog(NuroRES0102U00UpdateRES0104Handler.class);
	
	@Resource
	private Res0104Repository res0104Repository;
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00UpdateRES0104Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        boolean result = updateRES0104(request);
        response.setResult(result);
		return response.build();
    }
	
	private boolean updateRES0104(NuroServiceProto.NuroRES0102U00UpdateRES0104Request request) throws Exception{
		if( res0104Repository.updateRES0104(request.getUserId(), new Date(),request.getEndDate(), request.getSayu(), request.getHospCode(), request.getDoctor(), request.getStartDate()) > 0)
			return true;
    	return false;
    }
}
