package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
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
public class OcsoOCS1003P01DeleteFromOCS1003Handler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01DeleteFromOCS1003Request, SystemServiceProto.UpdateResponse>{
	private static final Log logger = LogFactory.getLog(OcsoOCS1003P01DeleteFromOCS1003Handler.class);
	
	@Resource
	private Ocs1003Repository ocs1003Repository;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01DeleteFromOCS1003Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = deleteOut1003(request , getHospitalCode(vertx, sessionId));
        response.setResult(result);
		return response.build();
	}
	
	private boolean deleteOut1003(OcsoServiceProto.OcsoOCS1003P01DeleteFromOCS1003Request request, String hospCode){
		Double pkocs1003 = CommonUtils.parseDouble(request.getPkocskey());
		if( ocs1003Repository.deleteOcsoOCS1003P01DeleteFromOCS1003(pkocs1003, hospCode) > 0)
			return true;
			return false;
	}
}
