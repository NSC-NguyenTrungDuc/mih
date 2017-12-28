package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.data.model.ihis.cpls.CPL0106U00GrdGroupListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0106U00GrdGroupRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0106U00GrdGroupResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL0106U00GrdGroupHandler extends ScreenHandler<CplsServiceProto.CPL0106U00GrdGroupRequest, CplsServiceProto.CPL0106U00GrdGroupResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(CPL0106U00GrdGroupHandler.class);                                    
	@Resource                                                                                                       
	private Cpl0101Repository cpl0101Repository;                                                                    
	                                                                                                                
	@Override        
	@Transactional(readOnly = true)
	public CPL0106U00GrdGroupResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL0106U00GrdGroupRequest request)
					throws Exception {
  	    CplsServiceProto.CPL0106U00GrdGroupResponse.Builder response = CplsServiceProto.CPL0106U00GrdGroupResponse.newBuilder();                      
        List<CPL0106U00GrdGroupListItemInfo> listGrdGroup = cpl0101Repository.getCPL0106U00GrdGroupListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getHangmogCode(),request.getGumsaName());
		if(!CollectionUtils.isEmpty(listGrdGroup)) {
			for(CPL0106U00GrdGroupListItemInfo item : listGrdGroup) {
				CplsModelProto.CPL0106U00GrdGroupListItemInfo.Builder info = CplsModelProto.CPL0106U00GrdGroupListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdGroupList(info);
			}
		}
		return response.build();
	}                                                                                                                 
}