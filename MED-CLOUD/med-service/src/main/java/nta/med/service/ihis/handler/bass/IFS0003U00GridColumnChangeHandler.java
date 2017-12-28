package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.IFS0003U00GridColumnChangeRequest;
import nta.med.service.ihis.proto.BassServiceProto.IFS0003U00GridColumnChangeResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class IFS0003U00GridColumnChangeHandler extends ScreenHandler<BassServiceProto.IFS0003U00GridColumnChangeRequest, BassServiceProto.IFS0003U00GridColumnChangeResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(IFS0003U00GridColumnChangeHandler.class);                                    
	@Resource                                                                                                       
	private CommonRepository commonRepository;                                                                    
	@Resource                                                                                                       
	private Ifs0003Repository ifs0003Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly = true)
	public IFS0003U00GridColumnChangeResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			IFS0003U00GridColumnChangeRequest request) throws Exception {
  	   	BassServiceProto.IFS0003U00GridColumnChangeResponse.Builder response = BassServiceProto.IFS0003U00GridColumnChangeResponse.newBuilder();                      
		String result = "";
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		switch (request.getColName()) {
			case "ocs_code":
				result = commonRepository.callFnLoadOcsCodeName(hospitalCode, request.getMapGubun(), request.getCode(), language);
				break;
	
			case "if_code":
				result = ifs0003Repository.callPkgIfsBasFnLoadIfCodeName(hospitalCode, request.getMapGubun(), request.getCode());
				break;
			default:
				break;
		}
		
		if(!StringUtils.isEmpty(result)){
			response.setResult(result);
		}
		return response.build();
	}                                                                                                            
}
