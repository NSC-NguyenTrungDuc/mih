package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur0102Repository;
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
public class NuroComboTimeHandler extends ScreenHandler<NuroServiceProto.NuroComboTimeRequest, NuroServiceProto.NuroComboTimeResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroComboTimeHandler.class);
	@Resource
	private Nur0102Repository nur0102Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroComboTimeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroComboTimeRequest request) throws Exception {
		List<ComboListItemInfo> listObject = nur0102Repository.getNuroComboTime(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId), request.getCodeType(), false);
        NuroServiceProto.NuroComboTimeResponse.Builder response = NuroServiceProto.NuroComboTimeResponse.newBuilder();
        if (listObject != null && !listObject.isEmpty()) {
            for (ComboListItemInfo obj : listObject) {
            	CommonModelProto.ComboListItemInfo.Builder nuroComboTimeInfo = CommonModelProto.ComboListItemInfo.newBuilder();
                if (!StringUtils.isEmpty(obj.getCode())) {
                	nuroComboTimeInfo.setCode(obj.getCode());
                }
                if (!StringUtils.isEmpty(obj.getCodeName())) {
                	nuroComboTimeInfo.setCodeName(obj.getCodeName());
                }
                response.addComboTimeItem(nuroComboTimeInfo);
            }
        }
		return response.build();
	}
}
