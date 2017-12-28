package nta.med.service.ihis.handler.phys;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur7001Repository;
import nta.med.data.model.ihis.phys.PHY2001U04GrdPatientListRowFocusChangedInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04LayNUR7001Request;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04LayNUR7001Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY2001U04LayNUR7001Handler
	extends ScreenHandler<PhysServiceProto.PHY2001U04LayNUR7001Request, PhysServiceProto.PHY2001U04LayNUR7001Response>{                     
	@Resource                                                                                                       
	private Nur7001Repository nur7001Repository;                                                                    
	                                                                                                                
	@Override        
	@Transactional(readOnly=true)
	public PHY2001U04LayNUR7001Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY2001U04LayNUR7001Request request) throws Exception {                                                                   
  	   	PhysServiceProto.PHY2001U04LayNUR7001Response.Builder response = PhysServiceProto.PHY2001U04LayNUR7001Response.newBuilder();                      
    	Date measureDate = DateUtil.toDate(request.getMeasureDate(), DateUtil.PATTERN_YYMMDD );
		List<PHY2001U04GrdPatientListRowFocusChangedInfo> listGrd = nur7001Repository.getGrdPatientListRowFocusChangedInfo(getHospitalCode(vertx, sessionId), request.getBunho(), measureDate);
		if(!CollectionUtils.isEmpty(listGrd)){
			for(PHY2001U04GrdPatientListRowFocusChangedInfo item : listGrd){
				PhysModelProto.PHY2001U04LayNUR7001Info.Builder info = PhysModelProto.PHY2001U04LayNUR7001Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayNurItem(info);
			}
		}
		return response.build();
	}
}