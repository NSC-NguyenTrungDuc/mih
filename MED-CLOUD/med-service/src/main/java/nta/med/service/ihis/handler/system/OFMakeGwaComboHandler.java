package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0272Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OFMakeGwaComboRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OFMakeGwaComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OFMakeGwaComboHandler extends ScreenHandler <SystemServiceProto.OFMakeGwaComboRequest, SystemServiceProto.OFMakeGwaComboResponse> {                     
	@Resource                                                                                                       
	private Bas0272Repository bas0272Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OFMakeGwaComboResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OFMakeGwaComboRequest request)
			throws Exception {                                                                   
  	   	SystemServiceProto.OFMakeGwaComboResponse.Builder response = SystemServiceProto.OFMakeGwaComboResponse.newBuilder();                      
		List<ComboListItemInfo> listMakeGwa=bas0272Repository.getOFMakeGwaCombo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),request.getSabun());
		if(!CollectionUtils.isEmpty(listMakeGwa)){
			for(ComboListItemInfo item:listMakeGwa){
				CommonModelProto.ComboListItemInfo.Builder info= CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGwaComboItem(info);
			}
		}
		return response.build();
	}
}