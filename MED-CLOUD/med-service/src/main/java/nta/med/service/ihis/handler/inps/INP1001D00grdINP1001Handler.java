package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.INP1001D00grdINP1001Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;

@Service                                                                                                          
@Scope("prototype")
public class INP1001D00grdINP1001Handler extends ScreenHandler<InpsServiceProto.INP1001D00grdINP1001Request, InpsServiceProto.INP1001D00grdINP1001Response>{
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public InpsServiceProto.INP1001D00grdINP1001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			InpsServiceProto.INP1001D00grdINP1001Request request)throws Exception {
		
		InpsServiceProto.INP1001D00grdINP1001Response.Builder response = InpsServiceProto.INP1001D00grdINP1001Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<INP1001D00grdINP1001Info> result = inp1001Repository.getINP1001D00grdINP1001Info(hospCode, language, request.getHoDong1(), request.getSendYn(), request.getQueryDate());
		
		if(!CollectionUtils.isEmpty(result)){
			for(INP1001D00grdINP1001Info item : result){
				InpsModelProto.INP1001D00grdINP1001Info.Builder info = InpsModelProto.INP1001D00grdINP1001Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addItems(info);
			}
		}
		
		return response.build();
	}
}
