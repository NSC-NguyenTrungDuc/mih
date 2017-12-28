package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroGetDoctorNameBAS0270Handler extends ScreenHandler<NuroServiceProto.NuroGetDoctorNameBAS0270Request, NuroServiceProto.NuroGetDoctorNameBAS0270Response> {
	private static final Log LOG = LogFactory.getLog(NuroGetDoctorNameBAS0270Handler.class);
	
	@Resource
	private Bas0270Repository bas0270Repository;

	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroGetDoctorNameBAS0270Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroGetDoctorNameBAS0270Request request) throws Exception {
		NuroServiceProto.NuroGetDoctorNameBAS0270Response.Builder response = NuroServiceProto.NuroGetDoctorNameBAS0270Response.newBuilder();
		String retVal = bas0270Repository.getDoctorNameBAS0270(getHospitalCode(vertx, sessionId), request.getGwa(), request.getDoctor(), request.getNaewonDate());
    	if(!StringUtils.isEmpty(retVal)){
    		response.setRetValue(retVal);
    	}
		return response.build();
	}

}
