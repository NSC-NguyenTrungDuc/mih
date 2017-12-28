package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.res.Res0104;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0104Repository;
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
public class NuroRES0102U00InsertRES0104Handler  extends ScreenHandler<NuroServiceProto.NuroRES0102U00InsertRES0104Request, SystemServiceProto.UpdateResponse>{
	private static final Log logger = LogFactory.getLog(NuroRES0102U00InsertRES0104Handler.class);
	
	@Resource
	private Res0104Repository res0104Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroRES0102U00InsertRES0104Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}else if(!StringUtils.isEmpty(request.getEndDate()) && DateUtil.toDate(request.getEndDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
            		
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00InsertRES0104Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = insertRES0104(request, request.getHospCode());
        response.setResult(result);
		return response.build();
    }
	
	private boolean insertRES0104(NuroServiceProto.NuroRES0102U00InsertRES0104Request request, String hospCode) {
		Res0104 res0104 = new Res0104(); 
		res0104.setSysDate(new Date());
		res0104.setSysId(request.getUserId());
		res0104.setUpdDate(new Date());
        res0104.setUpdId(request.getUserId());
        res0104.setDoctor(request.getDoctor());
        res0104.setStartDate(DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD));
        res0104.setEndDate(DateUtil.toDate(request.getEndDate(), DateUtil.PATTERN_YYMMDD));
        res0104.setEndYn("N");
        res0104.setSayu(request.getSayu());
        res0104.setHospCode(hospCode);
		res0104Repository.save(res0104);
		return true;
    }

}
