package nta.med.service.ihis.handler.cpls;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.dao.medi.cpl.Cpl3010Repository;
import nta.med.data.dao.medi.cpl.Cpl3020Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00OrderCancelExecuteRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL2010U00OrderCancelExecuteHandler extends ScreenHandler<CplsServiceProto.CPL2010U00OrderCancelExecuteRequest, SystemServiceProto.UpdateResponse> {                     
	@Resource                                                                                                       
	private Cpl3020Repository cpl3020Repository;                                                                    
	@Resource
	private Cpl3010Repository cpl3010Repository;
	@Resource
	private Cpl2010Repository cpl2010Repository;
	@Resource
	private Ocs1003Repository ocs1003Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL2010U00OrderCancelExecuteRequest request) throws Exception {                                                                   
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();    
  	   	String hospCode = getHospitalCode(vertx, sessionId);
		if(cpl3020Repository.deleteCPL2010U00OrderCancelDeleteCpl3020(CommonUtils.parseDouble(request.getPkcpl2010()))==0){
			response.setResult(false);
			throw new ExecutionException(response.build());
		}
		int cnt = cpl3020Repository.getCountCPL2010U00OrderCancelDelete(request.getSpecimenSer());
		if(cnt == 0){
			if(cpl3010Repository.deleteCPL2010U00OrderCancelDeleteCpl3010(request.getSpecimenSer())==0){
				response.setResult(false);
				throw new ExecutionException(response.build());
			}
		}
		
		ocs1003Repository.callPrOcsUpdateActing(hospCode,"O" ,CommonUtils.parseDouble(request.getFkocs1003()),"CPL",null,null,null,null,null);
		cpl2010Repository.callCPL2010U00PrOcsUpdateJubsu(hospCode,"O" ,Integer.parseInt(request.getFkocs1003()),"CPL",null,null);
		Date actingDate = null;
		cpl2010Repository.callCPL2010U00PrSchUpdateActing(hospCode, "O", CommonUtils.parseDouble(request.getFkocs1003()), actingDate);
		if(cpl2010Repository.getCPL2010U00OrderCancelUpdate(new Date(), CommonUtils.parseDouble(request.getFkocs1003()))==0){
			response.setResult(false);
			throw new ExecutionException(response.build());
		}
		response.setResult(true);
		return response.build();
	}
}