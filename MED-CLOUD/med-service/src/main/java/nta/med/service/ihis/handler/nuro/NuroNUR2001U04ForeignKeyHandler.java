package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out1001Repository;
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
public class NuroNUR2001U04ForeignKeyHandler extends ScreenHandler<NuroServiceProto.NuroNUR2001U04ForeignKeyRequest, NuroServiceProto.NuroNUR2001U04ForeignKeyResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroNUR2001U04ForeignKeyHandler.class);
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroNUR2001U04ForeignKeyResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroNUR2001U04ForeignKeyRequest request) throws Exception {
		NuroServiceProto.NuroNUR2001U04ForeignKeyResponse.Builder response = NuroServiceProto.NuroNUR2001U04ForeignKeyResponse.newBuilder();
		List<String> listObject = out1001Repository.getNuroNUR2001U04ForeignKey(getHospitalCode(vertx, sessionId), request.getComingDate(), request.getPatientCode(), 
        		request.getDepartmentCode(), request.getDoctorCode(), request.getComingType(), request.getReceptionNo());
        if (listObject != null && !listObject.isEmpty()) {
            for (String obj : listObject) {
            	CommonModelProto.DataStringListItemInfo.Builder builder = CommonModelProto.DataStringListItemInfo.newBuilder();
            	builder.setDataValue(obj);
                response.addResult(builder);
            }
        }
		return response.build();
	}
}
