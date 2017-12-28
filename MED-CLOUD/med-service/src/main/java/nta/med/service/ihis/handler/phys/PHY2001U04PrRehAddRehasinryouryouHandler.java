package nta.med.service.ihis.handler.phys;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto.PHY2001U04PrRehAddRehasinryouryouInfo;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04PrRehAddRehasinryouryouRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04PrRehAddRehasinryouryouResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY2001U04PrRehAddRehasinryouryouHandler
	extends ScreenHandler<PhysServiceProto.PHY2001U04PrRehAddRehasinryouryouRequest, PhysServiceProto.PHY2001U04PrRehAddRehasinryouryouResponse> {                     
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional
	public PHY2001U04PrRehAddRehasinryouryouResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			PHY2001U04PrRehAddRehasinryouryouRequest request) throws Exception {                                                                  
  	   	PhysServiceProto.PHY2001U04PrRehAddRehasinryouryouResponse.Builder response = PhysServiceProto.PHY2001U04PrRehAddRehasinryouryouResponse.newBuilder();                      
  	   	ComboListItemInfo info = null;
    	for(PHY2001U04PrRehAddRehasinryouryouInfo item : request.getSinryouryouGubunList()){
		Date iOrderDate = DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD);
		Double pkout1001 = CommonUtils.parseDouble(request.getFkout1001());
		info = ocs1003Repository.callPrRehAddRehasinryouryou(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), iOrderDate, request.getBunho(),
				 pkout1001, request.getDoctor(), item.getSinryouryouGubun(), request.getInputId(), request.getInputTab(), request.getIudGubun());
    	}
    	if(info != null && !"1".equalsIgnoreCase(info.getCode())){
			throw new ExecutionException(response.build());
    	}
    	return response.build();
    }
}