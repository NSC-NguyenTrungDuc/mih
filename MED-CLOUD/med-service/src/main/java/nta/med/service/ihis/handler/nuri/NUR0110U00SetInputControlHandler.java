package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0133Repository;
import nta.med.data.model.ihis.ocsi.OCS2005U00setInputControlInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00SetInputControlRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00SetInputControlResponse;

@Service
@Scope("prototype")
public class NUR0110U00SetInputControlHandler extends
		ScreenHandler<NuriServiceProto.NUR0110U00SetInputControlRequest, NuriServiceProto.NUR0110U00SetInputControlResponse> {

	@Resource
	private Ocs0133Repository ocs0133Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR0110U00SetInputControlResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0110U00SetInputControlRequest request) throws Exception {
		NuriServiceProto.NUR0110U00SetInputControlResponse.Builder response = NuriServiceProto.NUR0110U00SetInputControlResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<OCS2005U00setInputControlInfo> items = ocs0133Repository.getOCS2005U00setInputControlInfo(hospCode,
				request.getInputControl());
		for (OCS2005U00setInputControlInfo item : items) {
			NuriModelProto.NUR0110U00SetInputControlInfo.Builder info = NuriModelProto.NUR0110U00SetInputControlInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addResLst(info);
		}

		return response.build();
	}

}
