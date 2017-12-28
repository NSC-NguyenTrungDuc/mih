package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
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
public class NuroNUR1001R00GetGwaDoctorTempListHandler extends ScreenHandler<NuroServiceProto.NuroNUR1001R00GetGwaDoctorTempListRequest, NuroServiceProto.NuroNUR1001R00GetGwaDoctorTempListResponse> {
	private static final Log logger = LogFactory.getLog(NuroNUR1001R00GetGwaDoctorTempListHandler.class);

	@Resource
	private Bas0270Repository bas0270Repository;
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroNUR1001R00GetGwaDoctorTempListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroNUR1001R00GetGwaDoctorTempListRequest request) throws Exception {
		NuroServiceProto.NuroNUR1001R00GetGwaDoctorTempListResponse.Builder response = NuroServiceProto.NuroNUR1001R00GetGwaDoctorTempListResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		List<ComboListItemInfo> listCboAvgTime = bas0270Repository.getNuroNUR1001R00GetGwaDoctorList(hospCode, request.getGwa(), request.getMonth());
		if (listCboAvgTime != null && !listCboAvgTime.isEmpty()) {
			for (ComboListItemInfo obj : listCboAvgTime) {
				List<NuroNUR1001R00GetTempListItemInfo> listItem = out1001Repository.getNuroNUR1001R00GetTempListItem(hospCode, obj.getCodeName()
						, request.getMonth(), request.getGwa(), obj.getCode());
				if (listItem != null && !listItem.isEmpty()) {
					for (NuroNUR1001R00GetTempListItemInfo item : listItem) {
						NuroModelProto.NuroNUR1001R00GetTempListItemInfo.Builder builder = NuroModelProto.NuroNUR1001R00GetTempListItemInfo.newBuilder();
						
						if (!StringUtils.isEmpty(item.getDoctorName())) {
							builder.setDoctorName(item.getDoctorName());
						}
						if (item.getNum1() != null) {
							builder.setNum1(item.getNum1().toString());
						}
						if (item.getNum2() != null) {
							builder.setNum2(item.getNum2().toString());
						}
						if (item.getNum3() != null) {
							builder.setNum3(item.getNum3().toString());
						}
						if (item.getNum4() != null) {
							builder.setNum4(item.getNum4().toString());
						}
						if (item.getNum5() != null) {
							builder.setNum5(item.getNum5().toString());
						}
						if (item.getNum6() != null) {
							builder.setNum6(item.getNum6().toString());
						}
						if (item.getNum7() != null) {
							builder.setNum7(item.getNum7().toString());
						}
						if (item.getNum8() != null) {
							builder.setNum8(item.getNum8().toString());
						}
						if (item.getNum9() != null) {
							builder.setNum9(item.getNum9().toString());
						}
						if (item.getNum10() != null) {
							builder.setNum10(item.getNum10().toString());
						}
						if (item.getNum11() != null) {
							builder.setNum11(item.getNum11().toString());
						}
						if (item.getNum12() != null) {
							builder.setNum12(item.getNum12().toString());
						}
						if (item.getNum13() != null) {
							builder.setNum13(item.getNum13().toString());
						}
						if (item.getNum14() != null) {
							builder.setNum14(item.getNum14().toString());
						}
						if (item.getNum15() != null) {
							builder.setNum15(item.getNum15().toString());
						}
						if (item.getNum16() != null) {
							builder.setNum16(item.getNum16().toString());
						}
						if (item.getNum17() != null) {
							builder.setNum17(item.getNum17().toString());
						}
						if (item.getNum18() != null) {
							builder.setNum18(item.getNum18().toString());
						}
						if (item.getNum19() != null) {
							builder.setNum19(item.getNum19().toString());
						}
						if (item.getNum20() != null) {
							builder.setNum20(item.getNum20().toString());
						}
						if (item.getNum21() != null) {
							builder.setNum21(item.getNum21().toString());
						}
						if (item.getNum22() != null) {
							builder.setNum22(item.getNum22().toString());
						}
						if (item.getNum23() != null) {
							builder.setNum23(item.getNum23().toString());
						}
						if (item.getNum24() != null) {
							builder.setNum24(item.getNum24().toString());
						}
						if (item.getNum25() != null) {
							builder.setNum25(item.getNum25().toString());
						}
						if (item.getNum26() != null) {
							builder.setNum26(item.getNum26().toString());
						}
						if (item.getNum27() != null) {
							builder.setNum27(item.getNum27().toString());
						}
						if (item.getNum28() != null) {
							builder.setNum28(item.getNum28().toString());
						}
						if (item.getNum29() != null) {
							builder.setNum29(item.getNum29().toString());
						}
						if (item.getNum30() != null) {
							builder.setNum30(item.getNum30().toString());
						}
						if (item.getNum31() != null) {
							builder.setNum31(item.getNum31().toString());
						}
						if (!StringUtils.isEmpty(item.getLastDay())) {
							builder.setLastDay(item.getLastDay());
						}

						response.addTemItem(builder);
					}
				}
			}
		}
		return response.build();
	}
}
