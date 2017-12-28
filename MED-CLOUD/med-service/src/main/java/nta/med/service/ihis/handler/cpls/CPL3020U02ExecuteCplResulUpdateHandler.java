package nta.med.service.ihis.handler.cpls;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl3010Repository;
import nta.med.data.dao.medi.cpl.Cpl3020Repository;
import nta.med.data.dao.medi.ocs.Ocs5010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02ExecuteCplResulUpdateRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02ExecuteCplResulUpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL3020U02ExecuteCplResulUpdateHandler extends ScreenHandler <CplsServiceProto.CPL3020U02ExecuteCplResulUpdateRequest, CplsServiceProto.CPL3020U02ExecuteCplResulUpdateResponse> {                             
	@Resource
	private Ocs5010Repository ocs5010Repository;
	
	@Resource
	private Cpl3020Repository cpl3020Repository;
	
	@Resource
	private Cpl3010Repository cpl3010Repository;                                                              
	                                                                                                                
	@Override                                                                                                       
	public CPL3020U02ExecuteCplResulUpdateResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3020U02ExecuteCplResulUpdateRequest request) throws Exception {
        CplsServiceProto.CPL3020U02ExecuteCplResulUpdateResponse.Builder response = CplsServiceProto.CPL3020U02ExecuteCplResulUpdateResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
    	boolean update3020 = false;
    	boolean update3010 = false;
    	if(request.getCplResult().isEmpty()){
    		if(cpl3020Repository.updateCPL3020U00Cpl3020CplResult(request.getUserId(), new Date(),hospCode,CommonUtils.parseDouble(request.getPkcpl3020()))>0){
    			update3020 = true;
			}
    		if(cpl3010Repository.updateCPL3020U00CPL3010CplResult(request.getUserId(), new Date(),null,null,hospCode, request.getLabNo(), request.getSpecimenSer())>0){
    			update3010 = true;
		 	}
    		ocs5010Repository.callPrOcsUpdateResult(hospCode, request.getInOutGubun(),
            		CommonUtils.parseDouble(request.getFkocs()), request.getResultBuseo(), DateUtil.toDate(request.getResultDate(), DateUtil.PATTERN_YYMMDD)); 
            response.setPrOcsUpdateResult(true);
    		response.setUpdate3020Result(update3020);
    		response.setUpdate3010Result(update3010);
    		// PR_OCS_UPDATE_RESULT
    	}else{
    		if(cpl3020Repository.updateCPL3020U00Cpl3020CplResult(request.getUserId(),new Date() ,hospCode,CommonUtils.parseDouble(request.getPkcpl3020()))>0){
    			update3020 = true;
			}
    		if(cpl3010Repository.updateCPL3020U00CPL3010CplResult(request.getUserId(),new Date() ,new Date(),new Date(),hospCode, request.getLabNo(), request.getSpecimenSer())>0){
    			update3010 = true;
		 	}
    		
    		ocs5010Repository.callPrOcsUpdateResult(hospCode, request.getInOutGubun(),
            		CommonUtils.parseDouble(request.getFkocs()), request.getResultBuseo(), DateUtil.toDate(request.getResultDate(), DateUtil.PATTERN_YYMMDD)); 
            response.setPrOcsUpdateResult(true);
     		response.setUpdate3020Result(update3020);
     		response.setUpdate3010Result(update3010);
    	}
    	return response.build();
	}
}                                                                                                                 
