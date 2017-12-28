package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.ocs.Ocs0132;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;
import nta.med.service.ihis.proto.SystemServiceProto.PHY8002U01CboDisUseKaizenRequest;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY8002U01CboDisUseKaizenHandler extends ScreenHandler <SystemServiceProto.PHY8002U01CboDisUseKaizenRequest, SystemServiceProto.ComboResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, PHY8002U01CboDisUseKaizenRequest request)
			throws Exception {                                                                   
  	   	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                      
		List<Ocs0132> list = ocs0132Repository.getByCodeTypeOrderBySortKey(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "PHY_DISUSE_KAIZEN");
		if(!CollectionUtils.isEmpty(list)){
			for(Ocs0132 item : list){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getCode())){
					info.setCode(item.getCode());
				}
				if(!StringUtils.isEmpty(item.getCodeName())){
					info.setCodeName(item.getCodeName());
				}
				response.addComboItem(info);
			}
		}
		return response.build();
	}
}