package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U12IsUpdateCheckSelectInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12IsUpdateCheckSelectRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12IsUpdateCheckSelectResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U12IsUpdateCheckSelectHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U12IsUpdateCheckSelectRequest, OcsaServiceProto.OCS0103U12IsUpdateCheckSelectResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U12IsUpdateCheckSelectHandler.class);                                    
	@Resource                                                                                                       
	private Ocs2003Repository ocs2003Repository;                                                                    
	                                                                                                                
	@Override               
	@Transactional(readOnly = true)
	public OCS0103U12IsUpdateCheckSelectResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U12IsUpdateCheckSelectRequest request) throws Exception {                                                               
  	   	OcsaServiceProto.OCS0103U12IsUpdateCheckSelectResponse.Builder response = OcsaServiceProto.OCS0103U12IsUpdateCheckSelectResponse.newBuilder();                      
				
		List<OCS0103U12IsUpdateCheckSelectInfo> list = ocs2003Repository.getOCS0103U12IsUpdateCheckSelect(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getPkocs2003()));
		if(!CollectionUtils.isEmpty(list)){
			for(OCS0103U12IsUpdateCheckSelectInfo item : list){
				OcsaModelProto.OCS0103U12IsUpdateCheckSelectInfo.Builder info = OcsaModelProto.OCS0103U12IsUpdateCheckSelectInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addSelectInfo(info);
			}
		}
		return response.build();
	}

}