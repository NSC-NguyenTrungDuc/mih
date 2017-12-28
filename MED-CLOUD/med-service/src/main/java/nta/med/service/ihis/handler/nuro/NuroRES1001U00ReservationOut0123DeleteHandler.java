package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out0123Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.lang3.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class NuroRES1001U00ReservationOut0123DeleteHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00ReservationOut0123DeleteRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(NuroRES1001U00ReservationOut0123DeleteHandler.class);
	@Resource
	private Out0123Repository out0123Repository;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00ReservationOut0123DeleteRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = deleteOut0105ByPatientCodeAndGongbiCode(request, getHospitalCode(vertx, sessionId));
        response.setResult(result);
		return response.build();
	}
	
	 private boolean deleteOut0105ByPatientCodeAndGongbiCode(NuroServiceProto.NuroRES1001U00ReservationOut0123DeleteRequest request, String hospCode) {
 		Integer resultDelete = out0123Repository.deleteOut0123ByPatientCodeAndPkout1001(hospCode, request.getPatientCode(), StringUtils.isEmpty(request.getPkout1001()) ? null : new Long(request.getPkout1001()));
         if (resultDelete > 0) {
         	LOG.info("DELETE Out0105 successfully for " + resultDelete + " records");
         	return true;
         }else{
         	return false;
         }
	 }
}