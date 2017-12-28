package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0106Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.FnCplLoadDupGrdHangmogInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.FnCplLoadDupGrdHangmogRequest;
import nta.med.service.ihis.proto.SystemServiceProto.FnCplLoadDupGrdHangmogResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class FnCplLoadDupGrdHangmogHandler
	extends ScreenHandler<SystemServiceProto.FnCplLoadDupGrdHangmogRequest, SystemServiceProto.FnCplLoadDupGrdHangmogResponse> {                     
	@Resource                                                                                                       
	private Cpl0106Repository cpl0106Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public FnCplLoadDupGrdHangmogResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			FnCplLoadDupGrdHangmogRequest request) throws Exception {                                                                
  	   	SystemServiceProto.FnCplLoadDupGrdHangmogResponse.Builder response = SystemServiceProto.FnCplLoadDupGrdHangmogResponse.newBuilder();                      
		String getGrdHangmog ="";
		for(FnCplLoadDupGrdHangmogInfo item : request.getFnCplInfoList()){
			 getGrdHangmog = cpl0106Repository.callFnCplLoadDupGrdHangmog(getHospitalCode(vertx, sessionId),item.getHangmogCode1(),item.getSpecimenCode1(),
				item.getHangmogCode2(),item.getSpecimenCode2());
			if(!getGrdHangmog.equals("0")){
				break;
			}
		}
		if(!StringUtils.isEmpty(getGrdHangmog)){
			response.setResult(getGrdHangmog);
		}
		return response.build();
	}
}