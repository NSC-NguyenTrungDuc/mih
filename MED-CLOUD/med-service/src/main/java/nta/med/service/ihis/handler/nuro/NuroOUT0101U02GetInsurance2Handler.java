package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0212Repository;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GetInsuranceInfo2;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;


@Service
@Scope("prototype")
public class NuroOUT0101U02GetInsurance2Handler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02GetInsurance2Request, NuroServiceProto.NuroOUT0101U02GetInsurance2Response> {
	private static final Log LOGGER = LogFactory.getLog(NuroOUT0101U02GetInsurance2Handler.class);
	@Resource
	private Bas0212Repository bas0212Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOUT0101U02GetInsurance2Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02GetInsurance2Request request) throws Exception {
		NuroServiceProto.NuroOUT0101U02GetInsurance2Response.Builder response = NuroServiceProto.NuroOUT0101U02GetInsurance2Response.newBuilder();
		List<NuroOUT0101U02GetInsuranceInfo2> listNuroOUT0101U02GetInsuranceInfo2 = bas0212Repository.getNuroOUT0101U02GetInsuranceInfo2(request.getFind1(), getLanguage(vertx, sessionId));
		if(listNuroOUT0101U02GetInsuranceInfo2 != null && !listNuroOUT0101U02GetInsuranceInfo2.isEmpty()){
			for(NuroOUT0101U02GetInsuranceInfo2 item : listNuroOUT0101U02GetInsuranceInfo2){
				NuroModelProto.NuroOUT0101U02GetInsuranceInfo2.Builder nuroGetInsuranceInfo2 = NuroModelProto.NuroOUT0101U02GetInsuranceInfo2.newBuilder();
				if(item.getInsuranceCode() != null){
					nuroGetInsuranceInfo2.setInsuranceCode(item.getInsuranceCode());
				}
				if(item.getInsuranceName() != null){
					nuroGetInsuranceInfo2.setInsuranceName(item.getInsuranceName());
				}
				response.addInsuranceInfo(nuroGetInsuranceInfo2);
			}
		}
		return response.build();
	}

}
