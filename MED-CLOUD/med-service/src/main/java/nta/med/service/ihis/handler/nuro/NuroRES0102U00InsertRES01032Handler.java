package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.res.Res0103;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class NuroRES0102U00InsertRES01032Handler extends ScreenHandler<NuroServiceProto.NuroRES0102U00InsertRES0103Req2Request, SystemServiceProto.UpdateResponse>{
private static final Log logger = LogFactory.getLog(NuroRES0102U00InsertRES01032Handler.class);
	
	@Resource
	private Res0103Repository res0103Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroRES0102U00InsertRES0103Req2Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getJinryoPreDate()) && DateUtil.toDate(request.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00InsertRES0103Req2Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = insertRES0103(request, getHospitalCode(vertx, sessionId));
        response.setResult(result);
		return response.build();
	}
	
	private boolean insertRES0103(NuroServiceProto.NuroRES0102U00InsertRES0103Req2Request request, String hospCode) {
			Res0103 res0103 = new Res0103(); 
			res0103.setSysDate(new Date());
			res0103.setSysId(request.getUserId());
			res0103.setUpdDate(new Date());
			res0103.setUpdId(request.getUserId());
			res0103.setDoctor(request.getDoctor());
			res0103.setJinryoPreDate(DateUtil.toDate(request.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD));
			res0103.setResAmStartHhmm(request.getResAmStartHhmm());
			res0103.setResAmEndHhmm(request.getResAmEndHhmm());
			res0103.setResPmStartHhmm(request.getResPmStartHhmm());
			res0103.setResPmEndHhmm(request.getResPmEndHhmm());
			res0103.setRemark(request.getRemark());
			res0103.setHospCode(hospCode);
            
			res0103Repository.save(res0103);
			return true;
	}

}
