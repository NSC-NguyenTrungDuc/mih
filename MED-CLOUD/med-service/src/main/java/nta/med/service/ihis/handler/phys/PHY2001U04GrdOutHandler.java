package nta.med.service.ihis.handler.phys;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.phys.PHY2001U04GrdOutInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04GrdOutRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04GrdOutResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY2001U04GrdOutHandler 
	extends ScreenHandler<PhysServiceProto.PHY2001U04GrdOutRequest, PhysServiceProto.PHY2001U04GrdOutResponse> {                     
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;                                                                    
	                                                                                                                
	@Override              
	@Transactional(readOnly=true)
	public PHY2001U04GrdOutResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PHY2001U04GrdOutRequest request)
			throws Exception {                                                                  
  	   	PhysServiceProto.PHY2001U04GrdOutResponse.Builder response = PhysServiceProto.PHY2001U04GrdOutResponse.newBuilder();                      
    	Date orderDate = DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD);
    	List<PHY2001U04GrdOutInfo> listGrd = ocs1003Repository.getPHY2001U04GrdOutInfo(getHospitalCode(vertx, sessionId), orderDate);
    	if(!CollectionUtils.isEmpty(listGrd)){
    		for(PHY2001U04GrdOutInfo item : listGrd){
    			PhysModelProto.PHY2001U04GrdOutInfo.Builder info = PhysModelProto.PHY2001U04GrdOutInfo.newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdOutItem(info);
    		}
    	}
    	return response.build();
	}
}