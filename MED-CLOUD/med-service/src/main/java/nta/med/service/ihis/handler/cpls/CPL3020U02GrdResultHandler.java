package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl3010Repository;
import nta.med.data.model.ihis.cpls.CPL3020U02GrdResultListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02GrdResultRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02GrdResultResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL3020U02GrdResultHandler extends ScreenHandler<CplsServiceProto.CPL3020U02GrdResultRequest, CplsServiceProto.CPL3020U02GrdResultResponse>{                     
	@Resource                                                                                                       
	private Cpl3010Repository cpl3010Repository;                                                                    
	                                                                                                                
	@Override            
	@Transactional(readOnly = true)
	public CPL3020U02GrdResultResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL3020U02GrdResultRequest request)
			throws Exception {                                                                   
  	   	CplsServiceProto.CPL3020U02GrdResultResponse.Builder response = CplsServiceProto.CPL3020U02GrdResultResponse.newBuilder();                      
		List<CPL3020U02GrdResultListItemInfo> listGrdResult  = cpl3010Repository.getCPL3020U02GrdResultListItemInfo(getHospitalCode(vertx, sessionId),
				request.getSpecimenSer(), request.getLabNo(), request.getJundalGubun());
        if(!CollectionUtils.isEmpty(listGrdResult)) {
        	for(CPL3020U02GrdResultListItemInfo item : listGrdResult) {
        		CplsModelProto.CPL3020U00GrdResultListItemInfo.Builder info = CplsModelProto.CPL3020U00GrdResultListItemInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addGrdResultItemInfo(info);
        	}
        }
        return response.build();
	}
}