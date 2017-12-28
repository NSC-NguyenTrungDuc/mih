package nta.med.service.ihis.handler.cpls;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.dao.medi.cpl.Cpl0155Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00FwkResultInputSQLRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00FwkResultInputSQLResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CPL3020U00FwkResultInputSQLHandler extends ScreenHandler<CplsServiceProto.CPL3020U00FwkResultInputSQLRequest, CplsServiceProto.CPL3020U00FwkResultInputSQLResponse> {
	@Resource
	private Cpl0109Repository cpl0109Repository;
	
	@Resource
	private Cpl0155Repository cpl0155Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3020U00FwkResultInputSQLResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3020U00FwkResultInputSQLRequest request) throws Exception {
        CplsServiceProto.CPL3020U00FwkResultInputSQLResponse.Builder response = CplsServiceProto.CPL3020U00FwkResultInputSQLResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        
    	if(request.getDummy().equalsIgnoreCase("N")){
    		List<ComboListItemInfo> listResult = cpl0109Repository.getCPL3020U00FwkResultInputSQL(hospCode, request.getFind1(), request.getCodeType(), language);
    		if(listResult != null && !listResult.isEmpty()){
        		for(ComboListItemInfo item : listResult){
        			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
        			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        			response.addFwkResultList(info);
        		}
    		}
    	}else{
    		List<ComboListItemInfo> listResult = cpl0155Repository.getCPL3020U00FwkResultInputSQL(hospCode, request.getFind1(), request.getResultForm());
    		if(listResult != null && !listResult.isEmpty()){
        		for(ComboListItemInfo item : listResult){
        			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
        			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        			response.addFwkResultList(info);
        		}
    		}
    	}
    	return response.build();
	}
}
