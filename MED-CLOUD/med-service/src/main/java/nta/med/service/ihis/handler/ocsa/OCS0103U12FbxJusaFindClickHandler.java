package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12FbxJusaFindClickRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12FbxJusaFindClickResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U12FbxJusaFindClickHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U12FbxJusaFindClickRequest, OcsaServiceProto.OCS0103U12FbxJusaFindClickResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U12FbxJusaFindClickHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override        
	@Transactional(readOnly = true)
	public OCS0103U12FbxJusaFindClickResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U12FbxJusaFindClickRequest request) throws Exception {                                                                   
      	   	OcsaServiceProto.OCS0103U12FbxJusaFindClickResponse.Builder response = OcsaServiceProto.OCS0103U12FbxJusaFindClickResponse.newBuilder();                      
			List<ComboListItemInfo> listFbx= ocs0132Repository.getOCS0103U12FbxJusaComboListItemInfo(getHospitalCode(vertx, sessionId), 
					getLanguage(vertx, sessionId),request.getFind1(),request.getIoGubun());
			if(!CollectionUtils.isEmpty(listFbx)){
				for(ComboListItemInfo item: listFbx){
					CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addCboResult(info);
				}
			}
			return response.build();
	}

}