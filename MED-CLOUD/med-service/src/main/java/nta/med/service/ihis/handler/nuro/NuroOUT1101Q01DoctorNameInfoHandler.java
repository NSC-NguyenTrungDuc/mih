package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.nuro.NuroOUT1101Q01DoctorNameInfo;
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
public class NuroOUT1101Q01DoctorNameInfoHandler  extends ScreenHandler<NuroServiceProto.NuroOUT1101Q01DoctorNameInfoRequest, NuroServiceProto.NuroOUT1101Q01DoctorNameInfoResponse>{
	private static final Log logger = LogFactory.getLog(NuroOUT1101Q01DoctorNameInfoHandler.class);
	
	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOUT1101Q01DoctorNameInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1101Q01DoctorNameInfoRequest request) throws Exception {
		NuroServiceProto.NuroOUT1101Q01DoctorNameInfoResponse.Builder response = NuroServiceProto.NuroOUT1101Q01DoctorNameInfoResponse.newBuilder();
		List<NuroOUT1101Q01DoctorNameInfo> listNuroOUT1101Q01DoctorNameInfo = bas0270Repository.getNuroOUT1101Q01DoctorNameInfo(getHospitalCode(vertx, sessionId),  request.getGwa(), request.getDoctor());
        if (listNuroOUT1101Q01DoctorNameInfo != null && !listNuroOUT1101Q01DoctorNameInfo.isEmpty()) {
            for (NuroOUT1101Q01DoctorNameInfo obj : listNuroOUT1101Q01DoctorNameInfo) {
                NuroModelProto.NuroOUT1101Q01DoctorNameInfo.Builder builder = NuroModelProto.NuroOUT1101Q01DoctorNameInfo.newBuilder();
                if(!StringUtils.isEmpty(obj.getDoctorName())) {
                	builder.setDoctorName(obj.getDoctorName());
                }
                
                response.setDoctorNameInfo(builder);
            }
        } else {
        	NuroModelProto.NuroOUT1101Q01DoctorNameInfo.Builder builder = NuroModelProto.NuroOUT1101Q01DoctorNameInfo.newBuilder();
        	builder.setDoctorName("");
        	response.setDoctorNameInfo(builder);
        }
        
		return response.build();
	}

}
