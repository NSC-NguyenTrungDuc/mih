package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0001Repository;
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
public class NuroInspectionOrderGetTelHandler extends ScreenHandler<NuroServiceProto.NuroInspectionOrderGetTelRequest, NuroServiceProto.NuroInspectionOrderGetTelResponse> {
	private static final Log LOG = LogFactory.getLog(NuroInspectionOrderGetTelHandler.class);
	@Resource
	private Bas0001Repository bas0001Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroInspectionOrderGetTelResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroInspectionOrderGetTelRequest request) throws Exception {
		 NuroServiceProto.NuroInspectionOrderGetTelResponse.Builder response = NuroServiceProto.NuroInspectionOrderGetTelResponse.newBuilder();
		 List<String> listObject = bas0001Repository.getNuroInspectionOrderGetTel(getHospitalCode(vertx, sessionId), request.getReserDate());
         if (listObject != null && !listObject.isEmpty()) {
             for (String obj : listObject) {
                 response.setTelItem(StringUtils.isEmpty(obj) ? "" : obj);
             }
         }
		return response.build();
	}
}
