package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.system.GetJundaTableResponseInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemModelProto.GetJundaTableRequestInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetJundaTableRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetJundaTableResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class GetJundaTableHandler 
	extends ScreenHandler<SystemServiceProto.GetJundaTableRequest, SystemServiceProto.GetJundaTableResponse> {                     
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public GetJundaTableResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, GetJundaTableRequest request)
			throws Exception {                                                                  
  	   	SystemServiceProto.GetJundaTableResponse.Builder response = SystemServiceProto.GetJundaTableResponse.newBuilder();                      
		GetJundaTableRequestInfo itemRequest=request.getInfo1();
		if(itemRequest != null){
			List<GetJundaTableResponseInfo> listJunda=ocs0103Repository.getOCSLibOrderBizGetJundaTableListItemInfo(getHospitalCode(vertx, sessionId),
					itemRequest.getHangmogCode(),itemRequest.getAppDate(),itemRequest.getIoeGubun(),itemRequest.getJundalPart());
			if(!CollectionUtils.isEmpty(listJunda)){
				for(GetJundaTableResponseInfo item: listJunda){
					SystemModelProto.GetJundaTableResponseInfo.Builder info =SystemModelProto.GetJundaTableResponseInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addInfo1(info);
				}
			}
		}
		return response.build();
	}                                                                                                                 
}