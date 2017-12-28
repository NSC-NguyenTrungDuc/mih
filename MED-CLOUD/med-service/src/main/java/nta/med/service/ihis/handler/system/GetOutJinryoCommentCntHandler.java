package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out0123Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.GetOutJinryoCommentCntInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetOutJinryoCommentCntRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetOutJinryoCommentCntResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class GetOutJinryoCommentCntHandler	
	extends ScreenHandler<SystemServiceProto.GetOutJinryoCommentCntRequest, SystemServiceProto.GetOutJinryoCommentCntResponse> {                     
	@Resource                                                                                                       
	private Out0123Repository out0123Repository;
	
	@Override
	@Transactional(readOnly = true)
	public GetOutJinryoCommentCntResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			GetOutJinryoCommentCntRequest request) throws Exception {                                                              
  	   	SystemServiceProto.GetOutJinryoCommentCntResponse.Builder response = SystemServiceProto.GetOutJinryoCommentCntResponse.newBuilder();
		GetOutJinryoCommentCntInfo info = request.getJinryoCommentCntInfo();
		Integer result = out0123Repository.getOutJinryoCommentCnt(getHospitalCode(vertx, sessionId), info.getBunho(), info.getDoctor());
		if(result != null){
			response.setRetVal(result.toString());
		}
		return response.build();
	}
}
