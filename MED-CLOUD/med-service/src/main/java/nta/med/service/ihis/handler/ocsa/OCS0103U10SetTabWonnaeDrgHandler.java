package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U10SetTabWonnaeDrgInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U10SetTabWonnaeDrgRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U10SetTabWonnaeDrgResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U10SetTabWonnaeDrgHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U10SetTabWonnaeDrgRequest, OcsaServiceProto.OCS0103U10SetTabWonnaeDrgResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U10SetTabWonnaeDrgHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override         
	@Transactional(readOnly = true)
	public OCS0103U10SetTabWonnaeDrgResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U10SetTabWonnaeDrgRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103U10SetTabWonnaeDrgResponse.Builder response = OcsaServiceProto.OCS0103U10SetTabWonnaeDrgResponse.newBuilder();                      
		List<OCS0103U10SetTabWonnaeDrgInfo> listsetTab=ocs0103Repository.getOCS0103U10SetTabWonnaeDrgInfo(getHospitalCode(vertx, sessionId),request.getYakKijunCode(),
				request.getOrderDate(),request.getHangmogCode());
		if(!CollectionUtils.isEmpty(listsetTab)){
			for(OCS0103U10SetTabWonnaeDrgInfo item : listsetTab){
				OcsaModelProto.OCS0103U10SetTabWonnaeDrgInfo.Builder info = OcsaModelProto.OCS0103U10SetTabWonnaeDrgInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getCnt() != null) {
					info.setCnt(item.getCnt().toString());
				}
				response.addWonnaeDrgItem(info);
			}
		}
		return response.build();
	}

}