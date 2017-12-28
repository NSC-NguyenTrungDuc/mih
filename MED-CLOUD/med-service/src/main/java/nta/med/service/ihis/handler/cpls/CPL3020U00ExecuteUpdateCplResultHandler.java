package nta.med.service.ihis.handler.cpls;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl3010Repository;
import nta.med.data.dao.medi.cpl.Cpl3020Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00ExecuteUpdateCplResultRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.Date;

@Transactional
@Service
@Scope("prototype")
public class CPL3020U00ExecuteUpdateCplResultHandler extends ScreenHandler<CplsServiceProto.CPL3020U00ExecuteUpdateCplResultRequest, SystemServiceProto.UpdateResponse> {
	@Resource
	private Cpl3020Repository cpl3020Repository;
	
	@Resource
	private Cpl3010Repository cpl3010Repository;

	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
								 String sessionId, long contextId,
								 CPL3020U00ExecuteUpdateCplResultRequest request) {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		try {
			String hospCode = getHospitalCode(vertx, sessionId);
			response.setResult(updateCPL3020CplResult(request, hospCode));
		} catch (Exception e) {
			response.setResult(false);
			throw new ExecutionException(response.build());
		}

		return response.build();
	}

	public boolean updateCPL3020CplResult(CplsServiceProto.CPL3020U00ExecuteUpdateCplResultRequest request, String hospCode){
		try {
			boolean update3020 = false;
			boolean update3010 = false;
			 if(cpl3020Repository.updateCPL3020U00Cpl3020CplResult(request.getUserId(),new Date(), hospCode,CommonUtils.parseDouble(request.getPkcpl3020()))>0){
				 update3020 = true;
			 }
			 if(cpl3010Repository.updateCPL3020U00CPL3010CplResult(request.getUserId(),new Date(), null,null,hospCode, request.getLabNo(), request.getSpecimenSer())>0){
				 update3010 = true;
			 }
			 if(update3020 && update3010){
				return true;
			 }else{
				return false; 
			 }
		} catch (Exception e) {
			throw new ExecutionException();
		}
	}
}
