package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.cht.Cht0110Repository;
import nta.med.data.dao.medi.ocs.Ocs0503Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503U00GetCodeNameRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503U00GetCodeNameResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;


@Transactional
@Service
@Scope("prototype")
public class OcsaOCS0503U00GetCodeNameOCS0503Handler
	extends ScreenHandler<OcsaServiceProto.OCS0503U00GetCodeNameRequest, OcsaServiceProto.OCS0503U00GetCodeNameResponse>{
	@Resource
	private Cht0110Repository cht0110Repository;
	@Resource
	private Ocs0503Repository ocs0503Reposotory;
	@Resource
	private Bas0270Repository bas0270Repository;
	@Override
	@Transactional(readOnly = true)
	public OCS0503U00GetCodeNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0503U00GetCodeNameRequest request) throws Exception {
		OcsaServiceProto.OCS0503U00GetCodeNameResponse.Builder response=OcsaServiceProto.OCS0503U00GetCodeNameResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String codeName = null;
		switch (request.getCodeMode()) {
		case "sang_code":
			codeName=cht0110Repository.getCHT0110U00GetCodeName(hospCode,request.getCode());
			break;
		case "gwa_name":
			codeName=ocs0503Reposotory.getGwaNameOCS0503U00(hospCode,language, request.getCode());
			break;
		case "doctor_name":
			codeName=bas0270Repository.getDoctorNameOCS0503U00(hospCode, request.getCode());
			break;
		}
		if(!StringUtils.isEmpty(codeName)){
			response.setCodeName(codeName);
		}
		return response.build();
	}

}
