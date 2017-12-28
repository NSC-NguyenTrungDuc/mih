package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.system.HILoadCodeNameInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.HILoadCodeNameRequest;
import nta.med.service.ihis.proto.SystemServiceProto.HILoadCodeNameResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class HILoadCodeNameHandler
	extends ScreenHandler <SystemServiceProto.HILoadCodeNameRequest, SystemServiceProto.HILoadCodeNameResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public HILoadCodeNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, HILoadCodeNameRequest request)
			throws Exception {                                                                
  	   	SystemServiceProto.HILoadCodeNameResponse.Builder response = SystemServiceProto.HILoadCodeNameResponse.newBuilder();                      
		List<HILoadCodeNameInfo> listCodeName= ocs0132Repository.getHILoadCodeNameInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
			request.getOrderGubun(),request.getSpecimenCode(),request.getJusa(),request.getPay(),request.getOrderGubunBas(),
		request.getBogyongCode(),request.getJusaSpdGubun(),request.getJundalPartOut(),
		request.getJundalPartInp(),request.getOrdDanui(),request.getHangmogCode());
		if(!CollectionUtils.isEmpty(listCodeName)){
			for(HILoadCodeNameInfo item : listCodeName){
				CommonModelProto.HILoadCodeNameInfo.Builder info= CommonModelProto.HILoadCodeNameInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCodeNameItem(info);
			}	
		}
		return response.build();
	}
}