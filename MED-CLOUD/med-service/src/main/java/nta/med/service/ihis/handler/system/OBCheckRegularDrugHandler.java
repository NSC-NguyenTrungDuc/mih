package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs1023Repository;
import nta.med.data.model.ihis.system.OBCheckRegularDrugInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OBCheckRegularDrugRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OBCheckRegularDrugResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OBCheckRegularDrugHandler
	extends ScreenHandler<SystemServiceProto.OBCheckRegularDrugRequest, SystemServiceProto.OBCheckRegularDrugResponse> {                     
	@Resource                                                                                                       
	private Ocs1023Repository ocs1023Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OBCheckRegularDrugResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OBCheckRegularDrugRequest request)
			throws Exception {                                                                
      	   	SystemServiceProto.OBCheckRegularDrugResponse.Builder response = SystemServiceProto.OBCheckRegularDrugResponse.newBuilder();                      
		List<OBCheckRegularDrugInfo> listCheckRegular=ocs1023Repository.getOBCheckRegularDrugInfo(getHospitalCode(vertx, sessionId),request.getBunho(),request.getGwa(),request.getHangmog());
		if(!CollectionUtils.isEmpty(listCheckRegular)){
			for(OBCheckRegularDrugInfo item :listCheckRegular){
				CommonModelProto.OBCheckRegularDrugInfo.Builder info =CommonModelProto.OBCheckRegularDrugInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addRegDrugItem(info);
			}
		}
		return response.build();
	}
}