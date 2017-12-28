package nta.med.service.emr.handler;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.emr.EmrRecordRepository;
import nta.med.data.model.ihis.emr.EMRUserGetLockEditingInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.math.BigDecimal;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS2015U00EmrRecordLockHandler extends ScreenHandler<EmrServiceProto.OCS2015U00EmrRecordLockRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U00EmrRecordLockHandler.class);                                    
	@Resource                                                                                                       
	private EmrRecordRepository emrRecordRepository;                                                                    


	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U00EmrRecordLockRequest request) throws Exception {
			SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
				boolean result = false;
				if ("OCS2015U04".equals(request.getScreenId())) {
					result = checkUserAuthorization(request.getUpdId(), request.getRecordId());
				} else if ("OCS2015U06".equals(request.getScreenId())) {
					result = editHistoryMedical(request.getUpdId(), request.getRecordId());
				}
				
				response.setResult(result);
				if(result == false){
					throw new ExecutionException(response.build());
				}
		return response.build();
			}                                                                                                                                                   

	//MED_BD_OCS2015U04_BookmarkList
	private boolean checkUserAuthorization (String userId, String emrRecordId) {
		//[1] Check user created bookmark
		if (!emrRecordRepository.checkUserCreateBookmark(emrRecordId, userId)) {
			return false; //Show error message MSG_003
		}
		
		Integer result = 0;
		//[2] Get user who is editing record
		String userEditing = emrRecordRepository.getUserEditingRecord(emrRecordId);
		if (StringUtils.isEmpty(userEditing) || userId.equals(userEditing)) {
			//[5] Set lock for user
			result = emrRecordRepository.setLockForUser(userId, CommonUtils.parseInteger(emrRecordId));
			if (result != null && result > 0) {
				return true;
			} else return false;
		} else {
			//[3] Processing get lock editing
			EMRUserGetLockEditingInfo userLockInfo = emrRecordRepository.getEMRUserGetLockEditingInfo(emrRecordId);
			if (userLockInfo.getLockFlg().compareTo(BigDecimal.ZERO)==0) {
				//[5] Set lock for user
				result = emrRecordRepository.setLockForUser(userId, CommonUtils.parseInteger(emrRecordId));
				if (result != null && result > 0) {
					return true;
				} else return false;
			} else {
				//[4] Get editing time
				if (emrRecordRepository.getEditingTime(emrRecordId)==false) { //If bigger 2 hours
					//[5] Set lock for user
					result = emrRecordRepository.setLockForUser(userId, CommonUtils.parseInteger(emrRecordId));
					if (result != null && result > 0) {
						return true;
					} else return false;
				} else {
					return false; //Show error message MSG_003
				}
			}
		}
	}
	
	//MED_BD_OCS2015U06_MedicalRecordHistory
	private boolean editHistoryMedical (String userId, String emrRecordId) {
		Integer result = 0;
		
		//[1] Get user is editing record
		String updId = emrRecordRepository.getUserEditingRecord(emrRecordId);
		if (userId.equals(updId)) {
			//[3] Update editing lock
			//EmrRecordRepository.setLockForUser()
			result = emrRecordRepository.setLockForUser(userId, CommonUtils.parseInteger(emrRecordId));
			if (result != null && result > 0) {
				return true;
			} else return false;
		} else {
			//[2] Get lock editing and start time editing
			EMRUserGetLockEditingInfo userLockInfo = emrRecordRepository.getEMRUserGetLockEditingInfo(emrRecordId);
			if (userLockInfo.getLockFlg().compareTo(BigDecimal.ZERO)==0) {
				//[3] Update editing lock
				result = emrRecordRepository.setLockForUser(userId, CommonUtils.parseInteger(emrRecordId));
				if (result != null && result > 0) {
					return true;
				} else return false;
			} else {
				//[4] Check editing time
				boolean edited = emrRecordRepository.getEditingTime(emrRecordId);
				if (edited == false) { //If bigger 2 hours
					//[3] Update editing lock
					result = emrRecordRepository.setLockForUser(userId, CommonUtils.parseInteger(emrRecordId));
					if (result != null && result > 0) {
						return true;
					} else return false;
				} else {
					return false; //Show error message MSG_005 => Flow 5, MSG_004 => Flow 6 
				}
			}
		}
	}
}