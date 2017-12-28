package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OcsoGetNotApproveOrderCntRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OcsoGetNotApproveOrderCntResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OcsoGetNotApproveOrderCntHandler extends ScreenHandler <SystemServiceProto.OcsoGetNotApproveOrderCntRequest,SystemServiceProto.OcsoGetNotApproveOrderCntResponse>  {                             
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OcsoGetNotApproveOrderCntResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OcsoGetNotApproveOrderCntRequest request) throws Exception{                                                                   
  	   	SystemServiceProto.OcsoGetNotApproveOrderCntResponse.Builder response = SystemServiceProto.OcsoGetNotApproveOrderCntResponse.newBuilder();                      
		String result = out1001Repository.callFnOcsGetNotapproveOrdercnt(getHospitalCode(vertx, sessionId), request.getIoGubun(), request.getInsteadYn(), 
				request.getApproveYn(), request.getUserId(), request.getKey());
		if(!StringUtils.isEmpty(result)){
			response.setApproveOrderCntResult(result);
		}
		return response.build();
	}
}