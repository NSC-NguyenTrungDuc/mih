package nta.med.service.ihis.handler.inps;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01EtcIpwonlayCommonDoctorRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01EtcIpwonlayCommonDoctorResponse;

@Service                                                                                                          
@Scope("prototype") 
public class INP1001U01EtcIpwonlayCommonDoctorHandler extends ScreenHandler<InpsServiceProto.INP1001U01EtcIpwonlayCommonDoctorRequest, InpsServiceProto.INP1001U01EtcIpwonlayCommonDoctorResponse>{
	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP1001U01EtcIpwonlayCommonDoctorResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, INP1001U01EtcIpwonlayCommonDoctorRequest request) throws Exception {
		InpsServiceProto.INP1001U01EtcIpwonlayCommonDoctorResponse.Builder response = InpsServiceProto.INP1001U01EtcIpwonlayCommonDoctorResponse.newBuilder();
		String result = bas0270Repository.getDoctorByDoctorGwaAndCommonDoctorYn(getHospitalCode(vertx, sessionId), request.getGwa(), "Y");
		if (!StringUtils.isEmpty(result)) {
			InpsModelProto.INP1001U01EtcIpwonlayCommonDoctorInfo.Builder info = InpsModelProto.INP1001U01EtcIpwonlayCommonDoctorInfo.newBuilder();
			info.setDoctor(result);
			response.addLayItem(info);
		}			
		return response.build();
	}

}
