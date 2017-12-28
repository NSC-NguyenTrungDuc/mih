package nta.med.service.orca.handler;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.oif.Oif2101Repository;
import nta.med.data.model.ihis.orca.ORCALibGetClaimInsuredInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.orca.proto.OrcaModelProto;
import nta.med.service.orca.proto.OrcaServiceProto;
import nta.med.service.orca.proto.OrcaServiceProto.ORCALibGetClaimInsuredRequest;
import nta.med.service.orca.proto.OrcaServiceProto.ORCALibGetClaimInsuredResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ORCALibGetClaimInsuredHandler extends ScreenHandler<OrcaServiceProto.ORCALibGetClaimInsuredRequest, OrcaServiceProto.ORCALibGetClaimInsuredResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(ORCALibGetClaimInsuredHandler.class);                                    
	@Resource                                                                                                       
	private Oif2101Repository oif2101Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public ORCALibGetClaimInsuredResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			ORCALibGetClaimInsuredRequest request) throws Exception {
		OrcaServiceProto.ORCALibGetClaimInsuredResponse.Builder response = OrcaServiceProto.ORCALibGetClaimInsuredResponse.newBuilder();
		List<ORCALibGetClaimInsuredInfo > listClaim = oif2101Repository.getORCALibGetClaimInsuredInfo(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getFkoif1101()));
		if(!CollectionUtils.isEmpty(listClaim)){
			for(ORCALibGetClaimInsuredInfo  item : listClaim){
				OrcaModelProto.ORCALibGetClaimInsuredInfo .Builder info = OrcaModelProto.ORCALibGetClaimInsuredInfo .newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addClaimInsItem(info);
    		}
		}
		return response.build();
	}                                                                                                                 
}