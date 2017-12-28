package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0801Repository;
import nta.med.data.dao.medi.ocs.Ocs0802Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0803U00GetFindWorkerRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0803U00GetFindWorkerResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0803U00GetFindWorkerHandler
	extends ScreenHandler<OcsaServiceProto.OCS0803U00GetFindWorkerRequest, OcsaServiceProto.OCS0803U00GetFindWorkerResponse> {                     
	@Resource                                                                                                       
	private Ocs0801Repository ocs0801Repository;  
	@Resource
	private Ocs0802Repository ocs0802Repository;
	                                                                                                                
	@Override               
	@Transactional(readOnly = true)
	public OCS0803U00GetFindWorkerResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0803U00GetFindWorkerRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0803U00GetFindWorkerResponse.Builder response = OcsaServiceProto.OCS0803U00GetFindWorkerResponse.newBuilder();
  	    String hospCode = getHospitalCode(vertx, sessionId);
	   	String language = getLanguage(vertx, sessionId);
		List<ComboListItemInfo> listFindWorker = null;
		switch (request.getFindMode()) {
		case "pat_status":
			listFindWorker = ocs0801Repository.getOCS0803U00GetFindWorker(language);
			break;
		case "break_pat_status_code":
			listFindWorker = ocs0802Repository.getOCS0803U00GetFindWorker(hospCode, language, request.getPatStatus());
			break;
		}
		if(!CollectionUtils.isEmpty(listFindWorker)){
			for(ComboListItemInfo item: listFindWorker){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addFindWorker(info);
			}
		}
		
		return response.build();
	}

}