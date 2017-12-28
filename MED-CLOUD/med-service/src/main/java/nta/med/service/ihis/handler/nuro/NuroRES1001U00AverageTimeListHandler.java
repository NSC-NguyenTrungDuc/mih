package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0102Repository;
import nta.med.data.model.ihis.nuro.NuroRES1001U00AverageTimeListItemInfo;
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
public class NuroRES1001U00AverageTimeListHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00AverageTimeListRequest, NuroServiceProto.NuroRES1001U00AverageTimeListResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroRES1001U00AverageTimeListHandler.class);
	@Resource
	private Res0102Repository res0102Repository;

    @Override
	public boolean isValid(NuroServiceProto.NuroRES1001U00AverageTimeListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getExamPreDate()) && DateUtil.toDate(request.getExamPreDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES1001U00AverageTimeListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00AverageTimeListRequest request) throws Exception {
		NuroServiceProto.NuroRES1001U00AverageTimeListResponse.Builder response = NuroServiceProto.NuroRES1001U00AverageTimeListResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = request.getHospCodeLink();
		}
		List<NuroRES1001U00AverageTimeListItemInfo > listObject = res0102Repository.getAverageTimeList(hospCode, request.getExamPreDate(), request.getDoctorCode());
        if (listObject != null && !listObject.isEmpty()) {
            for (NuroRES1001U00AverageTimeListItemInfo item : listObject) {
            	NuroModelProto.NuroRES1001U00AverageTimeListItemInfo.Builder info = NuroModelProto.NuroRES1001U00AverageTimeListItemInfo.newBuilder();
             	if(item.getAvgTime() != null)  {
             		info.setAvgTime(String.format("%.0f", item.getAvgTime()));
             	}
             	if(item.getDocResLimit() != null)  {
             		info.setDocResLimit(String.format("%.0f", item.getDocResLimit()));
             	}
             	response.addAvgTimeListItem(info);
            }
        }
		return response.build();
	}
}
