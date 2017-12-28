package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.system.OCS0103U12SetTabWonnaeDrugInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OCS0103U12SetTabWonnaeDrugRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OCS0103U12SetTabWonnaeDrugResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U12SetTabWonnaeDrugHandler extends ScreenHandler <SystemServiceProto.OCS0103U12SetTabWonnaeDrugRequest, SystemServiceProto.OCS0103U12SetTabWonnaeDrugResponse> {                     
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                            
	
	@Override
	public boolean isValid(OCS0103U12SetTabWonnaeDrugRequest request,
			Vertx vertx, String clientId, String sessionId) {
		if(StringUtils.isEmpty(request.getYakKijunCode())){
			return false;
		}
		return true;
	}


	@Override
	@Transactional(readOnly = true)
	public OCS0103U12SetTabWonnaeDrugResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U12SetTabWonnaeDrugRequest request) throws Exception  {                                                                   
  	   	SystemServiceProto.OCS0103U12SetTabWonnaeDrugResponse.Builder response = SystemServiceProto.OCS0103U12SetTabWonnaeDrugResponse.newBuilder();                      
		List<OCS0103U12SetTabWonnaeDrugInfo> listResult = ocs0103Repository.getOCS0103U12SetTabWonnaeDrugListItem(getHospitalCode(vertx, sessionId), request.getYakKijunCode(),
				request.getOrderDate(),request.getHangmogCode());
		if(!CollectionUtils.isEmpty(listResult)){
			for(OCS0103U12SetTabWonnaeDrugInfo item : listResult){
				CommonModelProto.OCS0103U12SetTabWonnaeDrugInfo.Builder info = CommonModelProto.OCS0103U12SetTabWonnaeDrugInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if(item.getCount() != null){
					info.setCount(item.getCount().toString());
				}
				response.addInfo1(info);
			}
		}
		return response.build();
	}
}