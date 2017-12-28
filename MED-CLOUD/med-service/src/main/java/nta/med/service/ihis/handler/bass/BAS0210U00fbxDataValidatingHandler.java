package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0210U00fbxDataValidatingRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0210U00fbxDataValidatingResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0210U00fbxDataValidatingHandler extends ScreenHandler<BassServiceProto.BAS0210U00fbxDataValidatingRequest, BassServiceProto.BAS0210U00fbxDataValidatingResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(BAS0210U00fbxDataValidatingHandler.class);                                        
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;                                                                    
	                                                                                                                
	@Override     
	@Transactional(readOnly = true)
	public BAS0210U00fbxDataValidatingResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			BAS0210U00fbxDataValidatingRequest request) throws Exception {
  	   	BassServiceProto.BAS0210U00fbxDataValidatingResponse.Builder response = BassServiceProto.BAS0210U00fbxDataValidatingResponse.newBuilder();                      
		if(request.getControlName().equals("fbxSearchGubun")){
			String codeName =bas0102Repository.getCodeNameByCodeTypeAndCode(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),request.getCodeType(),request.getCode());
			response.setCodeName(codeName);
		}	                                                                
		return response.build();
	}                                                                                                                 
}