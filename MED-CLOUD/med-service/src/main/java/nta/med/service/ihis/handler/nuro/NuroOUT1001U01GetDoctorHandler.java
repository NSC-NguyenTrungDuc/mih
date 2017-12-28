package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01GetDoctorInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroOUT1001U01GetDoctorHandler extends ScreenHandler<NuroServiceProto.NuroOUT1001U01GetDoctorRequest, NuroServiceProto.NuroOUT1001U01GetDoctorResponse>{
private static final Log logger = LogFactory.getLog(NuroOUT1001U01GetDoctorHandler.class);
	
	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroOUT1001U01GetDoctorRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getNaewonDate())&& DateUtil.toDate(request.getNaewonDate(),DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroOUT1001U01GetDoctorResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01GetDoctorRequest request) throws Exception {
		NuroServiceProto.NuroOUT1001U01GetDoctorResponse.Builder response= NuroServiceProto.NuroOUT1001U01GetDoctorResponse.newBuilder();
		List<NuroOUT1001U01GetDoctorInfo> listNuroOUT1001U01GetDoctorInfo = bas0270Repository.getNuroOUT1001U01GetDoctorInfo(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId), 
				request.getNaewonDate(), request.getGwa(), request.getFind1());
        if (listNuroOUT1001U01GetDoctorInfo != null && !listNuroOUT1001U01GetDoctorInfo.isEmpty()) {
            for (NuroOUT1001U01GetDoctorInfo item : listNuroOUT1001U01GetDoctorInfo) {
                NuroModelProto.NuroOUT1001U01GetDoctorInfo.Builder builder = NuroModelProto.NuroOUT1001U01GetDoctorInfo.newBuilder();
                if(!StringUtils.isEmpty(item.getGwa())) {
                	builder.setGwa(item.getGwa());
                }
                if(!StringUtils.isEmpty(item.getGwaName())) {
                	builder.setGwaName(item.getGwaName());
            	}
                if(!StringUtils.isEmpty(item.getDoctor())) {
                	builder.setDoctor(item.getDoctor());
            	}
                if(!StringUtils.isEmpty(item.getDoctorName())) {
                	builder.setDoctorName(item.getDoctorName());
            	}
                if(!StringUtils.isEmpty(item.getWaitingPatient())) {
                	builder.setWaitingPatient(item.getWaitingPatient().toString());
            	}
                if(!StringUtils.isEmpty(item.getTotalPatient())) {
                	builder.setTotalPatient(item.getTotalPatient().toString());
            	}
               
                response.addDoctorItem(builder);
            }
        }
		return response.build();
	}
}
