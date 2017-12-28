package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out1001Repository;
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
public class NuroInspectionOrderGetReserMoveNameHandler extends ScreenHandler<NuroServiceProto.NuroInspectionOrderGetReserMoveNameRequest, NuroServiceProto.NuroInspectionOrderGetReserMoveNameResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroInspectionOrderGetReserMoveNameHandler.class);
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroInspectionOrderGetReserMoveNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroInspectionOrderGetReserMoveNameRequest request) throws Exception {
		 NuroServiceProto.NuroInspectionOrderGetReserMoveNameResponse.Builder response = NuroServiceProto.NuroInspectionOrderGetReserMoveNameResponse.newBuilder();
		 List<String> listObject = out1001Repository.getInspectionOrderReserMoveName(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getPatientCode(), request.getReserDate(), request.getDepartmentCode(),
         		request.getReserYn(), request.getRowNum());
         if (listObject != null && !listObject.isEmpty()) {
             for (String obj : listObject) {
                 response.setReserMoveName(StringUtils.isEmpty(obj) ? "" : obj);
             }
         }
		return response.build();
	}
}
