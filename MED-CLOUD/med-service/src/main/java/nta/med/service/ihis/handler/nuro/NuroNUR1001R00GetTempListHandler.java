package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.NuroNUR1001R00GetTempListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroNUR1001R00GetTempListHandler extends ScreenHandler<NuroServiceProto.NuroNUR1001R00GetTempListRequest, NuroServiceProto.NuroNUR1001R00GetTempListResponse> {
	private static final Log logger = LogFactory.getLog(NuroNUR1001R00GetTempListHandler.class);

	@Resource
	private Out1001Repository out1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroNUR1001R00GetTempListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroNUR1001R00GetTempListRequest request) throws Exception {
		NuroServiceProto.NuroNUR1001R00GetTempListResponse.Builder response = NuroServiceProto.NuroNUR1001R00GetTempListResponse.newBuilder();
		List<NuroNUR1001R00GetTempListItemInfo> listCboAvgTime = out1001Repository.getNuroNUR1001R00GetTempListItem(getHospitalCode(vertx, sessionId), request.getDoctorName()
				, request.getMonth(), request.getGwa(), request.getDoctor());
		if (listCboAvgTime != null && !listCboAvgTime.isEmpty()) {
			for (NuroNUR1001R00GetTempListItemInfo obj : listCboAvgTime) {
				NuroModelProto.NuroNUR1001R00GetTempListItemInfo.Builder builder = NuroModelProto.NuroNUR1001R00GetTempListItemInfo.newBuilder();
				
				if (!StringUtils.isEmpty(obj.getDoctorName())) {
					builder.setDoctorName(obj.getDoctorName());
				}
				if (obj.getNum1() != null) {
					builder.setNum1(obj.getNum1().toString());
				}
				if (obj.getNum2() != null) {
					builder.setNum2(obj.getNum2().toString());
				}
				if (obj.getNum3() != null) {
					builder.setNum3(obj.getNum3().toString());
				}
				if (obj.getNum4() != null) {
					builder.setNum4(obj.getNum4().toString());
				}
				if (obj.getNum5() != null) {
					builder.setNum5(obj.getNum5().toString());
				}
				if (obj.getNum6() != null) {
					builder.setNum6(obj.getNum6().toString());
				}
				if (obj.getNum7() != null) {
					builder.setNum7(obj.getNum7().toString());
				}
				if (obj.getNum8() != null) {
					builder.setNum8(obj.getNum8().toString());
				}
				if (obj.getNum9() != null) {
					builder.setNum9(obj.getNum9().toString());
				}
				if (obj.getNum10() != null) {
					builder.setNum10(obj.getNum10().toString());
				}
				if (obj.getNum11() != null) {
					builder.setNum11(obj.getNum11().toString());
				}
				if (obj.getNum12() != null) {
					builder.setNum12(obj.getNum12().toString());
				}
				if (obj.getNum13() != null) {
					builder.setNum13(obj.getNum13().toString());
				}
				if (obj.getNum14() != null) {
					builder.setNum14(obj.getNum14().toString());
				}
				if (obj.getNum15() != null) {
					builder.setNum15(obj.getNum15().toString());
				}
				if (obj.getNum16() != null) {
					builder.setNum16(obj.getNum16().toString());
				}
				if (obj.getNum17() != null) {
					builder.setNum17(obj.getNum17().toString());
				}
				if (obj.getNum18() != null) {
					builder.setNum18(obj.getNum18().toString());
				}
				if (obj.getNum19() != null) {
					builder.setNum19(obj.getNum19().toString());
				}
				if (obj.getNum20() != null) {
					builder.setNum20(obj.getNum20().toString());
				}
				if (obj.getNum21() != null) {
					builder.setNum21(obj.getNum21().toString());
				}
				if (obj.getNum22() != null) {
					builder.setNum22(obj.getNum22().toString());
				}
				if (obj.getNum23() != null) {
					builder.setNum23(obj.getNum23().toString());
				}
				if (obj.getNum24() != null) {
					builder.setNum24(obj.getNum24().toString());
				}
				if (obj.getNum25() != null) {
					builder.setNum25(obj.getNum25().toString());
				}
				if (obj.getNum26() != null) {
					builder.setNum26(obj.getNum26().toString());
				}
				if (obj.getNum27() != null) {
					builder.setNum27(obj.getNum27().toString());
				}
				if (obj.getNum28() != null) {
					builder.setNum28(obj.getNum28().toString());
				}
				if (obj.getNum29() != null) {
					builder.setNum29(obj.getNum29().toString());
				}
				if (obj.getNum30() != null) {
					builder.setNum30(obj.getNum30().toString());
				}
				if (obj.getNum31() != null) {
					builder.setNum31(obj.getNum31().toString());
				}
				if (!StringUtils.isEmpty(obj.getLastDay())) {
					builder.setLastDay(obj.getLastDay());
				}

				response.addTemItem(builder);
			}
		}
		return response.build();
	}
}
