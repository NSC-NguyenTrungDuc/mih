package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0222Repository;
import nta.med.data.model.ihis.ocsa.OCS0221Q01GrdOCS0222Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ReservedCommentGrdOCS0222Request;
import nta.med.service.ihis.proto.SystemServiceProto.ReservedCommentGrdOCS0222Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ReservedCommentGrdOCS0222Handler extends ScreenHandler <SystemServiceProto.ReservedCommentGrdOCS0222Request,SystemServiceProto.ReservedCommentGrdOCS0222Response> {                     
	@Resource                                                                                                       
	private Ocs0222Repository ocs0222Repository;                                                                   
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public ReservedCommentGrdOCS0222Response handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			ReservedCommentGrdOCS0222Request request) throws Exception {                                                                   
  	   	SystemServiceProto.ReservedCommentGrdOCS0222Response.Builder response = SystemServiceProto.ReservedCommentGrdOCS0222Response.newBuilder();                      
		List<OCS0221Q01GrdOCS0222Info> list = ocs0222Repository.getOCS0221Q01GrdOCS0222Info(getHospitalCode(vertx, sessionId), request.getMemb(), request.getSeq());
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS0221Q01GrdOCS0222Info item:list) {
				CommonModelProto.ReservedCommentGrdOCS0222Info.Builder info = CommonModelProto.ReservedCommentGrdOCS0222Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdOcs0222Item(info);
			}
		}
		return response.build();
	}
}