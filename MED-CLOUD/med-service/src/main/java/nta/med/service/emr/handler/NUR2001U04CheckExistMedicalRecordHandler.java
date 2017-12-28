package nta.med.service.emr.handler;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.emr.EmrRecord;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.emr.EmrRecordRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.NUR2001U04CheckExistMedicalRecordRequest;
import nta.med.service.emr.proto.EmrServiceProto.NUR2001U04CheckExistMedicalRecordResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class NUR2001U04CheckExistMedicalRecordHandler extends ScreenHandler<EmrServiceProto.NUR2001U04CheckExistMedicalRecordRequest, EmrServiceProto.NUR2001U04CheckExistMedicalRecordResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(NUR2001U04CheckExistMedicalRecordHandler.class);                                    
	@Resource                                                                                                       
	private EmrRecordRepository emrRecordRepository;                                                                    
	                                                                                                                
	@Override  
	@Transactional(readOnly = true)
	public NUR2001U04CheckExistMedicalRecordResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			NUR2001U04CheckExistMedicalRecordRequest request) throws Exception {
  	   	EmrServiceProto.NUR2001U04CheckExistMedicalRecordResponse.Builder response = EmrServiceProto.NUR2001U04CheckExistMedicalRecordResponse.newBuilder();
  	   	List<EmrRecord> listRecord = emrRecordRepository.getByActiveBunho(request.getPatientCode(), getHospitalCode(vertx, sessionId));
  	   	if (!CollectionUtils.isEmpty(listRecord)) {
  	   		for (EmrRecord item : listRecord) {
  	   			EmrModelProto.NUR2001U04CheckExistMedicalRecordInfo.Builder info = EmrModelProto.NUR2001U04CheckExistMedicalRecordInfo.newBuilder();
		  	   	if (item.getEmrRecordId() != null) {
		  	   		info.setEmrRecordId(item.getEmrRecordId().toString());
		  	   	}
		  	   	if (!StringUtils.isEmpty(item.getBunho())) {
		  	   		info.setBunho(item.getBunho());
		  	   	}
		  	   	if (!StringUtils.isEmpty(item.getContent())) {
		  	   		info.setContent(item.getContent());
		  	   	}
		  	   	if (item.getCreated() != null) {
		  	   		info.setCreated(DateUtil.toString(item.getCreated(), DateUtil.PATTERN_YYMMDD));
		  	   	}
		  	   	if (!StringUtils.isEmpty(item.getHospCode())) {
		  	   		info.setHospCode(item.getHospCode());
		  	   	}
		  	   	if (item.getLockFlg() != null) {
		  	   		info.setLockFlg(item.getLockFlg().toString());
		  	   	}
		  	   	if (!StringUtils.isEmpty(item.getMetadata())) {
		  	   		info.setMetadata(item.getMetadata());
		  	   	}
		  	   	if (!StringUtils.isEmpty(item.getRecordLog())) {
		  	   		info.setRecordLog(item.getRecordLog());
		  	   	}
		  	   	if (!StringUtils.isEmpty(item.getSysId())) {
		  	   		info.setSysId(item.getSysId());
		  	   	}
		  	   	if (!StringUtils.isEmpty(item.getUpdId())) {
		  	   		info.setUpdId(item.getUpdId());
		  	   	}
		  	   	if (item.getUpdated() != null) {
		  	   		info.setUpdated(DateUtil.toString(item.getUpdated(), DateUtil.PATTERN_YYMMDD));
		  	   	}
		  	   	if (item.getVersion() != null) {
		  	   		info.setVersion(item.getVersion().toString());
		  	   	}
		  	   	response.addMedicalRecordInfo(info);
  	   		}
  	   	}
  	   	return response.build();
  	   	
	}
}