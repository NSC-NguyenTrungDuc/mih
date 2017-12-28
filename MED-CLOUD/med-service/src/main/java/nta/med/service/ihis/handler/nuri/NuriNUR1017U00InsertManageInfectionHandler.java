package nta.med.service.ihis.handler.nuri;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.nur.Nur1017;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1017Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuriNUR1017U00InsertManageInfectionHandler extends ScreenHandler<NuriServiceProto.NuriNUR1017U00InsertManageInfectionRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuriNUR1017U00InsertManageInfectionHandler.class);
	@Resource
	private Nur1017Repository nur1017Repository;
	
	@Override
	@Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NuriNUR1017U00InsertManageInfectionRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Integer result = insertManageInfection(request, getHospitalCode(vertx, sessionId));
		response.setResult(result != null && result > 0);
		return response.build();
	}
	
	private Integer insertManageInfection(NuriServiceProto.NuriNUR1017U00InsertManageInfectionRequest request, String hospCode) throws Exception{
			Nur1017 nur1017 = new Nur1017();
			
			Date date = new Date();
		
			nur1017.setSysDate(date);
			nur1017.setSysId(request.getSysId());
			nur1017.setUpdDate(date);
			nur1017.setUpdId(request.getSysId());
			nur1017.setHospCode(hospCode);
			nur1017.setInfeCode(request.getInfeCode());
			nur1017.setBunho(request.getBunho());
			nur1017.setStartDate(DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD));
			nur1017.setEndDate(DateUtil.toDate(request.getEndDate(), DateUtil.PATTERN_YYMMDD));
			nur1017.setEndSayu(request.getEndSayu());
			nur1017.setInputText(request.getInputText());
			nur1017.setInfeJaeryo(request.getInfeJaeryo());
			nur1017.setPknur1017(CommonUtils.parseDouble(request.getPknur1017()));
			nur1017.setCancelYn(request.getCancelYn());
			
			nur1017Repository.save(nur1017);
			return 1;
	}
	
}
