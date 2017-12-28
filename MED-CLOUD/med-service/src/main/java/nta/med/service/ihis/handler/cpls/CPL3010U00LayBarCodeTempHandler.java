package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL3010U00LayBarCodeTempListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00LayBarCodeTempRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00LayBarCodeTempResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3010U00LayBarCodeTempHandler extends ScreenHandler<CplsServiceProto.CPL3010U00LayBarCodeTempRequest, CplsServiceProto.CPL3010U00LayBarCodeTempResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3010U00LayBarCodeTempResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3010U00LayBarCodeTempRequest request) throws Exception {
        CplsServiceProto.CPL3010U00LayBarCodeTempResponse.Builder response = CplsServiceProto.CPL3010U00LayBarCodeTempResponse.newBuilder();
    	List<CPL3010U00LayBarCodeTempListItemInfo> lstCPL3010U00LayBarCodeTempListItemInfo = cpl2010Repository.getCPL3010U00LayBarCodeTempListItemInfo(
    			getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getSpecimenSer());
        if(!CollectionUtils.isEmpty(lstCPL3010U00LayBarCodeTempListItemInfo)) {
        	for(CPL3010U00LayBarCodeTempListItemInfo item : lstCPL3010U00LayBarCodeTempListItemInfo) {
        		CplsModelProto.CPL3010U00LayBarCodeTempListItemInfo.Builder info = CplsModelProto.CPL3010U00LayBarCodeTempListItemInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addLayBarCodeTempItem(info);
        	}
        }
        return response.build();
	}
}
