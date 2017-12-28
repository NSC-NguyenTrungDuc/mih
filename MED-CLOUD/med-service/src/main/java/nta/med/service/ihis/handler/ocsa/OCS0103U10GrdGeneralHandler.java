package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U10GrdGeneralInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U10GrdGeneralRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U10GrdGeneralResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U10GrdGeneralHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U10GrdGeneralRequest, OcsaServiceProto.OCS0103U10GrdGeneralResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U10GrdGeneralHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override                 
	@Transactional(readOnly = true)
	public OCS0103U10GrdGeneralResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U10GrdGeneralRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U10GrdGeneralResponse.Builder response = OcsaServiceProto.OCS0103U10GrdGeneralResponse.newBuilder();                      
		List<OCS0103U10GrdGeneralInfo> listGrdGenera =ocs0103Repository.listOCS0103U10GrdGeneralInfo(getHospitalCode(vertx, sessionId),request.getFilter(),
				request.getYakKijunCode(),request.getOrderDate(),request.getHangmogCode(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listGrdGenera)){
			for(OCS0103U10GrdGeneralInfo item : listGrdGenera){
				OcsaModelProto.OCS0103U10GrdGeneralInfo.Builder info= OcsaModelProto.OCS0103U10GrdGeneralInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdGenItem(info);
			}
		}
		return response.build();
	}

}