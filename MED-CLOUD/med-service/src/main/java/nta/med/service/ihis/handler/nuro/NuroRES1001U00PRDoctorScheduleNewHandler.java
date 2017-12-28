package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.core.glossary.YesNo;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class NuroRES1001U00PRDoctorScheduleNewHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00PRDoctorScheduleNewRequest, NuroServiceProto.StoredProcedureResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroRES1001U00PRDoctorScheduleNewHandler.class);
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	public NuroServiceProto.StoredProcedureResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00PRDoctorScheduleNewRequest request) throws Exception {
		NuroServiceProto.StoredProcedureResponse.Builder response = NuroServiceProto.StoredProcedureResponse.newBuilder();
		String sessionHospCode = getHospitalCode(vertx, sessionId);
		String hospCode = getHospitalCode(vertx, sessionId);
		String isOtherClinic = YesNo.NO.getValue();
	    if(!StringUtils.isEmpty(request.getHospCodeLink())){
	    		hospCode = request.getHospCodeLink();
	        	isOtherClinic = YesNo.YES.getValue();
	    }
        String result = out1001Repository.callPrResDoctorScheduleNew(hospCode, sessionHospCode, request.getIDoctor(), request.getIYymm(), isOtherClinic, "");
        if(result != null && !result.isEmpty()){
        	if(result.equalsIgnoreCase("O")){
        		response.setResult(true);
        	}else{
        		response.setResult(false);
        	}
        }
		return response.build();
	}
}
