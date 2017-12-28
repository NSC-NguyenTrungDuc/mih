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
public class NuroInspectionOrderGetMaxCodeNameHandler extends ScreenHandler<NuroServiceProto.NuroInspectionOrderGetMaxCodeNameRequest, NuroServiceProto.NuroInspectionOrderGetMaxCodeNameResponse> {
	private static final Log LOG = LogFactory.getLog(NuroInspectionOrderGetMaxCodeNameHandler.class);
	@Resource
	private Sch0109Repository sch0109Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroInspectionOrderGetMaxCodeNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			 NuroServiceProto.NuroInspectionOrderGetMaxCodeNameRequest request) throws Exception {
		 NuroServiceProto.NuroInspectionOrderGetMaxCodeNameResponse.Builder response = NuroServiceProto.NuroInspectionOrderGetMaxCodeNameResponse.newBuilder();
		 // TODO: redundant request
		 List<String> listReserPart = null;
		 List<String> listObject = sch0109Repository.getNuroInspectionOrderMaxCodeName(getHospitalCode(vertx, sessionId), request.getCodeType(), listReserPart);
         if (listObject != null && !listObject.isEmpty()) {
             for (String obj : listObject) {
                 response.addCodeNameItem(StringUtils.isEmpty(obj) ? "" : obj);
             }
         }
		return response.build();
	}
}
