package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.pfe.Pfe0102Repository;
import nta.med.data.model.ihis.system.LayConstantInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCSACTLayconstantAlarmHandler extends ScreenHandler<OcsoServiceProto.OCSACTLayconstantAlarmRequest, SystemServiceProto.LayConstantInfoResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTLayconstantAlarmHandler.class);                                    
	@Resource                                                                                                       
	private Pfe0102Repository pfe0102Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.LayConstantInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCSACTLayconstantAlarmRequest request) throws Exception {
		SystemServiceProto.LayConstantInfoResponse.Builder response = SystemServiceProto.LayConstantInfoResponse.newBuilder();
		List<LayConstantInfo> listConstant = pfe0102Repository.getOCSACTLayconstant(getHospitalCode(vertx, sessionId), "PFE_ALARM", getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listConstant)){
			for(LayConstantInfo item : listConstant){
				SystemModelProto.LayConstantInfo.Builder info = SystemModelProto.LayConstantInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addLayConstantItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}