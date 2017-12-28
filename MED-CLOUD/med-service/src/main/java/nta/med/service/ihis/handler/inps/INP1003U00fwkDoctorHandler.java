package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.inps.INP1003U00fwkDoctorInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00fwkDoctorRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00fwkDoctorResponse;

/**
 * @author vnc.tuyen
 */
@Service
@Scope("prototype")
public class INP1003U00fwkDoctorHandler extends ScreenHandler<InpsServiceProto.INP1003U00fwkDoctorRequest, InpsServiceProto.INP1003U00fwkDoctorResponse> {

	@Resource
	private Bas0270Repository bas0270Repository;	
	
	@Override
	public INP1003U00fwkDoctorResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U00fwkDoctorRequest request) throws Exception {
		
		InpsServiceProto.INP1003U00fwkDoctorResponse.Builder response = InpsServiceProto.INP1003U00fwkDoctorResponse.newBuilder();
		
		String hospCode = request.getHospCode();
		String gwa = request.getGwa();
		String find = request.getFind();
		String doctorYmd = request.getDoctorYmd();
		String language = getLanguage(vertx, sessionId);
		
		List<INP1003U00fwkDoctorInfo> listInfo = bas0270Repository.getINP1003U00fwkDoctorInfo(hospCode, gwa, find, doctorYmd, language);
		if (CollectionUtils.isEmpty(listInfo)) {
			return response.build();
		}
		
		for (INP1003U00fwkDoctorInfo info : listInfo) {
			InpsModelProto.INP1003U00fwkDoctorInfo.Builder infoProto = InpsModelProto.INP1003U00fwkDoctorInfo.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addFwkItem(infoProto);
		}
		
		return response.build();
	}

}
