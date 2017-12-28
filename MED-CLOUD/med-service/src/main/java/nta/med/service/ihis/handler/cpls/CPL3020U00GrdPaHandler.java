package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.cpls.CPL3020U00GrdPaListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00GrdPaRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00GrdPaResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3020U00GrdPaHandler extends ScreenHandler <CplsServiceProto.CPL3020U00GrdPaRequest, CplsServiceProto.CPL3020U00GrdPaResponse> {
	@Resource
	private Out0101Repository out0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3020U00GrdPaResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL3020U00GrdPaRequest request)
			throws Exception {
        CplsServiceProto.CPL3020U00GrdPaResponse.Builder response = CplsServiceProto.CPL3020U00GrdPaResponse.newBuilder();
    	List<CPL3020U00GrdPaListItemInfo> listGrdPaList = out0101Repository.getGrdPaListItem(getHospitalCode(vertx, sessionId), 
    			request.getJundalGubun(), request.getGubun(),
    			request.getFromDate(), request.getToDate());
    	if(listGrdPaList != null && !listGrdPaList.isEmpty()){
    		for(CPL3020U00GrdPaListItemInfo item : listGrdPaList){
    			CplsModelProto.CPL3020U00GrdPaListItemInfo.Builder info = CplsModelProto.CPL3020U00GrdPaListItemInfo.newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
    			response.addGrdPaItem(info);
    		}
    	}
    	return response.build();
	}
}
