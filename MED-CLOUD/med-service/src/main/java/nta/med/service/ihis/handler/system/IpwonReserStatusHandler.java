package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.IpwonReserStatusInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.IpwonReserStatusRequest;
import nta.med.service.ihis.proto.SystemServiceProto.IpwonReserStatusResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class IpwonReserStatusHandler
	extends ScreenHandler<SystemServiceProto.IpwonReserStatusRequest, SystemServiceProto.IpwonReserStatusResponse> {                     
	@Resource                                                                                                       
	private Inp1003Repository inp1003Repository;
	
	@Override
	@Transactional(readOnly = true)
	public IpwonReserStatusResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, IpwonReserStatusRequest request)
			throws Exception {                                                                 
  	   	SystemServiceProto.IpwonReserStatusResponse.Builder response = SystemServiceProto.IpwonReserStatusResponse.newBuilder();
		IpwonReserStatusInfo info = request.getReserStatusInfo();
		String result = inp1003Repository.getIpwonReserStatus(getHospitalCode(vertx, sessionId), info.getDoctor().substring(2), info.getBunho());
		if(!StringUtils.isEmpty(result)){
			response.setRetValue(result);
		}
		return response.build();
	}
	
}
