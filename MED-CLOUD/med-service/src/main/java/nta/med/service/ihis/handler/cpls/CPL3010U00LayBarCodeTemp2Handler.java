package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL3010U00LayBarCodeTemp2ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00LayBarCodeTemp2Request;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00LayBarCodeTemp2Response;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3010U00LayBarCodeTemp2Handler extends ScreenHandler<CplsServiceProto.CPL3010U00LayBarCodeTemp2Request, CplsServiceProto.CPL3010U00LayBarCodeTemp2Response> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3010U00LayBarCodeTemp2Response handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3010U00LayBarCodeTemp2Request request) throws Exception {
        CplsServiceProto.CPL3010U00LayBarCodeTemp2Response.Builder response = CplsServiceProto.CPL3010U00LayBarCodeTemp2Response.newBuilder();
    	List<CPL3010U00LayBarCodeTemp2ListItemInfo> lstCPL3010U00LayBarCodeTemp2ListItemInfo = cpl2010Repository.getCPL3010U00LayBarCodeTemp2ListItemInfo(getHospitalCode(vertx, sessionId), 
    			getLanguage(vertx, sessionId), request.getSpecimenSer());
        if(!CollectionUtils.isEmpty(lstCPL3010U00LayBarCodeTemp2ListItemInfo)) {
        	for(CPL3010U00LayBarCodeTemp2ListItemInfo item : lstCPL3010U00LayBarCodeTemp2ListItemInfo) {
        		CplsModelProto.CPL3010U00LayBarCodeTemp2ListItemInfo.Builder info = CplsModelProto.CPL3010U00LayBarCodeTemp2ListItemInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addLayBarCodeTemp2(info);
        	}
        }
        return response.build();
	}
}

