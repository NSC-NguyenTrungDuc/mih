package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out0106Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.LoadPatientSpecificCommentRequest;
import nta.med.service.ihis.proto.SystemServiceProto.LoadPatientSpecificCommentResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class LoadPatientSpecificCommentHandler
	extends ScreenHandler<SystemServiceProto.LoadPatientSpecificCommentRequest, SystemServiceProto.LoadPatientSpecificCommentResponse> {                     
	@Resource                                                                                                       
	private Out0106Repository out0106Repository;
	
	@Override
	@Transactional(readOnly = true)
	public LoadPatientSpecificCommentResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			LoadPatientSpecificCommentRequest request) throws Exception {                                                                
      	   	SystemServiceProto.LoadPatientSpecificCommentResponse.Builder response = SystemServiceProto.LoadPatientSpecificCommentResponse.newBuilder();
		List<String> listResult = out0106Repository.getPatientSpecificComment(getHospitalCode(vertx, sessionId), request.getBunho());
		if(!CollectionUtils.isEmpty(listResult)){
			for(String result : listResult){
				CommonModelProto.DataStringListItemInfo.Builder builder = CommonModelProto.DataStringListItemInfo.newBuilder();
				builder.setDataValue(result);
				response.addListComment(builder);
			}
		}
		return response.build();
	}
}
