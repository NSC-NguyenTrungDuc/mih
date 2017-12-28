package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.data.dao.medi.cpl.CpltempRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00FrmSigeyulDelCplTempRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class CPL0000Q00FrmSigeyulDelCplTempHandler extends ScreenHandler<CplsServiceProto.CPL0000Q00FrmSigeyulDelCplTempRequest, SystemServiceProto.UpdateResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(CPL0000Q00FrmSigeyulDelCplTempHandler.class);                                        
	@Resource                                                                                                       
	private CpltempRepository cpltempRepository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL0000Q00FrmSigeyulDelCplTempRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
		Integer result= cpltempRepository.deleteCpltempCPL0000Q00(getHospitalCode(vertx, sessionId),request.getUserId());
		 response.setResult(result != null && result > 0);
		return response.build();
	}                                                                                                                 
}