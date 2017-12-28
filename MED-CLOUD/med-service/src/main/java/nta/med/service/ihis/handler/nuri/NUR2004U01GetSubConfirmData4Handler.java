package nta.med.service.ihis.handler.nuri;

import java.sql.SQLException;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U01GetSubConfirmData4Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR2004U01GetSubConfirmData4Handler
		extends ScreenHandler<NuriServiceProto.NUR2004U01GetSubConfirmData4Request, SystemServiceProto.UpdateResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(NUR2004U01GetSubConfirmData4Handler.class);
	
	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U01GetSubConfirmData4Request request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		
		try{
			Integer result = inp1001Repository.updateNUR2004U01GetSubConfirmData4(hospCode, userId, request.getToGwa(), request.getToDoctor(), request.getToResident(),
					request.getToHoCode1(), request.getToHoDong1(), request.getToBedNo(), request.getToBedNo2(), request.getToHoCode2(), request.getToHoDong2(),
					request.getToHoGrade1(), request.getToHoGrade2(), request.getToKaikeiHodong(), request.getToKaikeiHocode(), CommonUtils.parseDouble(request.getFkinp1001()));
			
			if(result < 0){
				response.setResult(false);
			}
		}catch (Exception e) {
			LOGGER.info(String.format("Update NUR2004U01GetSubConfirmData4Handler fail: hosp_code = %s", hospCode), e);
			if(e.getCause().getCause() instanceof SQLException){
				SQLException sqle = ((SQLException)e.getCause().getCause());
				response.setMsg(sqle.getMessage() != null ? sqle.getMessage() : "");
				response.setResult(false);
			}
			
			throw new ExecutionException(response.build());
		}
		response.setResult(true);
		return response.build();
	}

}
