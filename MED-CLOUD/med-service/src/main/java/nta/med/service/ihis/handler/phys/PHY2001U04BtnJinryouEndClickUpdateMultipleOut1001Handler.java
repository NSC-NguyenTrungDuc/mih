package nta.med.service.ihis.handler.phys;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto.PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Info;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype") 
@Transactional
public class PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Handler 
	extends ScreenHandler<PhysServiceProto.PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Request, SystemServiceProto.UpdateResponse> {                     
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Request request)
			throws Exception {                                                                   
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();    
  	   	String hospCode = getHospitalCode(vertx, sessionId);
		Integer result = null;
		String msg = null;
		for(PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Info info : request.getPkout1001LstItemList()){
			Double pkout1001 = CommonUtils.parseDouble(info.getPkout1001());
			if("Y".equalsIgnoreCase(info.getOrderEndYn())){
				msg = "1";
				result = out1001Repository.updateOcsoOCS1003P01JubsuInfo(hospCode,  "Y", pkout1001);
			}else{
				msg = "2";
				result = out1001Repository.updateOcsoOCS1003P01JubsuInfo(hospCode,  "E", pkout1001);
			}
		}
		return response.build();
	}
}