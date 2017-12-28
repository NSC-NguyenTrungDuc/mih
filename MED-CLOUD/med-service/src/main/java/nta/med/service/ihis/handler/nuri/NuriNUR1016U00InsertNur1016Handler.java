package nta.med.service.ihis.handler.nuri;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.nur.Nur1016;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1016Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;
@Transactional
@Service
@Scope("prototype")
public class NuriNUR1016U00InsertNur1016Handler extends ScreenHandler<NuriServiceProto.NuriNUR1016U00InsertNur1016Request, SystemServiceProto.UpdateResponse>{
	private static final Log LOG = LogFactory.getLog(NuriNUR1016U00InsertNur1016Handler.class);
	
	@Resource
	private Nur1016Repository nur1016Repository;
	
	@Override
	public boolean isValid(NuriServiceProto.NuriNUR1016U00InsertNur1016Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		} else if (!StringUtils.isEmpty(request.getEndDate())&& DateUtil.toDate(request.getEndDate(),DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NuriNUR1016U00InsertNur1016Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Integer result = insertNur1016(request, getHospitalCode(vertx, sessionId));
	    response.setResult(result != null && result > 0);
		return response.build();
	}
	
	private Integer insertNur1016(NuriServiceProto.NuriNUR1016U00InsertNur1016Request request, String hospCode) throws Exception{
			Nur1016 nur1016 = new Nur1016();
			nur1016.setSysDate(new Date());
			nur1016.setSysId(request.getUserId());
			nur1016.setUpdDate(new Date());
			nur1016.setUpdId(request.getUserId());
			nur1016.setHospCode(hospCode);
			if(!StringUtils.isEmpty(request.getPknur1016())){
				nur1016.setPknur1016(CommonUtils.parseDouble(request.getPknur1016()));
				
			}
			nur1016.setBunho(request.getBunho());
			nur1016.setAllergyGubun(request.getAllergyGubun());
			nur1016.setAllergyInfo(request.getAllergyInfo());
			if(!StringUtils.isEmpty(request.getStartDate())){
				nur1016.setStartDate(DateUtil.toDate(request.getStartDate(),DateUtil.PATTERN_YYMMDD));
			}
			if(!StringUtils.isEmpty(request.getEndDate())){
				nur1016.setEndDate(DateUtil.toDate(request.getEndDate(),DateUtil.PATTERN_YYMMDD));
			}
			nur1016.setEndSayu(request.getEndSayu());
			nur1016.setInputText(request.getInputText());
			nur1016.setCancelYn("N");
			
			nur1016Repository.save(nur1016);
			return 1;
		
	}
}
