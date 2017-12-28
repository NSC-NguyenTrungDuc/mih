package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.dao.medi.cpl.Cpl0155Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02FwkResultQueryStartingRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02FwkResultQueryStartingResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3020U02FwkResultQueryStartingHandler extends ScreenHandler <CplsServiceProto.CPL3020U02FwkResultQueryStartingRequest, CplsServiceProto.CPL3020U02FwkResultQueryStartingResponse>{
	@Resource
	private Cpl0155Repository cpl0155Repository;
	
	@Resource
	private Cpl0109Repository cpl0109Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3020U02FwkResultQueryStartingResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3020U02FwkResultQueryStartingRequest request) throws Exception {
        CplsServiceProto.CPL3020U02FwkResultQueryStartingResponse.Builder response = CplsServiceProto.CPL3020U02FwkResultQueryStartingResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
    	String retVal = cpl0155Repository.checkExitCPL3020U02FwkResult(hospCode, request.getResultForm());
    	if(!StringUtils.isEmpty(retVal) && retVal.equals("Y")){
    		List<ComboListItemInfo> listItem = cpl0155Repository.getCPL3020U02FwkResult(hospCode, request.getFind1(), request.getResultForm());
            if(!CollectionUtils.isEmpty(listItem)) {
            	for(ComboListItemInfo item : listItem) {
            		CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
            		if (!StringUtils.isEmpty(item.getCode())) {
            			info.setCode(item.getCode());
            		}
            		if (!StringUtils.isEmpty(item.getCodeName())) {
            			info.setCodeName(item.getCodeName());
            		}
            		response.addFwkResultList(info);
            	}
            }
    	}else{
    		List<ComboListItemInfo> listItem = cpl0109Repository.getCPL0101U00getACtrComboListItem(hospCode, "38", request.getFind1(), request.getFind1(), language);
            if(!CollectionUtils.isEmpty(listItem)) {
            	for(ComboListItemInfo item : listItem) {
            		CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
            		if (!StringUtils.isEmpty(item.getCode())) {
            			info.setCode(item.getCode());
            		}
            		if (!StringUtils.isEmpty(item.getCodeName())) {
            			info.setCodeName(item.getCodeName());
            		}
            		response.addFwkResultList(info);
            	}
            }
    	}
    	return response.build();
	}
}
