package nta.med.service.ihis.handler.ocsi;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ocs.Ocs2016;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs2016Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10InsertOCS2016Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS6010U10InsertOCS2016Handler extends ScreenHandler<OcsiServiceProto.OCS6010U10InsertOCS2016Request, SystemServiceProto.UpdateResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(OCS6010U10InsertOCS2016Handler.class);  
	
	@Resource
	private Ocs2016Repository ocs2016Repository;
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10InsertOCS2016Request request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String userId = request.getQUserId();
		String fkocs2015 = request.getFFkocs2015();
		String hangmogCode = request.getFHangmogCode();
		String suryang = request.getFSuryang();
		String bomYn = request.getFBomYn();
		String bomSourceKey = request.getFBomSourceKey();
		String seq = request.getFSeq();
		
		String pkocs2016 = commonRepository.getNextVal("OCS2016_SEQ");

		Ocs2016 ocs2016 = insertOcs2016(hospCode, userId, fkocs2015, hangmogCode, suryang, bomYn, bomSourceKey, seq, pkocs2016);
		
		if(ocs2016 == null || ocs2016.getId() == null){
			LOGGER.info(String.format("Insert OCS2016 fail, hosp_code = %s", hospCode));
			response.setResult(false);
			return response.build();
		}

		response.setResult(true);
		return response.build();
	}
	
	private Ocs2016 insertOcs2016(String hospCode, String userId, String fkocs2015, String hangmogCode, String suryang, String bomYn,
			String bomSourceKey, String seq, String pkocs2016) {
		
		Ocs2016 ocs2016 = new Ocs2016();
		ocs2016.setBomSourceKey(CommonUtils.parseDouble(bomSourceKey));
		ocs2016.setBomYn(bomYn);
		ocs2016.setFkocs2015(CommonUtils.parseDouble(fkocs2015));
		ocs2016.setHangmogCode(hangmogCode);
		ocs2016.setHospCode(hospCode);
		ocs2016.setPkocs2016(CommonUtils.parseDouble(pkocs2016));
		ocs2016.setSeq(CommonUtils.parseDouble(seq));
		ocs2016.setSuryang(CommonUtils.parseDouble(suryang));
		ocs2016.setSysDate(new Date());
		ocs2016.setSysId(userId);
		ocs2016.setUpdDate(new Date());
		ocs2016.setUpdId(userId);
		
		ocs2016Repository.save(ocs2016);
		return ocs2016;
	}

}
