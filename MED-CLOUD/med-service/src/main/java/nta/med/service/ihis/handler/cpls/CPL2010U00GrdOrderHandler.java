package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00GrdOrderCPL2010ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00GrdOrderRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00GrdOrderResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL2010U00GrdOrderHandler extends ScreenHandler<CplsServiceProto.CPL2010U00GrdOrderRequest, CplsServiceProto.CPL2010U00GrdOrderResponse> {                     
	@Resource                                                                                                       
	private Cpl2010Repository cpl2010Repository;                                                                    
	                                                                                                                
	@Override          
	@Transactional(readOnly = true)
	public CPL2010U00GrdOrderResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL2010U00GrdOrderRequest request)
			throws Exception {                                                                   
  	   	CplsServiceProto.CPL2010U00GrdOrderResponse.Builder response = CplsServiceProto.CPL2010U00GrdOrderResponse.newBuilder();                      
		//get list Grd oder
		List<CplsCPL2010U00GrdOrderCPL2010ListItemInfo> listGrdOrder=cpl2010Repository.getCplsCPL2010U00GrdOrderListItemInfo(getHospitalCode(vertx, sessionId),
				getLanguage(vertx, sessionId), request.getBunho(),request.getMijubsu(),request.getReserYn(), 
				 request.getFromDate(), request.getToDate(),request.getDoctor(), request.getEmergencyYn());
		 if(!CollectionUtils.isEmpty(listGrdOrder)){
			 for(CplsCPL2010U00GrdOrderCPL2010ListItemInfo item:listGrdOrder){
				 CplsModelProto.CPL2010U00GrdOrderListItemInfo.Builder info=CplsModelProto.CPL2010U00GrdOrderListItemInfo.newBuilder();
				 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				 response.addGrdOrderList(info);
			 }
		 }
		 return response.build();
	}
}