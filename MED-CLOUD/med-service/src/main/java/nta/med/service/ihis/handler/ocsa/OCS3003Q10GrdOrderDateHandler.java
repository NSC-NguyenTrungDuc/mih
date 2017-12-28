package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.ocsa.OCS3003Q10GrdOrderDateListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS3003Q10GrdOrderDateRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS3003Q10GrdOrderDateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS3003Q10GrdOrderDateHandler
	extends ScreenHandler<OcsaServiceProto.OCS3003Q10GrdOrderDateRequest, OcsaServiceProto.OCS3003Q10GrdOrderDateResponse> {                     
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override             
	@Transactional(readOnly = true)
	public OCS3003Q10GrdOrderDateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS3003Q10GrdOrderDateRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS3003Q10GrdOrderDateResponse.Builder response = OcsaServiceProto.OCS3003Q10GrdOrderDateResponse.newBuilder();                      
		List<OCS3003Q10GrdOrderDateListItemInfo> list = out1001Repository.getOCS3003Q10GrdOrderDateListItemInfo(getHospitalCode(vertx, sessionId),
				getLanguage(vertx, sessionId), request.getIoGubun(), request.getBunho(),
				request.getOrderDate(), request.getOrderGubun());
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS3003Q10GrdOrderDateListItemInfo item:list) {
				OcsaModelProto.OCS3003Q10GrdOrderDateListItemInfo.Builder info = OcsaModelProto.OCS3003Q10GrdOrderDateListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListInfo(info);
			}
		}
		 return response.build();
	}
}