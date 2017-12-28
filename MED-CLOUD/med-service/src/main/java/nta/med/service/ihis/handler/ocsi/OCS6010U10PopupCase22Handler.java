package nta.med.service.ihis.handler.ocsi;

import java.util.Date;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ocs.Ocs2015;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupCase22Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupCase22Handler
		extends ScreenHandler<OcsiServiceProto.OCS6010U10PopupCase22Request, SystemServiceProto.UpdateResponse> {

	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private Ocs2015Repository ocs2015Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupCase22Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String bunho = request.getBunho();
		Double fkinp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		Date orderDate = DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD);
		String inputGubun = request.getInputGubun();
		Double pkSeq = CommonUtils.parseDouble(request.getPkSeq());
		Date sysDate = new Date();
		
		Double seq = ocs2015Repository.getNextSeqOcs2015(hospCode, bunho, fkinp1001, orderDate, inputGubun, pkSeq);
		String strNextVal = commonRepository.getNextVal("OCS2015_SEQ");
		Double pkocs2015 = CommonUtils.parseDouble(strNextVal);
		
		Ocs2015 ocs2015 = new Ocs2015();
		ocs2015.setSysDate(sysDate);
		ocs2015.setSysId(getUserId(vertx, sessionId));
		ocs2015.setUpdDate(sysDate);
		ocs2015.setUpdId(getUserId(vertx, sessionId));
		ocs2015.setHospCode(hospCode);
		ocs2015.setPkocs2015(pkocs2015);
		ocs2015.setBunho(bunho);
		ocs2015.setFkinp1001(fkinp1001);
		ocs2015.setOrderDate(orderDate);
		ocs2015.setInputGubun(inputGubun);
		ocs2015.setInputId(request.getInputId());
		ocs2015.setPkSeq(pkSeq);
		ocs2015.setSeq(seq);
		ocs2015.setDrtDate(orderDate);
		ocs2015.setActDate(DateUtil.toDate(request.getActDate(), DateUtil.PATTERN_YYMMDD));
		ocs2015.setActId(getUserId(vertx, sessionId));
		ocs2015.setSiksaCode(request.getSiksaCode());
		
		ocs2015Repository.save(ocs2015);
		boolean result = ocs2015 != null && ocs2015.getId() != null;
		response.setResult(result);
		
		return response.build();
	}
	
}
