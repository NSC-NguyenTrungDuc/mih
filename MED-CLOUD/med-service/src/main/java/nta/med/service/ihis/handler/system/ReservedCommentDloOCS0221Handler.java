package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0221Repository;
import nta.med.data.model.ihis.system.ReservedCommentDloOCS0221Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ReservedCommentDloOCS0221Request;
import nta.med.service.ihis.proto.SystemServiceProto.ReservedCommentDloOCS0221Response;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ReservedCommentDloOCS0221Handler extends ScreenHandler <SystemServiceProto.ReservedCommentDloOCS0221Request, SystemServiceProto.ReservedCommentDloOCS0221Response> {                     
	@Resource                                                                                                       
	private Ocs0221Repository ocs0221Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public ReservedCommentDloOCS0221Response handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			ReservedCommentDloOCS0221Request request) throws Exception {                                                                   
  	   	SystemServiceProto.ReservedCommentDloOCS0221Response.Builder response = SystemServiceProto.ReservedCommentDloOCS0221Response.newBuilder();                      
		List<ReservedCommentDloOCS0221Info> listReserved = ocs0221Repository.getReservedCommentDloOCS0221Info(getHospitalCode(vertx, sessionId), 
				getLanguage(vertx, sessionId), request.getMemb(), request.getCategoryGubun());
		if(!CollectionUtils.isEmpty(listReserved)){
			for(ReservedCommentDloOCS0221Info item : listReserved){
				CommonModelProto.ReservedCommentDloOCS0221Info.Builder info = CommonModelProto.ReservedCommentDloOCS0221Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addReservedCmtItem(info);
			}
		}
		return response.build();
	}
}