package nta.med.service.ihis.handler.cpls;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl3020Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02ExecuteConfirmYNUpdateRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class CPL3020U02ExecuteConfirmYNUpdateHandler extends ScreenHandler <CplsServiceProto.CPL3020U02ExecuteConfirmYNUpdateRequest, SystemServiceProto.UpdateResponse> {
	@Resource
	private Cpl3020Repository cpl3020Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3020U02ExecuteConfirmYNUpdateRequest request) throws Exception  {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse .newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
    	Double pkcpl3020 = CommonUtils.parseDouble(request.getPkcpl3020());
    	boolean save = false;
    	if("Y".equals(request.getConfirmYn())){
    		if(cpl3020Repository.updateCPL3020U02ExecuteConfirmY(request.getUserId(), new Date(), request.getGumsaja(), hospCode, pkcpl3020) > 0){
    			response.setResult(true);	
    			save = true;
    		}
    	}else{
    		if(cpl3020Repository.updateCPL3020U02ExecuteConfirmN(request.getUserId(), new Date(), hospCode, pkcpl3020) > 0){
    			save = true;	
    		}
    	}
    	response.setResult(save);
    	return response.build();
	}
}
