package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OUTSANGU00getFindWorkerHandler extends ScreenHandler<OcsoServiceProto.OUTSANGU00getFindWorkerRequest, OcsoServiceProto.OUTSANGU00getFindWorkerResponse> {
	private static final Log LOGGER = LogFactory.getLog(OUTSANGU00getFindWorkerHandler.class);

	@Resource
	private Bas0102Repository bas0102Repository;

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OUTSANGU00getFindWorkerResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OUTSANGU00getFindWorkerRequest request) throws Exception {
		OcsoServiceProto.OUTSANGU00getFindWorkerResponse.Builder response = OcsoServiceProto.OUTSANGU00getFindWorkerResponse.newBuilder();
		List<ComboListItemInfo> listResult = bas0102Repository.getOcsoOUTSANGU00FindWorker(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getSangEndSayU());
		if(listResult != null && !listResult.isEmpty()){
			for(ComboListItemInfo item : listResult){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getCode())) {
					info.setCode(item.getCode());
				}
				if (!StringUtils.isEmpty(item.getCodeName())) {
					info.setCodeName(item.getCodeName());
				}
				response.addComboItem(info);
			}
		}
		return response.build();
	}

}
