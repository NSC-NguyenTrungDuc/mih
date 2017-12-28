package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl1000Repository;
import nta.med.data.model.ihis.cpls.CPL3010U00DsvUrineListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00DsvUrineRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00DsvUrineResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3010U00DsvUrineHandler extends ScreenHandler<CplsServiceProto.CPL3010U00DsvUrineRequest, CplsServiceProto.CPL3010U00DsvUrineResponse>{
	@Resource
	private Cpl1000Repository cpl1000Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3010U00DsvUrineResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL3010U00DsvUrineRequest request)
			throws Exception {
        CplsServiceProto.CPL3010U00DsvUrineResponse.Builder response = CplsServiceProto.CPL3010U00DsvUrineResponse.newBuilder();
    	Double fkocs = CommonUtils.parseDouble(request.getFkocs());
        List<CPL3010U00DsvUrineListItemInfo> lstCPL3010U00DsvUrineListItemInfo = cpl1000Repository.getCPL3010U00DsvUrineListItemInfo(getHospitalCode(vertx, sessionId), 
        		request.getSpecimenSer(), request.getGubun(), fkocs, request.getInOutGubun());
        if(!CollectionUtils.isEmpty(lstCPL3010U00DsvUrineListItemInfo)) {
        	for(CPL3010U00DsvUrineListItemInfo item : lstCPL3010U00DsvUrineListItemInfo) {
        		CplsModelProto.CPL3010U00DsvUrineListItemInfo.Builder info = CplsModelProto.CPL3010U00DsvUrineListItemInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addDsvUrineItem(info);
        	}
        }
        return response.build();
	}
}
