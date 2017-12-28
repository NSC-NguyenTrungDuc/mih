package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class OcsoOCS1003P01UpdateDoctorHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01UpdateDoctorRequest, SystemServiceProto.UpdateResponse> {
private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01UpdateDoctorHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01UpdateDoctorRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = updateOcsoOCS1003P01UpdateDoctor(request, getHospitalCode(vertx, sessionId));
		response.setResult(result);
		return response.build();
	}
	
	private boolean updateOcsoOCS1003P01UpdateDoctor(OcsoServiceProto.OcsoOCS1003P01UpdateDoctorRequest request, String hospCode){
		Double pkout1001 = CommonUtils.parseDouble(request.getPkNaewon());
		if(out1001Repository.updateOcsoOCS1003P01UpdateDoctor(request.getDoctor(), request.getGwa(), hospCode, pkout1001) > 0)
			return true;
			return false;
	}

}
