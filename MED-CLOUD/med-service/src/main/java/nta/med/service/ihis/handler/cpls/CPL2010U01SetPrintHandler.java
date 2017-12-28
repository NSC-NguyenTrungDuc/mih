package nta.med.service.ihis.handler.cpls;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.adm.Adm3300;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3300Repository;
import nta.med.service.ihis.handler.injs.InjsINJ1001U01SettingPrintHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01SetPrintRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Transactional
@Service
@Scope("prototype")
public class CPL2010U01SetPrintHandler
		extends ScreenHandler<CplsServiceProto.CPL2010U01SetPrintRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(CPL2010U01SetPrintHandler.class);
	@Resource
	private Adm3300Repository adm3300Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL2010U01SetPrintRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = false;
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		Integer resultUpdate = adm3300Repository.updateAdm3300(hospCode, userId, new Date(), request.getBPrintName(), request.getIpAddr());
		if (resultUpdate == 0) {
        	String trmId = adm3300Repository.getNexTrmId(hospCode);
        	if (!StringUtils.isEmpty(trmId)) {
        		 result = insertAdm3300(request, trmId, hospCode, userId);
        		 LOG.info("Insert into ADM3300: " + result);
        	}
        } else {
        	result = true;
        }
		
		response.setResult(result);
		return response.build();
	}

	private boolean insertAdm3300(CPL2010U01SetPrintRequest request, String trmId, String hospCode, String userId) {
		Adm3300 adm3300 = new Adm3300();
		adm3300.setTrmId(trmId);
		adm3300.setIpAddr(request.getIpAddr());
		adm3300.setSysId(userId);
		adm3300.setUserId(userId);
		adm3300.setHospCode(hospCode);
		adm3300.setCrMemb(userId);
		adm3300.setCrTime(new Date());
		adm3300.setBPrintName(request.getBPrintName());;
		adm3300 = adm3300Repository.save(adm3300);
		if (adm3300 != null && adm3300.getId() != null)
			return true;
		return false;
	}
}
