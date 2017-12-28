package nta.med.service.ihis.handler.phys;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.phys.PHY2001U04GrdPaCntInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04GrdPaCntRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04GrdPaCntResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY2001U04GrdPaCntHandler 
	extends ScreenHandler<PhysServiceProto.PHY2001U04GrdPaCntRequest, PhysServiceProto.PHY2001U04GrdPaCntResponse> {                     
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override               
	@Transactional(readOnly=true)
	public PHY2001U04GrdPaCntResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PHY2001U04GrdPaCntRequest request)
			throws Exception {                                                                 
  	   	PhysServiceProto.PHY2001U04GrdPaCntResponse.Builder response = PhysServiceProto.PHY2001U04GrdPaCntResponse.newBuilder();                      
    	Date naewonDate = DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
		List<PHY2001U04GrdPaCntInfo> listGrd =  out1001Repository.getPHY2001U04GrdPaCntInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), naewonDate);
		if(!CollectionUtils.isEmpty(listGrd)){
			for(PHY2001U04GrdPaCntInfo item : listGrd){
				PhysModelProto.PHY2001U04GrdPaCntInfo.Builder info = PhysModelProto.PHY2001U04GrdPaCntInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getPaCnt() != null) {
					info.setPaCnt(item.getPaCnt().toString());
				}
				response.addGrdPaCntItem(info);
			}
		}
		return response.build();
	}

}