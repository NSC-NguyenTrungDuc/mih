package nta.med.service.ihis.handler.phys;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.ocs.Ocs0132;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U00GrdGroupQueryRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U00GrdQueryResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY8002U00GrdGroupQueryHandler
	extends ScreenHandler<PhysServiceProto.PHY8002U00GrdGroupQueryRequest, PhysServiceProto.PHY8002U00GrdQueryResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override          
	@Transactional(readOnly=true)
	public PHY8002U00GrdQueryResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY8002U00GrdGroupQueryRequest request) throws Exception {                                                                
  	   	PhysServiceProto.PHY8002U00GrdQueryResponse.Builder response = PhysServiceProto.PHY8002U00GrdQueryResponse.newBuilder();   
  	   	String hospCode = getHospitalCode(vertx, sessionId);
	   	String language = getLanguage(vertx, sessionId);
		List<Ocs0132> listItem = ocs0132Repository.getByCodeTypeAndGroupKey(hospCode, language, request.getCodeType(), "1");
		if(!CollectionUtils.isEmpty(listItem)) {
			for (Ocs0132 item : listItem) {
				PhysModelProto.PHY8002U00GrdQueryInfo.Builder info = PhysModelProto.PHY8002U00GrdQueryInfo.newBuilder();
				info.setSelected("N");
				if (!StringUtils.isEmpty(item.getCode())) {
					info.setCode(item.getCode());
				}
				if (!StringUtils.isEmpty(item.getCodeName())) {
					info.setCodeName(item.getCodeName());
				}
				response.addGrdInfo(info);
			}
		}
		return response.build();
	}
}