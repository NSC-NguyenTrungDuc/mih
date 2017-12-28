package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg3041Repository;
import nta.med.data.model.ihis.drgs.DRG3041P05grdIpgoJUSAOrderInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3041P05grdIpgoJUSAOrderRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3041P05grdIpgoJUSAOrderResponse;

@Service
@Scope("prototype")
public class DRG3041P05grdIpgoJUSAOrderHandler extends
		ScreenHandler<DrgsServiceProto.DRG3041P05grdIpgoJUSAOrderRequest, DrgsServiceProto.DRG3041P05grdIpgoJUSAOrderResponse> {

	@Resource
	private Drg3041Repository drg3041Repository;
	
	@Override
	@Transactional(readOnly = true)
	public DRG3041P05grdIpgoJUSAOrderResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3041P05grdIpgoJUSAOrderRequest request) throws Exception {
		DrgsServiceProto.DRG3041P05grdIpgoJUSAOrderResponse.Builder response = DrgsServiceProto.DRG3041P05grdIpgoJUSAOrderResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<DRG3041P05grdIpgoJUSAOrderInfo> infos = drg3041Repository.getDRG3041P05grdIpgoJUSAOrderInfo(hospCode
				, language
				, request.getSerialV()
				, request.getJubsuDate()
				, CommonUtils.parseDouble(request.getDrgBunho()));
		if(!CollectionUtils.isEmpty(infos)){
			for (DRG3041P05grdIpgoJUSAOrderInfo info : infos) {
				DrgsModelProto.DRG3041P05grdIpgoJUSAOrderInfo.Builder pInfo = DrgsModelProto.DRG3041P05grdIpgoJUSAOrderInfo.newBuilder();
				BeanUtils.copyProperties(info, pInfo, language);
				response.addItems(pInfo);
			}
		}
		
		return response.build();
	}

}
