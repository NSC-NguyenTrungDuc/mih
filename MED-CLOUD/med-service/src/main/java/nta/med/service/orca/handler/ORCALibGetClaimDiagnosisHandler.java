package nta.med.service.orca.handler;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.oif.Oif5101Repository;
import nta.med.data.model.ihis.orca.ORCALibGetClaimDiagnosisInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.orca.proto.OrcaModelProto;
import nta.med.service.orca.proto.OrcaServiceProto;
import nta.med.service.orca.proto.OrcaServiceProto.ORCALibGetClaimDiagnosisRequest;
import nta.med.service.orca.proto.OrcaServiceProto.ORCALibGetClaimDiagnosisResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class ORCALibGetClaimDiagnosisHandler extends ScreenHandler<OrcaServiceProto.ORCALibGetClaimDiagnosisRequest, OrcaServiceProto.ORCALibGetClaimDiagnosisResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(ORCALibGetClaimDiagnosisHandler.class);                                    
	@Resource                                                                                                       
	private Oif5101Repository oif5101Repository;      
	                                                                                                               
	@Override
	public ORCALibGetClaimDiagnosisResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			ORCALibGetClaimDiagnosisRequest request) throws Exception {
		OrcaServiceProto.ORCALibGetClaimDiagnosisResponse.Builder response = OrcaServiceProto.ORCALibGetClaimDiagnosisResponse.newBuilder(); 
		Integer result = null;
		String hospCode = getHospitalCode(vertx, sessionId);
		Double fkoif1101 = CommonUtils.parseDouble(request.getFkoif1101());
		List<ORCALibGetClaimDiagnosisInfo > listClaim = oif5101Repository.getORCALibGetClaimDiagnosisInfo(request.getHospCode(), CommonUtils.parseDouble(request.getFkoif1101()));
		if(!CollectionUtils.isEmpty(listClaim)){
			for(ORCALibGetClaimDiagnosisInfo  item : listClaim){
				OrcaModelProto.ORCALibGetClaimDiagnosisInfo .Builder info = OrcaModelProto.ORCALibGetClaimDiagnosisInfo .newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addClaimDiagnosisItem(info);
    		}
			for(ORCALibGetClaimDiagnosisInfo  item : listClaim){
				result = oif5101Repository.updateOIF5101ByFkoif1101AndPkoif5101(hospCode, item.getDocId(), fkoif1101, item.getPkoif5101());
				if(result <= 0){
					response.setResult(false);
					throw new ExecutionException(response.build());
				}
			}
		}
		response.setResult(true);
		return response.build();
	}                                                                                                                 
}