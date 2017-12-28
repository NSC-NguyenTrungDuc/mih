package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetApproveFlagsRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetApproveFlagsResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class GetApproveFlagsHandler
	extends ScreenHandler<SystemServiceProto.GetApproveFlagsRequest, SystemServiceProto.GetApproveFlagsResponse> {                     
	@Resource                                                                                                       
	private  Ocs0132Repository  ocs0132Repository;                                                                           
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public GetApproveFlagsResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, GetApproveFlagsRequest request)
			throws Exception {                                                                 
  	   	SystemServiceProto.GetApproveFlagsResponse.Builder response = SystemServiceProto.GetApproveFlagsResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId); 
		List<ComboListItemInfo> listPostApprove = ocs0132Repository.getOCS1003Q05JusaComboBox(hospCode,language, "APPROVE_FLAG", "POSTAPPROVE_VISIBLE", "");
		if(!CollectionUtils.isEmpty(listPostApprove)){
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
			BeanUtils.copyProperties(listPostApprove.get(0), info, getLanguage(vertx, sessionId));
			response.setPostapproveVisibleInfo(info);
		}
		//Approve
		List<ComboListItemInfo> listApprove = ocs0132Repository.getOCS1003Q05JusaComboBox(hospCode,language, "APPROVE_FLAG", "POSTAPPROVE_VISIBLE", "");
		if(!CollectionUtils.isEmpty(listApprove)){
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
			BeanUtils.copyProperties(listApprove.get(0), info, getLanguage(vertx, sessionId));
			response.setApproveForceInfo(info);
		}
		return response.build();
	}
}