package nta.med.service.ihis.handler.phys;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.phy.Phy8004Repository;
import nta.med.data.model.ihis.phys.Phy8002U01GrdPhy8004LisItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01GrdPHY8004Request;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01GrdPHY8004Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY8002U01GrdPHY8004Handler
	extends ScreenHandler<PhysServiceProto.PHY8002U01GrdPHY8004Request, PhysServiceProto.PHY8002U01GrdPHY8004Response> {                     
	@Resource                                                                                                       
	private Phy8004Repository phy8004Repository;                                                                    
	                                                                                                                
	@Override                      
	@Transactional(readOnly=true)
	public PHY8002U01GrdPHY8004Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY8002U01GrdPHY8004Request request) throws Exception {                                                                   
  	   	PhysServiceProto.PHY8002U01GrdPHY8004Response.Builder response = PhysServiceProto.PHY8002U01GrdPHY8004Response.newBuilder();                      
		List<Phy8002U01GrdPhy8004LisItemInfo> list = phy8004Repository.getPhy8002U01GrdPhy8004LisItem(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getFkOcsIrai()));
		if(!CollectionUtils.isEmpty(list)){
			for(Phy8002U01GrdPhy8004LisItemInfo item : list){
				PhysModelProto.PHY8002U01GrdPHY8004LisItemInfo.Builder info = PhysModelProto.PHY8002U01GrdPHY8004LisItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addList(info);
			}
		}
		return response.build();
	}
}