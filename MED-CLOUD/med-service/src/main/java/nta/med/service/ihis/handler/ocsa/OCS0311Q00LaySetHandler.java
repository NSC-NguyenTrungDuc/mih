package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0312Repository;
import nta.med.data.model.ihis.ocsa.OCS0311U00grdSetCodeListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311Q00LaySetRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311Q00LaySetResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0311Q00LaySetHandler
	extends ScreenHandler<OcsaServiceProto.OCS0311Q00LaySetRequest, OcsaServiceProto.OCS0311Q00LaySetResponse> {                     
	@Resource                                                                                                       
	private Ocs0312Repository ocs0312Repository;                                                                    
	                                                                                                                
	@Override            
	@Transactional(readOnly = true)
	public OCS0311Q00LaySetResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0311Q00LaySetRequest request)
			throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0311Q00LaySetResponse.Builder response = OcsaServiceProto.OCS0311Q00LaySetResponse.newBuilder();                      
		List<OCS0311U00grdSetCodeListInfo> listLaySet = ocs0312Repository.getOCS0311U00grdSetCodeListInfo(getHospitalCode(vertx, sessionId),request.getSetPart(),request.getHangmogCode());
		if(!CollectionUtils.isEmpty(listLaySet)){
			for(OCS0311U00grdSetCodeListInfo item : listLaySet){
				OcsaModelProto.OCS0311Q00LaySetInfo.Builder info = OcsaModelProto.OCS0311Q00LaySetInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLaySetItem(info);
			}
		}
		return response.build();
	}

}