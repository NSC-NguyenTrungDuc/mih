package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0112Repository;
import nta.med.data.model.ihis.nuro.OUT0106U00PatientItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class OUT0106U00PatientListHandler extends ScreenHandler<NuroServiceProto.OUT0106U00PatientListRequest, NuroServiceProto.OUT0106U00PatientListResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OUT0106U00PatientListHandler.class);                                        
	@Resource                                                                                                       
	private Out0112Repository out0112Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OUT0106U00PatientListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT0106U00PatientListRequest request) throws Exception {
		NuroServiceProto.OUT0106U00PatientListResponse.Builder response = NuroServiceProto. OUT0106U00PatientListResponse.newBuilder();
		List<OUT0106U00PatientItemInfo> listItem = out0112Repository.getOUT0106U00PatientItemInfo(getHospitalCode(vertx, sessionId), request.getPatientInfo(), request.getNaewonDate());
		if(!CollectionUtils.isEmpty(listItem)){
			for(OUT0106U00PatientItemInfo item : listItem){
				NuroModelProto.OUT0106U00PatientItemInfo.Builder info = NuroModelProto.OUT0106U00PatientItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addItemInfo(info);
			}
		}
		return response.build();
	}

}
