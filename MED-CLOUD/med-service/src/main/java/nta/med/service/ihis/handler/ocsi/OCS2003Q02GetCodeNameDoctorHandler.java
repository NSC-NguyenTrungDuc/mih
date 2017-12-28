package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q02GetCodeNameDoctorRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q02GetCodeNameDoctorResponse;

@Service
@Scope("prototype")
public class OCS2003Q02GetCodeNameDoctorHandler extends
		ScreenHandler<OcsiServiceProto.OCS2003Q02GetCodeNameDoctorRequest, OcsiServiceProto.OCS2003Q02GetCodeNameDoctorResponse> {
	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Override
	@Transactional
	public OCS2003Q02GetCodeNameDoctorResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003Q02GetCodeNameDoctorRequest request) throws Exception {
		
		OcsiServiceProto.OCS2003Q02GetCodeNameDoctorResponse.Builder response = OcsiServiceProto.OCS2003Q02GetCodeNameDoctorResponse.newBuilder();
		String result = bas0270Repository.getOcsaOCS0503Q00DoctorNameList(getHospitalCode(vertx, sessionId), request.getGwa(), request.getCode());
		if (!StringUtils.isEmpty(result)) {
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(result);
			response.setDoctorItem(info);
		}
		return response.build();
	}

}
