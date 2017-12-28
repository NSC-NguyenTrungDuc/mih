package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0313Repository;
import nta.med.data.model.ihis.ocso.OCSACTDefaultJearyoInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCSACTDefaultJearyoHandler extends ScreenHandler<OcsoServiceProto.OCSACTDefaultJearyoRequest, OcsoServiceProto.OCSACTDefaultJearyoResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTDefaultJearyoHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0313Repository ocs0313Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCSACTDefaultJearyoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCSACTDefaultJearyoRequest request) throws Exception {
		OcsoServiceProto.OCSACTDefaultJearyoResponse.Builder response = OcsoServiceProto.OCSACTDefaultJearyoResponse.newBuilder(); 
		List<OCSACTDefaultJearyoInfo> listInfo = ocs0313Repository.getOCSACTDefaultJearyoInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getHangmogCode());
		if(!CollectionUtils.isEmpty(listInfo)){
			for(OCSACTDefaultJearyoInfo item : listInfo){
				OcsoModelProto.OCSACTDefaultJearyoInfo.Builder info = OcsoModelProto.OCSACTDefaultJearyoInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDefaultJearyoLst(info);
			}
		}
		return response.build();
	}                                                                                                                 
}