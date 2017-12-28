package nta.med.service.ihis.handler.phys;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.phys.PHY0001U00GrdRehaSinryouryouCodeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY0001U00GrdRehaSinryouryouCodeRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY0001U00GrdRehaSinryouryouCodeResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
public class PHY0001U00GrdRehaSinryouryouCodeHandler
	extends ScreenHandler<PhysServiceProto.PHY0001U00GrdRehaSinryouryouCodeRequest, PhysServiceProto.PHY0001U00GrdRehaSinryouryouCodeResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override      
	@Transactional(readOnly=true)
	public PHY0001U00GrdRehaSinryouryouCodeResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			PHY0001U00GrdRehaSinryouryouCodeRequest request) throws Exception {                                                                   
                                                                                                             
  	   	PhysServiceProto.PHY0001U00GrdRehaSinryouryouCodeResponse.Builder response = PhysServiceProto.PHY0001U00GrdRehaSinryouryouCodeResponse.newBuilder();                      
		List<PHY0001U00GrdRehaSinryouryouCodeInfo> listGrd = ocs0132Repository.getPHY0001U00GrdRehaSinryouryouCodeInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "REHA_SINRYOURYOU");
		if(!CollectionUtils.isEmpty(listGrd)){
			for(PHY0001U00GrdRehaSinryouryouCodeInfo item : listGrd){
				PhysModelProto.PHY0001U00GrdRehaSinryouryouCodeInfo.Builder info= PhysModelProto.PHY0001U00GrdRehaSinryouryouCodeInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
		        response.addGrdInfo(info);
			}
		}
		return response.build();
	}
}
