package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur1017Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class NUR1017U00LayValidationDupchkHandler extends ScreenHandler<NuriServiceProto.NUR1017U00LayValidationDupchkRequest, NuriServiceProto.NUR1017U00LayValidationDupchkResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(NUR1017U00LayValidationDupchkHandler.class);                                        
	@Resource                                                                                                       
	private Nur1017Repository nur1017Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1017U00LayValidationDupchkResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NUR1017U00LayValidationDupchkRequest request) throws Exception {
		NuriServiceProto.NUR1017U00LayValidationDupchkResponse.Builder response = NuriServiceProto.NUR1017U00LayValidationDupchkResponse.newBuilder();
		String result = nur1017Repository.getNUR1017U00LayValidationDupchk(getHospitalCode(vertx, sessionId), request.getInfeCode(), request.getBunho(), request.getStartDate());
		if(!StringUtils.isEmpty(result)){
			response.setYValue(result);
		}
		return response.build();
	}                                                                                                               
}                                                                                                                 
