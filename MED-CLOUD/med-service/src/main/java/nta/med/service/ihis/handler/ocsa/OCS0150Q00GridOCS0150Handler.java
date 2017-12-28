package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0150Repository;
import nta.med.data.model.ihis.ocsa.OCS0150Q00GridOCS0150Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0150Q00GridOCS0150Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0150Q00GridOCS0150Response;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0150Q00GridOCS0150Handler
	extends ScreenHandler<OcsaServiceProto.OCS0150Q00GridOCS0150Request, OcsaServiceProto.OCS0150Q00GridOCS0150Response> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0150Q00GridOCS0150Handler.class);                                    
	@Resource                                                                                                       
	private Ocs0150Repository ocs0150Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly = true)
	public OCS0150Q00GridOCS0150Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0150Q00GridOCS0150Request request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0150Q00GridOCS0150Response.Builder response = OcsaServiceProto.OCS0150Q00GridOCS0150Response.newBuilder();                      
    	List<OCS0150Q00GridOCS0150Info> listGrd=ocs0150Repository.getOCS0150Q00GridOCS0150Info(getHospitalCode(vertx, sessionId),
    			getLanguage(vertx, sessionId), request.getDoctor(), request.getGwa(), request.getIoGubun(),DateUtil.toDate(request.getOrderDate(),DateUtil.PATTERN_YYMMDD));
    	if(!CollectionUtils.isEmpty(listGrd)){
    		for(OCS0150Q00GridOCS0150Info item : listGrd){
    			OcsaModelProto.OCS0150Q00GridOCS0150Info.Builder info =OcsaModelProto.OCS0150Q00GridOCS0150Info.newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
    			info.setPotionDrugOrder(item.getPotionDrugYn());
    			info.setDiseaseNameUnregistered(item.getDiseaseUnregisteredYn());
    			info.setInfection(item.getInfectionPopYn());
				response.addGridOcs0150Info(info);
    		}
    	}
    	return response.build();
	}

}