package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.res.Res0102;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0102Repository;
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
public class NuroRES0102U00InsertRES0102Handler extends ScreenHandler<NuroServiceProto.NuroRES0102U00InsertRES0102Request, SystemServiceProto.UpdateResponse>{
private static final Log logger = LogFactory.getLog(NuroRES0102U00InsertRES0102Handler.class);
	
	@Resource
	private Res0102Repository res0102Repository;
	
	@Override
	@Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00InsertRES0102Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = insertRES0102(request, getHospitalCode(vertx, sessionId));
            response.setResult(result);
		return response.build();
        }
	
	private boolean insertRES0102(NuroServiceProto.NuroRES0102U00InsertRES0102Request request, String hospCode) {
			Res0102 res0102 = new Res0102(); 
			res0102.setSysDate(new Date());
			if(!StringUtils.isEmpty(request.getUserId())) {
				res0102.setSysId(request.getUserId());	
				res0102.setUpdId(request.getUserId());
			}
			res0102.setUpdDate(new Date());
			if(!StringUtils.isEmpty(request.getDoctor())) {
				res0102.setDoctor(request.getDoctor());
			}
			res0102.setHospCode(request.getHospCode());
			if(!StringUtils.isEmpty(request.getGwa())) {
				res0102.setGwa(request.getGwa());
			}
			if(!StringUtils.isEmpty(request.getStartDate())) {
				res0102.setStartDate(DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD));
			}
			if(!StringUtils.isEmpty(request.getEndDate())) {
				res0102.setEndDate(DateUtil.toDate(request.getEndDate(), DateUtil.PATTERN_YYMMDD));
			}
			if(!StringUtils.isEmpty(request.getAvgTime())) {
				res0102.setAvgTime(CommonUtils.parseDouble(request.getAvgTime()));
			}
			if(!StringUtils.isEmpty(request.getJinryoBreakYn())) {
				res0102.setJinryoBreakYn(request.getJinryoBreakYn());
			}
			//
			if(!StringUtils.isEmpty(request.getAmStartHhmm1())) {
				res0102.setAmStartHhmm1(request.getAmStartHhmm1());
			}
			if(!StringUtils.isEmpty(request.getAmStartHhmm2())) {
				res0102.setAmStartHhmm2(request.getAmStartHhmm2());
			}
			if(!StringUtils.isEmpty(request.getAmStartHhmm3())) {
				res0102.setAmStartHhmm3(request.getAmStartHhmm3());
			}
			if(!StringUtils.isEmpty(request.getAmStartHhmm4())) {
				res0102.setAmStartHhmm4(request.getAmStartHhmm4());
			}
			if(!StringUtils.isEmpty(request.getAmStartHhmm5())) {
				res0102.setAmStartHhmm5(request.getAmStartHhmm5());
			}
			if(!StringUtils.isEmpty(request.getAmStartHhmm6())) {
				res0102.setAmStartHhmm6(request.getAmStartHhmm6());
			}
			if(!StringUtils.isEmpty(request.getAmStartHhmm7())) {
				res0102.setAmStartHhmm7(request.getAmStartHhmm7());
			}
			//
			if(!StringUtils.isEmpty(request.getAmEndHhmm1())) {
				res0102.setAmEndHhmm1(request.getAmEndHhmm1());
			}
			if(!StringUtils.isEmpty(request.getAmEndHhmm2())) {
				res0102.setAmEndHhmm2(request.getAmEndHhmm2());
			}
			if(!StringUtils.isEmpty(request.getAmEndHhmm3())) {
				res0102.setAmEndHhmm3(request.getAmEndHhmm3());
			}
			if(!StringUtils.isEmpty(request.getAmEndHhmm4())) {
				res0102.setAmEndHhmm4(request.getAmEndHhmm4());
			}
			if(!StringUtils.isEmpty(request.getAmEndHhmm5())) {
				res0102.setAmEndHhmm5(request.getAmEndHhmm5());
			}
			if(!StringUtils.isEmpty(request.getAmEndHhmm6())) {
				res0102.setAmEndHhmm6(request.getAmEndHhmm6());
			}
			if(!StringUtils.isEmpty(request.getAmEndHhmm7())) {
				res0102.setAmEndHhmm7(request.getAmEndHhmm7());
			}
			//
			if(!StringUtils.isEmpty(request.getPmStartHhmm1())) {
				res0102.setPmStartHhmm1(request.getPmStartHhmm1());
			}
			if(!StringUtils.isEmpty(request.getPmStartHhmm2())) {
				res0102.setPmStartHhmm2(request.getPmStartHhmm2());
			}
			if(!StringUtils.isEmpty(request.getPmStartHhmm3())) {
				res0102.setPmStartHhmm3(request.getPmStartHhmm3());
			}
			if(!StringUtils.isEmpty(request.getPmStartHhmm4())) {
				res0102.setPmStartHhmm4(request.getPmStartHhmm4());
			}
			if(!StringUtils.isEmpty(request.getPmStartHhmm5())) {
				res0102.setPmStartHhmm5(request.getPmStartHhmm5());
			}
			if(!StringUtils.isEmpty(request.getPmStartHhmm6())) {
				res0102.setPmStartHhmm6(request.getPmStartHhmm6());
			}
			if(!StringUtils.isEmpty(request.getPmStartHhmm7())) {
				res0102.setPmStartHhmm7(request.getPmStartHhmm7());
			}
			//
			if(!StringUtils.isEmpty(request.getPmEndHhmm1())) {
				res0102.setPmEndHhmm1(request.getPmEndHhmm1());
			}
			if(!StringUtils.isEmpty(request.getPmEndHhmm2())) {
				res0102.setPmEndHhmm2(request.getPmEndHhmm2());
			}
			if(!StringUtils.isEmpty(request.getPmEndHhmm3())) {
				res0102.setPmEndHhmm3(request.getPmEndHhmm3());
			}
			if(!StringUtils.isEmpty(request.getPmEndHhmm4())) {
				res0102.setPmEndHhmm4(request.getPmEndHhmm4());
			}
			if(!StringUtils.isEmpty(request.getPmEndHhmm5())) {
				res0102.setPmEndHhmm5(request.getPmEndHhmm5());
			}
			if(!StringUtils.isEmpty(request.getPmEndHhmm6())) {
				res0102.setPmEndHhmm6(request.getPmEndHhmm6());
			}
			if(!StringUtils.isEmpty(request.getPmEndHhmm7())) {
				res0102.setPmEndHhmm7(request.getPmEndHhmm7());
			}
			//
			if(!StringUtils.isEmpty(request.getAmGwaRoom1())) {
				res0102.setAmGwaRoom1(request.getAmGwaRoom1());
			}
			if(!StringUtils.isEmpty(request.getAmGwaRoom2())) {
				res0102.setAmGwaRoom2(request.getAmGwaRoom2());
			}
			if(!StringUtils.isEmpty(request.getAmGwaRoom3())) {
				res0102.setAmGwaRoom3(request.getAmGwaRoom3());
			}
			if(!StringUtils.isEmpty(request.getAmGwaRoom4())) {
				res0102.setAmGwaRoom4(request.getAmGwaRoom4());
			}
			if(!StringUtils.isEmpty(request.getAmGwaRoom5())) {
				res0102.setAmGwaRoom5(request.getAmGwaRoom5());
			}
			if(!StringUtils.isEmpty(request.getAmGwaRoom6())) {
				res0102.setAmGwaRoom6(request.getAmGwaRoom6());
			}
			if(!StringUtils.isEmpty(request.getAmGwaRoom7())) {
				res0102.setAmGwaRoom7(request.getAmGwaRoom7());
			}
			//
			if(!StringUtils.isEmpty(request.getPmGwaRoom1())) {
				res0102.setPmGwaRoom1(request.getPmGwaRoom1());
			}
			if(!StringUtils.isEmpty(request.getPmGwaRoom2())) {
				res0102.setPmGwaRoom2(request.getPmGwaRoom2());
			}
			if(!StringUtils.isEmpty(request.getPmGwaRoom3())) {
				res0102.setPmGwaRoom3(request.getPmGwaRoom3());
			}
			if(!StringUtils.isEmpty(request.getPmGwaRoom4())) {
				res0102.setPmGwaRoom4(request.getPmGwaRoom4());
			}
			if(!StringUtils.isEmpty(request.getPmGwaRoom5())) {
				res0102.setPmGwaRoom5(request.getPmGwaRoom5());
			}
			if(!StringUtils.isEmpty(request.getPmGwaRoom6())) {
				res0102.setPmGwaRoom6(request.getPmGwaRoom6());
			}
			if(!StringUtils.isEmpty(request.getPmGwaRoom7())) {
				res0102.setPmGwaRoom7(request.getPmGwaRoom7());
			}
			//
			if(!StringUtils.isEmpty(request.getResAmStartHhmm1())) {
				res0102.setResAmStartHhmm1(request.getResAmStartHhmm1());
			}
			if(!StringUtils.isEmpty(request.getResAmStartHhmm2())) {
				res0102.setResAmStartHhmm2(request.getResAmStartHhmm2());
			}
			if(!StringUtils.isEmpty(request.getResAmStartHhmm3())) {
				res0102.setResAmStartHhmm3(request.getResAmStartHhmm3());
			}
			if(!StringUtils.isEmpty(request.getResAmStartHhmm4())) {
				res0102.setResAmStartHhmm4(request.getResAmStartHhmm4());
			}
			if(!StringUtils.isEmpty(request.getResAmStartHhmm5())) {
				res0102.setResAmStartHhmm5(request.getResAmStartHhmm5());
			}
			if(!StringUtils.isEmpty(request.getResAmStartHhmm6())) {
				res0102.setResAmStartHhmm6(request.getResAmStartHhmm6());
			}
			if(!StringUtils.isEmpty(request.getResAmStartHhmm7())) {
				res0102.setResAmStartHhmm7(request.getResAmStartHhmm7());
			}
			//
			if(!StringUtils.isEmpty(request.getResAmEndHhmm1())) {
				res0102.setResAmEndHhmm1(request.getResAmEndHhmm1());
			}
			if(!StringUtils.isEmpty(request.getResAmEndHhmm2())) {
				res0102.setResAmEndHhmm2(request.getResAmEndHhmm2());
			}
			if(!StringUtils.isEmpty(request.getResAmEndHhmm3())) {
				res0102.setResAmEndHhmm3(request.getResAmEndHhmm3());
			}
			if(!StringUtils.isEmpty(request.getResAmEndHhmm4())) {
				res0102.setResAmEndHhmm4(request.getResAmEndHhmm4());
			}
			if(!StringUtils.isEmpty(request.getResAmEndHhmm5())) {
				res0102.setResAmEndHhmm5(request.getResAmEndHhmm5());
			}
			if(!StringUtils.isEmpty(request.getResAmEndHhmm6())) {
				res0102.setResAmEndHhmm6(request.getResAmEndHhmm6());
			}
			if(!StringUtils.isEmpty(request.getResAmEndHhmm7())) {
				res0102.setResAmEndHhmm7(request.getResAmEndHhmm7());
			}
			//
			if(!StringUtils.isEmpty(request.getResPmStartHhmm1())) {
				res0102.setResPmStartHhmm1(request.getResPmStartHhmm1());
			}
			if(!StringUtils.isEmpty(request.getResPmStartHhmm2())) {
				res0102.setResPmStartHhmm2(request.getResPmStartHhmm2());
			}
			if(!StringUtils.isEmpty(request.getResPmStartHhmm3())) {
				res0102.setResPmStartHhmm3(request.getResPmStartHhmm3());
			}
			if(!StringUtils.isEmpty(request.getResPmStartHhmm4())) {
				res0102.setResPmStartHhmm4(request.getResPmStartHhmm4());
			}
			if(!StringUtils.isEmpty(request.getResPmStartHhmm5())) {
				res0102.setResPmStartHhmm5(request.getResPmStartHhmm5());
			}
			if(!StringUtils.isEmpty(request.getResPmStartHhmm6())) {
				res0102.setResPmStartHhmm6(request.getResPmStartHhmm6());
			}
			if(!StringUtils.isEmpty(request.getResPmStartHhmm7())) {
				res0102.setResPmStartHhmm7(request.getResPmStartHhmm7());
			}
			//
			if(!StringUtils.isEmpty(request.getResPmEndHhmm1())) {
				res0102.setResPmEndHhmm1(request.getResPmEndHhmm1());
			}
			if(!StringUtils.isEmpty(request.getResPmEndHhmm2())) {
				res0102.setResPmEndHhmm2(request.getResPmEndHhmm2());
			}
			if(!StringUtils.isEmpty(request.getResPmEndHhmm3())) {
				res0102.setResPmEndHhmm3(request.getResPmEndHhmm3());
			}
			if(!StringUtils.isEmpty(request.getResPmEndHhmm4())) {
				res0102.setResPmEndHhmm4(request.getResPmEndHhmm4());
			}
			if(!StringUtils.isEmpty(request.getResPmEndHhmm5())) {
				res0102.setResPmEndHhmm5(request.getResPmEndHhmm5());
			}
			if(!StringUtils.isEmpty(request.getResPmEndHhmm6())) {
				res0102.setResPmEndHhmm6(request.getResPmEndHhmm6());
			}
			if(!StringUtils.isEmpty(request.getResPmEndHhmm7())) {
				res0102.setResPmEndHhmm7(request.getResPmEndHhmm7());
			}
			//
			if(!StringUtils.isEmpty(request.getDocResLimit())) {
				res0102.setDocResLimit(CommonUtils.parseDouble(request.getDocResLimit()));
			}
			if(!StringUtils.isEmpty(request.getEtcResLimit())) {
				res0102.setEtcResLimit(CommonUtils.parseDouble(request.getEtcResLimit()));
			}
			res0102Repository.save(res0102);
			return true;
	    }
	
	}
