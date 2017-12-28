package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.system.PrOcsLoadNaewonInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.PrOcsLoadNaewonInfoRequest;
import nta.med.service.ihis.proto.SystemServiceProto.PrOcsLoadNaewonInfoResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PrOcsLoadNaewonInfoHandler extends ScreenHandler<SystemServiceProto.PrOcsLoadNaewonInfoRequest, SystemServiceProto.PrOcsLoadNaewonInfoResponse> {                     
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional
	public PrOcsLoadNaewonInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PrOcsLoadNaewonInfoRequest request)
			throws Exception {                                                                   
  	   	SystemServiceProto.PrOcsLoadNaewonInfoResponse.Builder response = SystemServiceProto.PrOcsLoadNaewonInfoResponse.newBuilder();                      
		PrOcsLoadNaewonInfo item = out0101Repository.callPrOcsLoadNaewonInfo(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getNaewonKey()));
		if(item != null){
			CommonModelProto.PrOcsLoadNaewonInfo.Builder info = CommonModelProto.PrOcsLoadNaewonInfo.newBuilder();
			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
			response.addNaewonItem(info);
		}
		return response.build();
	}
}