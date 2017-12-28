package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0212Repository;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GetInsuranceCode;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroOUT0101U02GetInsuranceCodeHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02GetInsuranceRequest, NuroServiceProto.NuroOUT0101U02GetInsuranceResponse> {
	@Resource
	private Bas0212Repository bas0212Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOUT0101U02GetInsuranceResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02GetInsuranceRequest request) throws Exception {
		NuroServiceProto.NuroOUT0101U02GetInsuranceResponse.Builder response = NuroServiceProto.NuroOUT0101U02GetInsuranceResponse.newBuilder();
		List<NuroOUT0101U02GetInsuranceCode> listNuroOUT0101U02GetInsuranceInfo = bas0212Repository.getNuroOUT0101U02GetInsuranceCode(request.getLawNo(), getLanguage(vertx, sessionId));
		if(listNuroOUT0101U02GetInsuranceInfo != null && !listNuroOUT0101U02GetInsuranceInfo.isEmpty()){
			for(NuroOUT0101U02GetInsuranceCode item : listNuroOUT0101U02GetInsuranceInfo){
				NuroModelProto.NuroOUT0101U02GetInsuranceCode.Builder nuroGetInsuranceCode = NuroModelProto.NuroOUT0101U02GetInsuranceCode.newBuilder();
				if(item.getInsuranceCode() != null){
					nuroGetInsuranceCode.setInsuranceCode(item.getInsuranceCode());
				}
				
				response.addInsuranceCodeItem(nuroGetInsuranceCode);
			}
		}
		return response.build();
	}

}
