package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0118U00CheckHangmogCodeRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0118U00CheckHangmogCodeResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class OCS0118U00CheckHangmogCodeHandler extends ScreenHandler<OcsaServiceProto.OCS0118U00CheckHangmogCodeRequest,OcsaServiceProto.OCS0118U00CheckHangmogCodeResponse>  {                     
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override           
	@Transactional(readOnly = true)
	public OCS0118U00CheckHangmogCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0118U00CheckHangmogCodeRequest request) throws Exception {
  	   	OcsaServiceProto.OCS0118U00CheckHangmogCodeResponse.Builder response = OcsaServiceProto.OCS0118U00CheckHangmogCodeResponse.newBuilder(); 
  	   	String result = ocs0103Repository.getSCH3001U00VsvHangmogCode(getHospitalCode(vertx, sessionId), request.getHangmogCode(), true);
  	   	if(!StringUtils.isEmpty(result)){
  	   		OcsaModelProto.OCS0118U00CheckHangmogCodeInfo.Builder info = OcsaModelProto.OCS0118U00CheckHangmogCodeInfo.newBuilder();
  	   		info.setHangmogName(result);
  	   		response.addCheckHangmocCodeInfo(info);
  	   	}
		return response.build();
	}  

}
