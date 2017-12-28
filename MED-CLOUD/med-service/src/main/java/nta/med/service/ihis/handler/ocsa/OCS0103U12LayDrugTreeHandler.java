package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg0140Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U12LayDrugTreeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12LayDrugTreeRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12LayDrugTreeResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U12LayDrugTreeHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U12LayDrugTreeRequest, OcsaServiceProto.OCS0103U12LayDrugTreeResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U12LayDrugTreeHandler.class);                                    
	@Resource                                                                                                       
	private Drg0140Repository drg0140Repository;                                                                    
	                                                                                                                
	@Override           
	@Transactional(readOnly = true)
	public OCS0103U12LayDrugTreeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U12LayDrugTreeRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103U12LayDrugTreeResponse.Builder response = OcsaServiceProto.OCS0103U12LayDrugTreeResponse.newBuilder();                      
		List<OCS0103U12LayDrugTreeInfo> list = drg0140Repository.getOCS0103U12LayDrugTreeListItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list)){
			for(OCS0103U12LayDrugTreeInfo item : list){
				OcsaModelProto.OCS0103U12LayDrugTreeInfo.Builder info = OcsaModelProto.OCS0103U12LayDrugTreeInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayDrugTreeList(info);
			}
		}
		return response.build();
	}

}