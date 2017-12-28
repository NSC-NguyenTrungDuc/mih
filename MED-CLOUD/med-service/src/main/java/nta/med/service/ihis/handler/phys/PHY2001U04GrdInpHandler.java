package nta.med.service.ihis.handler.phys;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.phys.PHY2001U04GrdInpInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04GrdInpRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04GrdInpResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY2001U04GrdInpHandler
	extends ScreenHandler<PhysServiceProto.PHY2001U04GrdInpRequest, PhysServiceProto.PHY2001U04GrdInpResponse> {                     
	@Resource                                                                                                       
	private Ocs2003Repository ocs2003Repository;                                                                    
	                                                                                                                
	@Override   
	@Transactional(readOnly=true)
	public PHY2001U04GrdInpResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PHY2001U04GrdInpRequest request)
			throws Exception {                                                                 
  	   	PhysServiceProto.PHY2001U04GrdInpResponse.Builder response = PhysServiceProto.PHY2001U04GrdInpResponse.newBuilder();                      
    	Date orderDate = DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD);
		List<PHY2001U04GrdInpInfo> listGrd = ocs2003Repository.getPHY2001U04GrdInpInfo(getHospitalCode(vertx, sessionId), orderDate);
		if(!CollectionUtils.isEmpty(listGrd)){
			for(PHY2001U04GrdInpInfo item : listGrd){
				PhysModelProto.PHY2001U04GrdInpInfo.Builder info = PhysModelProto.PHY2001U04GrdInpInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdInpItem(info);
			}
		}
		return response.build();
	}
}