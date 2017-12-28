package nta.med.service.emr.handler;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.emr.EmrRecordHistory;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.emr.EmrRecordHistoryRepository;
import nta.med.data.dao.emr.EmrRecordRepository;
import nta.med.data.dao.emr.SysPropertyRepository;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.emr.ContentMailInfo;
import nta.med.data.model.ihis.emr.EmailToInfo;
import nta.med.data.model.ihis.emr.EmrRecordGetOldDataInfo;
import nta.med.data.model.ihis.emr.PatientEmailInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U44EmrHistoricRecordUpdateRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.velocity.VelocityContext;
import org.apache.velocity.app.Velocity;
import org.apache.velocity.context.Context;
import org.springframework.context.annotation.Scope;
import org.springframework.mail.MailSender;
import org.springframework.mail.SimpleMailMessage;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import javax.mail.internet.AddressException;
import javax.mail.internet.InternetAddress;
import java.io.IOException;
import java.io.StringWriter;
import java.math.BigDecimal;
import java.sql.Timestamp;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS2015U44EmrHistoricRecordUpdateHandler extends ScreenHandler<EmrServiceProto.OCS2015U44EmrHistoricRecordUpdateRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U44EmrHistoricRecordUpdateHandler.class);                                    
	@Resource                                                                                                       
	private EmrRecordRepository emrRecordRepository;                                                                    
	@Resource                                                                                                       
	private EmrRecordHistoryRepository emrRecordHistoryRepository;                                                                    
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;
	@Resource
	private Adm3200Repository adm3200Repository;
	@Resource
	private SysPropertyRepository sysPropertyRepository;
	@Resource
	private Bas0001Repository bas0001Repository;
	@Resource
	private Out0101Repository out0101Repository;
	@Resource
	private MailSender mailSender;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, OCS2015U44EmrHistoricRecordUpdateRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		if(!saveLayout(request, getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId))){
			response.setMsg("MSG_004");
			response.setResult(false);
			throw new ExecutionException(response.build());
		}else{
			response.setResult(true);
		}
		return response.build();
	}

	private boolean saveLayout(OCS2015U44EmrHistoricRecordUpdateRequest request, String hospitalCode, String language) {
		boolean save = false;
		//[1] Prcessing release lock
		save = releaseLock(request.getRecordId(), request.getUpdId());
		if (!save){
			return save;
		}
		
		//[2] Insert history
		//Get last version in history, last version in table history always null 
		Integer lastVersion = emrRecordHistoryRepository.getOcs2015U44LastVerSionInsert(request.getRecordId());
		if(lastVersion == null){
			lastVersion = 0;
		}
		
		//Get data from EMR_RECORD for insert to EMR_RECORD_HISTORY
		EmrRecordGetOldDataInfo oldData = emrRecordRepository.getEmrRecordGetOldDataInfo(request.getRecordId());
		save = insertEmrRepositoryHistory(oldData.getEmrRecordId().toString(),oldData.getContent(), 
				oldData.getVersion(), oldData.getSysId(), oldData.getRecordLog(), oldData.getMetadata(), new Timestamp(System.currentTimeMillis()));
		if(!save){
			return save;
		}
		//IF TOTAL_VERSION of this medical record at EMR_RECORD_HISTORY > LIMIT_RECORD
		Integer limitVesrion = Integer.parseInt(bas0102Repository.getCodeNameByCodeTypeAndCode(hospitalCode, language, "OCS_EMR", "LM_RECORD"));
		Integer totalVersion = emrRecordHistoryRepository.getOcs2015U44TotalVersionCount(request.getRecordId());
		if(totalVersion > limitVesrion){
			Integer oldestVersion = emrRecordHistoryRepository.getOcs2015U44OldestVersionCount(request.getRecordId());
			save = deleteinsertEmrRepositoryHistory(CommonUtils.parseInteger(request.getRecordId()), oldestVersion); 
			if(!save){
				return save;
			}
		}
		
		//[3] Update new content of medical record
		//version ban dau khi insert = null, khi update len thanh 2
		save = updateEmrRepositoryHistory(request.getRecordId(), request.getMetadata(), request.getContent(), lastVersion+2, request.getUpdId(), request.getRecordLog());
		if(!save){
			return save;
		}

		// send Email
		if ("1".equals(request.getEmailFlg())) {
			save = sendEmail(request, hospitalCode, language);
		}
		return save; 
	}
	
	private boolean sendEmail(OCS2015U44EmrHistoricRecordUpdateRequest request, String hospitalCode, String language) {
		try {
			//1. Get list doctor email to
			List<EmailToInfo> listEmailTo = adm3200Repository.getEmailToInfoList(request.getRecordId()); //emrRecordId
			//3. Get email content template ,Get subject template
			ComboListItemInfo subjectContentEmail = sysPropertyRepository.getPropertyValueInfo("ja"); //locale => ja
			//3.2. hospital name
			String hospName = bas0001Repository.getYoyangNameInfo(hospitalCode, language);
			//3.4. patient code, patient name
			ComboListItemInfo patientCodeName = out0101Repository.getPatientCodeName(request.getRecordId()); //bunho => emr_record_id
			//3.7. doctor name, doctor code change log => only one
			ComboListItemInfo doctorChangeLog = adm3200Repository.getDoctorCodeName(request.getUpdId()); 
			//3.8. reception code, update time, mail log
			PatientEmailInfo listLog = emrRecordRepository.getCreatedRecordLog(request.getRecordId()) ; //emrRecordId
			//4. Velocity.evaluate => put value to param
			SimpleMailMessage mailMesg; 
			for (EmailToInfo toInfo : listEmailTo) {
				if (!StringUtils.isEmpty(toInfo.getEmail()) && validateEmail(toInfo.getEmail())==true) {
					mailMesg = new SimpleMailMessage();
					mailMesg.setTo(toInfo.getEmail());
					mailMesg.setSubject(subjectContentEmail.getCode());
					mailMesg.setText(getEmailBody(subjectContentEmail.getCodeName(), toInfo, 
							hospName, doctorChangeLog, patientCodeName, listLog));
					mailSender.send(mailMesg);
				}
			}
			return true;
		} catch (Exception e){
			return false;
		}
	}
	
	private boolean validateEmail(String email) {
		boolean isValid = false;
		try {
			InternetAddress internetAddress = new InternetAddress(email);
			internetAddress.validate();
			isValid = true;
		} catch (AddressException e) {
			e.printStackTrace();
		}
		return isValid;
	}
	
    private String getEmailBody(String templateContent, EmailToInfo emailTo, String hospName, 
    		ComboListItemInfo doctorChangeLog, ComboListItemInfo patientCodeName, PatientEmailInfo listLog) {
    	StringWriter writer = new StringWriter();
        try{
			ContentMailInfo mailInfo = new ContentMailInfo(hospName, patientCodeName.getCode(), patientCodeName.getCodeName(), 
					/*listLog.getPkout1001(), */doctorChangeLog.getCode(), doctorChangeLog.getCodeName(), listLog.getCreated(), listLog.getRecordLog());
            Context context = new VelocityContext();
            context.put("username", emailTo.getUserName());
            
            Map<String, Object> templateVariables = new HashMap<String, Object>();
            templateVariables.put("mailInfo", mailInfo);

            for(Map.Entry<String, Object> entry : templateVariables.entrySet()){
                context.put(entry.getKey(), entry.getValue());
            }
            
            boolean result = Velocity.evaluate(context, writer, "", templateContent);
            return result ? writer.toString() : "";
            
        } finally {
            try {
                writer.close();
            } catch (IOException e) {
            	LOGGER.error(e.getMessage(), e);
            }
        }
    }
	
	private boolean insertEmrRepositoryHistory(String recordId, String content, Integer version, String sysId, String recordLog, String metadata, Timestamp created){
		EmrRecordHistory emrRecordHistory = new EmrRecordHistory();
		emrRecordHistory.setEmrRecordId(CommonUtils.parseInteger(recordId));
		emrRecordHistory.setVersion(version);
		emrRecordHistory.setContent(content);
		emrRecordHistory.setSysId(sysId);
		emrRecordHistory.setActiveFlg( new BigDecimal(1));
		emrRecordHistory.setRecordLog(recordLog);
		emrRecordHistory.setMetadata(metadata);
		emrRecordHistory.setCreated(created);
		emrRecordHistoryRepository.save(emrRecordHistory);
		return true;
	}
	private boolean deleteinsertEmrRepositoryHistory(Integer recordId, Integer oldestVersion) {
		if(emrRecordHistoryRepository.deleteOcs2015U44Emr(recordId, oldestVersion)>0){
			return  true;
		}else{
			return false;
		}
	}    
	
	private boolean updateEmrRepositoryHistory(String recordId, String metadata, String content, Integer version, String sysId, String recordLog){
		if(emrRecordRepository.updateOCS2015U44EmrNewContentOfMedicalRecord(content, metadata, new BigDecimal(0), sysId, version, recordLog, CommonUtils.parseInteger(recordId))>0){
			return true;
		}else{
			return false;
		}
	}
	
	//[1] Prcessing release lock
	private boolean releaseLock(String recordId, String upId){
		if(emrRecordRepository.updateOCS2015U44ReleaseLock(CommonUtils.parseInteger(recordId), upId)>0){
			return true;
		}else{
			return false;
		}
	}
}
