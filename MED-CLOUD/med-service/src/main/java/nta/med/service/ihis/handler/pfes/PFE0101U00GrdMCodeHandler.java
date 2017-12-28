package nta.med.service.ihis.handler.pfes;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.pfe.Pfe0101Repository;
import nta.med.data.model.ihis.pfes.PFE0101U00GrdMCodeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PfesModelProto;
import nta.med.service.ihis.proto.PfesServiceProto;
import nta.med.service.ihis.proto.PfesServiceProto.PFE0101U00GrdMCodeRequest;
import nta.med.service.ihis.proto.PfesServiceProto.PFE0101U00GrdMCodeResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PFE0101U00GrdMCodeHandler
	extends ScreenHandler <PfesServiceProto.PFE0101U00GrdMCodeRequest, PfesServiceProto.PFE0101U00GrdMCodeResponse> {                     
	@Resource                                                                                                       
	private Pfe0101Repository pfe0101Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public PFE0101U00GrdMCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PFE0101U00GrdMCodeRequest request)
			throws Exception {                                                                 
  	   	PfesServiceProto.PFE0101U00GrdMCodeResponse.Builder response = PfesServiceProto.PFE0101U00GrdMCodeResponse.newBuilder();                      
		List<PFE0101U00GrdMCodeInfo> listGrd=pfe0101Repository.getPFE0101U00GrdMCodeInfo(request.getCodeType(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listGrd)){
			for(PFE0101U00GrdMCodeInfo item:listGrd){
				PfesModelProto.PFE0101U00GrdMCodeInfo.Builder info= PfesModelProto.PFE0101U00GrdMCodeInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
			        response.addMcodeItem(info);
			}
		}
		return response.build();
	}
}