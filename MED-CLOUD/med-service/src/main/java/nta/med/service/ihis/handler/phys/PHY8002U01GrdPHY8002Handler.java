package nta.med.service.ihis.handler.phys;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.phy.Phy8002Repository;
import nta.med.data.model.ihis.phys.Phy8002U01GrdPhy8002LisItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01GrdPHY8002Request;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01GrdPHY8002Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY8002U01GrdPHY8002Handler
	extends ScreenHandler<PhysServiceProto.PHY8002U01GrdPHY8002Request, PhysServiceProto.PHY8002U01GrdPHY8002Response> {                     
	@Resource                                                                                                       
	private Phy8002Repository phy8002Repository;                                                                    
	                                                                                                                
	@Override        
	@Transactional(readOnly=true)
	public PHY8002U01GrdPHY8002Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY8002U01GrdPHY8002Request request) throws Exception {                                                                   
  	   	PhysServiceProto.PHY8002U01GrdPHY8002Response.Builder response = PhysServiceProto.PHY8002U01GrdPHY8002Response.newBuilder();                      
		List<Phy8002U01GrdPhy8002LisItemInfo> list = phy8002Repository.getPhy8002U01GrdPhy8002LisItem(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getFkOcs()));
		if(!CollectionUtils.isEmpty(list)){
			for(Phy8002U01GrdPhy8002LisItemInfo item : list){
				PhysModelProto.PHY8002U01GrdPHY8002LisItemInfo.Builder info = PhysModelProto.PHY8002U01GrdPHY8002LisItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addList(info);
			}
		}
		return response.build();
	}
}