package nta.med.service.orca.handler;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.oif.Oif1101Repository;
import nta.med.data.model.ihis.orca.ORCALibGetClaimPatientInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.orca.proto.OrcaModelProto;
import nta.med.service.orca.proto.OrcaServiceProto;
import nta.med.service.orca.proto.OrcaServiceProto.ORCALibGetClaimPatientRequest;
import nta.med.service.orca.proto.OrcaServiceProto.ORCALibGetClaimPatientResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ORCALibGetClaimPatientHandler extends ScreenHandler<OrcaServiceProto.ORCALibGetClaimPatientRequest, OrcaServiceProto.ORCALibGetClaimPatientResponse>{                    
	private static final Log LOGGER = LogFactory.getLog(ORCALibGetClaimPatientHandler.class);                                    
	@Resource                                                                                                       
	private Oif1101Repository oif1101Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public ORCALibGetClaimPatientResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			ORCALibGetClaimPatientRequest request) throws Exception {
		OrcaServiceProto.ORCALibGetClaimPatientResponse.Builder response = OrcaServiceProto.ORCALibGetClaimPatientResponse.newBuilder();
		List<ORCALibGetClaimPatientInfo> listClaim = oif1101Repository.getORCALibGetClaimPatientInfo(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getFkoif1101()));
		if(!CollectionUtils.isEmpty(listClaim)){
			for(ORCALibGetClaimPatientInfo item : listClaim){
				OrcaModelProto.ORCALibGetClaimPatientInfo.Builder info = OrcaModelProto.ORCALibGetClaimPatientInfo.newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
    			if (item.getPkoif1101() != null) {
    				info.setPkoif1101(String.format("%.0f",item.getPkoif1101()));
    			}
    			if (item.getPkoif1102() != null) {
    				info.setPkoif1102(String.format("%.0f",item.getPkoif1102()));
    			}
    			if (item.getPkoif1103() != null) {
    				info.setPkoif1103(String.format("%.0f",item.getPkoif1103()));
    			}
				response.addPatItem(info);
    		}
		}
		return response.build();
	}                                                                                                                 
}