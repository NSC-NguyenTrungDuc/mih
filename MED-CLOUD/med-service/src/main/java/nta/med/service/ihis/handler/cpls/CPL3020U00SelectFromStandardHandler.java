package nta.med.service.ihis.handler.cpls;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL3020U00SelectFromStandardListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00SelectFromStandardRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00SelectFromStandardResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CPL3020U00SelectFromStandardHandler extends ScreenHandler <CplsServiceProto.CPL3020U00SelectFromStandardRequest, CplsServiceProto.CPL3020U00SelectFromStandardResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3020U00SelectFromStandardResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3020U00SelectFromStandardRequest request) throws Exception {
        CplsServiceProto.CPL3020U00SelectFromStandardResponse.Builder response = CplsServiceProto.CPL3020U00SelectFromStandardResponse.newBuilder();
    	Double pkcpl3020 = CommonUtils.parseDouble(request.getPkcpl3020());
    	List<CPL3020U00SelectFromStandardListItemInfo> listResult = cpl2010Repository.getCPL3020U00SelectFromStandard(getHospitalCode(vertx, sessionId), pkcpl3020);
    	if(listResult != null && !listResult.isEmpty()){
    		for(CPL3020U00SelectFromStandardListItemInfo item : listResult){
    			CplsModelProto.CPL3020U00SelectFromStandardListItemInfo.Builder info = CplsModelProto.CPL3020U00SelectFromStandardListItemInfo.newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
    			response.addResultList(info);
    		}
    	}
    	return response.build();
	}
}
