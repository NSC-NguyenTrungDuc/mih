package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.sch.Sch0109Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroInspectionOrderGetInfoTextHandler extends ScreenHandler<NuroServiceProto.NuroInspectionOrderGetInfoTextRequest, NuroServiceProto.NuroInspectionOrderGetInfoTextResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroInspectionOrderGetInfoTextHandler.class);
	@Resource
	private Sch0109Repository sch0109Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroInspectionOrderGetInfoTextResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroInspectionOrderGetInfoTextRequest request) throws Exception {
		NuroServiceProto.NuroInspectionOrderGetInfoTextResponse.Builder response = NuroServiceProto.NuroInspectionOrderGetInfoTextResponse.newBuilder();
		List<String> listObject = sch0109Repository.getNuroInspectionOrderText(getHospitalCode(vertx, sessionId), request.getCodeType(), getLanguage(vertx, sessionId));
        if (listObject != null && !listObject.isEmpty()) {
            for (String obj : listObject) {
                response.addInfoTextItem(StringUtils.isEmpty(obj) ? "" : obj);
            }
        }
		return response.build();
	}

}
