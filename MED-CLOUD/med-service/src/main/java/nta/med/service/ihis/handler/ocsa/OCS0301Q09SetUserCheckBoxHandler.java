package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0301Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.helper.OrderBizHelper;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301Q09SetUserCheckBoxRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301Q09SetUserCheckBoxResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0301Q09SetUserCheckBoxHandler
	extends ScreenHandler<OcsaServiceProto.OCS0301Q09SetUserCheckBoxRequest, OcsaServiceProto.OCS0301Q09SetUserCheckBoxResponse> {                     
	@Resource                                                                                                       
	private Ocs0301Repository ocs0301Repository;                                                                    
	                                                                                                                
	@Override      
	@Transactional(readOnly = true)
	public OCS0301Q09SetUserCheckBoxResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0301Q09SetUserCheckBoxRequest request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0301Q09SetUserCheckBoxResponse.Builder response = OcsaServiceProto.OCS0301Q09SetUserCheckBoxResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getGwa())){
			String gwaAllName=OrderBizHelper.getLoadColumnCodeName(hospCode, language, request.getGwaAllName());
			if(!StringUtils.isEmpty(gwaAllName)){
				response.setGwaAllName(gwaAllName);
			}
		}
		if(!StringUtils.isEmpty(request.getMemb())){
			String gwaDoctor=OrderBizHelper.getLoadColumnCodeName(hospCode, language, request.getGwaDoctorName());
			if(StringUtils.isEmpty(gwaDoctor)){
				String userIdName=OrderBizHelper.getLoadColumnCodeName(hospCode, language, request.getUserIdName());
				if(!StringUtils.isEmpty(userIdName)){
					response.setUserIdName(userIdName);
				}
			}else{
				response.setGwaDoctorName(gwaDoctor);
			}
			String result=ocs0301Repository.getYnOCS0301Q09SetUserCheckBoxCaseMem(hospCode,request.getMemb());
			if(!StringUtils.isEmpty(result)){
				response.setResult(result);
			}
		}
		return response.build();
	}

}