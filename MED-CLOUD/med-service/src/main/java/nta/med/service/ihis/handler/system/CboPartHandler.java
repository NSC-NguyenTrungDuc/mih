package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.CboPartRequest;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CboPartHandler 
	extends ScreenHandler<SystemServiceProto.CboPartRequest, SystemServiceProto.ComboResponse> {                     
	@Resource
	private Ocs0132Repository ocs0132Repository;                                                                   
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, CboPartRequest request) throws Exception {                                                     
  	   	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                      
		List<ComboListItemInfo> listCbo= ocs0132Repository.getXRT7001Q01CboPart(getHospitalCode(vertx, sessionId),getLanguage(vertx, sessionId),"OCS_ACT_PART_01");
		 if(!CollectionUtils.isEmpty(listCbo)){
			 for(ComboListItemInfo item :listCbo){
				 CommonModelProto.ComboListItemInfo.Builder info= CommonModelProto.ComboListItemInfo.newBuilder();
				 if (!StringUtils.isEmpty(item.getCode())) {
						info.setCode(item.getCode());
					}
					if (!StringUtils.isEmpty(item.getCodeName())) {
						info.setCodeName(item.getCodeName());
					}
					response.addComboItem(info);
			 }
		 }
		 return response.build();
	}
}