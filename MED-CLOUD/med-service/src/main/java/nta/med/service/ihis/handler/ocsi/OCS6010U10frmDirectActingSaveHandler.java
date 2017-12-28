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
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.service.ihis.proto.OcsiModelProto.OCS6010U10frmDirectActinggrdOCS2015Info;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10frmDirectActingSaveRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
@Transactional
public class OCS6010U10frmDirectActingSaveHandler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10frmDirectActingSaveRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS6010U10frmDirectActingSaveHandler.class);  
	@Resource
	private Ocs2015Repository ocs2015Repository;
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10frmDirectActingSaveRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		response.setResult(true);
		if (CollectionUtils.isEmpty(request.getItemsList())) {
			response.setResult(false);
			LOGGER.info("List SaveLayout : null !!!!!");
			return response.build();
		}
		
		for (OCS6010U10frmDirectActinggrdOCS2015Info item : request.getItemsList()) {
			if (DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
				Double nextSeq = ocs2015Repository.getNextSeqOcs2015Ext(hospCode, item.getBunho()
								, CommonUtils.parseDouble(item.getFkinp1001())
								, DateUtil.toDate(item.getOrderDate(), DateUtil.PATTERN_YYMMDD)
								, item.getInputGubun()
								, CommonUtils.parseDouble(item.getPkSeq()));
				String pkocs2015 = commonRepository.getNextVal("OCS2015_SEQ");
				response.setResult(insertOcs2015(item, hospCode, nextSeq, pkocs2015, userId, item.getFkocs2005()));
			} else if (DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
				if (ocs2015Repository.updateOCS6010U10(hospCode, CommonUtils.parseDouble(item.getPkocs2015()), item.getActId(), DateUtil.toDate(item.getActDate(), DateUtil.PATTERN_YYMMDD), item.getActDate() == null ? null : item.getActId(), item.getActResultCode(), item.getActResultText()) < 0) {
					response.setResult(false);
					LOGGER.info("update Ocs2015 : fail !!!!!");
					return response.build();
				}
			} else if (DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
				if (ocs2015Repository.deleteOcs2015InOCS6010Ext(hospCode, CommonUtils.parseDouble(item.getPkocs2015())) < 0) {
					response.setResult(false);
					LOGGER.info("delete Ocs2015 : fail !!!!!");
					return response.build();
				}
			} else {
				response.setResult(false);
				LOGGER.info("DataRowState : null !!!!!");
				return response.build();
			}
		}
		return response.build();
	}
	
	private boolean insertOcs2015(OCS6010U10frmDirectActinggrdOCS2015Info info, String hospCode, Double nextSeq, String pkocs2015, String userId, String fkocs2005) {
		Ocs2015 ocs2015 = new Ocs2015();
		ocs2015.setSysDate(new Date());
		ocs2015.setSysId(userId);
		ocs2015.setPkocs2015(CommonUtils.parseDouble(pkocs2015));
		ocs2015.setBunho(info.getBunho());
		ocs2015.setUpdDate(new Date());
		ocs2015.setUpdId(userId);
		ocs2015.setFkinp1001(CommonUtils.parseDouble(info.getFkinp1001()));
		ocs2015.setOrderDate(DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD));
		ocs2015.setInputGubun(info.getInputGubun());
		ocs2015.setInputId(info.getInputId());
		ocs2015.setPkSeq(CommonUtils.parseDouble(info.getPkSeq()));
		ocs2015.setSeq(nextSeq);
		ocs2015.setDrtDate(DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD));
		ocs2015.setActDate(DateUtil.toDate(info.getActDate(), DateUtil.PATTERN_YYMMDD));
		ocs2015.setActId(info.getActId());
		ocs2015.setActResultCode(info.getActResultCode());
		ocs2015.setActResultText(info.getActResultText());
		ocs2015.setHospCode(hospCode);
		ocs2015.setInputGwa(info.getInputGwa());
		ocs2015.setInputDoctor(info.getInputDoctor());
		ocs2015.setFkocs2005(CommonUtils.parseDouble(fkocs2005));
		ocs2015 = ocs2015Repository.save(ocs2015);
		boolean result = ocs2015 != null && ocs2015.getId() != null;
		return result;
	}
}
