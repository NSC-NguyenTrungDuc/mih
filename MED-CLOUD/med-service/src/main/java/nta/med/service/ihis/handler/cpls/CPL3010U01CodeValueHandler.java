package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01CodeValueRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01CodeValueResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL3010U01CodeValueHandler extends ScreenHandler <CplsServiceProto.CPL3010U01CodeValueRequest, CplsServiceProto.CPL3010U01CodeValueResponse> {                     
	@Resource                                                                                                       
	private Cpl0109Repository cpl0109Repository;                                                                    
	                                                                                                                
	@Override           
	@Transactional(readOnly = true)
	public CPL3010U01CodeValueResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL3010U01CodeValueRequest request)
			throws Exception  {                                                                   
  	   	CplsServiceProto.CPL3010U01CodeValueResponse.Builder response = CplsServiceProto.CPL3010U01CodeValueResponse.newBuilder();                      
		String codeValue = cpl0109Repository.getCPL3020U02SetAutoConfirmChecked(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),"IF","IFPATH");
		if(!StringUtils.isEmpty(codeValue)){
			response.setCodeValue(codeValue);
		}
		return response.build();
	}
}