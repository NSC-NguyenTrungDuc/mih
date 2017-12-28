package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.xrt.Xrt0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.CbxXrayGubunRequest;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CbxXrayGubunHandler 
	extends ScreenHandler<SystemServiceProto.CbxXrayGubunRequest, SystemServiceProto.ComboResponse> {                     
	@Resource                                                                                                       
	private Xrt0102Repository xrt0102Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, CbxXrayGubunRequest request) throws Exception {                                                                 
  	   	 SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                      
		 //get Combo list item info
		 List<ComboListItemInfo> listCombo=xrt0102Repository.getXRT0001U00InitializeComboListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		 if(!CollectionUtils.isEmpty(listCombo)){
			 for(ComboListItemInfo item: listCombo){
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