package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0105Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class NuroOUT0101U02UpdateGongbiListHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02UpdateGongbiListRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(NuroOUT0101U02UpdateGongbiListHandler.class);
	@Resource
	private Out0105Repository out0105Repository;

    @Override
	public boolean isValid(NuroServiceProto.NuroOUT0101U02UpdateGongbiListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		} else if(!StringUtils.isEmpty(request.getEndDate()) && DateUtil.toDate(request.getEndDate(), DateUtil.PATTERN_YYMMDD) == null){
			return false;
		} else if(!StringUtils.isEmpty(request.getLastCheckDate()) && DateUtil.toDate(request.getLastCheckDate(), DateUtil.PATTERN_YYMMDD) == null){
			return false;
		}
		return true;
	}

    
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02UpdateGongbiListRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Integer resulUpdate = out0105Repository.updateNuroOUT0101U02Gongbi(request.getUserId(), new Date(),  
        		DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD), request.getPatientCode(), request.getBudamjaPatient(), 
        		request.getGongbiCode(), request.getSugubjaCode(), DateUtil.toDate(request.getEndDate(), DateUtil.PATTERN_YYMMDD),  
        		request.getRemark(), DateUtil.toDate(request.getLastCheckDate(), DateUtil.PATTERN_YYMMDD), getHospitalCode(vertx, sessionId), request.getOldStartDate());
		response.setResult(resulUpdate != null && resulUpdate > 0);
		return response.build();
	}
}
