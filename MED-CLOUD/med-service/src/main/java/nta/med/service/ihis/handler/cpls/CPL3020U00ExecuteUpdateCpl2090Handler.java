package nta.med.service.ihis.handler.cpls;

import nta.med.core.common.exception.ExecutionException;
import nta.med.data.dao.medi.cpl.Cpl2090Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00ExecuteUpdateCpl2090Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Transactional
@Service
@Scope("prototype")
public class CPL3020U00ExecuteUpdateCpl2090Handler extends ScreenHandler <CplsServiceProto.CPL3020U00ExecuteUpdateCpl2090Request, SystemServiceProto.UpdateResponse> {
	@Resource
	private Cpl2090Repository cpl2090Repository;

	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
								 String sessionId, long contextId,
								 CPL3020U00ExecuteUpdateCpl2090Request request) {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		try {
			String hospCode = getHospitalCode(vertx, sessionId);
			response.setResult(executeUpdateCpl2090(request, hospCode));
		} catch (Exception e) {
			response.setResult(false);
			throw new ExecutionException(response.build());
		}
		return response.build();

	}

	public boolean executeUpdateCpl2090(CplsServiceProto.CPL3020U00ExecuteUpdateCpl2090Request request, String hospCode){
		try {
			if(cpl2090Repository.updateCPL3020U00CPL2090(
					request.getUserId(), 
					request.getNote(), 
					request.getCode(), 
					request.getEtcComment(), 
					request.getJundalGubun(), 
					request.getSpecimenSer(),
					hospCode)>0)
				return true;
		} catch (Exception e) {
			throw new ExecutionException();
		}
		return false;
	}
}
