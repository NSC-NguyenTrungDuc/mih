package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0131Repository;
import nta.med.data.model.ihis.adma.Ocs0131U01Grd0131ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.Ocs0131U01Grd0131Request;
import nta.med.service.ihis.proto.OcsaServiceProto.Ocs0131U01Grd0131Response;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
public class Ocs0131U01Grd0131Handler
	extends ScreenHandler<OcsaServiceProto.Ocs0131U01Grd0131Request, OcsaServiceProto.Ocs0131U01Grd0131Response> {                     
	private static final Log LOGGER = LogFactory.getLog(Ocs0131U01Grd0131Handler.class);                                    
	@Resource                                                                                                       
	private Ocs0131Repository ocs0131Repository;                                                                    
	                                                                                                                
	@Override       
	@Transactional(readOnly = true)
	public Ocs0131U01Grd0131Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId, Ocs0131U01Grd0131Request request)
			throws Exception {                                                                   
  	   	OcsaServiceProto.Ocs0131U01Grd0131Response.Builder response = OcsaServiceProto.Ocs0131U01Grd0131Response.newBuilder();                      
		List<Ocs0131U01Grd0131ListItemInfo> listGrd = ocs0131Repository.getOcs0131U01Grd0131ListItemInfo(request.getCodeType(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listGrd)){
			for(Ocs0131U01Grd0131ListItemInfo item : listGrd){
				OcsaModelProto.Ocs0131U01Grd0131ListItemInfo.Builder info = OcsaModelProto.Ocs0131U01Grd0131ListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrd0131Info(info);
			}
		}
		return response.build();
	}

}
