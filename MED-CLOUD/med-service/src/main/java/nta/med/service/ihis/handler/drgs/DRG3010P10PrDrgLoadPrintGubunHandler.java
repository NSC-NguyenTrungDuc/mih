package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg3060Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10PrDrgLoadPrintGubunRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class DRG3010P10PrDrgLoadPrintGubunHandler extends
		ScreenHandler<DrgsServiceProto.DRG3010P10PrDrgLoadPrintGubunRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Drg3060Repository drg3060Repository;
	
	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010P10PrDrgLoadPrintGubunRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String procResult = drg3060Repository.callPrDrgLoadPrintGubun(hospCode
				, DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD)
				, CommonUtils.parseDouble(request.getDrgBunho())
				, request.getPrintGubun());
		
		response.setResult(procResult == null ? "" : procResult);
		return response.build();
	}
	
}
