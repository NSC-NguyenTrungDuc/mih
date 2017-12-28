package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0108Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetDefaultOrdDanui2Request;
import nta.med.service.ihis.proto.SystemServiceProto.GetDefaultOrdDanui2Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class GetDefaultOrdDanui2Handler
	extends ScreenHandler<SystemServiceProto.GetDefaultOrdDanui2Request, SystemServiceProto.GetDefaultOrdDanui2Response> {                     
	@Resource                                                                                                       
	private Ocs0108Repository ocs0108Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public GetDefaultOrdDanui2Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId, GetDefaultOrdDanui2Request request)
			throws Exception {                                                               
  	   	SystemServiceProto.GetDefaultOrdDanui2Response.Builder response = SystemServiceProto.GetDefaultOrdDanui2Response.newBuilder();                      
		List<ComboListItemInfo> listOrdDanui = ocs0108Repository.getGetDefaultOrdDanuiInfo(getHospitalCode(vertx, sessionId),
				getLanguage(vertx, sessionId),request.getHangmogCode());
		if(!CollectionUtils.isEmpty(listOrdDanui)){
			for(ComboListItemInfo item : listOrdDanui){
				CommonModelProto.GetDefaultOrdDanuiInfo.Builder info= CommonModelProto.GetDefaultOrdDanuiInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDanuiItem(info);
			}
		}
		return response.build();
	}

}