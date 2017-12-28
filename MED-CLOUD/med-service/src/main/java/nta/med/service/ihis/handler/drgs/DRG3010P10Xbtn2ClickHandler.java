package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.dao.medi.drg.Drg3060Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10Xbtn2ClickRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class DRG3010P10Xbtn2ClickHandler
		extends ScreenHandler<DrgsServiceProto.DRG3010P10Xbtn2ClickRequest, SystemServiceProto.StringResponse> {

	private static final Log LOGGER = LogFactory.getLog(DRG3010P10Xbtn2ClickHandler.class);
	
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Resource
	private Drg3060Repository drg3060Repository;
	
	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010P10Xbtn2ClickRequest request) throws Exception {
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		Double fkocs2003 = CommonUtils.parseDouble(request.getFkocs2003());
		String boryuYn = request.getBoryuYn();
		
		int rowUpdated = drg3010Repository.updateReUseYnByHospCodeFkOcs2003(hospCode, fkocs2003, "Y");
		if(rowUpdated <= 0){
			LOGGER.info(String.format("UPDATE Drg3010 FAIL: HOSP_CODE = %s, fkocs2003 = %s", hospCode, request.getFkocs2003()));
			response.setResult("");
			return response.build();
		}
		
		
		String procResult = drg3060Repository.callPrDrgMakeDrg3060(hospCode, userId, fkocs2003, boryuYn);
		
		response.setResult(procResult == null ? "" : procResult);
		return response.build();
	}

}
