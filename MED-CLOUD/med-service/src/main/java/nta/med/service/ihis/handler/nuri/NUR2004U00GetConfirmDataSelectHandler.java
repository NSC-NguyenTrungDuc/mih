package nta.med.service.ihis.handler.nuri;

import java.util.List;

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
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00GetConfirmDataSelectRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00GetConfirmDataSelectResponse;

@Service
@Scope("prototype")
public class NUR2004U00GetConfirmDataSelectHandler extends
		ScreenHandler<NuriServiceProto.NUR2004U00GetConfirmDataSelectRequest, NuriServiceProto.NUR2004U00GetConfirmDataSelectResponse> {

	@Resource
	private Inp2004Repository inp2004Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR2004U00GetConfirmDataSelectResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00GetConfirmDataSelectRequest request) throws Exception {
		NuriServiceProto.NUR2004U00GetConfirmDataSelectResponse.Builder response = NuriServiceProto.NUR2004U00GetConfirmDataSelectResponse.newBuilder();
		
		List<Inp2004> inps = inp2004Repository.findByHospCodeFkinp1001TransCnt(getHospitalCode(vertx, sessionId),
				CommonUtils.parseDouble(request.getFkinp1001()), CommonUtils.parseDouble(request.getTransCnt()));
		
		for (Inp2004 item : inps) {
			NuriModelProto.NUR2004U00GetConfirmDataSelectInfo.Builder info = NuriModelProto.NUR2004U00GetConfirmDataSelectInfo.newBuilder();
			info.setBunho(item.getBunho());
			info.setStartDate(item.getStartDate() == null ? "" : DateUtil.toString(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
			info.setTransTime(item.getTransTime() == null ? "" : item.getTransTime());
			info.setToGwa(item.getToGwa() == null ? "" : item.getToGwa());
			info.setToDoctor(item.getToDoctor() == null ? "" : item.getToDoctor());
			info.setToResident(item.getToResident() == null ? "" : item.getToResident());
			info.setToHoCode1(item.getToHoCode1() == null ? "" : item.getToHoCode1());
			info.setToHoDong1(item.getToHoDong1() == null ? "" : item.getToHoDong1());
			info.setToHoCode2(item.getToHoCode2() == null ? "" : item.getToHoCode2());
			info.setToHoDong2(item.getToHoDong2() == null ? "" : item.getToHoDong2());
			info.setTransGubun(item.getTransGubun() == null ? "" : item.getTransGubun());
			info.setToBedNo(item.getToBedNo() == null ? "" : item.getToBedNo());
			info.setToBedNo2(item.getToBedNo2() == null ? "" : item.getToBedNo2());
			info.setFromHoCode1(item.getFromHoCode1() == null ? "" : item.getFromHoCode1());
			info.setFromHoDong1(item.getFromHoDong1() == null ? "" : item.getFromHoDong1());
			info.setFromBedNo(item.getFromBedNo() == null ? "" : item.getFromBedNo());
			info.setToHoGrade1(item.getToHoGrade1() == null ? "" : item.getToHoGrade1());
			info.setToHoGrade2(item.getToHoGrade2() == null ? "" : item.getToHoGrade2());
			info.setToKaikeiHodong(item.getToKaikeiHodong() == null ? "" : item.getToKaikeiHodong());
			info.setToKaikeiHocode(item.getToKaikeiHocode() == null ? "" : item.getToKaikeiHocode());
			info.setFkinp1001(String.format("%.0f",item.getFkinp1001()));
			
			response.addListDtconfirm(info);
		}
		
		return response.build();
	}
	
}
