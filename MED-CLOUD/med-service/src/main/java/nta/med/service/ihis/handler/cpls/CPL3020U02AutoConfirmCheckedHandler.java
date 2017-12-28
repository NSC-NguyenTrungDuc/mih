package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02AutoConfirmCheckedRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02AutoConfirmCheckedResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL3020U02AutoConfirmCheckedHandler extends ScreenHandler <CplsServiceProto.CPL3020U02AutoConfirmCheckedRequest, CplsServiceProto.CPL3020U02AutoConfirmCheckedResponse> {                     
	@Resource                                                                                                       
	private Cpl0109Repository cpl0109Repository;                                                                    
	                                                                                                                
	@Override           
	@Transactional(readOnly = true)
	public CPL3020U02AutoConfirmCheckedResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3020U02AutoConfirmCheckedRequest request) throws Exception {                                                                   
  	   	CplsServiceProto.CPL3020U02AutoConfirmCheckedResponse.Builder response = CplsServiceProto.CPL3020U02AutoConfirmCheckedResponse.newBuilder();                      
		String value = cpl0109Repository.getCPL3020U02SetAutoConfirmChecked(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeType(), request.getJangbiCode());
		if(!StringUtils.isEmpty(value)){
			response.setCodeValue(value);
		}
		return response.build();
	}
}