package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

/**
 * @author dainguyen.
 */
@Service
@Scope("prototype")
public class NuroMakeDeptComboHandler extends ScreenHandler<NuroServiceProto.NuroMakeDeptComboRequest, NuroServiceProto.NuroMakeDeptComboResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroMakeDeptComboHandler.class);
	@Resource
	private Bas0260Repository bas0260Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroMakeDeptComboResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroMakeDeptComboRequest request) throws Exception {
		NuroServiceProto.NuroMakeDeptComboResponse.Builder response = NuroServiceProto.NuroMakeDeptComboResponse.newBuilder();
		List<ComboListItemInfo> listObject = bas0260Repository.generateNuroDeparmentList(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId));
		if (listObject != null && !listObject.isEmpty()) {
			for (ComboListItemInfo obj : listObject) {
				CommonModelProto.ComboListItemInfo.Builder nuroMakeDeptInfo = CommonModelProto.ComboListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(obj.getCode())) {
					nuroMakeDeptInfo.setCode(obj.getCode());
				}
				if (!StringUtils.isEmpty(obj.getCodeName())) {
					nuroMakeDeptInfo.setCodeName(obj.getCodeName());
				}
				response.addDeptComboItem(nuroMakeDeptInfo);
			}
		}
		return response.build();
	}
}
