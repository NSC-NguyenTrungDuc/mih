package nta.med.service.emr.handler;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.emr.EmrRecordHistoryRepository;
import nta.med.data.dao.emr.EmrRecordRepository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS2015U40EmrMedicalRecordContentHandler extends ScreenHandler<EmrServiceProto.OCS2015U40EmrMedicalRecordContentRequest, EmrServiceProto.OCS2015U40EmrMedicalRecordContentResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U40EmrMedicalRecordContentHandler.class);                                    
	@Resource                                                                                                       
	private EmrRecordRepository emrRecordRepository;            
	@Resource  
	private EmrRecordHistoryRepository emrRecordHistoryRepository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U40EmrMedicalRecordContentResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U40EmrMedicalRecordContentRequest request) throws Exception {
		EmrServiceProto.OCS2015U40EmrMedicalRecordContentResponse.Builder response = EmrServiceProto.OCS2015U40EmrMedicalRecordContentResponse.newBuilder();
		ComboListItemInfo result = null;
		Integer version = emrRecordRepository.getEmrRecordMaxVersion(CommonUtils.parseInteger(request.getRecordId()));

		if(request.getVersion().equals(version == null ? "" : version.toString())){
			result = emrRecordRepository.getOCS2015U40EmrMedicalRecordContentListItem(request.getRecordId());
		} else {
			result = emrRecordHistoryRepository.getOCS2015U40EmrMedicalRecordHisotryContentListItem(CommonUtils.parseInteger(request.getRecordId()), CommonUtils.parseInteger(request.getVersion()));
		}

		if(result != null){
			if(!StringUtils.isEmpty(result.getCode())){
				response.setContent(result.getCode());
			}
			if(!StringUtils.isEmpty(result.getCodeName())){
				response.setMetadata(result.getCodeName());
			}
		}
		return response.build();
	}
}