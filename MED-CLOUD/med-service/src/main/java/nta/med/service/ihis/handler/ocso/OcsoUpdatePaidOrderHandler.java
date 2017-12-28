package nta.med.service.ihis.handler.ocso;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.out.Out1001;
import nta.med.core.glossary.OrderStatus;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OcsoUpdatePaidOrderRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.OcsoUpdatePaidOrderResponse;

@Service                                                                                                          
@Scope("prototype")
public class OcsoUpdatePaidOrderHandler extends ScreenHandler<OcsoServiceProto.OcsoUpdatePaidOrderRequest, OcsoServiceProto.OcsoUpdatePaidOrderResponse>{

	private static final Log LOGGER = LogFactory.getLog(OcsoUpdatePaidOrderHandler.class);
	
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Resource
	private Ocs1003Repository ocs1003Repository;
	
	@Override
	public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			OcsoUpdatePaidOrderRequest request) throws Exception {
		List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
        if(!CollectionUtils.isEmpty(bas0001List)){
            Bas0001 bas0001 = bas0001List.get(0);
            setSessionInfo(vertx, sessionId,
                    SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(), bas0001.getLanguage(), "", 1, ""));
        }else{
            LOGGER.info("OcsoUpdatePaidOrderHandler preHandle not found hosp code");
        }
	}
	
	@Override
	@Transactional
	public OcsoUpdatePaidOrderResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OcsoUpdatePaidOrderRequest request) throws Exception {
		
		OcsoUpdatePaidOrderResponse.Builder response = OcsoUpdatePaidOrderResponse.newBuilder();
		String hospCode = request.getHospCode();
		Date receptionDate = DateUtil.toDate(request.getReceptionDate(), DateUtil.PATTERN_YYYY_MM_DD);
		List<String> refIdList = request.getReceptRefIdList();
		
		if(CollectionUtils.isEmpty(refIdList)){
			response.setResult(false);
			return response.build();
		}
		
		List<Out1001> receptionList = out1001Repository.findByNaewonDateReceptRefId(hospCode, receptionDate, refIdList);
		if(CollectionUtils.isEmpty(receptionList)){
			LOGGER.info("Reception list in KCCK is empty, hosp_code = " + hospCode + ", reception_date = " + request.getReceptionDate() + ", refIdList = " + refIdList);
			response.setResult(true);
			return response.build();
		}
		
		List<BigDecimal> pkOut1001List = new ArrayList<>();
		for (Out1001 rep : receptionList) {
			pkOut1001List.add(BigDecimal.valueOf(rep.getPkout1001()));
		}
		
		int rowUpdated = ocs1003Repository.updateOrderStatus(hospCode, pkOut1001List, OrderStatus.TRANFER_SUCCESS.getValue(), OrderStatus.PAID_ORDER.getValue());
		LOGGER.info("Update paid order, row_updated = " + rowUpdated);
		
		response.setResult(rowUpdated > 0);
		return response.build();
	}
	
}
