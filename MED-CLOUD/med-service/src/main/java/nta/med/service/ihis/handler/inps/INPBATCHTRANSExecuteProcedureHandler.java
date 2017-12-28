package nta.med.service.ihis.handler.inps;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPBATCHTRANSExecuteProcedureRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INPBATCHTRANSExecuteProcedureResponse;
import nta.med.service.ihis.proto.InpsServiceProto.INPBATCHTRANScbxBuseoRequest;

@Service
@Scope("prototype")
public class INPBATCHTRANSExecuteProcedureHandler extends ScreenHandler<InpsServiceProto.INPBATCHTRANSExecuteProcedureRequest, InpsServiceProto.INPBATCHTRANSExecuteProcedureResponse>{
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INPBATCHTRANSExecuteProcedureResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPBATCHTRANSExecuteProcedureRequest request) throws Exception {
		InpsServiceProto.INPBATCHTRANSExecuteProcedureResponse.Builder response = InpsServiceProto.INPBATCHTRANSExecuteProcedureResponse.newBuilder();
		
		return response.build();
	}

}
