package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1024Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0103U12IsUpdateCheckInsertInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12IsUpdateCheckInsertRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U12IsUpdateCheckInsertHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U12IsUpdateCheckInsertRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U12IsUpdateCheckInsertHandler.class);                                    
	@Resource                                                                                                       
	private Ocs1024Repository ocs1024Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly = true)
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U12IsUpdateCheckInsertRequest request) throws Exception {                                                                   
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
		if(request.getInsertInfoCount() > 0 ){
			for(OCS0103U12IsUpdateCheckInsertInfo item : request.getInsertInfoList()){
				String result = ocs1024Repository.callFnOcsInsertBgtdrgYn(	getHospitalCode(vertx, sessionId), item.getBunho(),
																			CommonUtils.parseDouble(item.getPkocs1024()) ,
																			item.getSuryang(), item.getDv(), item.getDvTime(), item.getNalsu());
				if(result.equalsIgnoreCase("Y")){
					response.setResult(true);
				}else{
					response.setResult(false);
					break;
				}
			}
		}else{
			response.setResult(true);
		}
		return response.build();
	}

}