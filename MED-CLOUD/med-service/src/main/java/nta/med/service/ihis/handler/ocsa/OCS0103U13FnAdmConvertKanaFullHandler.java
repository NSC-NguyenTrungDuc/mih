package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U13FnAdmConvertKanaFullRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U13FnAdmConvertKanaFullResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U13FnAdmConvertKanaFullHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U13FnAdmConvertKanaFullRequest, OcsaServiceProto.OCS0103U13FnAdmConvertKanaFullResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0103U13FnAdmConvertKanaFullHandler.class);                                        
	@Resource                                                                                                       
	private Adm0000Repository adm0000Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional
	public OCS0103U13FnAdmConvertKanaFullResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U13FnAdmConvertKanaFullRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103U13FnAdmConvertKanaFullResponse.Builder response = OcsaServiceProto.OCS0103U13FnAdmConvertKanaFullResponse.newBuilder();                      
		String convertKana= adm0000Repository.callFnAdmConvertKanaFull(getHospitalCode(vertx, sessionId),request.getSearchWord());
		if(!StringUtils.isEmpty(convertKana)){
			response.setResult(convertKana);
		}
		return response.build();
	}

}