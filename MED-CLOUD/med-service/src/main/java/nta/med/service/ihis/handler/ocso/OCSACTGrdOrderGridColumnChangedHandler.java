package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCSACTGrdOrderGridColumnChangedHandler extends ScreenHandler<OcsoServiceProto.OCSACTGrdOrderGridColumnChangedRequest, OcsoServiceProto.OCSACTSingleStringResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTGrdOrderGridColumnChangedHandler.class);                                    
	@Resource                                                                                                       
	private Adm3200Repository adm3200Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCSACTSingleStringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCSACTGrdOrderGridColumnChangedRequest request) throws Exception {
		OcsoServiceProto.OCSACTSingleStringResponse.Builder response = OcsoServiceProto.OCSACTSingleStringResponse.newBuilder(); 
		List<String> listUser = adm3200Repository.getUserNameList(getHospitalCode(vertx, sessionId), request.getUserId());
		if(!CollectionUtils.isEmpty(listUser)){
			String user = listUser.get(0);
			if(!StringUtils.isEmpty(user)){
				response.setResponseStr(user);
			}
		}
		return response.build();
	}                                                                                                                 
}