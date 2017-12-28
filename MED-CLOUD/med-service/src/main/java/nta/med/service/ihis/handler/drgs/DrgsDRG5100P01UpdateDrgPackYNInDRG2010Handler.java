package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Transactional
@Service
@Scope("prototype")
public class DrgsDRG5100P01UpdateDrgPackYNInDRG2010Handler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01UpdateDrgPackYNInDRG2010Request, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01UpdateDrgPackYNInDRG2010Handler.class);
	@Resource
	private Drg2010Repository drg2010Repository;

	private boolean updateDrgsDRG5100P01UpdateDrgPackYNInDRG2010(DrgsServiceProto.DrgsDRG5100P01UpdateDrgPackYNInDRG2010Request request, String hospitalCode) throws Exception {
		try {
			Double fkocs1003 = CommonUtils.parseDouble(request.getFkocs1003());
			if(drg2010Repository.updateDrgsDRG5100P01UpdateDrgPackYNInDRG2010(request.getDrgPackYn(), hospitalCode, fkocs1003) > 0)
				return true;
		} catch (Exception e) {
			LOG.error(e.getMessage(), e);
			return false;
		}
		return false;
	}

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01UpdateDrgPackYNInDRG2010Request request) throws Exception {
		boolean result = updateDrgsDRG5100P01UpdateDrgPackYNInDRG2010(request, getHospitalCode(vertx, sessionId));
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		response.setResult(result);
		return response.build();
	}
}
