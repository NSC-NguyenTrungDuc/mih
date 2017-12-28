package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.ocsa.OCS0503Q00DoctorListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503Q00FdwCommonDoctorRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503Q00FdwCommonDoctorResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0503Q00FdwCommonDoctorHandler
	extends ScreenHandler<OcsaServiceProto.OCS0503Q00FdwCommonDoctorRequest, OcsaServiceProto.OCS0503Q00FdwCommonDoctorResponse> {                     
	@Resource                                                                                                       
	private Bas0270Repository bas0270Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly = true)
	public OCS0503Q00FdwCommonDoctorResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0503Q00FdwCommonDoctorRequest request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0503Q00FdwCommonDoctorResponse.Builder response = OcsaServiceProto.OCS0503Q00FdwCommonDoctorResponse.newBuilder();                      
		List<OCS0503Q00DoctorListInfo> list = bas0270Repository.getOcsaOCS0503Q00DoctorList(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getGwaCode());
		if(!CollectionUtils.isEmpty(list)){
			for(OCS0503Q00DoctorListInfo item : list){
				OcsaModelProto.OCS0503Q00DoctorListInfo.Builder info = OcsaModelProto.OCS0503Q00DoctorListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDoctorInfo(info);
			}
		}
		return response.build();
	}

}