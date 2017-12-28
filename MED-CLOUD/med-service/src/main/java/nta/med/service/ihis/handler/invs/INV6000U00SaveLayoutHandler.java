package nta.med.service.ihis.handler.invs;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inv.Inv6000Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV6000U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
@Transactional
public class INV6000U00SaveLayoutHandler extends ScreenHandler<InvsServiceProto.INV6000U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(INV6000U00SaveLayoutHandler.class);
	@Resource
	private Inv6000Repository inv6000Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INV6000U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Date inputDate = DateUtil.toDate(request.getInputDate(), DateUtil.PATTERN_YYMMDD);
		ComboListItemInfo result = inv6000Repository.callPrInvMakeStockCounts(getHospitalCode(vertx, sessionId), request.getProc(),
				request.getMonth(), request.getUserId(), request.getInputUser(), inputDate, request.getRemark());
		LOGGER.info("INV6000U00SaveLayoutHandler :" + result != null ? result.getCodeName() : "");
		if(result != null) response.setMsg(result.getCode());
		if("S".equals(result.getCode()) || "B".equals(result.getCode()) || "Y".equals(result.getCode())){
			response.setResult(true);
			
		}else{
			response.setResult(false);
			throw new ExecutionException(response.build());
		}
		return response.build();
	}

}
