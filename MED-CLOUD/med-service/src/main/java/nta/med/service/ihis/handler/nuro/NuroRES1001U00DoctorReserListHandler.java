package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.NuroRES1001U00DoctorReserListItemInfo;
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
public class NuroRES1001U00DoctorReserListHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00DoctorReserListRequest, NuroServiceProto.NuroRES1001U00DoctorReserListResponse> {
	private static final Log LOG = LogFactory.getLog(NuroRES1001U00DoctorReserListHandler.class);
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES1001U00DoctorReserListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00DoctorReserListRequest request) throws Exception {
		NuroServiceProto.NuroRES1001U00DoctorReserListResponse.Builder response = NuroServiceProto.NuroRES1001U00DoctorReserListResponse.newBuilder();
		String sessionHospCode = getHospitalCode(vertx, sessionId);
		String hospCode = getHospitalCode(vertx, sessionId);
		boolean isOtherClinic = false;
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = request.getHospCodeLink();
			isOtherClinic = true;
		}
		List<NuroRES1001U00DoctorReserListItemInfo> listObject = out1001Repository.getNuroRES1001U00DoctorReserListItemInfo(hospCode, sessionHospCode, getLanguage(vertx, sessionId),
				request.getPatientCode(), isOtherClinic, request.getTabIsAll());
        if (listObject != null && !listObject.isEmpty()) {
        	 for (NuroRES1001U00DoctorReserListItemInfo item : listObject) {
             	NuroModelProto.NuroRES1001U00DoctorReserListItemInfo.Builder info = NuroModelProto.NuroRES1001U00DoctorReserListItemInfo.newBuilder();
             	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
             	response.addDoctorReserListItem(info);
             }
        }
		return response.build();
	}
}
