package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503Q00DepartmentNameRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503Q00DepartmentNameResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0503Q00DepartmentNameHandler
	extends ScreenHandler<OcsaServiceProto.OCS0503Q00DepartmentNameRequest, OcsaServiceProto.OCS0503Q00DepartmentNameResponse> {                     
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    
	                                                                                                                
	@Override     
	@Transactional(readOnly = true)
	public OCS0503Q00DepartmentNameResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0503Q00DepartmentNameRequest request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0503Q00DepartmentNameResponse.Builder response = OcsaServiceProto.OCS0503Q00DepartmentNameResponse.newBuilder();                      
		String result = bas0260Repository.getOcsaOCS0503Q00DepartmentNameList(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getGwaCode());
		if(!StringUtils.isEmpty(result)){
			response.setGwaName(result);
		}
		return response.build();
	}

}