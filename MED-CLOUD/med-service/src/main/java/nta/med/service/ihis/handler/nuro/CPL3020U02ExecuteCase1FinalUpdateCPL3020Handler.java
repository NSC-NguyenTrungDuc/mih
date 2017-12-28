package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl3020Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class CPL3020U02ExecuteCase1FinalUpdateCPL3020Handler extends ScreenHandler<CplsServiceProto.CPL3020U02ExecuteCase1FinalUpdateCPL3020Request, SystemServiceProto.UpdateResponse> {
private static final Log LOG = LogFactory.getLog(CPL3020U02ExecuteCase1FinalUpdateCPL3020Handler.class);
	
	@Resource
	private Cpl3020Repository cpl3020Repository;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CplsServiceProto.CPL3020U02ExecuteCase1FinalUpdateCPL3020Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Double pkcpl3020 = CommonUtils.parseDouble(request.getPkcpl3020());
    	if(cpl3020Repository.updateCPL3020U02ExecuteCase1(request.getUserId(), new Date(), getHospitalCode(vertx, sessionId), request.getComments(), request.getDisplayYn(), pkcpl3020) > 0){
    		response.setResult(true);	
    	}else{
    		response.setResult(false);
    	}
		return response.build();
	}

}
