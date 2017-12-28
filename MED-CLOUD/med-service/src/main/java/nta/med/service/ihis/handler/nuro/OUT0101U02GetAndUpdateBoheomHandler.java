package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class OUT0101U02GetAndUpdateBoheomHandler extends ScreenHandler<NuroServiceProto.OUT0101U02GetAndUpdateBoheomRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(OUT0101U02GetAndUpdateBoheomHandler.class);
	
	@Resource
	private Out0102Repository out0102Repository;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT0101U02GetAndUpdateBoheomRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String nuroOUT0101U02GetY = out0102Repository.getNuroOUT0101U02GetY(hospCode, request.getPatientCode(), 
				request.getType(), DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD));
    	response.setResult(false);
		if("Y".equals(nuroOUT0101U02GetY)){
			Date startDate = DateUtil.toDate(request.getStartDate(),DateUtil.PATTERN_YYMMDD); 
			Date endDate = DateUtil.toDate(request.getEndDate(),DateUtil.PATTERN_YYMMDD);
			Date lastCheckDate = DateUtil.toDate(request.getLastCheckDate(),DateUtil.PATTERN_YYMMDD);
			Date chuidukDate = DateUtil.toDate(request.getChuidukDate(),DateUtil.PATTERN_YYMMDD);
			Date oldStartDate = DateUtil.toDate(request.getOldStartDate(),DateUtil.PATTERN_YYMMDD);
			
			out0102Repository.updateNuroOUT0101U02UpdateBoheom(request.getUserId(), new Date(), startDate, request.getPatientCode(), request.getType(),
					request.getJohap(), request.getGaein(), request.getPiname(), request.getBonGaGubun(), endDate, request.getGaeinNo(), 
					lastCheckDate, chuidukDate, hospCode, request.getPatientCodeOld(), oldStartDate);
			response.setResult(true);
		}
		return response.build();
	}

}
