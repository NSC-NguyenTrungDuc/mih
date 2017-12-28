package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.CHTSCboSusikGubunRequest;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CHTSCboSusikGubunHandler
	extends ScreenHandler<SystemServiceProto.CHTSCboSusikGubunRequest, SystemServiceProto.ComboResponse> {                             
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, CHTSCboSusikGubunRequest request) throws Exception {                                                                
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                      
		List<ComboListItemInfo> listResult = bas0102Repository.getCht0115Q01cboDetailGubunListItem(getHospitalCode(vertx, sessionId), "SUSIK_GUBUN", getLanguage(vertx, sessionId),null);
		if(!CollectionUtils.isEmpty(listResult)){
			for(ComboListItemInfo item : listResult){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}
		return response.build();
	}
}                                                                                                                 
