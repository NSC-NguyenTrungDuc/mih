package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.out.Out0102;
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
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class NuroOUT0101U02InsertBoheomHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02InsertBoheomRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroOUT0101U02InsertBoheomHandler.class);

	@Resource
	private Out0102Repository out0102Repository;

	@Override
	public boolean isValid(NuroServiceProto.NuroOUT0101U02InsertBoheomRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		} else if(!StringUtils.isEmpty(request.getEndDate()) && DateUtil.toDate(request.getEndDate(), DateUtil.PATTERN_YYMMDD) == null){
			return false;
		} else if(!StringUtils.isEmpty(request.getLastCheckDate()) && DateUtil.toDate(request.getLastCheckDate(), DateUtil.PATTERN_YYMMDD) == null){
			return false;
		}else if(!StringUtils.isEmpty(request.getChuidukDate()) && DateUtil.toDate(request.getChuidukDate(), DateUtil.PATTERN_YYMMDD) == null){
			return false;
		}
		return true;
	}

	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02InsertBoheomRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Integer result = insertOut0102(request, getHospitalCode(vertx, sessionId));
		response.setResult(result != null && result > 0);
		return response.build();
	}
	
	private Integer insertOut0102(NuroServiceProto.NuroOUT0101U02InsertBoheomRequest request, String hospCode){
		Out0102 out0102 = new Out0102();
		out0102.setSysDate(new Date());
		if(!StringUtils.isEmpty(request.getSysId())){
			out0102.setSysId(request.getSysId());
		}
		out0102.setUpdDate(new Date());
		if(!StringUtils.isEmpty(request.getUpdateId())){
			out0102.setUpdId(request.getUpdateId());
		}
		if(!StringUtils.isEmpty(request.getStartDate())){
			out0102.setStartDate(DateUtil.toDate(request.getStartDate(),DateUtil.PATTERN_YYMMDD));
		}
		if(!StringUtils.isEmpty(request.getPatientCode())){
			out0102.setBunho(request.getPatientCode());
		}
		if(!StringUtils.isEmpty(request.getType())){
			out0102.setGubun(request.getType());
		}
		if(!StringUtils.isEmpty(request.getJohap())){
			out0102.setJohap(request.getJohap());
		}
		if(!StringUtils.isEmpty(request.getGaein())){
			out0102.setGaein(request.getGaein());
		}
		if(!StringUtils.isEmpty(request.getPiname())){
			out0102.setPiname(request.getPiname());
		}
		if(!StringUtils.isEmpty(request.getBonGaGubun())){
			out0102.setBonGaGubun(request.getBonGaGubun());
		}
		if(!StringUtils.isEmpty(request.getEndDate())){
			out0102.setEndDate(DateUtil.toDate(request.getEndDate(),DateUtil.PATTERN_YYMMDD));
		}
		if(!StringUtils.isEmpty(request.getGaeinNo())){
			out0102.setGaeinNo(request.getGaeinNo());
		}
		if(!StringUtils.isEmpty(request.getLastCheckDate())){
			out0102.setLastCheckDate(DateUtil.toDate(request.getLastCheckDate(), DateUtil.PATTERN_YYMMDD));
		}
		if(!StringUtils.isEmpty(request.getChuidukDate())){
			out0102.setChuidukDate(DateUtil.toDate(request.getChuidukDate(),DateUtil.PATTERN_YYMMDD));
		}
		out0102.setHospCode(hospCode);
		LOGGER.info(out0102.toString());
		out0102Repository.save(out0102);
		return 1;
	}

}
