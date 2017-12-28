package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.data.model.ihis.system.LayConstantInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.LayConstantInfoRequest;
import nta.med.service.ihis.proto.SystemServiceProto.LayConstantInfoResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class LayConstantInfoHandler 
	extends ScreenHandler<SystemServiceProto.LayConstantInfoRequest, SystemServiceProto.LayConstantInfoResponse> {                     
	@Resource                                                                                                       
	private Inv0102Repository inv0102Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public LayConstantInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, LayConstantInfoRequest request)
			throws Exception {                                                                  
      	   	SystemServiceProto.LayConstantInfoResponse.Builder response = SystemServiceProto.LayConstantInfoResponse.newBuilder();                      
		List<LayConstantInfo> listConstant = inv0102Repository.getLayConstantInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
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