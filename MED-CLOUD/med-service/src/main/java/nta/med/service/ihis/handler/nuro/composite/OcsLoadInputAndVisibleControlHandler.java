package nta.med.service.ihis.handler.nuro.composite;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0130Repository;
import nta.med.data.dao.medi.ocs.Ocs0141Repository;
import nta.med.data.model.ihis.nuro.OcsLoadInputControlListItemInfo;
import nta.med.data.model.ihis.nuro.OcsLoadVisibleControlListItemInfo;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service
@Scope("prototype")
public class OcsLoadInputAndVisibleControlHandler extends
		ScreenHandler<NuroServiceProto.OcsLoadInputAndVisibleControlRequest, NuroServiceProto.OcsLoadInputAndVisibleControlResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsLoadInputAndVisibleControlHandler.class);
	
	@Resource
	private Ocs0130Repository ocs0130Repository;
	
	@Resource
	private Ocs0141Repository ocs0141Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OcsLoadInputAndVisibleControlResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, NuroServiceProto.OcsLoadInputAndVisibleControlRequest request) throws Exception {
		NuroServiceProto.OcsLoadInputAndVisibleControlResponse.Builder response = NuroServiceProto.OcsLoadInputAndVisibleControlResponse
				.newBuilder();
		List<OcsLoadInputControlListItemInfo> ocsLoadInputControlListItemInfo = ocs0130Repository
				.getOcslibControlListItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getInputControl());
		List<OcsLoadVisibleControlListItemInfo> ocsLoadVisibleControlListItemInfo = ocs0141Repository
				.getOcslibVisibleListItem(request.getInputTab());
		if (!CollectionUtils.isEmpty(ocsLoadInputControlListItemInfo)) {
			for (OcsLoadInputControlListItemInfo item : ocsLoadInputControlListItemInfo) {
				NuroModelProto.OcsLoadInputControlListItemInfo.Builder info = NuroModelProto.OcsLoadInputControlListItemInfo
						.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addControlList(info);
			}
		}		
		if (!CollectionUtils.isEmpty(ocsLoadVisibleControlListItemInfo)) {
			for (OcsLoadVisibleControlListItemInfo item : ocsLoadVisibleControlListItemInfo) {
				NuroModelProto.OcsLoadVisibleControlListItemInfo.Builder info = NuroModelProto.OcsLoadVisibleControlListItemInfo
						.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addVisibleControlList(info);
			}
		}		
		return response.build();
	}
}
