package nta.med.service.ihis.handler.ocsi;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ocs.Ocs2016;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs2016Repository;
import nta.med.service.ihis.proto.OcsiModelProto.OCS6010U10PopupTAgrdOCS2016Info;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTASavelayout2016Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupTASavelayout2016Handler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PopupTASavelayout2016Request, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS6010U10PopupTASavelayout2016Handler.class);  
	@Resource
	private Ocs2016Repository ocs2016Repository;
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupTASavelayout2016Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		response.setResult(true);
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String userId = request.getUserId();
		if (CollectionUtils.isEmpty(request.getGrdSaveList())) {
			LOGGER.info("List Savelayout: null !!!!!");
			response.setResult(false);
			return response.build();
		}
		
		for (OCS6010U10PopupTAgrdOCS2016Info item : request.getGrdSaveList()) {
			if (DataRowState.ADDED.getValue().equals(item.getDataRowStage())) {
				Double seq = ocs2016Repository.getMaxSeqOCS6010U10(hospCode, item.getFkocs2015());
				String nextVal = commonRepository.getNextVal("OCS2016_SEQ");
				if (StringUtils.isEmpty(nextVal)) {
					LOGGER.info("Next Val OCS2016: null !!!!");
					response.setResult(false);
					return response.build();
				}
				response.setResult(insertOcs2016(item, hospCode, userId, seq, nextVal));
			} else if (DataRowState.MODIFIED.getValue().equals(item.getDataRowStage())) {
				//Do nothing
			} else if (DataRowState.DELETED.getValue().equals(item.getDataRowStage())) {
				//Do nothing
			} else {
				LOGGER.info("DatarowState: null");
				response.setResult(false);
			}
		}
		return response.build();
	}

	private boolean insertOcs2016(OCS6010U10PopupTAgrdOCS2016Info info, String hospCode, String userId, Double seq, String nextVal) {
		Ocs2016 ocs2016 = new Ocs2016();
		ocs2016.setSysDate(new Date());
		ocs2016.setSysId(userId);
		ocs2016.setHospCode(hospCode);
		ocs2016.setPkocs2016(CommonUtils.parseDouble(nextVal));
		ocs2016.setFkocs2015(CommonUtils.parseDouble(info.getFkocs2015()));
		ocs2016.setSeq(seq);
		ocs2016.setHangmogCode(info.getHangmogCode());
		ocs2016.setSuryang(CommonUtils.parseDouble(info.getSuryang()));
		ocs2016.setNalsu(CommonUtils.parseDouble(info.getNalsu()));
		ocs2016.setOrdDanui(info.getOrdDanui());
		ocs2016.setBogyongCode(info.getBogyongCode());
		ocs2016.setJusaCode(info.getJusaCode());
		ocs2016.setJusaSpdGubun(info.getJusaSpdGubun());
		ocs2016.setDv(CommonUtils.parseDouble(info.getDv()));
		ocs2016.setDvTime(info.getDvTime());
		ocs2016.setTimeGubun(null);
		ocs2016.setBomSourceKey(CommonUtils.parseDouble(info.getBomSourceKey()));
		ocs2016.setBomYn(info.getBomYn());
		
		ocs2016Repository.save(ocs2016);
		boolean result = ocs2016 != null && ocs2016.getId() != null;
		return result;
	}
}
