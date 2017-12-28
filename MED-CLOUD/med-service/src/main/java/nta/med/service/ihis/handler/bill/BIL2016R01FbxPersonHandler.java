package nta.med.service.ihis.handler.bill;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.BillServiceProto;
import nta.med.service.ihis.proto.BillServiceProto.BIL2016R01FbxPersonRequest;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service                                                                                                          
@Scope("prototype")  
public class BIL2016R01FbxPersonHandler
	extends ScreenHandler<BillServiceProto.BIL2016R01FbxPersonRequest, SystemServiceProto.ComboResponse> {   
	private static final Log LOGGER = LogFactory.getLog(BIL2016R01FbxPersonHandler.class);
	
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;    
	
	@Override             
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, BIL2016R01FbxPersonRequest request)
			throws Exception {                                                                
  	   	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                      
		List<ComboListItemInfo> listGrd = bas0102Repository.getPersonListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
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
