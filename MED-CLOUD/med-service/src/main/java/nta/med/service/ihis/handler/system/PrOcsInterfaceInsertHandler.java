package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1053Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.PrOcsInterfaceInsertInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.PrOcsInterfaceInsertRequest;
import nta.med.service.ihis.proto.SystemServiceProto.PrOcsInterfaceInsertResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PrOcsInterfaceInsertHandler extends ScreenHandler <SystemServiceProto.PrOcsInterfaceInsertRequest, SystemServiceProto.PrOcsInterfaceInsertResponse> {                     
	@Resource                                                                                                       
	private Ocs1053Repository ocs1053Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional
	public PrOcsInterfaceInsertResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PrOcsInterfaceInsertRequest request) throws Exception {                                                                 
  	   	SystemServiceProto.PrOcsInterfaceInsertResponse.Builder response = SystemServiceProto.PrOcsInterfaceInsertResponse.newBuilder();                      
		String result="";
		for(PrOcsInterfaceInsertInfo item : request.getInfoItemList()){
			result=ocs1053Repository.callPrOcsInterfaceInsert(getHospitalCode(vertx, sessionId),item.getIoGubun(),
					CommonUtils.parseInteger(item.getPkKey()),item.getUserId());
			if(!result.equals("0")){
				break;
			}
		}
		if(!StringUtils.isEmpty(result)){
			response.setResult(result);
		}
		return response.build();
	}
}