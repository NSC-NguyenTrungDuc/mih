package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01LayPatInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsoOCS1003P01LayPatHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01LayPatRequest, OcsoServiceProto.OcsoOCS1003P01LayPatResponse> {
	private static final Log LOG = LogFactory.getLog(OcsoOCS1003P01LayPatHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01LayPatResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01LayPatRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01LayPatResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01LayPatResponse.newBuilder();
		List<OcsoOCS1003P01LayPatInfo> listInfo = out1001Repository.getOcsoOCS1003P01LayPatInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), 
				request.getFDoctor(), request.getFBunho(), request.getFNaewonDate(), request.getFLoginDoctorYn());
    	if (listInfo != null && !listInfo.isEmpty()) {
			for (OcsoOCS1003P01LayPatInfo obj : listInfo) {
				OcsoModelProto.OcsoOCS1003P01LayPatInfo.Builder itemBuilder = OcsoModelProto.OcsoOCS1003P01LayPatInfo.newBuilder();
				BeanUtils.copyProperties(obj, itemBuilder, getLanguage(vertx, sessionId));
				response.addLayPatInfo(itemBuilder);
			}
    	}
		return response.build();
	}

}
