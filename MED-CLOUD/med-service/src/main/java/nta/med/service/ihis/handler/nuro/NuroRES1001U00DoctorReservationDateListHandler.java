package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0105Repository;
import nta.med.data.model.ihis.nuro.NuroRES1001U00DoctorReservationDateListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroRES1001U00DoctorReservationDateListHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00DoctorReservationDateListRequest, NuroServiceProto.NuroRES1001U00DoctorReservationDateListResponse> {
	private static final Log LOG = LogFactory.getLog(NuroRES1001U00DoctorReservationDateListHandler.class);
	@Resource
	private Res0105Repository res0105Repository;

    @Override
	public boolean isValid(NuroServiceProto.NuroRES1001U00DoctorReservationDateListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}else if(!StringUtils.isEmpty(request.getEndDate()) && DateUtil.toDate(request.getEndDate(), DateUtil.PATTERN_YYMMDD) == null){
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES1001U00DoctorReservationDateListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00DoctorReservationDateListRequest request) throws Exception {
		NuroServiceProto.NuroRES1001U00DoctorReservationDateListResponse.Builder response = NuroServiceProto.NuroRES1001U00DoctorReservationDateListResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = request.getHospCodeLink();
		}
		List<NuroRES1001U00DoctorReservationDateListItemInfo> listObject = 
         		res0105Repository.getNuroRES1001U00DoctorReservationDateList(hospCode, request.getDoctorCode(), request.getStartDate(), request.getEndDate());
         if (!CollectionUtils.isEmpty(listObject)) {
         	 for (NuroRES1001U00DoctorReservationDateListItemInfo item : listObject) {
              	NuroModelProto.NuroRES1001U00DoctorReservationDateListItemInfo.Builder info = NuroModelProto.NuroRES1001U00DoctorReservationDateListItemInfo.newBuilder();
              	if(!StringUtils.isEmpty(item.getDoctorCode()))  {
              		info.setDoctorCode(item.getDoctorCode());
              	}
              	if(!StringUtils.isEmpty(item.getDate()))  {
              		info.setDate(item.getDate());
              	}
              	if(item.getResDate() != null)  {
              		info.setResDate(DateUtil.toString(item.getResDate(), DateUtil.PATTERN_YYMMDD));
              	}
              	if(!StringUtils.isEmpty(item.getResFlag()))  {
              		info.setResFlag(item.getResFlag());
              	}
              	if(!StringUtils.isEmpty(item.getResInwon()))  {
              		info.setResInwon(item.getResInwon());
              	}
              	if(!StringUtils.isEmpty(item.getResOutwon()))  {
              		info.setResOutwon(item.getResOutwon());
              	}
              	response.addDoctorResDateListItem(info);
              }
         }
		return response.build();
	}
}
