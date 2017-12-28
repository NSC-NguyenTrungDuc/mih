package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0212Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;


@Service
@Scope("prototype")
public class NuroOUT0101U02GetInsuranceNameHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02GetInsuranceNameRequest, NuroServiceProto.NuroOUT0101U02GetInsuranceNameResponse>{
	@Resource
	private Bas0212Repository bas0212Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOUT0101U02GetInsuranceNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02GetInsuranceNameRequest request) throws Exception {
		NuroServiceProto.NuroOUT0101U02GetInsuranceNameResponse.Builder response = NuroServiceProto.NuroOUT0101U02GetInsuranceNameResponse.newBuilder();
		String  nuroOUT0101U02GetInsuranceName = bas0212Repository.getNuroOUT0101U02GetInsuranceName(request.getGongbiCode(), getLanguage(vertx, sessionId));
		if(nuroOUT0101U02GetInsuranceName != null && !nuroOUT0101U02GetInsuranceName.isEmpty()){
			response.setGongbiName(nuroOUT0101U02GetInsuranceName);
		}
		return response.build();
	}

}
