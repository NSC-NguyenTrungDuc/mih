package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.data.dao.medi.cpl.Cpl3010Repository;
import nta.med.data.dao.medi.cpl.Cpl3020Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto.CPL3010U01SaveLayoutInfo;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class CPL3010U01SaveLayoutHandler extends ScreenHandler<CplsServiceProto.CPL3010U01SaveLayoutRequest, SystemServiceProto.UpdateResponse > {                     
	@Resource                                                                                                       
	private Cpl3010Repository cpl3010Repository; 
	@Resource
	private Cpl3020Repository cpl3020Repository;
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3010U01SaveLayoutRequest request) throws Exception {                                                                   
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
  		Integer result  = null;
  		String hospCode = getHospitalCode(vertx, sessionId);
  		String language = getLanguage(vertx, sessionId);
		for(CPL3010U01SaveLayoutInfo info : request.getSaveLayoutLstList()){
			if(cpl3020Repository.updateCPL3010U01(hospCode, language,info.getCplResult(),info.getStandardYn(),
					info.getComments1(),info.getComments2(),request.getUserId(),info.getRequestKey(),info.getBmlCode()) > 0){
				if(cpl3010Repository.updateCPL3010U01CPL3010(request.getUserId(),hospCode,info.getRequestKey()) > 0){
					result = 1;
				}else{
					throw new ExecutionException(response.build());
				}
			}else{
				throw new ExecutionException(response.build());
			}
		}
		response.setResult(result != null && result > 0);
		return response.build();
	}
}