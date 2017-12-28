package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroNUR2001U04DoctorNameHandler extends ScreenHandler<NuroServiceProto.NuroNUR2001U04DoctorNameRequest, NuroServiceProto.NuroNUR2001U04DoctorNameResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroNUR2001U04DoctorNameHandler.class);
	@Resource
	private Bas0270Repository bas0270Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroNUR2001U04DoctorNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroNUR2001U04DoctorNameRequest request) throws Exception {
		NuroServiceProto.NuroNUR2001U04DoctorNameResponse.Builder response = NuroServiceProto.NuroNUR2001U04DoctorNameResponse.newBuilder();
		List<String> listObject = bas0270Repository.getNuroNUR2001U04DoctorName(getHospitalCode(vertx, sessionId), request.getDoctorCode(), request.getDate());
        if (listObject != null && !listObject.isEmpty()) {
            for (String obj : listObject) {
            	CommonModelProto.DataStringListItemInfo.Builder builder = CommonModelProto.DataStringListItemInfo.newBuilder();
            	builder.setDataValue(obj);
                response.addDoctorName(builder);
            }
        }
		return response.build();
	}
}
