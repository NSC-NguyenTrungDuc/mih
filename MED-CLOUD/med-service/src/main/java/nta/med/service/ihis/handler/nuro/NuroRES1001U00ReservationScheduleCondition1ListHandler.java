package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0103Repository;
import nta.med.data.model.ihis.nuro.NuroRES1001U00ReservationScheduleConditionListItemInfo;
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
public class NuroRES1001U00ReservationScheduleCondition1ListHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00ReservationScheduleCondition1ListRequest, NuroServiceProto.NuroRES1001U00ReservationScheduleConditionListResponse> {
	private static final Log LOG = LogFactory.getLog(NuroRES1001U00ReservationScheduleCondition1ListHandler.class);
	@Resource
	private Res0103Repository res0103Repository;

    @Override
	public boolean isValid(NuroServiceProto.NuroRES1001U00ReservationScheduleCondition1ListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getExamPreDate()) && DateUtil.toDate(request.getExamPreDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES1001U00ReservationScheduleConditionListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00ReservationScheduleCondition1ListRequest request) throws Exception {
		NuroServiceProto.NuroRES1001U00ReservationScheduleConditionListResponse.Builder response = NuroServiceProto.NuroRES1001U00ReservationScheduleConditionListResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = request.getHospCodeLink();
		}
		List<NuroRES1001U00ReservationScheduleConditionListItemInfo> listObject = res0103Repository.getReservationScheduleConditionListItemInfo(hospCode, request.getDoctorCode(), request.getExamPreDate());
        if (listObject != null && !listObject.isEmpty()) {
        	 for (NuroRES1001U00ReservationScheduleConditionListItemInfo item : listObject) {
             	NuroModelProto.NuroRES1001U00ReservationScheduleConditionListItemInfo.Builder info = NuroModelProto.NuroRES1001U00ReservationScheduleConditionListItemInfo.newBuilder();
             	if(!StringUtils.isEmpty(item.getAmStartTime()))  {
             		info.setAmStartTime(item.getAmStartTime());
             	}
             	if(!StringUtils.isEmpty(item.getAmEndTime()))  {
             		info.setAmEndTime(item.getAmEndTime());
             	}
             	if(!StringUtils.isEmpty(item.getPmStartTime()))  {
             		info.setPmStartTime(item.getPmStartTime());
             	}
             	if(!StringUtils.isEmpty(item.getPmEndTime()))  {
             		info.setPmEndTime(item.getPmEndTime());
             	}
             	response.addResScheduleListItem(info);
             }
        }
		return response.build();
	}
}
