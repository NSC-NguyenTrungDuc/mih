package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.ocs.Ocs0170;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0170Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.HIOcsSpecificCommentRequest;
import nta.med.service.ihis.proto.SystemServiceProto.HIOcsSpecificCommentResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
public class HIOcsSpecificCommentHandler 
	extends ScreenHandler<SystemServiceProto.HIOcsSpecificCommentRequest, SystemServiceProto.HIOcsSpecificCommentResponse> {                     
	@Resource                                                                                                       
	private Ocs0170Repository ocs0170Repository; 
	
	@Override
	@Transactional(readOnly = true)
	public HIOcsSpecificCommentResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			HIOcsSpecificCommentRequest request) throws Exception {                                                               
      	   	SystemServiceProto.HIOcsSpecificCommentResponse.Builder response = SystemServiceProto.HIOcsSpecificCommentResponse.newBuilder();                      
		List<Ocs0170> listItem = ocs0170Repository.getHIOcsSpecificComment(getHospitalCode(vertx, sessionId), request.getSpecificComment());
		if(!CollectionUtils.isEmpty(listItem)){
			for(Ocs0170 item : listItem){
				SystemModelProto.HIOcsSpecificCommentInfo.Builder builder = SystemModelProto.HIOcsSpecificCommentInfo.newBuilder();
				BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
				response.addSpecCommentItem(builder);
			}
		}
		return response.build();
	}
}
