package nta.med.service.ihis.handler.nuri;

import java.math.BigDecimal;
import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.nur.Nur7001;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur7001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriServiceProto;
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
public class NuriNUR7001U00InsertNUR7001Handler extends ScreenHandler<NuriServiceProto.NuriNUR7001U00InsertNUR7001NewRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(NuriNUR7001U00InsertNUR7001Handler.class);
	@Resource
	private Nur7001Repository nur7001Repository;
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NuriNUR7001U00InsertNUR7001NewRequest request) throws Exception {
		 SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		 Integer result = insertNUR7001(request, getHospitalCode(vertx, sessionId));
		 response.setResult(result != null && result > 0);
		 return response.build();
	}
	
	private Integer insertNUR7001(NuriServiceProto.NuriNUR7001U00InsertNUR7001NewRequest request, String hospCode) {
			Double pkSeq = CommonUtils.parseDouble(nur7001Repository.getNuriNUR7001U00GetMaxSeqInNUR7001(hospCode, request.getBunho(), request.getMeasureDate()));
    		if(pkSeq == null || pkSeq.equals(new Double(0))){
    			pkSeq = new  Double(1);
    		}
			Nur7001 nur7001 = new Nur7001();
			nur7001.setSysDate(new Date());
			nur7001.setSysId(request.getUserId());
			nur7001.setUpdId(request.getUserId());
			nur7001.setHospCode(hospCode);
			nur7001.setUpdDate(new Date());
			nur7001.setBunho(request.getBunho());
			nur7001.setMeasureDate(DateUtil.toDate(request.getMeasureDate(), DateUtil.PATTERN_YYMMDD));
			nur7001.setSeq(pkSeq);
			nur7001.setVald("Y");
			nur7001.setHeight(StringUtils.isEmpty(request.getHeight()) ? null : new Double(request.getHeight()));
			nur7001.setWeight(StringUtils.isEmpty(request.getWeight()) ? null : new Double(request.getWeight()));
			nur7001.setBpFrom(StringUtils.isEmpty(request.getBpFrom()) ? null : new Double(request.getBpFrom()));
			nur7001.setBpTo(StringUtils.isEmpty(request.getBpFrom()) ? null : new Double(request.getBpFrom()));
			nur7001.setBodyHeat(StringUtils.isEmpty(request.getBodyHeat()) ? null : new Double(request.getBodyHeat()));
			nur7001.setPulse(StringUtils.isEmpty(request.getPulse()) ? null : new BigDecimal(request.getPulse()));
			nur7001.setSpo2(StringUtils.isEmpty(request.getSpo2()) ? null : new Double(request.getSpo2()));
			nur7001.setMeasureTime(request.getMeasureTime());
			nur7001.setBreath(StringUtils.isEmpty(request.getBreath()) ? null : new Double(request.getBreath()));
			nur7001Repository.save(nur7001);
			return 1;
	}
}
