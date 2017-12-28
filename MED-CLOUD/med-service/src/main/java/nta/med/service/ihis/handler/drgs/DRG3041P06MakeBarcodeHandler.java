package nta.med.service.ihis.handler.drgs;

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
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3041P06MakeBarcodeRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3041P06MakeBarcodeResponse;

@Service
@Scope("prototype")
public class DRG3041P06MakeBarcodeHandler extends
		ScreenHandler<DrgsServiceProto.DRG3041P06MakeBarcodeRequest, DrgsServiceProto.DRG3041P06MakeBarcodeResponse> {

	private static final Log LOGGER = LogFactory.getLog(DRG3041P06MakeBarcodeHandler.class);
	
	@Resource
	private Drg3041Repository drg3041Repository;
	
	@Override
	@Transactional
	public DRG3041P06MakeBarcodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3041P06MakeBarcodeRequest request) throws Exception {
		DrgsServiceProto.DRG3041P06MakeBarcodeResponse.Builder response = DrgsServiceProto.DRG3041P06MakeBarcodeResponse.newBuilder();
		PrDrgMakeBarCodeResultInfo result = drg3041Repository.callPrDrgMakeBarCode(getHospitalCode(vertx, sessionId)
				, request.getBarcodeNo()
				, request.getIudGubun()
				, request.getUserId()
				, DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD)
				, request.getUserGubun()
				, request.getBunho());
		
		LOGGER.info(String.format("Execute PR_DRG_MAKE_BARCODE: Result = %s, hosp_code = %s", (StringUtils.isEmpty(result.getIoReturn()) ? "NULL/Empty" : result.getIoReturn()), getHospitalCode(vertx, sessionId)));
		
		response.setResult(result.getIoReturn() != null);
		response.setMsg(result.getIoReturn() == null ? "" : result.getIoReturn());
		response.setJusaYn(result.getIoJusaYn() == null ? "" : result.getIoJusaYn());
		response.setIpgoDate(result.getIoIpgoDate() == null ? "" : DateUtil.toString(result.getIoIpgoDate(), DateUtil.PATTERN_YYMMDD ));
		
		return response.build();
	}

}
