package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00OrderCancelGrdCPL2010ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00OrderCancelGrdOrderRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00OrderCancelGrdOrderResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CplsCPL2010U00OrderCancelGrdOrderCPL2010Handler extends
		ScreenHandler <CplsServiceProto.CPL2010U00OrderCancelGrdOrderRequest, CplsServiceProto.CPL2010U00OrderCancelGrdOrderResponse>{
	@Resource
	private Cpl2010Repository cpl2010Repository;

	@Override
	public boolean isValid(CPL2010U00OrderCancelGrdOrderRequest request,
			Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	} 
	
	@Override
	@Transactional(readOnly = true)
	public CPL2010U00OrderCancelGrdOrderResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL2010U00OrderCancelGrdOrderRequest request) throws Exception {
		CplsServiceProto.CPL2010U00OrderCancelGrdOrderResponse.Builder response = CplsServiceProto.CPL2010U00OrderCancelGrdOrderResponse.newBuilder();
		List<CplsCPL2010U00OrderCancelGrdCPL2010ListItemInfo> listOrderCancerGrd = cpl2010Repository.getCPL2010U00OrderCancelGrdOrder(getHospitalCode(vertx, sessionId),
				getLanguage(vertx, sessionId),request.getBunho(), DateUtil.toDate(request.getOrderDate(),DateUtil.PATTERN_YYMMDD));
		if (listOrderCancerGrd != null && !listOrderCancerGrd.isEmpty()) {
			for (CplsCPL2010U00OrderCancelGrdCPL2010ListItemInfo item : listOrderCancerGrd) {
				CplsModelProto.CPL2010U00OrderCancelGrdOrderListItemInfo.Builder info = CplsModelProto.CPL2010U00OrderCancelGrdOrderListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdOrderList(info);
			}
		}
	    return response.build();
	}
}