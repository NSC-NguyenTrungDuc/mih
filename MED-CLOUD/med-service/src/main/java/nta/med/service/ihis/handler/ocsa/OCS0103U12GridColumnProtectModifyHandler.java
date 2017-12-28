package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12GridColumnProtectModifyRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12GridColumnProtectModifyResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U12GridColumnProtectModifyHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U12GridColumnProtectModifyRequest, OcsaServiceProto.OCS0103U12GridColumnProtectModifyResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U12GridColumnProtectModifyHandler.class);                                    
	@Resource                                                                                                       
	private Ocs2003Repository ocs2003Repository;                                                                    
	                                                                                                                
	@Override                 
	@Transactional(readOnly = true)
	public OCS0103U12GridColumnProtectModifyResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U12GridColumnProtectModifyRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U12GridColumnProtectModifyResponse.Builder response = OcsaServiceProto.OCS0103U12GridColumnProtectModifyResponse.newBuilder();                      
		String grdColumn=ocs2003Repository.getOCS0103U12GridColumnProtectModify(getHospitalCode(vertx, sessionId),request.getBunho(),
				DateUtil.toDate(request.getOrderDate(),DateUtil.PATTERN_YYMMDD),request.getHangmogCode());
		if(!StringUtils.isEmpty(grdColumn)){
			response.setCnt(grdColumn);
		}
		return response.build();
	}

}