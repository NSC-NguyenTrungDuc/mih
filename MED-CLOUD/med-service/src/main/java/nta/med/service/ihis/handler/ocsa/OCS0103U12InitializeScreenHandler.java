package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12InitializeScreenRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12InitializeScreenResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U12InitializeScreenHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U12InitializeScreenRequest, OcsaServiceProto.OCS0103U12InitializeScreenResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0103U12InitializeScreenHandler.class);                                        
	@Resource                                                                                                       
	private Bas0270Repository bas0270Repository;                                                                                                                                                                                    
	@Override                    
	@Transactional(readOnly = true)
	public OCS0103U12InitializeScreenResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U12InitializeScreenRequest request) throws Exception {                                                                    
  	   	OcsaServiceProto.OCS0103U12InitializeScreenResponse.Builder response = OcsaServiceProto.OCS0103U12InitializeScreenResponse.newBuilder();                      
		String codeName="";
		String hospCode = getHospitalCode(vertx, sessionId);
		
		if(request.getCode().getColName().equalsIgnoreCase("gwa_doctor")){
			codeName= bas0270Repository.getLoadColumnCodeNameInfoCaseGwaDoctor(hospCode,request.getCode().getArg1(),request.getCode().getArg2(),request.getCode().getArg3());
		}
		if(StringUtils.isEmpty(codeName)){
			String mainDoctorCode =bas0270Repository.getMainGwaDoctorCodeInfo(hospCode,request.getCode().getArg2());
			if(!StringUtils.isEmpty(mainDoctorCode)){
				response.setMainDoctorCode(mainDoctorCode);
			}
		}
		if(!StringUtils.isEmpty(codeName)){
			response.setCodeName(codeName);
		}
		
		return response.build();
	}
}