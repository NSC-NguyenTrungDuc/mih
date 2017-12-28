package nta.med.service.ihis.handler.nuro;

import java.math.BigDecimal;
import java.sql.Timestamp;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.emr.EmrRecord;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.emr.EmrRecordRepository;
import nta.med.data.model.ihis.emr.EMRUserGetLockEditingInfo;
import nta.med.data.model.ihis.emr.OCS2015U00LoadPatientMedicalRecordInfo;
import nta.med.service.emr.handler.OCS2015U09EmrRecordUpdateHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
@Transactional
public class NUR2015U01EmrRecordUpdateHandler extends ScreenHandler<NuroServiceProto.NUR2015U01EmrRecordUpdateRequest, SystemServiceProto.UpdateResponse>{
	private static final Log LOG = LogFactory.getLog(OCS2015U09EmrRecordUpdateHandler.class);                                    
	@Resource
	private EmrRecordRepository emrRecordRepository;
//	@Resource
//	private EmrBookmarkRepository emrBookmarkRepository;
//	@Resource
//	private EmrRecordHistoryRepository emrRecordHistoryRepository;
//	@Resource
//	private Bas0102Repository bas0102Repository;
	
	@Override                                                                                                       
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, NuroServiceProto.NUR2015U01EmrRecordUpdateRequest request) throws Exception {
		String hospCode = getHospitalCode(vertx, sessionId);
		LOG.info("NUR2015U01EmrRecordUpdateHandler EMR sessionId "+ sessionId);
		LOG.info("NUR2015U01EmrRecordUpdateHandler EMR hospCode" + hospCode);

		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Integer emrRecordId = finishExaminationProgess(request, hospCode, getLanguage(vertx, sessionId));
				if (emrRecordId!=null) {
					response.setMsg(emrRecordId.toString());
					response.setResult(true);
				} else {
					response.setResult(false);
					throw new ExecutionException(response.build());
				}
		return response.build();
		}                                                                                                                                                   
	

	//4. Finish examination progess [OCS2015U00_MainScreen]
	public Integer finishExaminationProgess(NuroServiceProto.NUR2015U01EmrRecordUpdateRequest request, String hospitalCode, String language) {
		//MED_BD_OCS2015U00_MainScreen
		Integer result = 0;
		Integer emrRecordId = 0;
		boolean save = false;
		//[0] 3. Load patient's medical records
		OCS2015U00LoadPatientMedicalRecordInfo medicalRecord = emrRecordRepository.getOCS2015U00LoadPatientMedicalRecordInfo(request.getBunho(), hospitalCode);
		if (medicalRecord != null && medicalRecord.getEmrRecordId() != null) {//Medical record is exist
			//[2] Get user is editing record
			String updId = emrRecordRepository.getUserEditingRecord(medicalRecord.getEmrRecordId().toString());
			if (request.getSysId().equals(updId)) {
				//[4] Update editing lock
				LOG.info("call NUR2015U01EmrRecordUpdateHandler setLockForUser");
				result = emrRecordRepository.setLockForUser(updId, medicalRecord.getEmrRecordId());

			} else {
				//[3] Get lock editing and start time editing

				EMRUserGetLockEditingInfo emrUser = emrRecordRepository.getEMRUserGetLockEditingInfo (medicalRecord.getEmrRecordId().toString());
				LOG.info("call NUR2015U01EmrRecordUpdateHandler getEMRUserGetLockEditingInfo");
				if (emrUser.getLockFlg().compareTo(new BigDecimal(0))==0) { //Lock flag = 0
					//[4] Update editing lock
					LOG.info("call NUR2015U01EmrRecordUpdateHandler setLockForUser 1");
					result = emrRecordRepository.setLockForUser(updId, medicalRecord.getEmrRecordId());

				} else { //Lock flag != 0
					//[5] Check editing time
					if(emrRecordRepository.getEditingTime (medicalRecord.getEmrRecordId()+"")==false) {
						//[4] Update editing lock
						LOG.info("call NUR2015U01EmrRecordUpdateHandler setLockForUser 2");
						result = emrRecordRepository.setLockForUser(updId, medicalRecord.getEmrRecordId());
					} else {
						return null; //[9] Show error message
					}
				}
			}
			if (result == null || result < 1) return null;
			//[6 START ] Insert history
//			LOG.info("call OCS2015U09EmrRecordUpdateHandler getOcs2015U44LastVerSionInsert");
//			Integer lastVersion = emrRecordHistoryRepository.getOcs2015U44LastVerSionInsert(medicalRecord.getEmrRecordId().toString());
//			if(lastVersion == null){
//				lastVersion = 0;
//			}
			//Get data from EMR_RECORD for insert to EMR_RECORD_HISTORY
//			LOG.info("call OCS2015U09EmrRecordUpdateHandler getEmrRecordGetOldDataInfo");
//			EmrRecordGetOldDataInfo oldData = emrRecordRepository.getEmrRecordGetOldDataInfo(medicalRecord.getEmrRecordId().toString());
//			save = insertEmrRepositoryHistory(oldData.getEmrRecordId().toString(),oldData.getContent(), 
//					oldData.getVersion(), oldData.getSysId(), oldData.getRecordLog(), oldData.getMetadata());
//			if(!save){
//				return null;
//			}
			//IF TOTAL_VERSION of this medical record at EMR_RECORD_HISTORY > LIMIT_RECORD
//			Integer limitVesrion = CommonUtils.parseInteger(bas0102Repository.getCodeNameByCodeTypeAndCode(hospitalCode, language, "OCS_EMR", "LM_RECORD"));
//			Integer totalVersion = emrRecordHistoryRepository.getOcs2015U44TotalVersionCount(medicalRecord.getEmrRecordId().toString());
//			if(limitVesrion != null){
//				if(totalVersion > limitVesrion){
//					Integer oldestVersion = emrRecordHistoryRepository.getOcs2015U44OldestVersionCount(medicalRecord.getEmrRecordId().toString());
//					save = deleteinsertEmrRepositoryHistory(medicalRecord.getEmrRecordId(), oldestVersion); 
//					if(!save){
//						return null;
//					}
//				}
//			} else {
//				LOG.warn("OCS2015U09EmrRecordUpdateHandler EMR limitVesrion isNull");
//			}
//			LOG.info("call OCS2015U09EmrRecordUpdateHandler updateEmrRepositoryHistory");
//			//[7] Update new content of medical record
			save = updateEmrRepositoryHistory(medicalRecord.getEmrRecordId().toString(), request.getMetadata(), request.getContent(), request.getSysId(), request.getRecordLog());
			if(!save){
				return null;
			}
			emrRecordId = medicalRecord.getEmrRecordId();
		} else { //Medical record not exist
			//[1] Insert the first record
			LOG.info("call insertNUR2015U01EmrRecord:");
			emrRecordId = insertNUR2015U01EmrRecord(request, hospitalCode);
			if (emrRecordId == null) {
				return null;
			}
		}
		//[8] Insert bookmark list
		
//		save = insertOCS2015U04AddBookmark(request, emrRecordId);
//		if(!save){
//			return null;
//		}
		return emrRecordId;
	}
	
	private boolean updateEmrRepositoryHistory(String recordId, String metadata, String content, String sysId, String recordLog){
		if(emrRecordRepository.updateNUR2015U01EmrNewContentOfMedicalRecord(content, metadata, new BigDecimal(0), sysId, recordLog, CommonUtils.parseInteger(recordId))>0){
			return true;
		}else{
			return false;
		}
	}
	
//	private boolean deleteinsertEmrRepositoryHistory(Integer recordId, Integer oldestVersion) {
//		if(emrRecordHistoryRepository.deleteOcs2015U44Emr(recordId, oldestVersion)>0){
//			return  true;
//		}else{
//			return false;
//		}
//	} 
	
//	private boolean insertEmrRepositoryHistory(String recordId, String content, Integer version, String sysId, String recordLog, String metadata){
//		try{
//			EmrRecordHistory emrRecordHistory = new EmrRecordHistory();
//			emrRecordHistory.setEmrRecordId(CommonUtils.parseInteger(recordId));
//			emrRecordHistory.setVersion(version);
//			emrRecordHistory.setContent(content);
//			emrRecordHistory.setSysId(sysId);
//			emrRecordHistory.setActiveFlg( new BigDecimal(1));
//			emrRecordHistory.setRecordLog(recordLog);
//			emrRecordHistory.setMetadata(metadata);
//			emrRecordHistory.setCreated(new Timestamp(System.currentTimeMillis()));
//			emrRecordHistoryRepository.save(emrRecordHistory);
//			return true;
//		} catch (Exception e){
//			LOGGER.error(e.getMessage(), e);
//			return false;
//		}
//	}
	
	private Integer insertNUR2015U01EmrRecord (NuroServiceProto.NUR2015U01EmrRecordUpdateRequest request, String hospitalCode){
		try{
			LOG.info("NUR2015U01EmrRecordUpdateRequest EMR insertNUR2015U01EmrRecord " + hospitalCode);
			EmrRecord emrRecord = new EmrRecord();
			emrRecord.setActiveFlg(new BigDecimal(1));
			LOG.info("NUR2015U01EmrRecordUpdateRequest EMR setBunho " + request.getBunho());
			emrRecord.setBunho(request.getBunho());
			LOG.info("NUR2015U01EmrRecordUpdateRequest EMR setContent " + request.getContent());
			emrRecord.setContent(request.getContent());
			emrRecord.setCreated(new Timestamp(System.currentTimeMillis()));
			emrRecord.setHospCode(hospitalCode);
			LOG.info("NUR2015U01EmrRecordUpdateRequest EMR hospCode setter " + hospitalCode);
			emrRecord.setLockFlag(new BigDecimal(0));
			emrRecord.setMetadata(request.getMetadata());
			emrRecord.setRecordLog(request.getRecordLog());
			emrRecord.setSysId(request.getSysId());
			emrRecord.setUpdId(request.getSysId());
			emrRecord.setUpdated(new Timestamp(System.currentTimeMillis()));
			emrRecord.setVersion(1);
			emrRecord = emrRecordRepository.save(emrRecord);
			return emrRecord.getEmrRecordId();
		} catch (Exception e){
			LOG.error(e.getMessage(), e);
			return null;
		}
	}
	
//	private boolean insertOCS2015U04AddBookmark (NuroServiceProto.NUR2015U01EmrRecordUpdateRequest request, Integer emrRecordId) {
//		List<OCS2015U09EmrBookmarkInfo> listBookMark = null; //request.getBookmarkList();
//		try {
//			if (!CollectionUtils.isEmpty(listBookMark)){
//				for (OCS2015U09EmrBookmarkInfo info:listBookMark) {
//					EmrBookmark emrBookmark = new EmrBookmark();
//					emrBookmark.setEmrRecordId(emrRecordId);
//					emrBookmark.setBookmarkText(info.getBookmarkText());
//					emrBookmark.setNaewonDate(DateUtil.toDate(info.getNaewonDate(), DateUtil.PATTERN_YYMMDD_BLANK));
//					emrBookmark.setPkout1001(CommonUtils.parseDouble(info.getPkout1001()));
//					emrBookmark.setSysId(request.getSysId());
//					emrBookmark.setUpdId(request.getSysId());
//					emrBookmark.setActiveFlg(new BigDecimal(1));
////					emrBookmark.setCreated(new Timestamp(System.currentTimeMillis()));
////					emrBookmark.setUpdated(new Timestamp(System.currentTimeMillis()));
//					emrBookmark.setBookmarkTitle("Default value");
//					emrBookmarkRepository.save(emrBookmark);
//				}
//			}
//			return true;
//		}  catch (Exception e){
//			LOGGER.error(e.getMessage(), e);
//			return false;
//		}
//	}
}
