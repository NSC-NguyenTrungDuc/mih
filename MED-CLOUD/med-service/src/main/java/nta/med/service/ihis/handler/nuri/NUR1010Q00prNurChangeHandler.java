package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1010Q00prNurChangeHandler extends ScreenHandler<NuriServiceProto.NUR1010Q00prNurChangeRequest, NuriServiceProto.NUR1010Q00prNurChangeResponse> {   
	
	@Resource                                   
	private Inp2004Repository inp2004Repository;

	@Override
	@Transactional
	public NuriServiceProto.NUR1010Q00prNurChangeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00prNurChangeRequest request) throws Exception {
				
		NuriServiceProto.NUR1010Q00prNurChangeResponse.Builder response = NuriServiceProto.NUR1010Q00prNurChangeResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String err = inp2004Repository.callPrNurChangeHocode(hospCode, CommonUtils.parseDouble(request.getFromFkinp1001()), CommonUtils.parseDouble(request.getToFkinp1001()),
				request.getFromBunho(), request.getToBunho(), request.getFromKaikeiChange(), request.getToKaikeiChange(), request.getFromTransCnt(),
				request.getToTransCnt(), request.getUserId());
		
		response.setError(err);
		
		return response.build();
	}
}
