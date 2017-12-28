package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.ocsa.Ocs0131U01Grd0132ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.Ocs0131U01Grd0132Request;
import nta.med.service.ihis.proto.OcsaServiceProto.Ocs0131U01Grd0132Response;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class Ocs0131U01Grd0132Handler
	extends ScreenHandler<OcsaServiceProto.Ocs0131U01Grd0132Request, OcsaServiceProto.Ocs0131U01Grd0132Response> {                     
	private static final Log LOGGER = LogFactory.getLog(Ocs0131U01Grd0132Handler.class);                                    
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override        
	@Transactional(readOnly = true)
	public Ocs0131U01Grd0132Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId, Ocs0131U01Grd0132Request request)
			throws Exception {                                                               
  	   	OcsaServiceProto.Ocs0131U01Grd0132Response.Builder response = OcsaServiceProto.Ocs0131U01Grd0132Response.newBuilder();                      
		List<Ocs0131U01Grd0132ListItemInfo> listGrd = ocs0132Repository.getOcs0131U01Grd0132ListItemInfo(request.getCodeType(), 
				getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listGrd)){
			for(Ocs0131U01Grd0132ListItemInfo item : listGrd){
				OcsaModelProto.Ocs0131U01Grd0132ListItemInfo.Builder info = OcsaModelProto.Ocs0131U01Grd0132ListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrd0132Info(info);
			}
		}
		return response.build();
	}
}
