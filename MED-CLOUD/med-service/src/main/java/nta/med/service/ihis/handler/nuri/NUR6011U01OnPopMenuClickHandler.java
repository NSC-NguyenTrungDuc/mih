package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur6012Repository;
import nta.med.data.dao.medi.nur.Nur6014Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR6011U01OnPopMenuClickHandler extends ScreenHandler<NuriServiceProto.NUR6011U01OnPopMenuClickRequest, SystemServiceProto.UpdateResponse> {   
	
	@Resource                                   
	private Nur6012Repository nur6012Repository;
	
	@Resource                                   
	private Nur6014Repository nur6014Repository;

	@Override
	@Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR6011U01OnPopMenuClickRequest request) throws Exception {
				
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		if(nur6012Repository.deleteNur6012FromNUR6011(hospCode, request.getBunho(), request.getFromDate(), request.getBedsoreBuwi(), request.getAssessorDate()) < 0){
			response.setResult(false);
			return response.build();
		}else{
			if(nur6014Repository.deleteNur6014FromNUR6011(hospCode, request.getBunho(), request.getFromDate(), request.getBedsoreBuwi(), request.getAssessorDate()) < 0){
				throw new ExecutionException(response.setResult(false).build());
			}
		}
		
		response.setResult(true);
		return response.build();
	}
}
