package nta.med.service.ihis.handler.injs;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.adm.Adm3300;
import nta.med.data.dao.medi.adm.Adm3300Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class InjsINJ1001U01SettingPrintHandler extends ScreenHandler<InjsServiceProto.InjsINJ1001U01SettingPrintRequest, InjsServiceProto.InjsINJ1001U01SettingPrintResponse> {
	private static final Log LOG = LogFactory.getLog(InjsINJ1001U01SettingPrintHandler.class);
	@Resource
	private Adm3300Repository adm3300Repository;
	
	@Override
	public InjsServiceProto.InjsINJ1001U01SettingPrintResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.InjsINJ1001U01SettingPrintRequest request) throws Exception {
		String hospitalCode = getHospitalCode(vertx, sessionId);
		InjsServiceProto.InjsINJ1001U01SettingPrintResponse.Builder response = InjsServiceProto.InjsINJ1001U01SettingPrintResponse.newBuilder();
		Integer resultUpdate = adm3300Repository.updateAdm3300(hospitalCode, request.getUserId(), new Date(), request.getBPrintName(), request.getIpAddr());
        boolean result = false;
        if (resultUpdate == 0) {
        	String trmId = adm3300Repository.getNexTrmId(hospitalCode);
        	if (!StringUtils.isEmpty(trmId)) {
        		 insertAdm3300(request, trmId, hospitalCode);
        		 result = true;
        	}
        } else {
        	result = true;
        }
        response.setResult(result);
		return response.build();
	}
	
	public void insertAdm3300(InjsServiceProto.InjsINJ1001U01SettingPrintRequest request, String trmId, String hospitalCode) {	
			Adm3300 adm3300 = new Adm3300();
			adm3300.setTrmId(trmId);
			adm3300.setIpAddr(request.getIpAddr());
			adm3300.setSysId(request.getUserId());
			adm3300.setUserId(request.getUserId());
			adm3300.setHospCode(hospitalCode);
			adm3300.setCrMemb(request.getUserId());
			adm3300.setCrTime(new Date());
			adm3300.setBPrintName(request.getBPrintName());;
			adm3300Repository.save(adm3300);
	}
}
