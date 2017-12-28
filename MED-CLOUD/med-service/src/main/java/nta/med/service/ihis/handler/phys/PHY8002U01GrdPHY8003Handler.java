package nta.med.service.ihis.handler.phys;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.phy.Phy8003Repository;
import nta.med.data.model.ihis.phys.Phy8002U01GrdPhy8003LisItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01GrdPHY8003Request;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01GrdPHY8003Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY8002U01GrdPHY8003Handler
	extends ScreenHandler<PhysServiceProto.PHY8002U01GrdPHY8003Request, PhysServiceProto.PHY8002U01GrdPHY8003Response> {                     
	@Resource                                                                                                       
	private Phy8003Repository phy8003Repository;                                                                    
	                                                                                                                
	@Override              
	@Transactional(readOnly=true)
	public PHY8002U01GrdPHY8003Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY8002U01GrdPHY8003Request request) throws Exception {                                                                 
  	   	PhysServiceProto.PHY8002U01GrdPHY8003Response.Builder response = PhysServiceProto.PHY8002U01GrdPHY8003Response.newBuilder();                      
		List<Phy8002U01GrdPhy8003LisItemInfo> list = phy8003Repository.getPhy8002U01GrdPhy8003LisItem(getHospitalCode(vertx, sessionId), request.getKanjaNo(),CommonUtils.parseDouble(request.getFkOcsIrai()));
		if(!CollectionUtils.isEmpty(list)){
			for(Phy8002U01GrdPhy8003LisItemInfo item : list){
				PhysModelProto.PHY8002U01GrdPHY8003LisItemInfo.Builder info = PhysModelProto.PHY8002U01GrdPHY8003LisItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addList(info);
			}
		}
		return response.build();
	}
}