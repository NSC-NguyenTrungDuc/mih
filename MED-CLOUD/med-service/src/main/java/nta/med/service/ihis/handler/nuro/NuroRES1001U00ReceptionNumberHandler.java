package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
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
public class NuroRES1001U00ReceptionNumberHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00ReceptionNumberRequest, NuroServiceProto.NuroRES1001U00ReceptionNumberResponse> {
	private static final Log LOG = LogFactory.getLog(NuroRES1001U00ReceptionNumberHandler.class);
	@Resource
	private Out1001Repository out1001Repository;

    @Override
	public boolean isValid(NuroServiceProto.NuroRES1001U00ReceptionNumberRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getExamPreDate()) && DateUtil.toDate(request.getExamPreDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES1001U00ReceptionNumberResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00ReceptionNumberRequest request) throws Exception {
		List<Double> listObject = out1001Repository.getNuroRES1001U00ReceptionNumber(getHospitalCode(vertx, sessionId), getHospitalCode(vertx, sessionId), request.getPatientCode(), request.getExamPreDate(), false);
        NuroServiceProto.NuroRES1001U00ReceptionNumberResponse.Builder response = NuroServiceProto.NuroRES1001U00ReceptionNumberResponse.newBuilder();
        if (listObject != null && !listObject.isEmpty()) {
              for (Double obj : listObject) {
                  response.setReceptionNo(obj == null ? "" : obj.toString());
              }
          }
		return response.build();
	}
}
