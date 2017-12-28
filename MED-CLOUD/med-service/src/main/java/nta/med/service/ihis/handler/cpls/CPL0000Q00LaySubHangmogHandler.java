package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl3020Repository;
import nta.med.data.model.ihis.cpls.CPL0000Q00LaySubHangmogListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00LaySubHangmogRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00LaySubHangmogResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL0000Q00LaySubHangmogHandler extends ScreenHandler<CplsServiceProto.CPL0000Q00LaySubHangmogRequest, CplsServiceProto.CPL0000Q00LaySubHangmogResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(CPL0000Q00LaySubHangmogHandler.class);                                    
	@Resource                                                                                                       
	private Cpl3020Repository cpl3020Repository;                                                                    
	                                                                                                                
	@Override                  
	@Transactional(readOnly = true)
	public CPL0000Q00LaySubHangmogResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL0000Q00LaySubHangmogRequest request) throws Exception {
  	   	CplsServiceProto.CPL0000Q00LaySubHangmogResponse.Builder response = CplsServiceProto.CPL0000Q00LaySubHangmogResponse.newBuilder();                      
		List<CPL0000Q00LaySubHangmogListItemInfo> listCPL0000Q00LaySubHangmogListItemInfo = cpl3020Repository.getCPL0000Q00LaySubHangmogListItemInfo(getHospitalCode(vertx, sessionId),
        		request.getBunho(), request.getHangmogCode());
        if(!CollectionUtils.isEmpty(listCPL0000Q00LaySubHangmogListItemInfo)) {
        	for(CPL0000Q00LaySubHangmogListItemInfo item : listCPL0000Q00LaySubHangmogListItemInfo) {
        		CplsModelProto.CPL0000Q00LaySubHangmogListItemInfo.Builder info = CplsModelProto.CPL0000Q00LaySubHangmogListItemInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addSubHangmogItem(info);
        	}
        }
        return response.build();
	}
}