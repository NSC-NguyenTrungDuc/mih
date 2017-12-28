package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0311Repository;
import nta.med.data.model.ihis.ocsa.OCS0311Q00LayRootListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311Q00LayRootListRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311Q00LayRootListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0311Q00LayRootListHandler
	extends ScreenHandler<OcsaServiceProto.OCS0311Q00LayRootListRequest, OcsaServiceProto.OCS0311Q00LayRootListResponse> {                     
	@Resource                                                                                                       
	private Ocs0311Repository ocs0311Repository;                                                                    
	                                                                                                                
	@Override      
	@Transactional(readOnly = true)
	public OCS0311Q00LayRootListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0311Q00LayRootListRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0311Q00LayRootListResponse.Builder response = OcsaServiceProto.OCS0311Q00LayRootListResponse.newBuilder();                      
		List<OCS0311Q00LayRootListInfo> listLayRoot = ocs0311Repository.getOCS0311Q00LayRootListInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),request.getSetPart(),request.getHangmogCode());
		if(!CollectionUtils.isEmpty(listLayRoot)){
			for(OCS0311Q00LayRootListInfo item : listLayRoot){
				OcsaModelProto.OCS0311Q00LayRootListInfo.Builder info = OcsaModelProto.OCS0311Q00LayRootListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayRootListItem(info);
			}
		}
		return response.build();
	}

}