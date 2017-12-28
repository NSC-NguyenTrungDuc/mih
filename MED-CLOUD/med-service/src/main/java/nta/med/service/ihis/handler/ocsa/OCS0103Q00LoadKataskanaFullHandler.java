package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103Q00LoadKatakanaFullRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103Q00LoadKatakanaFullResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class OCS0103Q00LoadKataskanaFullHandler extends ScreenHandler<OcsaServiceProto.OCS0103Q00LoadKatakanaFullRequest, OcsaServiceProto.OCS0103Q00LoadKatakanaFullResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103Q00LoadKataskanaFullHandler.class);        
	
	@Resource                                                                                                       
	private Adm0000Repository adm0000Repository;                                                                        
	                                                                                                                
	@Override                       
	@Transactional(readOnly = true)
	public OCS0103Q00LoadKatakanaFullResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103Q00LoadKatakanaFullRequest request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0103Q00LoadKatakanaFullResponse.Builder response = OcsaServiceProto.OCS0103Q00LoadKatakanaFullResponse.newBuilder();
		String result = adm0000Repository.callFnAdmConvertKanaFull(getHospitalCode(vertx, sessionId), request.getText());
		if(!StringUtils.isEmpty(result)){
			response.setResult(result);
		}
		return response.build();
	}

}
