package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0106Repository;
import nta.med.data.model.ihis.cpls.CPL0106U00GrdListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0106U00GrdCodeRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0106U00GrdCodeResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL0106U00GrdCodeHandler extends ScreenHandler<CplsServiceProto.CPL0106U00GrdCodeRequest, CplsServiceProto.CPL0106U00GrdCodeResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(CPL0106U00GrdCodeHandler.class);                                    
	@Resource                                                                                                       
	private Cpl0106Repository cpl0106Repository;                                                                    
	                                                                                                                
	@Override              
	@Transactional(readOnly = true)
	public CPL0106U00GrdCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL0106U00GrdCodeRequest request) throws Exception {
      	   	CplsServiceProto.CPL0106U00GrdCodeResponse.Builder response = CplsServiceProto.CPL0106U00GrdCodeResponse.newBuilder();                      
      	List<CPL0106U00GrdListItemInfo> listGrdCode = cpl0106Repository.getCPL0106U00GrdListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), 
        		"04", request.getHangmogCode(), request.getSpecimenCode(), 
        		request.getEmergency(), request.getGroupGubun());
        if(!CollectionUtils.isEmpty(listGrdCode)) {
        	for(CPL0106U00GrdListItemInfo item : listGrdCode) {
        		CplsModelProto.CPL0106U00GrdListItemInfo.Builder info = CplsModelProto.CPL0106U00GrdListItemInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addGrdCodeList(info);
        	}
        }
		return response.build();
	}                                                                                                                 
}