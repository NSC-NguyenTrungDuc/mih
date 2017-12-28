package nta.med.service.ihis.handler.ocsi;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ocs.Ocs2015;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.service.ihis.proto.OcsiModelProto.OCS6010U10PopupTAgrdOCS2015Info;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTASavelayout2015Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupTASavelayout2015Handler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PopupTASavelayout2015Request, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS6010U10PopupTASavelayout2015Handler.class);  
	@Resource
	private Ocs2015Repository ocs2015Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupTASavelayout2015Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		response.setResult(true);
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String userId = request.getUserId();
		if (CollectionUtils.isEmpty(request.getGrdSaveList())) {
			LOGGER.info("List Savelayout: null !!!!!");
			response.setResult(false);
			return response.build();
		}
		for (OCS6010U10PopupTAgrdOCS2015Info item : request.getGrdSaveList()) {
			if (DataRowState.ADDED.getValue().equals(item.getDataRowStage())) {
				Double seq = ocs2015Repository.getNextSeqOcs2015(hospCode, item.getBunho(), CommonUtils.parseDouble(item.getFkinp1001()), DateUtil.toDate(item.getOrderDate(), DateUtil.PATTERN_YYMMDD), item.getInputGubun(), CommonUtils.parseDouble(item.getPkSeq()));
				response.setResult(insertOcs2015(item, hospCode, userId, seq));
			} else if (DataRowState.MODIFIED.getValue().equals(item.getDataRowStage())) {
				if (ocs2015Repository.updateOCS6010U10(hospCode
													, CommonUtils.parseDouble(item.getPkocs2015())
													, userId
													, DateUtil.toDate(item.getActDate(), DateUtil.PATTERN_YYMMDD)
													, item.getActId()
													, item.getActResultCode()
													, item.getActResultText()) < 0)
					response.setResult(false);
			} else if (DataRowState.DELETED.getValue().equals(item.getDataRowStage())) {
				// Do nothing
			} else {
				LOGGER.info("DatarowState: null");
				response.setResult(false);
			}
		}
		return response.build();
	}	
	
	private boolean insertOcs2015(OCS6010U10PopupTAgrdOCS2015Info info, String hospCode, String userId, Double seq) {
		Ocs2015 ocs2015 = new Ocs2015();
		ocs2015.setSysDate(new Date());
		ocs2015.setSysId(userId);
		ocs2015.setUpdDate(new Date());
		ocs2015.setInputId(info.getInputId());
		ocs2015.setHospCode(hospCode);
		ocs2015.setFkinp1001(CommonUtils.parseDouble(info.getFkinp1001()));
		ocs2015.setOrderDate(DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD));
		ocs2015.setInputGubun(info.getInputGubun());
		ocs2015.setPkocs2015(CommonUtils.parseDouble(info.getPkocs2015()));
		ocs2015.setBunho(info.getBunho());
		ocs2015.setPkSeq(CommonUtils.parseDouble(info.getPkSeq()));
		ocs2015.setSeq(seq);
		ocs2015.setDrtDate(DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD));
		ocs2015.setActDate(DateUtil.toDate(info.getActDate(), DateUtil.PATTERN_YYMMDD));
		ocs2015.setActId(info.getActId());
		ocs2015.setActResultCode(info.getActResultCode());
		ocs2015.setActResultText(info.getActResultText());
		ocs2015.setSuryang(null);// TODO
		ocs2015.setDirectGubun(null);
		
		ocs2015.setFkocs2005(null);
		ocs2015Repository.save(ocs2015);
		boolean result = ocs2015 != null && ocs2015.getId() != null;
		return result;
	}
}
