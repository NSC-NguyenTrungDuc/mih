package nta.med.service.ihis.handler.phys;

import java.math.BigInteger;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01GetLayJissekiDataRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01GetLayJissekiDataResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY8002U01GetLayJissekiDataHandler
	extends ScreenHandler<PhysServiceProto.PHY8002U01GetLayJissekiDataRequest, PhysServiceProto.PHY8002U01GetLayJissekiDataResponse> {                     
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;         
	@Resource                                                                                                       
	private Ocs2003Repository ocs2003Repository;   
	                                                                                                                
	@Override      
	@Transactional(readOnly=true)
	public PHY8002U01GetLayJissekiDataResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			PHY8002U01GetLayJissekiDataRequest request) throws Exception {                                                                
  	   	PhysServiceProto.PHY8002U01GetLayJissekiDataResponse.Builder response = PhysServiceProto.PHY8002U01GetLayJissekiDataResponse.newBuilder();   
  	   	String hospCode = getHospitalCode(vertx, sessionId);
		BigInteger result = null;
		if(request.getInOutGubun().equals("O")){
			result = ocs1003Repository.getPhy8002U01GetLayJissekiDataOcs1003Count(hospCode, CommonUtils.parseDouble(request.getFkocs()));
		}else{
			result = ocs2003Repository.getPhy8002U01GetLayJissekiDataOcs2003Count(hospCode, CommonUtils.parseDouble(request.getFkocs()));
		}
		if(result != null){
			response.setResult(result.toString());
		}
		return response.build();
	}
}