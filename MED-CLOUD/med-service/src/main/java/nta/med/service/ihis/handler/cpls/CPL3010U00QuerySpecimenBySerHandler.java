package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL3010U00GrdPartListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00QuerySpecimenBySerRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00QuerySpecimenBySerResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3010U00QuerySpecimenBySerHandler extends ScreenHandler <CplsServiceProto.CPL3010U00QuerySpecimenBySerRequest, CplsServiceProto.CPL3010U00QuerySpecimenBySerResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3010U00QuerySpecimenBySerResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3010U00QuerySpecimenBySerRequest request) throws Exception {
	    CplsServiceProto.CPL3010U00QuerySpecimenBySerResponse.Builder response = CplsServiceProto.CPL3010U00QuerySpecimenBySerResponse.newBuilder();
	    List<CPL3010U00GrdPartListItemInfo> listObject = cpl2010Repository.getCPL3010U00QuerySpecimenBySer(getHospitalCode(vertx, sessionId), 
	    		getLanguage(vertx, sessionId), request.getSpecimenSer());
	    if(!CollectionUtils.isEmpty(listObject)) {
	    	for(CPL3010U00GrdPartListItemInfo item : listObject) {
	    		CplsModelProto.CPL3010U00GrdPartListItemInfo.Builder info = CplsModelProto.CPL3010U00GrdPartListItemInfo.newBuilder();
	    		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
	    		response.addGrdPartList(info);
	    	}
	    }
	    return response.build();
	}
}
