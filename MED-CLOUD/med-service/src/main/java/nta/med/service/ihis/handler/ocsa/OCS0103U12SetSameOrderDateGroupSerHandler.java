package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12SetSameOrderDateGroupSerRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12SetSameOrderDateGroupSerResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U12SetSameOrderDateGroupSerHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U12SetSameOrderDateGroupSerRequest, OcsaServiceProto.OCS0103U12SetSameOrderDateGroupSerResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U12SetSameOrderDateGroupSerHandler.class);                                    
	@Resource                                                                                                       
	private Ocs2003Repository ocs2003Repository;                                                                    
	                                                                                                                
	@Override               
	@Transactional(readOnly = true)
	public OCS0103U12SetSameOrderDateGroupSerResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U12SetSameOrderDateGroupSerRequest request) throws Exception {                                                               
  	   	OcsaServiceProto.OCS0103U12SetSameOrderDateGroupSerResponse.Builder response = OcsaServiceProto.OCS0103U12SetSameOrderDateGroupSerResponse.newBuilder();                      
		List<String> list = ocs2003Repository.getOCS0103U12SetSameOrderDateGroupSerListItem(getHospitalCode(vertx, sessionId), DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD),
				request.getInputTab(), request.getBunho(), request.getInputDoctor());
		if(!CollectionUtils.isEmpty(list)){
			for(String item : list){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addData(info);
			}
		}
		return response.build();
	}

}