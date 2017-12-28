package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.data.model.ihis.cpls.CPL0000Q00LaySigeyulTempListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00LaySigeyulTempRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00LaySigeyulTempResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL0000Q00LaySigeyulTempHandler extends ScreenHandler<CplsServiceProto.CPL0000Q00LaySigeyulTempRequest, CplsServiceProto.CPL0000Q00LaySigeyulTempResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(CPL0000Q00LaySigeyulTempHandler.class);                                    
	@Resource                                                                                                       
	private Cpl0101Repository cpl0101Repository;                                                                    
	                                                                                                                
	@Override      
	@Transactional(readOnly = true)
	public CPL0000Q00LaySigeyulTempResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL0000Q00LaySigeyulTempRequest request) throws Exception {
  	   	CplsServiceProto.CPL0000Q00LaySigeyulTempResponse.Builder response = CplsServiceProto.CPL0000Q00LaySigeyulTempResponse.newBuilder();                      
    	List<CPL0000Q00LaySigeyulTempListItemInfo> listCPL0000Q00LaySigeyulTempListItemInfo = cpl0101Repository.getCPL0000Q00LaySigeyulTempListItemInfo(getHospitalCode(vertx, sessionId), request.getGroupHangmog(),
    			request.getSpecimenCode(), request.getHangmogCode(),getLanguage(vertx, sessionId));
        if(!CollectionUtils.isEmpty(listCPL0000Q00LaySigeyulTempListItemInfo)) {
        	for(CPL0000Q00LaySigeyulTempListItemInfo item : listCPL0000Q00LaySigeyulTempListItemInfo) {
        		CplsModelProto.CPL0000Q00LaySigeyulTempListItemInfo.Builder info = CplsModelProto.CPL0000Q00LaySigeyulTempListItemInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addSigeyulTempItem(info);
        	}
        }
		return response.build();
	}                                                                                                                 
}