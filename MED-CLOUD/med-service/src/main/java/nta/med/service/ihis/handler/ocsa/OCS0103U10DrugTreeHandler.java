package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg0141Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U10DrugTreeInfo;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U10DrugTreeRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U10DrugTreeResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U10DrugTreeHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U10DrugTreeRequest, OcsaServiceProto.OCS0103U10DrugTreeResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U10DrugTreeHandler.class);                                    
	@Resource                                                                                                       
	private Drg0141Repository drg0141Repository;                                                                    
	                                                                                                                
	@Override           
	@Transactional(readOnly = true)
	public OCS0103U10DrugTreeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0103U10DrugTreeRequest request)
			throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U10DrugTreeResponse.Builder response = OcsaServiceProto.OCS0103U10DrugTreeResponse.newBuilder();                      
		List<OCS0103U10DrugTreeInfo> listDrg=drg0141Repository.listOCS0103U10DrugTreeInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listDrg)){
			for(OCS0103U10DrugTreeInfo item :listDrg){
				OcsaModelProto.OCS0103U10DrugTreeInfo.Builder info= OcsaModelProto.OCS0103U10DrugTreeInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDrugTreeItem(info);
			}
		}
		return response.build();
	}

}