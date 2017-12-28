package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL3010U00LaySpecimenInfoListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00LaySpecimenRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00LaySpecimenResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3010U00LaySpecimenHandler extends ScreenHandler <CplsServiceProto.CPL3010U00LaySpecimenRequest, CplsServiceProto.CPL3010U00LaySpecimenResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3010U00LaySpecimenResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3010U00LaySpecimenRequest request) throws Exception {
        CplsServiceProto.CPL3010U00LaySpecimenResponse.Builder response = CplsServiceProto.CPL3010U00LaySpecimenResponse.newBuilder();
    	List<CPL3010U00LaySpecimenInfoListItemInfo> lstCPL3010U00LaySpecimenInfoListItemInfo = cpl2010Repository.getCPL3010U00LaySpecimenInfoListItemInfo(
    			getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getSpecimenSer());
        if(!CollectionUtils.isEmpty(lstCPL3010U00LaySpecimenInfoListItemInfo)) {
        	for(CPL3010U00LaySpecimenInfoListItemInfo item : lstCPL3010U00LaySpecimenInfoListItemInfo) {
        		CplsModelProto.CPL3010U00LaySpecimenInfoListItemInfo.Builder info = CplsModelProto.CPL3010U00LaySpecimenInfoListItemInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addLaySpecimenInfo(info);
        	}
        }
        return response.build();
	}
}
