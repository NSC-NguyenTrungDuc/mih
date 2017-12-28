package nta.med.service.ihis.handler.clis;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.clis.CLIS2015U03PatientListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisModelProto;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U03PatientListRequest;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U03PatientListResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CLIS2015U03PatientListHandler extends ScreenHandler<ClisServiceProto.CLIS2015U03PatientListRequest, ClisServiceProto.CLIS2015U03PatientListResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(CLIS2015U03PatientListHandler.class);                                    
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public CLIS2015U03PatientListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CLIS2015U03PatientListRequest request) throws Exception {
		ClisServiceProto.CLIS2015U03PatientListResponse.Builder response = ClisServiceProto.CLIS2015U03PatientListResponse.newBuilder();
		Integer protocolId = CommonUtils.parseInteger(request.getProtocolId());
		List<CLIS2015U03PatientListInfo> listResult = out0101Repository.getCLIS2015U03PatientListInfo(protocolId);
		if(!CollectionUtils.isEmpty(listResult)){
			for(CLIS2015U03PatientListInfo item : listResult){
				ClisModelProto.CLIS2015U03PatientListInfo.Builder info = ClisModelProto.CLIS2015U03PatientListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addPatientListItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}