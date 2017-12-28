package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0304Repository;
import nta.med.data.model.ihis.ocsa.OcsaOCS0304U00GrdOCS0306ListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0304U00GrdOCS0306Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0304U00GrdOCS0306Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0304U00GrdOCS0306Handler
	extends ScreenHandler<OcsaServiceProto.OCS0304U00GrdOCS0306Request, OcsaServiceProto.OCS0304U00GrdOCS0306Response> {                     
	@Resource                                                                                                       
	private Ocs0304Repository ocs0304Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly = true)
	public OCS0304U00GrdOCS0306Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0304U00GrdOCS0306Request request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0304U00GrdOCS0306Response.Builder response = OcsaServiceProto.OCS0304U00GrdOCS0306Response.newBuilder();                      
		List<OcsaOCS0304U00GrdOCS0306ListInfo> list = ocs0304Repository.getOcsaOCS0304U00GrdOCS0306ListInfo(getHospitalCode(vertx, sessionId),"1",
            		request.getDoctor(),request.getYaksokDirectCode());
        if (!CollectionUtils.isEmpty(list)) {
            for (OcsaOCS0304U00GrdOCS0306ListInfo item : list) {
            	OcsaModelProto.OcsaOCS0304U00GrdOCS0306ListInfo.Builder info = OcsaModelProto.OcsaOCS0304U00GrdOCS0306ListInfo.newBuilder();
            	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
            	response.addListInfo(info);
            }
        }
        return response.build();
	}

}