package nta.med.service.ihis.handler.phys;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.phys.PHY2001U04GrdPatientListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04GrdPatientListRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04GrdPatientListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY2001U04GrdPatientListHandler 
	extends ScreenHandler<PhysServiceProto.PHY2001U04GrdPatientListRequest, PhysServiceProto.PHY2001U04GrdPatientListResponse> {                     
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly=true)
	public PHY2001U04GrdPatientListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			PHY2001U04GrdPatientListRequest request) throws Exception {                                                                  
  	   	PhysServiceProto.PHY2001U04GrdPatientListResponse.Builder response = PhysServiceProto.PHY2001U04GrdPatientListResponse.newBuilder();                      
		List<PHY2001U04GrdPatientListInfo> listGrd = out1001Repository.getPHY2001U04GrdPatientListInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getNaewonDate(), request.getGwa(), request.getDoctor(), request.getBunho(),
				request.getJubsuGubun(), request.getJinryoYn() , request.getNaewonYn(), request.getSysId());
		if(!CollectionUtils.isEmpty(listGrd)){
			for(PHY2001U04GrdPatientListInfo item : listGrd){
				PhysModelProto.PHY2001U04GrdPatientListInfo.Builder info = PhysModelProto.PHY2001U04GrdPatientListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdPatientItem(info);
			}
		}
		return response.build();
	}
}