package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01PaidOrderListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class DrgsDRG5100P01PaidOrderListHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01PaidOrderListRequest, DrgsServiceProto.DrgsDRG5100P01PaidOrderListResponse> {
	private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01PaidOrderListHandler.class);
	@Resource
	private Drg2010Repository drg2010Repository;

	@Override
	public boolean isValid(DrgsServiceProto.DrgsDRG5100P01PaidOrderListRequest request, Vertx vertx, String clientId, String sessionId) {
		if(!StringUtils.isEmpty(request.getFromDate()) && DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD) == null){
			return false;
		} else if(!StringUtils.isEmpty(request.getToDate()) && DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD) == null){
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public DrgsServiceProto.DrgsDRG5100P01PaidOrderListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01PaidOrderListRequest request) throws Exception {
					List<DrgsDRG5100P01PaidOrderListItemInfo> listObject = drg2010Repository.getDrgsDRG5100P01PaidListItemInfo(getHospitalCode(vertx, sessionId),
					request.getGwa(), DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD), DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD)
					, request.getGubun(), request.getWonyoiYn(), request.getBunho(), false);
			DrgsServiceProto.DrgsDRG5100P01PaidOrderListResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01PaidOrderListResponse.newBuilder();
			if(!CollectionUtils.isEmpty(listObject)) {
				for(DrgsDRG5100P01PaidOrderListItemInfo item : listObject) {
					DrgsModelProto.DrgsDRG5100P01PaidOrderListItemInfo.Builder info = DrgsModelProto.DrgsDRG5100P01PaidOrderListItemInfo.newBuilder();
					if (!StringUtils.isEmpty(item.getBunho())) {
						info.setBunho(item.getBunho());
					}
					if (!StringUtils.isEmpty(item.getOrderDate())) {
						info.setOrderDate(DateUtil.toString(item.getOrderDate(), DateUtil.PATTERN_YYMMDD));
					}
					if (item.getDrgBunho() != null) {
						info.setDrgBunho(item.getDrgBunho().toString());
					}
					if (!StringUtils.isEmpty(item.getSuname())) {
						info.setSuname(item.getSuname());
					}
					if (!StringUtils.isEmpty(item.getBoryuYn())) {
						info.setBoryuYn(item.getBoryuYn());
					}
					if (!StringUtils.isEmpty(item.getOrderRemark())) {
						info.setOrderRemark(item.getOrderRemark());
					}
					if (!StringUtils.isEmpty(item.getDrgRemark())) {
						info.setDrgRemark(item.getDrgRemark());
					}

					response.addPaidOrderList(info);
				}
			}
		return response.build();
	}
}
