package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.data.dao.medi.ifs.Ifs0002Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.IFS0003U00FbxSearchGubunRequest;
import nta.med.service.ihis.proto.BassServiceProto.IFS0003U00FbxSearchGubunResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class IFS0003U00FbxSearchGubunHandler extends ScreenHandler<BassServiceProto.IFS0003U00FbxSearchGubunRequest, BassServiceProto.IFS0003U00FbxSearchGubunResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(IFS0003U00FbxSearchGubunHandler.class);                                    
	@Resource                                                                                                       
	private Ifs0002Repository ifs0002Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public IFS0003U00FbxSearchGubunResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			IFS0003U00FbxSearchGubunRequest request) throws Exception {
  	   	BassServiceProto.IFS0003U00FbxSearchGubunResponse.Builder response = BassServiceProto.IFS0003U00FbxSearchGubunResponse.newBuilder();                      
		String result = ifs0002Repository.getIfs003U03FbxSearchGubun(getHospitalCode(vertx, sessionId), request.getCodeType(), request.getCode());
		if(!StringUtils.isEmpty(result)){
			response.setCodeName(result);
		}
		return response.build();
	}
}