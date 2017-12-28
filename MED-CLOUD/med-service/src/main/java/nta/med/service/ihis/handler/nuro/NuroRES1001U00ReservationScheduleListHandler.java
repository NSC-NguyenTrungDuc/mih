package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0106Repository;
import nta.med.data.model.ihis.nuro.NuroRES1001U00ReservationScheduleListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.lang3.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroRES1001U00ReservationScheduleListHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00ReservationScheduleListRequest, NuroServiceProto.NuroRES1001U00ReservationScheduleListResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroRES1001U00ReservationScheduleListHandler.class);
	@Resource
	private Res0106Repository res0106Repository;

    @Override
	public boolean isValid(NuroServiceProto.NuroRES1001U00ReservationScheduleListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getExamPreDate()) && DateUtil.toDate(request.getExamPreDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES1001U00ReservationScheduleListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00ReservationScheduleListRequest request) throws Exception {
		NuroServiceProto.NuroRES1001U00ReservationScheduleListResponse.Builder response = NuroServiceProto.NuroRES1001U00ReservationScheduleListResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = getHospitalCode(vertx, sessionId);
		}
		List<NuroRES1001U00ReservationScheduleListItemInfo> listObject = res0106Repository.getReservationScheduleList(hospCode, request.getExamPreDate(), 
        		request.getDepartmentCode(), request.getDoctorCode(), request.getFromTime(), request.getToTime(), request.getAvgTime());
        if (listObject != null && !listObject.isEmpty()) {
            for (NuroRES1001U00ReservationScheduleListItemInfo  item : listObject) {
            	NuroModelProto.NuroRES1001U00ReservationScheduleListItemInfo.Builder info = NuroModelProto.NuroRES1001U00ReservationScheduleListItemInfo.newBuilder();
            	if (!StringUtils.isEmpty(item.getExamPreTime())) {
            		info.setExamPreTime(item.getExamPreTime());
            	}
            	if (!StringUtils.isEmpty(item.getPatientCode())) {
            		info.setPatientCode(item.getPatientCode());
            	}
            	if (!StringUtils.isEmpty(item.getPatientName1())) {
            		info.setPatientName1(item.getPatientName1());
            	}
            	if (!StringUtils.isEmpty(item.getPatientName2())) {
            		info.setPatientName2(item.getPatientName2());
            	}
            	if (!StringUtils.isEmpty(item.getExamStatus())) {
            		info.setExamStatus(item.getExamStatus());
            	}
            	if (!StringUtils.isEmpty(item.getReserDate())) {
            		info.setReserDate(item.getReserDate());
            	}
            	if (!StringUtils.isEmpty(item.getPkout1001())) {
            		info.setPkout1001(item.getPkout1001());
            	}
            	if (item.getExamPreDate() != null) {
            		info.setExamPreDate(DateUtil.toString(item.getExamPreDate(), DateUtil.PATTERN_YYMMDD));
            	}
            	if (!StringUtils.isEmpty(item.getDepartmentCode())) {
            		info.setDepartmentCode(item.getDepartmentCode());
            	}
            	if (!StringUtils.isEmpty(item.getReceptionNo())) {
            		info.setReceptionNo(item.getReceptionNo());
            	}
            	if (!StringUtils.isEmpty(item.getType())) {
            		info.setType(item.getType());
            	}
            	if (!StringUtils.isEmpty(item.getDoctorCode())) {
            		info.setDoctorCode(item.getDoctorCode());
            	}
            	if (!StringUtils.isEmpty(item.getResType())) {
            		info.setResType(item.getResType());
            	}
            	if (!StringUtils.isEmpty(item.getResChanggu())) {
            		info.setResChanggu(item.getResChanggu());
            	}
            	if (!StringUtils.isEmpty(item.getResInputType())) {
            		info.setResInputType(item.getResInputType());
            	}
            	if (!StringUtils.isEmpty(item.getComingStatus())) {
            		info.setComingStatus(item.getComingStatus());
            	}
            	if (!StringUtils.isEmpty(item.getNewRow())) {
            		info.setNewRow(item.getNewRow());
            	}
            	if (!StringUtils.isEmpty(item.getExamState())) {
            		info.setExamState(item.getExamState());
            	}
                response.addResScheduleListItem(info);
            }
        }
		return response.build();
	}
}
