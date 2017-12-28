package nta.med.service.ihis.handler.drgs;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg3041Repository;
import nta.med.data.model.ihis.drgs.PrDrgMakeBarCodeResultInfo;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3041P01DsvSaveRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class DRG3041P01DsvSaveHandler
		extends ScreenHandler<DrgsServiceProto.DRG3041P01DsvSaveRequest, SystemServiceProto.UpdateResponse> {

	private static final Log LOGGER = LogFactory.getLog(DRG3041P01DsvSaveHandler.class);
	
	@Resource
	private Drg3041Repository drg3041Repository;

	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3041P01DsvSaveRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		PrDrgMakeBarCodeResultInfo result = drg3041Repository.callPrDrgMakeBarCode(getHospitalCode(vertx, sessionId)
				, request.getBarcodeNo()
				, request.getIudGubun()
				, request.getUserId()
				, DateUtil.getDateTime(new Date(), DateUtil.PATTERN_YYMMDD)
				, request.getUserGubun()
				, request.getBunho());
		
		LOGGER.info(String.format("Execute PR_DRG_MAKE_BARCODE: Result = %s, hosp_code = %s", (StringUtils.isEmpty(result.getIoReturn()) ? "NULL/Empty" : result.getIoReturn()), getHospitalCode(vertx, sessionId)));
		
		response.setMsg(StringUtils.isEmpty(result.getIoReturn()) ? "" : result.getIoReturn());
		response.setResult(StringUtils.isEmpty(result.getIoReturn()) ? false : true);
		
		return response.build();
	}

}
