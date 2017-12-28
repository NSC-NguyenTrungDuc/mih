package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.out.Out0105;
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
public class OUT0101U02GetAndInsertGongbiListHandler extends ScreenHandler<NuroServiceProto.OUT0101U02GetAndInsertGongbiListRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(OUT0101U02GetAndInsertGongbiListHandler.class);
	
	@Resource
	private Out0105Repository out0105Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.OUT0101U02GetAndInsertGongbiListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}else if (!StringUtils.isEmpty(request.getEndDate()) && DateUtil.toDate(request.getEndDate(), DateUtil.PATTERN_YYMMDD) == null){
			return false;
		}else if (!StringUtils.isEmpty(request.getLastCheckDate()) && DateUtil.toDate(request.getLastCheckDate(), DateUtil.PATTERN_YYMMDD) == null){
			return false;
		}
		return true;
	}

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT0101U02GetAndInsertGongbiListRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String result = out0105Repository.getNuroOUT0101U02GongbiListGetY(hospCode, request.getGongbiCode(), request.getPatientCode(), DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD));
        if(result != null) {
        	response.setResult(false);
        }else{
        	insertOut0105(request, hospCode);
        	response.setResult(true);
        }
		return response.build();
	}
	
	private void insertOut0105(NuroServiceProto.OUT0101U02GetAndInsertGongbiListRequest request, String hospCode) {
		Out0105 out0105 = new Out0105();
		out0105.setSysId(request.getUserId());
		out0105.setUpdDate(new Date());
		out0105.setUpdId(request.getUserId());
		out0105.setHospCode(hospCode);
		out0105.setStartDate(DateUtil.toDate(request.getStartDate(),DateUtil.PATTERN_YYMMDD));
		out0105.setBunho(request.getPatientCode());
		out0105.setBudamjaBunho(request.getBudamjaPatient());
		out0105.setGongbiCode(request.getGongbiCode());
		out0105.setSugubjaBunho(request.getSugubjaPatient());
		out0105.setEndDate(DateUtil.toDate(request.getEndDate(),DateUtil.PATTERN_YYMMDD));
		out0105.setRemark(request.getRemark());
		out0105.setLastCheckDate(DateUtil.toDate(request.getLastCheckDate(),DateUtil.PATTERN_YYMMDD));
		out0105Repository.save(out0105);
    }
}
