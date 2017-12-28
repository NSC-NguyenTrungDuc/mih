package nta.med.service.emr.handler;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.emr.EmrRecordHistoryRepository;
import nta.med.data.dao.emr.EmrRecordRepository;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.emr.OCS2015U40EmrHistoryMedicalRecordInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS2015U40EmrHistoryMedicalRecordHandler extends ScreenHandler<EmrServiceProto.OCS2015U40EmrHistoryMedicalRecordRequest, EmrServiceProto.OCS2015U40EmrHistoryMedicalRecordResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U40EmrHistoryMedicalRecordHandler.class);                                    
	@Resource      	                                                                                                 
	private EmrRecordRepository emrRecordRepository;
	@Resource      	                                                                                                 
	private EmrRecordHistoryRepository emrRecordHistoryRepository;
	@Resource                                                                                                       
	private Adm3200Repository adm3200Repository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U40EmrHistoryMedicalRecordResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U40EmrHistoryMedicalRecordRequest request) throws Exception {
		EmrServiceProto.OCS2015U40EmrHistoryMedicalRecordResponse.Builder response = EmrServiceProto.OCS2015U40EmrHistoryMedicalRecordResponse.newBuilder();
		String hospitalCode = getHospitalCode(vertx, sessionId);
		Integer reCordId = emrRecordRepository.getEmrRecordId(request.getBunho(), hospitalCode);
		if(reCordId != null){
			List<OCS2015U40EmrHistoryMedicalRecordInfo> list = emrRecordHistoryRepository.getOCS2015U40EmrHistoryMedicalRecordListItem(reCordId);
			if(!CollectionUtils.isEmpty(list)){
				for(OCS2015U40EmrHistoryMedicalRecordInfo item : list){
					EmrModelProto.OCS2015U40EmrHistoryMedicalRecordInfo.Builder info = EmrModelProto.OCS2015U40EmrHistoryMedicalRecordInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
//					String author = adm3200Repository.getCPL3020U00UserNmVsvJubsuja(hospitalCode, item.getSysId());
//					if(!StringUtils.isEmpty(author)){
//						info.setAuthor(author);
//					}
					info.setEmrRecordId(reCordId.toString());
					response.addEmrHistoryMedicalRecordItem(info);
				}
			}
		}
		return response.build();
	}
}