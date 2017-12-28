package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class NuroOUT0101U02UpdatePatientHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02UpdatePatientRequest, SystemServiceProto.UpdateResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroOUT0101U02UpdatePatientHandler.class);
	@Resource
	private Out0101Repository out0101Repository;
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02UpdatePatientRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		response.setResult(updatePatient(request, getHospitalCode(vertx, sessionId)));
		return response.build();
	}
	
	private boolean updatePatient(NuroServiceProto.NuroOUT0101U02UpdatePatientRequest request, String hospCode){
			if(out0101Repository.updateNuroOUT0101U02Patient(
					request.getUserId(), 
					request.getPatientName(), 
					request.getSex(),DateUtil.toDate(request.getBirth(), DateUtil.PATTERN_YYMMDD),
					request.getZipCode1(), 
					request.getZipCode2(),
					request.getAddress1(), 
					request.getAddress2(), 
					request.getTel(), 
					request.getTel1(), 
					request.getType(),
					request.getTelHp(), 
					request.getEmail(),
					request.getPatientName2(), 
					request.getTelType(), 
					request.getTelType2(), 
					request.getTelType3(),
					request.getDeleteYn(),
					request.getPaceMakerYn(),
					request.getSelfPaceMaker(),
					request.getPatientType(),
					"",
					hospCode,
					request.getPatientCode(),
					"") > 0){
				return true;
			}else{
				return false;
			}
	}

}
