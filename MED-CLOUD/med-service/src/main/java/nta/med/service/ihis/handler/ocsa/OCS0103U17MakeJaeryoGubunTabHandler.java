package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0142Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U17MakeJaeryoGubunTabRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U17MakeJaeryoGubunTabResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U17MakeJaeryoGubunTabHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U17MakeJaeryoGubunTabRequest, OcsaServiceProto.OCS0103U17MakeJaeryoGubunTabResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U17MakeJaeryoGubunTabHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0142Repository ocs0142Repository;                                                                    
	                                                                                                                
	@Override           
	@Transactional(readOnly = true)
	public OCS0103U17MakeJaeryoGubunTabResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U17MakeJaeryoGubunTabRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103U17MakeJaeryoGubunTabResponse.Builder response = OcsaServiceProto.OCS0103U17MakeJaeryoGubunTabResponse.newBuilder();                      
		List<ComboListItemInfo> listResutl = ocs0142Repository.getOCS0103U17MakeJaeryoGubunTabListItem(getHospitalCode(vertx, sessionId), request.getInputTab(), "ORDER_GUBUN_BAS");
		if(!CollectionUtils.isEmpty(listResutl)){
			for(ComboListItemInfo item : listResutl){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboList(info);
			}
		}
		return response.build();
	}

}