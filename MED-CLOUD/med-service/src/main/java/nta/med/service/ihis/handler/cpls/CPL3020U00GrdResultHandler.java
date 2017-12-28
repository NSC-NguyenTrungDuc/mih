package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.model.ihis.cpls.CPL3020U00GrdResultListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00GrdResultRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00GrdResultResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3020U00GrdResultHandler extends ScreenHandler <CplsServiceProto.CPL3020U00GrdResultRequest, CplsServiceProto.CPL3020U00GrdResultResponse> {
	@Resource
	private Cpl0109Repository cpl0109Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3020U00GrdResultResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL3020U00GrdResultRequest request)
			throws Exception  {
        CplsServiceProto.CPL3020U00GrdResultResponse.Builder response = CplsServiceProto.CPL3020U00GrdResultResponse.newBuilder();
    	List<CPL3020U00GrdResultListItemInfo> listGrdResultList = cpl0109Repository.getGrdResultListItem(getHospitalCode(vertx, sessionId),
    			getLanguage(vertx, sessionId), request.getLabNo(),request.getSpecimenSer(),
    			request.getJundalGubun(),request.getCodeType());
    	if(listGrdResultList != null && !listGrdResultList.isEmpty()){
    		for(CPL3020U00GrdResultListItemInfo item : listGrdResultList){
    			CplsModelProto.CPL3020U00GrdResultListItemInfo.Builder info = CplsModelProto.CPL3020U00GrdResultListItemInfo.newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
    			response.addGrdResultItem(info);
    		}
    	}
    	return response.build();
	}
}
