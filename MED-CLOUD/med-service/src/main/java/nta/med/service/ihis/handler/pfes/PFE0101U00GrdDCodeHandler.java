package nta.med.service.ihis.handler.pfes;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.pfe.Pfe0102Repository;
import nta.med.data.model.ihis.pfes.PFE0101U00GrdDCodeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PfesModelProto;
import nta.med.service.ihis.proto.PfesServiceProto;
import nta.med.service.ihis.proto.PfesServiceProto.PFE0101U00GrdDCodeRequest;
import nta.med.service.ihis.proto.PfesServiceProto.PFE0101U00GrdDCodeResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PFE0101U00GrdDCodeHandler
	extends ScreenHandler<PfesServiceProto.PFE0101U00GrdDCodeRequest, PfesServiceProto.PFE0101U00GrdDCodeResponse> {                     
	@Resource                                                                                                       
	private Pfe0102Repository pfe0102Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public PFE0101U00GrdDCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PFE0101U00GrdDCodeRequest request)
			throws Exception {                                                                  
  	   	PfesServiceProto.PFE0101U00GrdDCodeResponse.Builder response = PfesServiceProto.PFE0101U00GrdDCodeResponse.newBuilder();                      
		List<PFE0101U00GrdDCodeInfo> listGrd=pfe0102Repository.getPFE0101U00GrdDCodeInfo(getHospitalCode(vertx, sessionId),request.getCodeType(),request.getCode(),request.getCodeName(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listGrd)){
			for(PFE0101U00GrdDCodeInfo item : listGrd){
				PfesModelProto.PFE0101U00GrdDCodeInfo.Builder info= PfesModelProto.PFE0101U00GrdDCodeInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
		        response.addDcodeItem(info);
			}
		}
		return response.build();
	}

}