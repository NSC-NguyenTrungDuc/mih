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
import nta.med.service.ihis.proto.SystemServiceProto.GetJundaTable1Request;
import nta.med.service.ihis.proto.SystemServiceProto.GetJundaTable1Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class GetJundaTable1Handler 
	extends ScreenHandler<SystemServiceProto.GetJundaTable1Request, SystemServiceProto.GetJundaTable1Response> {                     
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public GetJundaTable1Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId, GetJundaTable1Request request)
			throws Exception {                                                                  
  	   	SystemServiceProto.GetJundaTable1Response.Builder response = SystemServiceProto.GetJundaTable1Response.newBuilder();                      
		GetJundaTableRequestInfo inputInfo = request.getInfo1();
		if(inputInfo != null){
			List<GetJundaTableResponseInfo> listJunda = ocs0103Repository.getOCSLibOrderBizGetJundaTableListItemInfo(getHospitalCode(vertx, sessionId),
					inputInfo.getHangmogCode(),inputInfo.getAppDate(),inputInfo.getIoeGubun(),inputInfo.getJundalPart());
			if(!CollectionUtils.isEmpty(listJunda)){
				for(GetJundaTableResponseInfo item: listJunda){
					SystemModelProto.GetJundaTableResponseInfo.Builder info = SystemModelProto.GetJundaTableResponseInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addInfo1(info);
				}
			}
		}
		return response.build();
	}
}