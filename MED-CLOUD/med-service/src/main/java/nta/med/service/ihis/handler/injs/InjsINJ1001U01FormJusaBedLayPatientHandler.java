package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.inj.Inj0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class InjsINJ1001U01FormJusaBedLayPatientHandler extends ScreenHandler<InjsServiceProto.INJ1001U01FormJusaBedLayPatientRequest, InjsServiceProto.INJ1001U01FormJusaBedLayPatientResponse> {
	private static final Log LOGGER = LogFactory.getLog(InjsINJ1001U01FormJusaBedLayPatientHandler.class);
	@Resource
	private Inj0102Repository inj0102Repository;
	
	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ1001U01FormJusaBedLayPatientResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1001U01FormJusaBedLayPatientRequest request) throws Exception {
		InjsServiceProto.INJ1001U01FormJusaBedLayPatientResponse.Builder response = InjsServiceProto.INJ1001U01FormJusaBedLayPatientResponse.newBuilder();
		List<String> getCodeName = inj0102Repository.getINJ1001U01FormJusaBedLayPatientRequest(getHospitalCode(vertx, sessionId), request.getCodeName(), getLanguage(vertx, sessionId));
        if(!CollectionUtils.isEmpty(getCodeName)){
        	for(String item : getCodeName){
        		response.addCodeName(item);
        	}
        }
		return response.build();
	}
}
