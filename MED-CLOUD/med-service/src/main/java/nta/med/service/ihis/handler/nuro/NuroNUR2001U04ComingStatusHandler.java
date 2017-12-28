package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service
@Scope("prototype")
public class NuroNUR2001U04ComingStatusHandler extends ScreenHandler<NuroServiceProto.NuroNUR2001U04ComingStatusRequest, NuroServiceProto.NuroNUR2001U04ComingStatusResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroNUR2001U04ComingStatusHandler.class);

	@Resource
	private Out1001Repository out1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroNUR2001U04ComingStatusResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroNUR2001U04ComingStatusRequest request) throws Exception {
		NuroServiceProto.NuroNUR2001U04ComingStatusResponse.Builder response = NuroServiceProto.NuroNUR2001U04ComingStatusResponse.newBuilder();
		Integer oldReceptionNo = CommonUtils.parseInteger(request.getOldReceptionNo());
		List<String> listObject = out1001Repository.getNuroNUR2001U04ComingStatus(getHospitalCode(vertx, sessionId), request.getPatientCode(),request.getComingDate(), request.getDepartmentCode(),
        		request.getDoctorCode(), request.getComingType(), oldReceptionNo, request.getExamStatus());
        if (listObject != null && !listObject.isEmpty()) {
            for (String obj : listObject) {
                response.setResult(StringUtils.isEmpty(obj) ? "" : obj);
            }
        }
		return response.build();
	}
}
