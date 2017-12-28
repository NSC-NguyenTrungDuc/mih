package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OFMakeUserComboRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OFMakeUserComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OFMakeUserComboHandler extends ScreenHandler<SystemServiceProto.OFMakeUserComboRequest, SystemServiceProto.OFMakeUserComboResponse>{                     
	@Resource                                                                                                       
	private Adm3200Repository adm3200Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OFMakeUserComboResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OFMakeUserComboRequest request)
			throws Exception{                                                                   
  	   	SystemServiceProto.OFMakeUserComboResponse.Builder response = SystemServiceProto.OFMakeUserComboResponse.newBuilder();                      
		List<ComboListItemInfo> listMakerUser=adm3200Repository.getOFMakeUserCombo(getHospitalCode(vertx, sessionId),"",request.getIsDoctorMode());
		if(!CollectionUtils.isEmpty(listMakerUser)){
			for(ComboListItemInfo item:listMakerUser){
				CommonModelProto.ComboListItemInfo.Builder info= CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addUserComboItem(info);
			}
		}
		return response.build();
	}
}