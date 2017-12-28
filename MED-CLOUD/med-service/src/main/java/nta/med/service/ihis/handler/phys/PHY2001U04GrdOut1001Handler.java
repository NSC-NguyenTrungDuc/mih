package nta.med.service.ihis.handler.phys;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.phys.PHY2001U04GrdOut1001Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04GrdOut1001Request;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04GrdOut1001Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY2001U04GrdOut1001Handler
	extends ScreenHandler<PhysServiceProto.PHY2001U04GrdOut1001Request, PhysServiceProto.PHY2001U04GrdOut1001Response> {                     
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override 
	@Transactional(readOnly=true)
	public PHY2001U04GrdOut1001Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY2001U04GrdOut1001Request request) throws Exception {                                                                  
  	   	PhysServiceProto.PHY2001U04GrdOut1001Response.Builder response = PhysServiceProto.PHY2001U04GrdOut1001Response.newBuilder();                      
    	Date naewonDate = DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
    	List<PHY2001U04GrdOut1001Info> listGrd = out1001Repository.getPHY2001U04GrdOut1001Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getGwa(), request.getBunho(), naewonDate);
  		if(!CollectionUtils.isEmpty(listGrd)){
  			for(PHY2001U04GrdOut1001Info item : listGrd){
  				PhysModelProto.PHY2001U04GrdOut1001Info.Builder info = PhysModelProto.PHY2001U04GrdOut1001Info.newBuilder();
  				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdOut1001Item(info);
  			}
  		}
  		return response.build();
	}
}