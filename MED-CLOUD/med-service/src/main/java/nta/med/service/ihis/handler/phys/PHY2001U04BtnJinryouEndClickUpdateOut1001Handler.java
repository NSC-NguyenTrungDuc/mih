package nta.med.service.ihis.handler.phys;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04BtnJinryouEndClickUpdateOut1001Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class PHY2001U04BtnJinryouEndClickUpdateOut1001Handler
	extends ScreenHandler<PhysServiceProto.PHY2001U04BtnJinryouEndClickUpdateOut1001Request, SystemServiceProto.UpdateResponse> {                     
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY2001U04BtnJinryouEndClickUpdateOut1001Request request)
			throws Exception {                                                               
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
		Double pkout1001 = CommonUtils.parseDouble(request.getPkout1001());
		Integer result = out1001Repository.updateOcsoOCS1003P01JubsuInfo(getHospitalCode(vertx, sessionId), request.getNaewonYn(), pkout1001);
		return response.build();
	}
}