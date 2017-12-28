package nta.med.service.ihis.handler.phys;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto.PHY2001U04SaveLayoutInfo;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class PHY2001U04SaveLayoutHandler
	extends ScreenHandler<PhysServiceProto.PHY2001U04SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY2001U04SaveLayoutRequest request) throws Exception {                                                                  
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
		Integer result = null;
		for(PHY2001U04SaveLayoutInfo info : request.getSaveLayoutItemList()){
			Double pkout1001 = CommonUtils.parseDouble(info.getPkout1001());
			result = out1001Repository.updatePhyWherePkout1001(getHospitalCode(vertx, sessionId), request.getUserId(), info.getNaewonYn(),
					info.getArriveTime(), info.getJubsuGubun(), pkout1001);
		}
		response.setResult(result != null && result > 0);
		return response.build();
	}
}