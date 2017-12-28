package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdDcOrderInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdDcOrderRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdDcOrderResponse;

@Service
@Scope("prototype")
public class DRG3010P10GrdDcOrderHandler extends
		ScreenHandler<DrgsServiceProto.DRG3010P10GrdDcOrderRequest, DrgsServiceProto.DRG3010P10GrdDcOrderResponse> {

	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public DRG3010P10GrdDcOrderResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010P10GrdDcOrderRequest request) throws Exception {
		DrgsServiceProto.DRG3010P10GrdDcOrderResponse.Builder response = DrgsServiceProto.DRG3010P10GrdDcOrderResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<DRG3010P10GrdDcOrderInfo> infos = drg3010Repository.getDRG3010P10GrdDcOrderInfo(hospCode
				, language
				, DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD)
				, CommonUtils.parseDouble(request.getDrgBunho())
				, request.getBunho()
				, request.getMagamBunryu());
		
		if(!CollectionUtils.isEmpty(infos)){
			for (DRG3010P10GrdDcOrderInfo info : infos) {
				DrgsModelProto.DRG3010P10GrdDcOrderInfo.Builder pInfo = DrgsModelProto.DRG3010P10GrdDcOrderInfo.newBuilder();
				BeanUtils.copyProperties(info, pInfo, language);
				response.addGrdList(pInfo);
			}
		}
		
		return response.build();
	}

}
