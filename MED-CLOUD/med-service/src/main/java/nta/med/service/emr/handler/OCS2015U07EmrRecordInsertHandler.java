package nta.med.service.emr.handler;

import nta.med.core.domain.emr.EmrRecord;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.emr.EmrRecordRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.math.BigDecimal;

@Service                                                                                                          
@Scope("prototype")    
@Transactional
public class OCS2015U07EmrRecordInsertHandler extends ScreenHandler<EmrServiceProto.OCS2015U07EmrRecordInsertRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U07EmrRecordInsertHandler.class);                                    
	@Resource                                                                                                       
	private EmrRecordRepository emrRecordRepository;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U07EmrRecordInsertRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		EmrRecord result = insertOCS2015U07EmrRecord(request, getHospitalCode(vertx, sessionId));
		if (result!=null) {
			response.setResult(true);
			response.setMsg(result.getEmrRecordId()+"");
		} else {
			response.setResult(false);
		}
		return response.build();
	}
	
	public EmrRecord insertOCS2015U07EmrRecord(EmrServiceProto.OCS2015U07EmrRecordInsertRequest request, String hospCode){
		try{
			EmrRecord emrRecord = new EmrRecord();
			emrRecord.setHospCode(hospCode);
			emrRecord.setBunho(request.getBunho());
			emrRecord.setContent(request.getContent());
			emrRecord.setMetadata(request.getMetadata());
			emrRecord.setVersion(CommonUtils.parseInteger(request.getVersion()));
			emrRecord.setRecordLog("新規作成"); //TODO remove hard code after apply multi language
			emrRecord.setLockFlag(new BigDecimal(0));
			emrRecord.setActiveFlg(new BigDecimal(1));
			emrRecord.setSysId(request.getSysId());
			emrRecord.setUpdId(request.getSysId());
//			emrRecord.setCreated(new Timestamp(System.currentTimeMillis()));
//			emrRecord.setUpdated(new Timestamp(System.currentTimeMillis()));
			emrRecord = emrRecordRepository.save(emrRecord);
			return emrRecord;
		} catch (Exception e){
			LOGGER.error(e.getMessage(), e);
			return null;
		}
	}
}