package nta.med.service.ihis.handler.phys;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.phys.PHY2001U04GrdExcelInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04GrdExcelRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04GrdExcelResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY2001U04GrdExcelHandler
	extends ScreenHandler<PhysServiceProto.PHY2001U04GrdExcelRequest, PhysServiceProto.PHY2001U04GrdExcelResponse> {                     
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override 
	@Transactional(readOnly=true)
	public PHY2001U04GrdExcelResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PHY2001U04GrdExcelRequest request)
			throws Exception {                                                                   
  	   	PhysServiceProto.PHY2001U04GrdExcelResponse.Builder response = PhysServiceProto.PHY2001U04GrdExcelResponse.newBuilder();                      
		List<PHY2001U04GrdExcelInfo> listGrd = out1001Repository.getPHY2001U04GrdExcelInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getNaewonDate(), request.getGwa(), request.getDoctor(), request.getBunho(), request.getJubsuGubun(), request.getJinryoYn(), request.getNaewonYn());
		if(!CollectionUtils.isEmpty(listGrd)){
			for(PHY2001U04GrdExcelInfo item : listGrd){
				PhysModelProto.PHY2001U04GrdExcelInfo.Builder info = PhysModelProto.PHY2001U04GrdExcelInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdExcelItem(info);
			}
		}
		return response.build();
	}
}