package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02DeleteCurrentTabRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02DeleteCurrentTabResponse;

@Service
@Scope("prototype")
public class OCS2005U02DeleteCurrentTabHandler extends
		ScreenHandler<OcsiServiceProto.OCS2005U02DeleteCurrentTabRequest, OcsiServiceProto.OCS2005U02DeleteCurrentTabResponse> {

	@Resource
	private Ocs2005Repository ocs2005Repository;

	@Override
	public OCS2005U02DeleteCurrentTabResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02DeleteCurrentTabRequest request) throws Exception {
		OcsiServiceProto.OCS2005U02DeleteCurrentTabResponse.Builder response = OcsiServiceProto.OCS2005U02DeleteCurrentTabResponse.newBuilder();

		String rs = ocs2005Repository.executeFnOcsOcs2005DeleteYn(getHospitalCode(vertx, sessionId),
				DateUtil.toDate(request.getDrtDate(), DateUtil.PATTERN_YYMMDD), request.getBldGubun());

		CommonModelProto.DataStringListItemInfo.Builder pInfo = CommonModelProto.DataStringListItemInfo.newBuilder()
				.setDataValue(rs);
		response.setObjItem(pInfo);

		return response.build();
	}

}
