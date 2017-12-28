package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3211Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0150Q00FindboxMembRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0150Q00FindboxMembHandler
	extends ScreenHandler<OcsaServiceProto.OCS0150Q00FindboxMembRequest, SystemServiceProto.ComboResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0150Q00FindboxMembHandler.class);                                    
	@Resource                                                                                                       
	private Adm3211Repository adm3211Repository;                                                                    
	                                                                                                                
	@Override        
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OCS0150Q00FindboxMembRequest request)
			throws Exception {                                                               
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                       
		List<ComboListItemInfo> listFind= adm3211Repository.getOCS0150Q00FindboxMemb(getHospitalCode(vertx, sessionId),getLanguage(vertx, sessionId),request.getFind1());
		if(!CollectionUtils.isEmpty(listFind)){
			for(ComboListItemInfo item : listFind){
				CommonModelProto.ComboListItemInfo.Builder info= CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}
		return response.build();
	}

}