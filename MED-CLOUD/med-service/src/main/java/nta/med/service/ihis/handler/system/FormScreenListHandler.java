package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0300Repository;
import nta.med.data.model.ihis.system.FormScreenInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.FormScreenListRequest;
import nta.med.service.ihis.proto.SystemServiceProto.FormScreenListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
public class FormScreenListHandler
	extends ScreenHandler<SystemServiceProto.FormScreenListRequest, SystemServiceProto.FormScreenListResponse> {                     
	@Resource
	private Adm0300Repository adm0300Repository;
	
	@Override
	@Transactional(readOnly = true)
	public FormScreenListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, FormScreenListRequest request)
			throws Exception {                                                                 
  	   	SystemServiceProto.FormScreenListResponse.Builder response = SystemServiceProto.FormScreenListResponse.newBuilder();                      
		List<FormScreenInfo> listInfo = adm0300Repository.getFormScreenInfo(getLanguage(vertx, sessionId), request.getScreenId());
		if(!CollectionUtils.isEmpty(listInfo)){
			for(FormScreenInfo info : listInfo){
				SystemModelProto.FormScreenInfo.Builder builder = SystemModelProto.FormScreenInfo.newBuilder();
				BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
				if(info.getPgmEntGrad() != null){
					builder.setPgmEntGrad(String.format("%.0f",info.getPgmEntGrad()));
				}
				if(info.getPgmUpdGrad() != null){
					builder.setPgmUpdGrad(String.format("%.0f",info.getPgmUpdGrad()));
				}
				response.addFormScreenInfo(builder);
			}
		}
		return response.build();		
	}
}
