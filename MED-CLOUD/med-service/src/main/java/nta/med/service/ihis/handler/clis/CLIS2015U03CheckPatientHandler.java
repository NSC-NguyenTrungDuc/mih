package nta.med.service.ihis.handler.clis;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.clis.ClisProtocolPatientRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisModelProto;
import nta.med.service.ihis.proto.ClisModelProto.CLIS2015U03CheckPatientRequestInfo;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U03CheckPatientRequest;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U03CheckPatientResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CLIS2015U03CheckPatientHandler extends ScreenHandler<ClisServiceProto.CLIS2015U03CheckPatientRequest, ClisServiceProto.CLIS2015U03CheckPatientResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(CLIS2015U03CheckPatientHandler.class);                                    
	@Resource                                                                                                       
	private ClisProtocolPatientRepository clisProtocolPatientRepository;                                                                   

	@Override
	@Transactional(readOnly = true)
	public CLIS2015U03CheckPatientResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CLIS2015U03CheckPatientRequest request) throws Exception {
		ClisServiceProto.CLIS2015U03CheckPatientResponse.Builder response = ClisServiceProto.CLIS2015U03CheckPatientResponse.newBuilder();
		List<CLIS2015U03CheckPatientRequestInfo> listInfo = request.getCheckItemList();
		if(!CollectionUtils.isEmpty(listInfo)){
			for(CLIS2015U03CheckPatientRequestInfo item : listInfo){
				ClisModelProto.CLIS2015U03CheckPatientResultInfo.Builder info = ClisModelProto.CLIS2015U03CheckPatientResultInfo.newBuilder();
				String result = clisProtocolPatientRepository.getYByBunho(getHospitalCode(vertx, sessionId), item.getBunho());
				if(!StringUtils.isEmpty(result)){
					info.setChkResult(result);
					response.addChkResult(info);
				}
			}
		}
		return response.build();
	}                                                                                                                 
}