package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.model.ihis.system.CheckHideButtonInfo;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.CheckHideButtonRequest;
import nta.med.service.ihis.proto.SystemServiceProto.CheckHideButtonResponse;

@Service
@Scope("prototype")
public class CheckHideButtonHandler
		extends ScreenHandler<SystemServiceProto.CheckHideButtonRequest, SystemServiceProto.CheckHideButtonResponse> {

	private static final Log LOGGER = LogFactory.getLog(CheckUserDoctorLoginHandler.class);

	@Resource
	private Ocs0132Repository ocs0132Repository;

	@Override
	@Transactional(readOnly = true)
	public CheckHideButtonResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CheckHideButtonRequest request) throws Exception {

		SystemServiceProto.CheckHideButtonResponse.Builder response = SystemServiceProto.CheckHideButtonResponse
				.newBuilder();
		String codeType = request.getCodeType();
		String hospCode = getHospitalCode(vertx, sessionId);

		List<CheckHideButtonInfo> listItem = ocs0132Repository.getCheckHideButtonInfo(hospCode, codeType);
		if (!CollectionUtils.isEmpty(listItem)) {
			for (CheckHideButtonInfo item : listItem) {
				SystemModelProto.CheckHideButtonInfo.Builder info = SystemModelProto.CheckHideButtonInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDt(info);
			}
		}
		
		return response.build();
	}

}
