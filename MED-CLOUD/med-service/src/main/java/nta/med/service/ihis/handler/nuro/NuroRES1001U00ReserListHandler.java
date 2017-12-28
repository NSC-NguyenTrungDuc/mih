package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.NuroRES1001U00ReserListItemInfo;
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
public class NuroRES1001U00ReserListHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00ReserListRequest, NuroServiceProto.NuroRES1001U00ReserListResponse> {
	private static final Log LOG = LogFactory.getLog(NuroRES1001U00ReserListHandler.class);
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES1001U00ReserListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00ReserListRequest request) throws Exception {
		NuroServiceProto.NuroRES1001U00ReserListResponse.Builder response = NuroServiceProto.NuroRES1001U00ReserListResponse.newBuilder();
		String sessionHospCode = getHospitalCode(vertx, sessionId);
		String hospCode = getHospitalCode(vertx, sessionId);
		boolean isOtherClinic = false;
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = request.getHospCodeLink();
			isOtherClinic = true;
		}
		List<NuroRES1001U00ReserListItemInfo> listObject = out1001Repository.getNuroRES1001U00ReserListItemInfo(hospCode, sessionHospCode, getLanguage(vertx, sessionId), request.getPatientCode(), isOtherClinic);
        if (listObject != null && !listObject.isEmpty()) {
        	 for (NuroRES1001U00ReserListItemInfo item : listObject) {
             	NuroModelProto.NuroRES1001U00ReserListItemInfo.Builder info = NuroModelProto.NuroRES1001U00ReserListItemInfo.newBuilder();
             	if(item.getComingDate() != null)  {
             		info.setComingDate(DateUtil.toString(item.getComingDate(), DateUtil.PATTERN_YYMMDD));
             	}
             	if(!StringUtils.isEmpty(item.getExamPreTime()))  {
             		info.setExamPreTime(item.getExamPreTime());
             	}
             	if(!StringUtils.isEmpty(item.getDepartmentName()))  {
             		info.setDepartmentName(item.getDepartmentName());
             	}
             	if(!StringUtils.isEmpty(item.getDoctorName()))  {
             		info.setDoctorName(item.getDoctorName());
             	}
             	response.addReserListItem(info);
             }
        }
		return response.build();
	}
}
