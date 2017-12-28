package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL0000Q00LayOrderListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00LayOrderRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00LayOrderResponse;

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
public class CPL0000Q00LayOrderHandler extends ScreenHandler<CplsServiceProto.CPL0000Q00LayOrderRequest, CplsServiceProto.CPL0000Q00LayOrderResponse> {
	private static final Log LOG = LogFactory.getLog(CPL0000Q00LayOrderHandler.class);
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	
	@Override
	@Transactional(readOnly = true)
	public CPL0000Q00LayOrderResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL0000Q00LayOrderRequest request)
					throws Exception {
            CplsServiceProto.CPL0000Q00LayOrderResponse.Builder response = CplsServiceProto.CPL0000Q00LayOrderResponse.newBuilder();
            List<CPL0000Q00LayOrderListItemInfo> listItem = cpl2010Repository.getCPL0000Q00LayOrder(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho());
            if(!CollectionUtils.isEmpty(listItem)) {
            	for(CPL0000Q00LayOrderListItemInfo item : listItem) {
            		CplsModelProto.CPL0000Q00LayOrderListItemInfo.Builder info = CplsModelProto.CPL0000Q00LayOrderListItemInfo.newBuilder();
            		if (item.getOrderDate() != null) {
            			info.setOrderDate(DateUtil.toString(item.getOrderDate(), DateUtil.PATTERN_YYMMDD));
            		}
            		if (!StringUtils.isEmpty(item.getGwa())) {
            			info.setGwa(item.getGwa());
            		}
            		if (!StringUtils.isEmpty(item.getDoctor())) {
            			info.setDoctor(item.getDoctor());
            		}
            		if (!StringUtils.isEmpty(item.getGwaName())) {
            			info.setGwaName(item.getGwaName());
            		}
            		if (!StringUtils.isEmpty(item.getDoctorName())) {
            			info.setDoctorName(item.getDoctorName());
            		}
            		if (!StringUtils.isEmpty(item.getInOutGubun())) {
            			info.setInOutGubun(item.getInOutGubun());
            		}
            		
            		response.addLayOrderList(info);
            	}
            }
		return response.build();
	}

}
