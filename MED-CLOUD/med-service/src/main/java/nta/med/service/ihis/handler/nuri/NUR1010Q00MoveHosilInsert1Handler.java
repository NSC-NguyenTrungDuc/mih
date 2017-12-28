package nta.med.service.ihis.handler.nuri;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0250Repository;
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
public class NUR1010Q00MoveHosilInsert1Handler extends ScreenHandler<NuriServiceProto.NUR1010Q00MoveHosilInsert1Request, SystemServiceProto.UpdateResponse> {   
	
	@Resource                                   
	private Bas0250Repository bas0250Repository;
	
	@Resource                                   
	private Inp2004Repository inp2004Repository;

	@Override
	@Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00MoveHosilInsert1Request request) throws Exception {
				
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		
		String isExist = bas0250Repository.checkNUR1010Q00isExistBas2050(hospCode, request.getFromHoCode(), request.getFromHoDong());
		
		insertInp2004(hospCode, userId, request.getToHoCode(), request.getToHoDong(), CommonUtils.parseDouble(request.getFkinp1001()), request.getBunho(),
				request.getTransCnt(), request.getToGwa(), request.getToDoctor(), request.getToResident(), request.getFromHoCode(), request.getFromHoDong(),
				request.getFromBedNo(), request.getToBedNo(), request.getToHoGrade1(), request.getToHoGrade2(), request.getFromKaikeiHocode(),
				request.getFromKaikeiHodong(), request.getToKaikeiHocode(), request.getToKaikeiHodong(), isExist);
		response.setResult(true);
		
		return response.build();
	}
	
	private void insertInp2004(String hospCode, String userId, String toHoCode, String toHoDong, Double fkinp1001, String bunho, String transCnt, String toGwa,
			String toDoctor, String toResident, String fromHoCode, String fromHoDong, String fromBedNo, String toBedNo, String toHoGrade1, String toHoGrade2,
			String fromKaikeiHocode, String fromKaikeiHodong, String toKaikeiHocode, String toKaikeiHodong, String isExist){
		Inp2004 inp2004 = new Inp2004();
		
		inp2004.setSysDate(new Date());
		inp2004.setSysId(userId);
		inp2004.setUpdDate(new Date());
		inp2004.setUpdId(userId);
		inp2004.setHospCode(hospCode);
		inp2004.setFkinp1001(fkinp1001);
		inp2004.setBunho(bunho);
		if(StringUtils.isEmpty(transCnt) || transCnt == ""){
			transCnt = "1";
		}
		inp2004.setTransCnt(CommonUtils.parseDouble(transCnt));
		inp2004.setTransTime(DateUtil.getCurrentDateTime(DateUtil.PATTERN_HHMM));
		inp2004.setStartDate(new Date());
		inp2004.setTonggyeDate(new Date());
		inp2004.setFromGwa(toGwa);
		inp2004.setToGwa(toGwa);
		inp2004.setFromDoctor(toDoctor);
		inp2004.setToDoctor(toDoctor);
		inp2004.setFromResident(toResident);
		inp2004.setToResident(toResident);
		inp2004.setCancelSayu(null);
		inp2004.setFromHoCode1(fromHoCode);
		inp2004.setFromHoDong1(fromHoDong);
		inp2004.setToHoCode1(toHoCode);
		inp2004.setToHoDong1(toHoDong);
		if(isExist.equals("Y")){
			inp2004.setFromHoCode2(fromHoCode);
			inp2004.setFromHoDong2(fromHoDong);
			inp2004.setToHoCode2(toHoCode);
			inp2004.setToHoDong2(toHoDong);
		}
		inp2004.setCancelYn("N");
		inp2004.setEndDate(DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD));
		inp2004.setToNurseConfirmId(userId);
		inp2004.setToNurseConfirmDate(new Date());
		inp2004.setTransGubun("03");
		inp2004.setFromBedNo(fromBedNo);
		inp2004.setToBedNo(toBedNo);
		inp2004.setToNurseConfirmTime(DateUtil.getCurrentDateTime(DateUtil.PATTERN_HHMM));
		inp2004.setToHoGrade1(toHoGrade1);
		inp2004.setToHoGrade2(toHoGrade2);
		inp2004.setFromKaikeiHodong(fromKaikeiHodong);
		inp2004.setFromKaikeiHocode(fromKaikeiHocode);
		inp2004.setToKaikeiHodong(toKaikeiHodong);
		inp2004.setToKaikeiHocode(toKaikeiHocode);
		
		inp2004Repository.save(inp2004);
	}
}
