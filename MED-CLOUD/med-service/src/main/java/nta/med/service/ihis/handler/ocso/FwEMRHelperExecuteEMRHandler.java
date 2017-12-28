package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class FwEMRHelperExecuteEMRHandler extends ScreenHandler<OcsoServiceProto.FwEMRHelperExecuteEMRRequest, SystemServiceProto.StringResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(FwEMRHelperExecuteEMRHandler.class);                                    
	@Resource                                                                                                       
	private Bas0270Repository bas0270Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.FwEMRHelperExecuteEMRRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String doctor =  bas0270Repository.getDoctorBySabunAndDoctorGwa(getHospitalCode(vertx, sessionId), request.getUserId(), request.getGwa());
		if(!StringUtils.isEmpty(doctor)){
			response.setResult(doctor);
		}
		return response.build();
	}                                                                                                                 
}