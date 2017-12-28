package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0253Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1010Q00UpdateSetBedStatusHandler extends ScreenHandler<NuriServiceProto.NUR1010Q00UpdateSetBedStatusRequest, SystemServiceProto.UpdateResponse> {   
	
	@Resource                                   
	private Bas0253Repository bas0253Repository;

	@Override
	@Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00UpdateSetBedStatusRequest request) throws Exception {
				
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		if(bas0253Repository.updateSetBedStatus(hospCode, request.getHoCode(), request.getHoDong(), request.getBedNo(), request.getBedStatus(), request.getBedLockText()) > 0){
			response.setResult(true);
		}else{
			response.setResult(false);
		}
		
		return response.build();
	}
}
