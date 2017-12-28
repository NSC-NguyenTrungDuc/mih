package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.nuro.NuroRES1001U00DoctorReservationStatusListItemInfo;
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
public class NuroRES1001U00DoctorReservationStatusListHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00DoctorReservationStatusListRequest, NuroServiceProto.NuroRES1001U00DoctorReservationStatusListResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroRES1001U00DoctorReservationStatusListHandler.class);
	@Resource
	private Bas0270Repository bas0270Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES1001U00DoctorReservationStatusListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00DoctorReservationStatusListRequest request) throws Exception {
		NuroServiceProto.NuroRES1001U00DoctorReservationStatusListResponse.Builder response = NuroServiceProto.NuroRES1001U00DoctorReservationStatusListResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		boolean isOtherClinic = false;
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = request.getHospCodeLink();
			isOtherClinic = true;
		}
		List<NuroRES1001U00DoctorReservationStatusListItemInfo> listObject = bas0270Repository.getDoctorReservationStatusList(hospCode, request.getDepartmentCode(), request.getDoctorCode(), isOtherClinic);
        if (listObject != null && !listObject.isEmpty()) {
            for (NuroRES1001U00DoctorReservationStatusListItemInfo item : listObject) {
            	NuroModelProto.NuroRES1001U00DoctorReservationStatusListItemInfo.Builder info = NuroModelProto.NuroRES1001U00DoctorReservationStatusListItemInfo.newBuilder();
            	if(!StringUtils.isEmpty(item.getDoctorName()))  {
            		info.setDoctorName(item.getDoctorName());
            	}
            	if(!StringUtils.isEmpty(item.getReservationStatus()))  {
            		info.setReservationStatus(item.getReservationStatus());
            	}
            	response.addDoctorResStatusListItem(info);
            }
        }
		return response.build();
	}
}
