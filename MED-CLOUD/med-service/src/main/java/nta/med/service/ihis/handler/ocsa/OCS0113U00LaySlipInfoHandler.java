package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0101Repository;
import nta.med.data.model.ihis.ocsa.OCS0113U00LaySlipListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0113U00LaySlipInfoRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0113U00LaySlipInfoResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0113U00LaySlipInfoHandler
	extends ScreenHandler<OcsaServiceProto.OCS0113U00LaySlipInfoRequest, OcsaServiceProto.OCS0113U00LaySlipInfoResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0113U00LaySlipInfoHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0101Repository  ocs0101Repository;                                                                    
	                                                                                                                
	@Override                                                             
	@Transactional(readOnly = true)
	public OCS0113U00LaySlipInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0113U00LaySlipInfoRequest request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0113U00LaySlipInfoResponse.Builder response = OcsaServiceProto.OCS0113U00LaySlipInfoResponse.newBuilder();                      
		List<OCS0113U00LaySlipListItemInfo> listResult = ocs0101Repository.getOCS0113U00LaySlipItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listResult)){
			for(OCS0113U00LaySlipListItemInfo item : listResult){
				OcsaModelProto.OCS0113U00LaySlipListItemInfo.Builder info = OcsaModelProto.OCS0113U00LaySlipListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListLaySlipInfo(info);
			}
		}
		return response.build();
	}


}