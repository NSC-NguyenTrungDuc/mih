package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cplreq1Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01IsWriteFileUpdateNoParamRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CplsCPL3010U01IsWriteFileUpdateNoParamHandler extends ScreenHandler <CplsServiceProto.CPL3010U01IsWriteFileUpdateNoParamRequest, SystemServiceProto.UpdateResponse>{
	@Resource
	private Cplreq1Repository cplreq1Repository;
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3010U01IsWriteFileUpdateNoParamRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response=SystemServiceProto.UpdateResponse.newBuilder();
		Integer result=cplreq1Repository.updateCPL3010U01IsWriteFileUpdateNoParam();
		 if(result > 0){
			 response.setResult(true);
		 }else{
			 response.setResult(false);
		 }
		 return response.build();
	}
}
