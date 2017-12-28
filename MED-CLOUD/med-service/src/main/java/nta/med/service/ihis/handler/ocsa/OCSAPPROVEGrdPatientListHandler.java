package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.ocsa.OCSAPPROVEGrdPatientListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCSAPPROVEGrdPatientListRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCSAPPROVEGrdPatientListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCSAPPROVEGrdPatientListHandler
	extends ScreenHandler<OcsaServiceProto.OCSAPPROVEGrdPatientListRequest, OcsaServiceProto.OCSAPPROVEGrdPatientListResponse> {                     
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;                                                                    
	                                                                                                                
	@Override            
	@Transactional(readOnly = true)
	public OCSAPPROVEGrdPatientListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCSAPPROVEGrdPatientListRequest request) throws Exception {                                                                
  	   	OcsaServiceProto.OCSAPPROVEGrdPatientListResponse.Builder response = OcsaServiceProto.OCSAPPROVEGrdPatientListResponse.newBuilder();                      
		List<OCSAPPROVEGrdPatientListInfo> list = out0101Repository.getOCSAPPROVEGrdPatientListItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getInputGubun(), request.getIoGubun(), request.getDoctor(),request.getInsteadYn(), request.getApproveYn(), request.getInputTab());
		if(!CollectionUtils.isEmpty(list)){
			for(OCSAPPROVEGrdPatientListInfo item : list){
				OcsaModelProto.OCSAPPROVEGrdPatientListInfo.Builder info = OcsaModelProto.OCSAPPROVEGrdPatientListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdPatientListInfo(info);
			}
		}
		return response.build();
	}
}