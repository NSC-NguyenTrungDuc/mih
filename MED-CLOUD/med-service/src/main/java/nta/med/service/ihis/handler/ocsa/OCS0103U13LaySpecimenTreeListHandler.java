package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U13LaySpecimenTreeListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U13LaySpecimenTreeListRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U13LaySpecimenTreeListResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U13LaySpecimenTreeListHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U13LaySpecimenTreeListRequest, OcsaServiceProto.OCS0103U13LaySpecimenTreeListResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0103U13LaySpecimenTreeListHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override                 
	@Transactional(readOnly = true)
	public OCS0103U13LaySpecimenTreeListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U13LaySpecimenTreeListRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103U13LaySpecimenTreeListResponse.Builder response = OcsaServiceProto.OCS0103U13LaySpecimenTreeListResponse.newBuilder();                      
		List<OCS0103U13LaySpecimenTreeListInfo> listLaySpecimenTree = ocs0103Repository.getOCS0103U13LaySpecimenTreeListInfo(getHospitalCode(vertx, sessionId),
				getLanguage(vertx, sessionId), request.getUser());
		if(!CollectionUtils.isEmpty(listLaySpecimenTree)){
			for(OCS0103U13LaySpecimenTreeListInfo item : listLaySpecimenTree){
				OcsaModelProto.OCS0103U13LaySpecimenTreeListInfo.Builder info = OcsaModelProto.OCS0103U13LaySpecimenTreeListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLaySpecimenTreeItem(info);
			}
		}
		return response.build();
	}

}