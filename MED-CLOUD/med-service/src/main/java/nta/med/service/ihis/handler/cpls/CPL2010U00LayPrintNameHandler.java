package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm3300Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00LayPrintNameRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00LayPrintNameResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL2010U00LayPrintNameHandler extends ScreenHandler <CplsServiceProto.CPL2010U00LayPrintNameRequest, CplsServiceProto.CPL2010U00LayPrintNameResponse> {                     
	@Resource                                                                                                       
	private Adm3300Repository adm3300Repository;                                                                    
	                                                                                                                
	@Override          
	@Transactional(readOnly = true)
	public CPL2010U00LayPrintNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL2010U00LayPrintNameRequest request) throws Exception  {                                                                   
  	   	CplsServiceProto.CPL2010U00LayPrintNameResponse.Builder response = CplsServiceProto.CPL2010U00LayPrintNameResponse.newBuilder();                      
		String result = adm3300Repository.getLayPrintName(getHospitalCode(vertx, sessionId), request.getIpAddress());
		if(!StringUtils.isEmpty(result)){
			response.setPrintName(result);
		}
		return response.build();
	}
}