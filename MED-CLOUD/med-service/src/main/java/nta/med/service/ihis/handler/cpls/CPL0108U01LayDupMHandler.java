package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0108Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0108U01LayDupMRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0108U01StringResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL0108U01LayDupMHandler extends ScreenHandler <CplsServiceProto.CPL0108U01LayDupMRequest, CplsServiceProto.CPL0108U01StringResponse> {                     
	@Resource                                                                                                       
	private Cpl0108Repository cpl0108Repository;                                                                    
	                                                                                                                
	@Override      
	@Transactional(readOnly = true)
	public CPL0108U01StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL0108U01LayDupMRequest request)
			throws Exception {                                                                   
  	   	CplsServiceProto.CPL0108U01StringResponse.Builder response = CplsServiceProto.CPL0108U01StringResponse.newBuilder();                      
		List<String> getX = cpl0108Repository.getXByCodeType( request.getCodeType(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(getX) && !StringUtils.isEmpty(getX.get(0))){
			response.setResStr(getX.get(0));
		}
		return response.build();
	}      
}

