package nta.med.service.ihis.handler.drgs;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99FnAdmMsgHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99FnAdmMsgRequest, SystemServiceProto.StringResponse>{
	
	@Override
    @Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99FnAdmMsgRequest request) throws Exception{
	
		return null;
	}
}