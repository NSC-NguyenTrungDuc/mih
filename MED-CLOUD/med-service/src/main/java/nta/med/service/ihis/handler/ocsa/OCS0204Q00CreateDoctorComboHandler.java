package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0204Q00CreateDoctorComboRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
public class OCS0204Q00CreateDoctorComboHandler
	extends ScreenHandler<OcsaServiceProto.OCS0204Q00CreateDoctorComboRequest, SystemServiceProto.ComboResponse> {                     
	@Resource                                                                                                       
	private Bas0270Repository bas0270Repository;                                                                    
	                                                                                                                
	@Override             
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OCS0204Q00CreateDoctorComboRequest request)
			throws Exception {                                                                
  	   	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                      
		List<ComboListItemInfo> listGrd = bas0270Repository.getDoctorComboListItemInfo(getHospitalCode(vertx, sessionId), request.getGwa());
		if(!CollectionUtils.isEmpty(listGrd)){
			for(ComboListItemInfo item : listGrd){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}
		return response.build();
	}

}
