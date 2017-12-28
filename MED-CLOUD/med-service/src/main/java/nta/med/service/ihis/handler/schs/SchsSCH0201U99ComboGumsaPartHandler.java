package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.sch.Sch0001Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99ComboGumsaPartRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class SchsSCH0201U99ComboGumsaPartHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201U99ComboGumsaPartRequest, SystemServiceProto.ComboResponse> {                     
	@Resource                                                                                                       
	private Sch0001Repository sch0001Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly=true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, SchsSCH0201U99ComboGumsaPartRequest request)
			throws Exception {                                                                 
  	   	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                      
		//Get result from SQL
		List<ComboListItemInfo> list = sch0001Repository.getSchsSCH0201U99ComboGumsaPart(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getJundalTable());
		//Check null
		if(!CollectionUtils.isEmpty(list)){
			for(ComboListItemInfo item:list){
				//Create new builder for response
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				//Copy data for response
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
			    response.addComboItem(info);
			}
		}
		return response.build();
	}	
}