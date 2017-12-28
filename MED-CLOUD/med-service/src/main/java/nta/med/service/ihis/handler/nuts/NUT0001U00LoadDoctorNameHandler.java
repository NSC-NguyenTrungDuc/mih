package nta.med.service.ihis.handler.nuts;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NutsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class NUT0001U00LoadDoctorNameHandler extends ScreenHandler<NutsServiceProto.NUT0001U00LoadDoctorNameRequest, NutsServiceProto.NUT0001U00LoadDoctorNameResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(NUT0001U00LoadDoctorNameHandler.class);                                    
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public NutsServiceProto.NUT0001U00LoadDoctorNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NutsServiceProto.NUT0001U00LoadDoctorNameRequest request) throws Exception {
		NutsServiceProto.NUT0001U00LoadDoctorNameResponse.Builder response = NutsServiceProto.NUT0001U00LoadDoctorNameResponse.newBuilder(); 
		String result = bas0260Repository.getDoctorNameItemInfo(request.getParam(), new Date(), getHospitalCode(vertx, sessionId));
		if(!StringUtils.isEmpty(result)){
			response.setResult(result);
		}
		return response.build();
	}                                                                                                            
}