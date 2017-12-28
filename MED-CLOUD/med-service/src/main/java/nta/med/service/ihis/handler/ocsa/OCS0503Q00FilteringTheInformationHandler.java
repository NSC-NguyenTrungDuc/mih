package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.ocsa.OCS0503Q00FilteringTheInformationInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503Q00FilteringTheInformationRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503Q00FilteringTheInformationResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0503Q00FilteringTheInformationHandler
	extends ScreenHandler<OcsaServiceProto.OCS0503Q00FilteringTheInformationRequest, OcsaServiceProto.OCS0503Q00FilteringTheInformationResponse> {                     
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override                   
	@Transactional(readOnly = true)
	public OCS0503Q00FilteringTheInformationResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0503Q00FilteringTheInformationRequest request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0503Q00FilteringTheInformationResponse.Builder response = OcsaServiceProto.OCS0503Q00FilteringTheInformationResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
        List<OCS0503Q00FilteringTheInformationInfo> listGrdConsult = out1001Repository.getOcsaOCS0503Q00GrdRequestOUT1001List(hospCode,
        		language, request.getGrdConsultBunho(), request.getGrdConsultNaewonDate());
        if (!CollectionUtils.isEmpty(listGrdConsult)) {
        	for (OCS0503Q00FilteringTheInformationInfo item : listGrdConsult) {
        		OcsaModelProto.OCS0503Q00FilteringTheInformationInfo .Builder info = OcsaModelProto.OCS0503Q00FilteringTheInformationInfo .newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addGrdConsultOut1001(info);
        	}
        }
        
        List<OCS0503Q00FilteringTheInformationInfo> listGridRequest = out1001Repository.getOcsaOCS0503Q00GrdRequestOUT1001List(hospCode,
        		language, request.getGridRequestBunho(), request.getGridRequestNaewonDate());
        if (!CollectionUtils.isEmpty(listGridRequest)) {
        	for (OCS0503Q00FilteringTheInformationInfo item : listGridRequest) {
        		OcsaModelProto.OCS0503Q00FilteringTheInformationInfo .Builder info = OcsaModelProto.OCS0503Q00FilteringTheInformationInfo .newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addGridRequestOut1001Info(info);
        	}
        }
        return response.build();
	}

}