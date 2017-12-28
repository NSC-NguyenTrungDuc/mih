package nta.med.service.ihis.handler.ocsi;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs2016;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.dao.medi.ocs.Ocs2016Repository;
import nta.med.data.dao.medi.ocs.Ocs2017Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupDAbtnListRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupDAbtnListHandler
		extends ScreenHandler<OcsiServiceProto.OCS6010U10PopupDAbtnListRequest, SystemServiceProto.UpdateResponse> {

	private static final Log LOGGER = LogFactory.getLog(OCS6010U10PopupDAbtnListHandler.class);
	
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Resource
	private Ocs2017Repository ocs2017Repository;
	
	@Resource
	private Ocs2016Repository ocs2016Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupDAbtnListRequest request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		Date dtpactDate = DateUtil.toDate(request.getDtpactDate(), DateUtil.PATTERN_YYMMDD);
		List<String> lstPkocs2016 = request.getMpkocs2016List();
		
		if(CollectionUtils.isEmpty(lstPkocs2016)){
			response.setResult(false);
			return response.build();
		}
		
		for (String pkocs2016 : lstPkocs2016) {
			List<Ocs2016> lstOcs2016 = ocs2016Repository.findByHospCodePkOcs2016(hospCode, CommonUtils.parseDouble(pkocs2016));
			if(CollectionUtils.isEmpty(lstOcs2016)){
				LOGGER.info(String.format("OCS2016 not found, hosp_code = %s, pkocs2016 = %s", hospCode, pkocs2016));
				throw new ExecutionException(response.setResult(false).build());
			}
			
			Double pkocs2003 = lstOcs2016.get(0).getFkocs2003();
			ocs2003Repository.updateOcs2003InOCS6010U10PopupDAbtnList(hospCode, pkocs2003, dtpactDate, "3", "PA");
			
			ocs2017Repository.updateOcs2017InOCS6010U10PopupDAbtnList(hospCode, pkocs2003, dtpactDate, userId, userId, dtpactDate);
		}
		
		response.setResult(true);
		return response.build();
	}
}
