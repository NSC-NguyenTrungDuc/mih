package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00FwkDanuiRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00FwkDanuiResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0311U00FwkDanuiHandler
	extends ScreenHandler<OcsaServiceProto.OCS0311U00FwkDanuiRequest, OcsaServiceProto.OCS0311U00FwkDanuiResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly = true)
	public OCS0311U00FwkDanuiResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0311U00FwkDanuiRequest request)
			throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0311U00FwkDanuiResponse.Builder response = OcsaServiceProto.OCS0311U00FwkDanuiResponse.newBuilder();                      
		List<ComboListItemInfo> listFwkDanui = ocs0132Repository.getInjsComboListItemInfo(getHospitalCode(vertx, sessionId),getLanguage(vertx, sessionId),"ORD_DANUI");
		 if(listFwkDanui !=null && !listFwkDanui.isEmpty()){
			 for(ComboListItemInfo item : listFwkDanui){
				 CommonModelProto.ComboListItemInfo.Builder info= CommonModelProto.ComboListItemInfo.newBuilder();
				 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				 response.addFwkDanuiList(info);
			 }
		 }
		 return response.build();
	}

}