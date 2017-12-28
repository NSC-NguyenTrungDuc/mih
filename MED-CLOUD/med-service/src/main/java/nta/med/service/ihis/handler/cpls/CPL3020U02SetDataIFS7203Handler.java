/**
 * 
 */
package nta.med.service.ihis.handler.cpls;

import java.util.Calendar;
import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.ifs.Ifs7203;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ifs.Ifs7203Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02SetDataIFS7203Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.lang.time.DateUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CPL3020U02SetDataIFS7203Handler extends
				ScreenHandler<CplsServiceProto.CPL3020U02SetDataIFS7203Request, SystemServiceProto.UpdateResponse> {
	
	@Resource
	private Ifs7203Repository ifs7203Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3020U02SetDataIFS7203Request request) throws Exception {
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		boolean save = false;
		Double pkifs7203 = CommonUtils.parseDouble(commonRepository.getNextVal("IFS7203_SEQ"));
		
		save = insertIfs7203(getHospitalCode(vertx, sessionId),
				pkifs7203, request.getRecordGubun(), request.getSentaCode(), 
				request.getIraiKey(), request.getKaruteNo(), request.getKanjamei(), 
				request.getKoumokusuu(), request.getHoukokubi(), request.getYobi1(), request.getYobi2());
		response.setMsg(pkifs7203.toString());
		response.setResult(save);
		return response.build();
	}
	
	private boolean insertIfs7203(String hospCode, Double pkifs7203,
			String recordGubun, String sentaCode,
			String iraiKey, String karuteNo,
			String kanjamei, String koumokusuu,
			String houkokubi, String yobi1, String yobi2){
                
		Ifs7203 ifs7203 = new Ifs7203();
		Date sysdate = new Date();
		
		ifs7203.setSysDate(sysdate);
		ifs7203.setSysId("IF");
		ifs7203.setHospCode(hospCode);
		ifs7203.setPkifs7203(pkifs7203);
		ifs7203.setRecordGubun(recordGubun);
		ifs7203.setSentaCode(sentaCode);
		ifs7203.setIraiKey(iraiKey);
		ifs7203.setKaruteNo(karuteNo);
		ifs7203.setKanjamei(kanjamei);
		ifs7203.setKoumokusuu(koumokusuu);
		ifs7203.setHoukokubi(houkokubi);
		ifs7203.setYobi1(yobi1);
		ifs7203.setYobi2(yobi2);
		ifs7203.setIfDate(DateUtils.truncate(sysdate, Calendar.DATE));
		ifs7203.setIfTime(DateUtil.toString(sysdate, DateUtil.PATTERN_HHMMSS));
		ifs7203.setIfFlag("10");
		ifs7203.setIfErr(null);
		ifs7203Repository.save(ifs7203);
		return true;
	}

}