package nta.med.service.ihis.handler.phys;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04SetSinryouryouAutoRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04SetSinryouryouAutoResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY2001U04SetSinryouryouAutoHandler
	extends ScreenHandler<PhysServiceProto.PHY2001U04SetSinryouryouAutoRequest, PhysServiceProto.PHY2001U04SetSinryouryouAutoResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override             
	@Transactional(readOnly=true)
	public PHY2001U04SetSinryouryouAutoResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			PHY2001U04SetSinryouryouAutoRequest request) throws Exception {                                                                  
  	   	PhysServiceProto.PHY2001U04SetSinryouryouAutoResponse.Builder response = PhysServiceProto.PHY2001U04SetSinryouryouAutoResponse.newBuilder();                      
  	    String hospCode = getHospitalCode(vertx, sessionId);
	   	String language = getLanguage(vertx, sessionId);
		//ex with code =  "AUTO_YN"
		List<String> listResult = ocs0132Repository.getOCS0132CodeNameList(hospCode, language, request.getCodeType(), request.getCode1(),false);
		if(!CollectionUtils.isEmpty(listResult) && !StringUtils.isEmpty(listResult.get(0))){
			response.setObj1(listResult.get(0));
		}
		//ex with code =  ""ENABLE_YN"
		List<String> listResult2 = ocs0132Repository.getOCS0132CodeNameList(hospCode, language, request.getCodeType(), request.getCode2(),false);
		if(!CollectionUtils.isEmpty(listResult2) && !StringUtils.isEmpty(listResult2.get(0))){
			response.setObj2(listResult2.get(0));
		}
		return response.build();
	}
}