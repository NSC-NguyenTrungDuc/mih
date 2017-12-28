package nta.med.service.ihis.handler.drgs;

import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Service
@Scope("prototype")
public class DRG0201U00BarCodeHandler extends ScreenHandler<DrgsServiceProto.DRG0201U00BarCodeRequest, DrgsServiceProto.DRG0201U00BarCodeResponse> {
	private static final Log LOG = LogFactory.getLog(DRG0201U00BarCodeHandler.class);
	@Resource
	private Drg2010Repository drg2010Repository;

	@Override
	@Transactional(readOnly = true)
	public DrgsServiceProto.DRG0201U00BarCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0201U00BarCodeRequest request) throws Exception {
		//TODO implement this
		DrgsServiceProto.DRG0201U00BarCodeResponse.Builder response = DrgsServiceProto.DRG0201U00BarCodeResponse.newBuilder();
		return response.build();
	}
}
