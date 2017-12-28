package nta.med.service.ihis.handler.nuri;

import java.util.Date;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.inp.Inp2004;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00ProcessInsertRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR2004U00ProcessInsertHandler
		extends ScreenHandler<NuriServiceProto.NUR2004U00ProcessInsertRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Inp2004Repository inp2004Repository;

	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00ProcessInsertRequest request) throws Exception {

		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();

		String hospCode = getHospitalCode(vertx, sessionId);
		
		String userId = request.getUserId();
		String fkinp1001 = request.getFkinp1001();
		String bunho = request.getBunho();
		String transCnt = request.getTransCnt();
		String orderDate = request.getOrderDate();
		String fromGwa = request.getFromGwa();
		String toGwa = request.getToGwa();
		String fromDoctor = request.getFromDoctor();
		String toDoctor = request.getToDoctor();
		String fromResident = request.getFromResident();
		String toResident = request.getToResident();
		String fromHoCode1 = request.getFromHoCode1();
		String fromHoDong1 = request.getFromHoDong1();
		String toHoCode1 = request.getToHoCode1();
		String toHoDong1 = request.getToHoDong1();
		String fromHoCode2 = request.getFromHoCode2();
		String fromHoDong2 = request.getFromHoDong2();
		
		Inp2004 inp2004 = new Inp2004();
		inp2004.setSysDate(new Date());
		inp2004.setSysId(userId);
		inp2004.setUpdDate(new Date());
		inp2004.setUpdId(userId);
		inp2004.setHospCode(hospCode);
		inp2004.setFkinp1001(CommonUtils.parseDouble(fkinp1001));
		inp2004.setBunho(bunho);
		inp2004.setTransCnt(CommonUtils.parseDouble(transCnt));
		//inp2004.setTransTime(DateUtil.toDate(new Date().toString(), DateUtil.PATTERN_HHMM).toString());
		inp2004.setTransTime(DateUtil.toString(new Date(), DateUtil.PATTERN_HHMM));
		inp2004.setStartDate(DateUtil.toDate(orderDate, DateUtil.PATTERN_YYMMDD));
		inp2004.setTonggyeDate(new Date());
		inp2004.setFromGwa(fromGwa.trim());
		inp2004.setToGwa(toGwa.trim());
		inp2004.setFromDoctor(fromDoctor);
		inp2004.setToDoctor(toDoctor);
		inp2004.setFromResident(fromResident);
		inp2004.setToResident(toResident);
		inp2004.setCancelSayu("");
		inp2004.setFromHoCode1(fromHoCode1);
		inp2004.setFromHoDong1(fromHoDong1);
		inp2004.setToHoCode1(toHoCode1);
		inp2004.setToHoDong1(toHoDong1);
		inp2004.setFromHoCode2(fromHoCode2);
		inp2004.setFromHoDong2(fromHoDong2);
		
		String toHoCode2 = request.getToHoCode2();
		String toHoDong2 = request.getToHoCode2();
		String transGubun = request.getTransGubun();
		String fromBedNo = request.getFromBedNo();
		String toBedNo = request.getToBedNo();
		String toBedNo2 = request.getToBedNo2();
		String toHoGrade1 = request.getToHoGrade1();
		String fromKaikeiHodong = request.getFromKaikeiHodong();
		String fromKaikeiHocode = request.getFromKaikeiHocode();
		String toKaikeiHodong = request.getToKaikeiHodong();
		String toKaikeiHocode = request.getToKaikeiHocode();
		
		inp2004.setToHoCode2(toHoCode2);
		inp2004.setToHoDong2(toHoDong2);
		inp2004.setCancelYn("N");
		inp2004.setTransGubun(transGubun);
		inp2004.setToNurseConfirmId("");
		inp2004.setToNurseConfirmDate(null);
		inp2004.setToNurseConfirmTime(null);
		inp2004.setFromBedNo(fromBedNo);
		inp2004.setToBedNo(toBedNo);
		inp2004.setFromBedNo(fromBedNo);
		inp2004.setToBedNo2(toBedNo2);
		inp2004.setEndDate(DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD));
		inp2004.setToHoGrade1(toHoGrade1);
		inp2004.setToHoGrade2(toHoGrade1);
		inp2004.setFromKaikeiHodong(fromKaikeiHodong);
		inp2004.setFromKaikeiHocode(fromKaikeiHocode);
		inp2004.setToKaikeiHocode(toKaikeiHocode);
		inp2004.setToKaikeiHodong(toKaikeiHodong);
		
		inp2004Repository.save(inp2004);
		
		response.setResult(true);
		return response.build();
	}
}
