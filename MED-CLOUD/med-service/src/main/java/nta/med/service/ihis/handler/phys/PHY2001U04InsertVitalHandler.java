package nta.med.service.ihis.handler.phys;

import java.math.BigDecimal;
import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.nur.Nur7001;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur7001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04InsertVitalRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class PHY2001U04InsertVitalHandler
	extends ScreenHandler<PhysServiceProto.PHY2001U04InsertVitalRequest, SystemServiceProto.UpdateResponse> {                     
	@Resource                                                                                                       
	private Nur7001Repository nur7001Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY2001U04InsertVitalRequest request) throws Exception {                                                                   
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	Integer result = null;
		String getMaxSeq = nur7001Repository.getNuriNUR7001U00GetMaxSeqInNUR7001(hospCode, request.getBunho(), request.getMeasureDate());
		insertNUR7001(request, getMaxSeq, hospCode);
		result = 1;
		response.setResult(result != null);
		return response.build();
	} 
	private void insertNUR7001(PhysServiceProto.PHY2001U04InsertVitalRequest request, String newSeq, String hospCode){
		Nur7001 nur7001 = new Nur7001();
		Date measureDate = DateUtil.toDate(request.getMeasureDate(), DateUtil.PATTERN_YYMMDD);
		String measureTime = DateUtil.getCurrentHH24MI();
		nur7001.setSysDate(new Date());
		nur7001.setSysId(request.getUserId());
		nur7001.setUpdId(request.getUserId());
		nur7001.setHospCode(hospCode);
		nur7001.setUpdDate(new Date());
		nur7001.setBunho(request.getBunho());
		nur7001.setMeasureDate(measureDate);
		nur7001.setSeq(CommonUtils.parseDouble(newSeq));
		nur7001.setVald("Y");
		//nur7001.setHeight(CommonUtils.parseDouble(request.get));
		//nur7001.setWeight(weight);
		nur7001.setBpFrom(CommonUtils.parseDouble(request.getBpFrom()));
		nur7001.setBpTo(CommonUtils.parseDouble(request.getBpTo()));
		//nur7001.setBodyHeat(bodyHeat);
		nur7001.setPulse(new BigDecimal(request.getPulse()));
		//nur7001.setSpo2(spo2);
		nur7001.setMeasureTime(measureTime);
		//nur7001.setBreath(breath);
		nur7001Repository.save(nur7001);
	}
}