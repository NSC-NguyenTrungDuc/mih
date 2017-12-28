package nta.med.service.ihis.handler.nuri;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.domain.inp.Inp2004;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;

import org.apache.commons.lang3.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1010Q00ChangeHosilInsertHandler extends ScreenHandler<NuriServiceProto.NUR1010Q00ChangeHosilInsertRequest, SystemServiceProto.UpdateResponse> {   
	
	@Resource                                   
	private Inp2004Repository inp2004Repository;

	@Override
	@Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00ChangeHosilInsertRequest request) throws Exception {
				
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		
		insertInp2004(hospCode, userId, CommonUtils.parseDouble(request.getFromFkinp1001()), request.getFromBunho(), request.getTransCnt(), request.getJunpyoDate(),
				request.getToGwa(), request.getToDoctor(), request.getToResident(), request.getToHoCode1(), request.getToHoCode2(), request.getToHoDong1(),
				request.getToHoDong2(), request.getToBedNo(), request.getToBedNo2());
		
		response.setResult(true);
		
		return response.build();
	}
	
	private void insertInp2004(String hospCode, String userId, Double formFkinp1001, String fromBunho, String transCnt, String junpyoDate, String toGwa, String toDoctor,
			String toResident, String toHoCode1, String hoHoCode2, String toHoDong1, String toHoDong2, String toBedNo, String toBedNo2){
		Inp2004 inp2004 = new Inp2004();
		
		inp2004.setSysDate(new Date());
		inp2004.setSysId(userId);
		inp2004.setUpdDate(new Date());
		inp2004.setUpdId(userId);
		inp2004.setHospCode(hospCode);
		inp2004.setFkinp1001(formFkinp1001);
		inp2004.setBunho(fromBunho);
		if(StringUtils.isEmpty(transCnt) || transCnt == ""){
			transCnt = "1";
		}
		inp2004.setTransCnt(CommonUtils.parseDouble(transCnt));
		inp2004.setTransTime(DateUtil.getCurrentDateTime(DateUtil.PATTERN_HHMM));
		if(!StringUtils.isEmpty(junpyoDate) && junpyoDate != ""){
			inp2004.setStartDate(DateUtil.toDate(junpyoDate, DateUtil.PATTERN_YYMMDD));
			inp2004.setTonggyeDate(DateUtil.toDate(junpyoDate, DateUtil.PATTERN_YYMMDD));
		}
		inp2004.setFromGwa(StringUtils.trim(toGwa));
		inp2004.setToGwa(StringUtils.trim(toGwa));
		inp2004.setFromDoctor(toDoctor);
		inp2004.setToDoctor(toDoctor);
		inp2004.setFromResident(toResident);
		inp2004.setToResident(toResident);
		inp2004.setCancelSayu(null);
		inp2004.setFromHoCode1(hoHoCode2);
		inp2004.setFromHoDong1(toHoDong2);
		inp2004.setToHoCode1(toHoCode1);
		inp2004.setToHoDong1(toHoDong1);
		inp2004.setCancelYn("N");
		inp2004.setEndDate(DateUtil.toDate("9999/12/31", DateUtil.PATTERN_YYMMDD));
		inp2004.setToNurseConfirmId(userId);
		inp2004.setToNurseConfirmDate(new Date());
		inp2004.setTransGubun("03");
		inp2004.setFromBedNo(toBedNo2);
		inp2004.setToBedNo(toBedNo);
		inp2004.setToNurseConfirmTime(DateUtil.getCurrentDateTime(DateUtil.PATTERN_HHMM));
		
		inp2004Repository.save(inp2004);
		
	}
}
