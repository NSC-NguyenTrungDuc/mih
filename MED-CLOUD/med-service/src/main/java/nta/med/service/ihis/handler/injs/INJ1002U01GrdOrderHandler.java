package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inj.Inj1002Repository;
import nta.med.data.model.ihis.injs.INJ1002U01GrdOrderListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class INJ1002U01GrdOrderHandler extends ScreenHandler<InjsServiceProto.INJ1002U01GrdOrderRequest, InjsServiceProto.INJ1002U01GrdOrderResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(INJ1002U01GrdOrderHandler.class);                                    
	@Resource                                                                                                       
	private Inj1002Repository inj1002Repository;                                                                    

	@Override
	public boolean isValid(InjsServiceProto.INJ1002U01GrdOrderRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getReserDate()) && DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ1002U01GrdOrderResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1002U01GrdOrderRequest request) throws Exception {
		InjsServiceProto.INJ1002U01GrdOrderResponse.Builder response = InjsServiceProto.INJ1002U01GrdOrderResponse.newBuilder();  
		List<INJ1002U01GrdOrderListItemInfo> listResult = inj1002Repository.getINJ1002U01Initialize(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(),  request.getReserDate());
        if (!CollectionUtils.isEmpty(listResult)) {
        	for(INJ1002U01GrdOrderListItemInfo item : listResult){
        		InjsModelProto.INJ1002U01GrdOrderListItemInfo.Builder info = InjsModelProto.INJ1002U01GrdOrderListItemInfo.newBuilder();
            	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
            	response.addGrdOrderList(info);
        	}
        }
		return response.build();
	}                                                                                                                 
}