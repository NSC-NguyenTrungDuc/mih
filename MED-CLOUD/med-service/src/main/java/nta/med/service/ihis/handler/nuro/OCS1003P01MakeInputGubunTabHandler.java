package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OCS1003P01MakeInputGubunTabHandler extends ScreenHandler<NuroServiceProto.OCS1003P01MakeInputGubunTabRequest, NuroServiceProto.OCS1003P01MakeInputGubunTabResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS1003P01MakeInputGubunTabHandler.class);
	@Resource
	private Ocs0132Repository ocs0132Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OCS1003P01MakeInputGubunTabResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuroServiceProto.OCS1003P01MakeInputGubunTabRequest request)
			throws Exception {
		NuroServiceProto.OCS1003P01MakeInputGubunTabResponse.Builder response = NuroServiceProto.OCS1003P01MakeInputGubunTabResponse.newBuilder();
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<ComboListItemInfo> listResult = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospitalCode, request.getCode(), "INPUT_GUBUN", language);
		if (!CollectionUtils.isEmpty(listResult)) {
			for (ComboListItemInfo item : listResult) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addTabList(info);
			}
		}
		return response.build();
	}
}