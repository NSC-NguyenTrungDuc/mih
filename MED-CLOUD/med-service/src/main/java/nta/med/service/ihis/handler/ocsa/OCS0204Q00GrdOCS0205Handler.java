package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0205Repository;
import nta.med.data.model.ihis.ocsa.Ocs0204Q00GrdOcs0205ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0204Q00GrdOCS0205Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0204Q00GrdOCS0205Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
public class OCS0204Q00GrdOCS0205Handler 
	extends ScreenHandler<OcsaServiceProto.OCS0204Q00GrdOCS0205Request, OcsaServiceProto.OCS0204Q00GrdOCS0205Response> {                     
	@Resource                                                                                                       
	private Ocs0205Repository ocs0205Repository;                                                                    
	                                                                                                                
	@Override                
	@Transactional(readOnly = true)
	public OCS0204Q00GrdOCS0205Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0204Q00GrdOCS0205Request request) throws Exception {                                                                
  	   	OcsaServiceProto.OCS0204Q00GrdOCS0205Response.Builder response = OcsaServiceProto.OCS0204Q00GrdOCS0205Response.newBuilder();                      
		List<Ocs0204Q00GrdOcs0205ListItemInfo> listGrd = ocs0205Repository.getOcs0204Q00GrdOcs0205ListItemInfo(getHospitalCode(vertx, sessionId), request.getMemb(), request.getSangGubun(), request.getSangNameInx());
		if(!CollectionUtils.isEmpty(listGrd)){
			for(Ocs0204Q00GrdOcs0205ListItemInfo item : listGrd){
				OcsaModelProto.Ocs0204Q00GrdOcs0205ListItemInfo.Builder info = OcsaModelProto.Ocs0204Q00GrdOcs0205ListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if(item.getPkSeq() != null){
					info.setPkSeq(String.format("%.0f", item.getPkSeq()));
				}
				if(item.getSer() != null){
					info.setSer(String.format("%.0f", item.getSer()));
				}
				response.addGrdocs0205Info(info);
			}
		}
		return response.build();
	}
}
