package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.nuro.NuroOUT1101Q01FwkDoctorInfo;
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
public class NuroOUT1101Q01FwkDoctorInfoHandler extends ScreenHandler<NuroServiceProto.NuroOUT1101Q01FwkDoctorRequest, NuroServiceProto.NuroOUT1101Q01FwkDoctorResponse>{
	private static final Log logger = LogFactory.getLog(NuroOUT1101Q01FwkDoctorInfoHandler.class);
	
	@Resource
	private Bas0270Repository bas0270Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOUT1101Q01FwkDoctorResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1101Q01FwkDoctorRequest request) throws Exception {
		 List<NuroOUT1101Q01FwkDoctorInfo> listNuroOUT1101Q01FwkDoctorInfo = bas0270Repository.getNuroOUT1101Q01FwkDoctorInfo(getHospitalCode(vertx, sessionId), request.getGwa(), request.getFind1());
         NuroServiceProto.NuroOUT1101Q01FwkDoctorResponse.Builder response = NuroServiceProto.NuroOUT1101Q01FwkDoctorResponse.newBuilder();
         if (listNuroOUT1101Q01FwkDoctorInfo != null && !listNuroOUT1101Q01FwkDoctorInfo.isEmpty()) {
             for (NuroOUT1101Q01FwkDoctorInfo obj : listNuroOUT1101Q01FwkDoctorInfo) {
                 NuroModelProto.NuroOUT1101Q01FwkDoctorInfo.Builder builder = NuroModelProto.NuroOUT1101Q01FwkDoctorInfo.newBuilder();
                 if(!StringUtils.isEmpty(obj.getSabun())) {
                 	builder.setSabun(obj.getSabun());
                 }
                 if(!StringUtils.isEmpty(obj.getDoctorName())) {
                 	builder.setDoctorName(obj.getDoctorName());
                 }
                 
                 response.addNuroFwkDoctorInfoList(builder);
             }
         }
		return response.build();
	}

}
