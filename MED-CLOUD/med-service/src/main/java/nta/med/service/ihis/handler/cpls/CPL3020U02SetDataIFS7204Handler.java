/**
 * 
 */
package nta.med.service.ihis.handler.cpls;

import java.util.Calendar;
import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.ifs.Ifs7204;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ifs.Ifs7204Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02SetDataIFS7204Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.lang.time.DateUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CPL3020U02SetDataIFS7204Handler extends
				ScreenHandler<CplsServiceProto.CPL3020U02SetDataIFS7204Request, SystemServiceProto.UpdateResponse> {
	
	@Resource
	private Ifs7204Repository ifs7204Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3020U02SetDataIFS7204Request request) throws Exception {
		// TODO Auto-generated method stub
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		boolean save = false;
		Double pkifs7204 = CommonUtils.parseDouble(commonRepository.getNextVal("IFS7204_SEQ"));
		Double fkifs7203 = CommonUtils.parseDouble(request.getFk());
		save = insertIfs7204(getHospitalCode(vertx, sessionId), pkifs7204, 
				request.getRecordGubun(), request.getSentaCode(), 
				request.getIraiKey(), request.getHangmogCode(), 
				request.getResultCode(), request.getSpecimenSer(), 
				request.getResultVal(), request.getDanui(), 
				request.getFromStandard(), request.getToStandard(), request.getEmergency(), request.getYobi1(), 
				fkifs7203);
		response.setMsg(pkifs7204.toString());
		response.setResult(save);
		return response.build();
	}
	
	private boolean insertIfs7204(String hospCode, Double pkifs7204,
			String recordGubun, String sentaCode,
			String iraiKey, String hangmogCode, 
			String resultCode, String specimenSer,
			String resultVal, String danui,
			String fromStandard, String toStandard, String emergency, String yobi1,
			Double fkifs7203){
		
		Ifs7204 ifs7204 = new Ifs7204();
		Date sysdate = new Date();
		
		ifs7204.setSysDate(sysdate);
		ifs7204.setSysId("IF");
		ifs7204.setHospCode(hospCode);
		ifs7204.setPkifs7204(pkifs7204);
		ifs7204.setRecordGubun(recordGubun);
		ifs7204.setSentaCode(sentaCode);
		ifs7204.setIraiKey(iraiKey);
		ifs7204.setHangmogCode(hangmogCode);
		ifs7204.setResultCode(resultCode);
		ifs7204.setSpecimenSer(specimenSer);
		ifs7204.setResultVal(resultVal);
		ifs7204.setDanui(danui);
		ifs7204.setFromStandard(fromStandard);
		ifs7204.setToStandard(toStandard);
		ifs7204.setEmergency(emergency);
		ifs7204.setYobi1(yobi1);
		ifs7204.setFkifs7203(fkifs7203);
		ifs7204.setIfDate(DateUtils.truncate(sysdate, Calendar.DATE));
		ifs7204.setIfTime(DateUtil.toString(sysdate, DateUtil.PATTERN_HHMMSS));
		ifs7204.setIfFlag("10");
		ifs7204.setIfErr(null);
		ifs7204Repository.save(ifs7204);
		return true;
	}

}