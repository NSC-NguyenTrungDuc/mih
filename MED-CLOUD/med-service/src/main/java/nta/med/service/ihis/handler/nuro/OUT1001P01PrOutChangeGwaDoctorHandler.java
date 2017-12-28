package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OUT1001P01PrOutChangeGwaDoctorHandler extends ScreenHandler<NuroServiceProto.OUT1001P01PrOutChangeGwaDoctorRequest, SystemServiceProto.UpdateResponse> {                     
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    

	@Override
	@Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT1001P01PrOutChangeGwaDoctorRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String pkOut1001 = request.getPkout1001().replace(",", ".");
		
		String result = out1001Repository.callPrOutChangeGwaDoctor(getHospitalCode(vertx, sessionId), request.getBunho(), pkOut1001,
				request.getGwa(), request.getDoctor(), request.getUserId());
		if(!"0".equalsIgnoreCase(result)){
			response.setResult(false);
			response.setMsg(result);
		} else {
			response.setResult(true);
		}
		return response.build();
	}                                                                                                                 
}