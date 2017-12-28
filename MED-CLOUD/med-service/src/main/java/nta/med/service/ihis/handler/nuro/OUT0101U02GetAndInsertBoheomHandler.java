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
public class OUT0101U02GetAndInsertBoheomHandler extends ScreenHandler<NuroServiceProto.OUT0101U02GetAndInsertBoheomRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(OUT0101U02GetAndInsertBoheomHandler.class);
	
	@Resource
	private Out0102Repository out0102Repository;
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT0101U02GetAndInsertBoheomRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String  nuroOUT0101U02GetY = out0102Repository.getNuroOUT0101U02GetY(hospCode, request.getPatientCode(), 
				request.getType(), DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD));
		if(nuroOUT0101U02GetY != null && !nuroOUT0101U02GetY.isEmpty()){
			response.setResult(false);
		}else{
			insertOut0102(request, hospCode);
			response.setResult(true);
		}
		
		return response.build();
	}
	
	private void insertOut0102(NuroServiceProto.OUT0101U02GetAndInsertBoheomRequest request, String hospCode){			
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
		out0102Repository.save(out0102);
	}
	
}
