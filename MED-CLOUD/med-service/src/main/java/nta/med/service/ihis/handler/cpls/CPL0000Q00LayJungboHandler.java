package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL0000Q00LayJungboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00LayJungboRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00LayJungboResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL0000Q00LayJungboHandler extends ScreenHandler<CplsServiceProto.CPL0000Q00LayJungboRequest, CplsServiceProto.CPL0000Q00LayJungboResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(CPL0000Q00LayJungboHandler.class);                                    
	@Resource                                                                                                       
	private Cpl2010Repository cpl2010Repository;                                                                    
	                                                                                                                
	@Override         
	@Transactional(readOnly = true)
	public CPL0000Q00LayJungboResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL0000Q00LayJungboRequest request)
					throws Exception {
  	   	CplsServiceProto.CPL0000Q00LayJungboResponse.Builder response = CplsServiceProto.CPL0000Q00LayJungboResponse.newBuilder();
		List<CPL0000Q00LayJungboListItemInfo> listCPL0000Q00LayJungboListItemInfo = cpl2010Repository.getCPL0000Q00LayJungboListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getSpecimenSer(),
    			request.getHangmogCode(), request.getSpecimenCode(), request.getEmergency());
        if(!CollectionUtils.isEmpty(listCPL0000Q00LayJungboListItemInfo)) {
        	for(CPL0000Q00LayJungboListItemInfo item : listCPL0000Q00LayJungboListItemInfo) {
        		CplsModelProto.CPL0000Q00LayJungboListItemInfo.Builder info = CplsModelProto.CPL0000Q00LayJungboListItemInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addJungboItem(info);
        	}
        }
		return response.build();
	}                                                                                                                 
}