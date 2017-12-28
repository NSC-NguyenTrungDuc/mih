package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.dao.medi.cpl.Cpl3020Repository;
import nta.med.data.model.ihis.cpls.CPL3010U00GrdGumListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00GrdGumRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00GrdGumResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3010U00GrdGumHandler extends ScreenHandler<CplsServiceProto.CPL3010U00GrdGumRequest, CplsServiceProto.CPL3010U00GrdGumResponse> {
	@Resource
	private Cpl3020Repository cpl3020Repository;
	
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3010U00GrdGumResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL3010U00GrdGumRequest request)
			throws Exception {
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
        CplsServiceProto.CPL3010U00GrdGumResponse.Builder response = CplsServiceProto.CPL3010U00GrdGumResponse.newBuilder();
    	List<CPL3010U00GrdGumListItemInfo> lstCPL3010U00GrdGumListItemInfo = cpl3020Repository.getCPL3010U00GrdGumListItemInfo(hospCode, language, request.getSpecimenSer());
        if(!CollectionUtils.isEmpty(lstCPL3010U00GrdGumListItemInfo)) {
        	for(CPL3010U00GrdGumListItemInfo item : lstCPL3010U00GrdGumListItemInfo) {
        		CplsModelProto.CPL3010U00GrdGumListItemInfo.Builder info = CplsModelProto.CPL3010U00GrdGumListItemInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
	            Double fkocs = cpl2010Repository.getCPL3010U00GrdGumQueryEnd(hospCode, item.getFkcpl2010());
        		if (fkocs != null) {
        			info.setFkocs(String.format("%.0f",fkocs));
        		}
        		response.addGrdGumItem(info);
        	}
        }
        return response.build();
	}
}
