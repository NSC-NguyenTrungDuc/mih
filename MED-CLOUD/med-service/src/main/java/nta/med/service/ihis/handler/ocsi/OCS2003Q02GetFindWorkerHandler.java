package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q02GetFindWorkerRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q02GetFindWorkerResponse;

@Service
@Scope("prototype")
public class OCS2003Q02GetFindWorkerHandler extends
		ScreenHandler<OcsiServiceProto.OCS2003Q02GetFindWorkerRequest, OcsiServiceProto.OCS2003Q02GetFindWorkerResponse> {

	@Resource
	private Bas0260Repository bas0260Repository;

	@Resource
	private Bas0270Repository bas0270Repository;

	@Override
	@Transactional(readOnly = true)
	public OCS2003Q02GetFindWorkerResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003Q02GetFindWorkerRequest request) throws Exception {

		OcsiServiceProto.OCS2003Q02GetFindWorkerResponse.Builder response = OcsiServiceProto.OCS2003Q02GetFindWorkerResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		String findMod = request.getFindMode();
		String refCode = request.getRefCode();
		List<ComboListItemInfo> cboList = null;

		if ("gwa".equals(findMod)) {
			cboList = bas0260Repository.findBasGwaByHospCodeIpwonYnBuseoGubun(hospCode, language, "Y", "1", true);
		} else if ("doctor".equals(findMod)) {
			cboList = bas0270Repository.findDoctorByHospCodeSysDateDoctorGwa(hospCode, language, refCode, true);
		}

		if (!CollectionUtils.isEmpty(cboList)) {
			for (ComboListItemInfo info : cboList) {
				CommonModelProto.ComboListItemInfo.Builder pInfo = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(info, pInfo, language);
				response.addFdwItem(pInfo);
			}
		}

		return response.build();
	}

}
