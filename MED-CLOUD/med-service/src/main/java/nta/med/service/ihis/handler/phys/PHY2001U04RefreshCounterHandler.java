package nta.med.service.ihis.handler.phys;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.phys.PHY2001U04RefreshCounterInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04RefreshCounterRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04RefreshCounterResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY2001U04RefreshCounterHandler
	extends ScreenHandler<PhysServiceProto.PHY2001U04RefreshCounterRequest, PhysServiceProto.PHY2001U04RefreshCounterResponse> {                     
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override     
	@Transactional(readOnly=true)
	public PHY2001U04RefreshCounterResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			PHY2001U04RefreshCounterRequest request) throws Exception {                                                                 
  	   	PhysServiceProto.PHY2001U04RefreshCounterResponse.Builder response = PhysServiceProto.PHY2001U04RefreshCounterResponse.newBuilder();                      
    	Date naewonDate = DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
		List<PHY2001U04RefreshCounterInfo> listCounter = out1001Repository.getPHY2001U04RefreshCounterInfo(getHospitalCode(vertx, sessionId), request.getGwa(), naewonDate);
		if(!CollectionUtils.isEmpty(listCounter)){
			for(PHY2001U04RefreshCounterInfo item : listCounter){
				PhysModelProto.PHY2001U04RefreshCounterInfo.Builder info = PhysModelProto.PHY2001U04RefreshCounterInfo.newBuilder();
				if (item.getG1() != null) {
					info.setG1(item.getG1().toString());
				}
				if (item.getG2() != null) {
					info.setG2(item.getG2().toString());
				}
				if (item.getSa() != null) {
					info.setSa(item.getSa().toString());
				}
				if (item.getRe() != null) {
					info.setRe(item.getRe().toString());
				}
				response.addRefCounterItem(info);
			}
		}
		return response.build();
	}
}