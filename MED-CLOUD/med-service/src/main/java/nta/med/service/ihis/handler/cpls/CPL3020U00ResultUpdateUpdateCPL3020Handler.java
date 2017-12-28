package nta.med.service.ihis.handler.cpls;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl3020Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00ResultUpdateUpdateCPL3020Request;
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
public class CPL3020U00ResultUpdateUpdateCPL3020Handler extends ScreenHandler<CplsServiceProto.CPL3020U00ResultUpdateUpdateCPL3020Request, SystemServiceProto.UpdateResponse> {
	@Resource
	private Cpl3020Repository cpl3020Repository;

	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
								 String sessionId, long contextId,
								 CPL3020U00ResultUpdateUpdateCPL3020Request request) {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		try {
			String hospCode = getHospitalCode(vertx, sessionId);
			response.setResult(updateCPL3020U00(request, hospCode));
		} catch (Exception e) {
			response.setResult(false);
			throw new ExecutionException(response.build());
		}

		return response.build();
	}

	public boolean updateCPL3020U00(CplsServiceProto.CPL3020U00ResultUpdateUpdateCPL3020Request request, String hospCode){
		try {
			if(cpl3020Repository.updateCPL3020U00Cpl3020(request.getUserId(), hospCode, CommonUtils.parseDouble(request.getPkcpl3020()))>0)
				return true;
		} catch (Exception e) {
			throw new ExecutionException();
		}
		return false;
	}
}
