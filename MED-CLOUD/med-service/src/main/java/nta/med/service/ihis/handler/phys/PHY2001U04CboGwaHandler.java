package nta.med.service.ihis.handler.phys;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04CboGwaRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY2001U04CboGwaHandler
	extends ScreenHandler<PhysServiceProto.PHY2001U04CboGwaRequest, SystemServiceProto.ComboResponse> {                     
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    
	                                                                                                                
	@Override        
	@Transactional(readOnly=true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, PHY2001U04CboGwaRequest request) throws Exception {                                                                  
  	   	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                      
    	Date comingDate = DateUtil.toDate(request.getBuseoYmd(), DateUtil.PATTERN_YYMMDD );
		List<ComboListItemInfo> listCombo = bas0260Repository.getComboDepartmentItemInfo(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId), comingDate, true);
		if(!CollectionUtils.isEmpty(listCombo)){
			for(ComboListItemInfo item : listCombo){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}
		return response.build();
	}

}