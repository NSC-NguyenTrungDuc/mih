package nta.med.service.ihis.handler.pfes;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PfesServiceProto;
import nta.med.service.ihis.proto.PfesServiceProto.PFE0101U00LayUserNameRequest;
import nta.med.service.ihis.proto.PfesServiceProto.PFE0101U00LayUserNameResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PFE0101U00LayUserNameHandler
	extends ScreenHandler<PfesServiceProto.PFE0101U00LayUserNameRequest, PfesServiceProto.PFE0101U00LayUserNameResponse> {                     
	@Resource                                                                                                       
	private Adm3200Repository adm3200Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public PFE0101U00LayUserNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PFE0101U00LayUserNameRequest request) throws Exception {                                                                 
  	   	PfesServiceProto.PFE0101U00LayUserNameResponse.Builder response = PfesServiceProto.PFE0101U00LayUserNameResponse.newBuilder();                      
		List<String> layUserList = adm3200Repository.getUserNameList(getHospitalCode(vertx, sessionId),request.getCode());
		if(!CollectionUtils.isEmpty(layUserList) && !StringUtils.isEmpty(layUserList.get(0))){
			response.setUserName(layUserList.get(0));
		}
		return response.build();
	}
}