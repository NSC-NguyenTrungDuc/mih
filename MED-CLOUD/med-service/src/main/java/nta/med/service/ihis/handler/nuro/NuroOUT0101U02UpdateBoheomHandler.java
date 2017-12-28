package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;


@Service
@Scope("prototype")
@Transactional
public class NuroOUT0101U02UpdateBoheomHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02UpdateBoheomRequest, SystemServiceProto.UpdateResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroOUT0101U02UpdateBoheomHandler.class);
	
	@Resource
	private Out0102Repository out0102Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroOUT0101U02UpdateBoheomRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		} else if (!StringUtils.isEmpty(request.getEndDate()) && DateUtil.toDate(request.getEndDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}else if (!StringUtils.isEmpty(request.getLastCheckDate()) && DateUtil.toDate(request.getLastCheckDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}else if (!StringUtils.isEmpty(request.getChuidukDate()) && DateUtil.toDate(request.getChuidukDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}else if (!StringUtils.isEmpty(request.getOldStartDate()) && DateUtil.toDate(request.getOldStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02UpdateBoheomRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = updateOut0102(request, getHospitalCode(vertx, sessionId));
		response.setResult(result);
		return response.build();
	}
	
	private boolean updateOut0102(NuroServiceProto.NuroOUT0101U02UpdateBoheomRequest request, String hospCode){
		Date startDate = DateUtil.toDate(request.getStartDate(),DateUtil.PATTERN_YYMMDD); 
		Date endDate = DateUtil.toDate(request.getEndDate(),DateUtil.PATTERN_YYMMDD);
		Date lastCheckDate = DateUtil.toDate(request.getLastCheckDate(),DateUtil.PATTERN_YYMMDD);
		Date chuidukDate = DateUtil.toDate(request.getChuidukDate(),DateUtil.PATTERN_YYMMDD);
		Date oldStartDate = DateUtil.toDate(request.getOldStartDate(),DateUtil.PATTERN_YYMMDD);
		Integer result = out0102Repository.updateNuroOUT0101U02UpdateBoheom(request.getUserId(), new Date(), startDate, request.getPatientCode(), request.getType(),
				request.getJohap(), request.getGaein(), request.getPiname(), request.getBonGaGubun(), endDate, request.getGaeinNo(), 
				lastCheckDate, chuidukDate, hospCode, request.getPatientCodeOld(), oldStartDate);
		if(result > 0){
			return true;
		}else{
			return false;
		}
	}

}
