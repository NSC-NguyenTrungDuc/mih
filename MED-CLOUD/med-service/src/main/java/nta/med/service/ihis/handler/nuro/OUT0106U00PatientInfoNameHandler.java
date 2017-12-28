package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0112Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class OUT0106U00PatientInfoNameHandler extends ScreenHandler<NuroServiceProto.OUT0106U00PatientInfoNameRequest, NuroServiceProto.OUT0106U00PatientInfoNameResponse>{                             
	private static final Log LOGGER = LogFactory.getLog(OUT0106U00PatientInfoNameHandler.class);                                        
	@Resource                                                                                                       
	private Out0112Repository out0112Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OUT0106U00PatientInfoNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT0106U00PatientInfoNameRequest request) throws Exception {
		Date naewonDate = DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
		NuroServiceProto.OUT0106U00PatientInfoNameResponse.Builder response = NuroServiceProto. OUT0106U00PatientInfoNameResponse.newBuilder(); 
		String result = out0112Repository.getOUT0106U00PatientInfoName(getHospitalCode(vertx, sessionId), request.getPatientInfo(), naewonDate);
		if(!StringUtils.isEmpty(result)){
			response.setPatientInfoName(result);
		}
		return response.build();
	}

}
