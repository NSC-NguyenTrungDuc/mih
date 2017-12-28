package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0116Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0113U00GetFindWorkerRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0113U00GetFindWorkerResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0113U00GetFindWorkerHandler
	extends ScreenHandler<OcsaServiceProto.OCS0113U00GetFindWorkerRequest, OcsaServiceProto.OCS0113U00GetFindWorkerResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0113U00GetFindWorkerHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0116Repository  ocs0116Repository;                                                                    
	                                                                                                                
	@Override     
	@Transactional(readOnly = true)
	public OCS0113U00GetFindWorkerResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0113U00GetFindWorkerRequest request) throws Exception {                                                               
  	   	OcsaServiceProto.OCS0113U00GetFindWorkerResponse.Builder response = OcsaServiceProto.OCS0113U00GetFindWorkerResponse.newBuilder();                      
		List<ComboListItemInfo> list = ocs0116Repository.getOCS0113U00GetFindWorker(getHospitalCode(vertx, sessionId), false);
		if(!CollectionUtils.isEmpty(list)){
			for(ComboListItemInfo item : list){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListCombo(info);
			}
		}
		return response.build();
	}
}