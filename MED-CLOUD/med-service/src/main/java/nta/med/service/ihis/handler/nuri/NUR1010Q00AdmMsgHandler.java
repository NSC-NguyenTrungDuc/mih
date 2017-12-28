package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm0003Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1010Q00AdmMsgHandler extends ScreenHandler<NuriServiceProto.NUR1010Q00AdmMsgRequest, SystemServiceProto.StringResponse> {   
	
	@Resource                                   
	private Adm0003Repository adm0003Repository;

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00AdmMsgRequest request) throws Exception {
				
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String language = getLanguage(vertx, sessionId);
		String msg = "";
		
		if(request.getCode() == "" || StringUtils.isEmpty(request.getCode())){
			msg = "ERROR";
		}else{		
			msg = adm0003Repository.getFormEnvironInfoMessage(language, CommonUtils.parseDouble(request.getCode()));
		}
		
		response.setResult(msg);
		
		return response.build();
	}
}
