package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.OutsangRepository;
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
public class OcsoOCS1003P01DeleteFromOutsangHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01DeleteFromOutsangRequest, SystemServiceProto.UpdateResponse>{
	private static final Log logger = LogFactory.getLog(OcsoOCS1003P01DeleteFromOutsangHandler.class);
	
	@Resource
	private OutsangRepository outsangRepository;
	
	private boolean deleteOutsang(OcsoServiceProto.OcsoOCS1003P01DeleteFromOutsangRequest request, String hospCode) {
			Double pkSeq= CommonUtils.parseDouble(request.getPkSeq());
			if( outsangRepository.deleteOcsoOCS1003P01DeleteFromOutsang(request.getBunho(), request.getGwa(), request.getIoGubun(), pkSeq, hospCode) > 0)
				return true;
				return false;
	}

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01DeleteFromOutsangRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = deleteOutsang(request, getHospitalCode(vertx, sessionId));
        response.setResult(result);
		return response.build();
	}
}
