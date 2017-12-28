package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0310Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310U00MakeFindWorker2Request;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0310U00MakeFindWorker2Handler extends ScreenHandler<BassServiceProto.BAS0310U00MakeFindWorker2Request, SystemServiceProto.ComboResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0310U00MakeFindWorker2Handler.class);                                    
	@Resource                                                                                                       
	private Bas0310Repository bas0310Repository;                                                                    
	                                                                                                                
	@Override 
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, BAS0310U00MakeFindWorker2Request request)
					throws Exception {
  	   	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                      
		List<ComboListItemInfo> listItem = bas0310Repository.getSgCodeNameListItemInfo(getHospitalCode(vertx, sessionId), request.getFind());
		if(!CollectionUtils.isEmpty(listItem)){
			for(ComboListItemInfo item : listItem){
				CommonModelProto.ComboListItemInfo.Builder builder = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
				response.addComboItem(builder);
			}
		}
				
		return response.build();
	}                                                                                                                 
}