package nta.med.service.ihis.handler.ocso;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs0701;
import nta.med.core.domain.ocs.Ocs0702;
import nta.med.core.glossary.CommonEnum;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0701Repository;
import nta.med.data.dao.medi.ocs.Ocs0702Repository;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCS2016U00QuestionSaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS2016U00QuestionSaveLayoutHandler extends
		ScreenHandler<OcsoServiceProto.OCS2016U00QuestionSaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Ocs0701Repository ocs0701Repository;

	@Resource
	private Ocs0702Repository ocs0702Repository;

	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2016U00QuestionSaveLayoutRequest request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<OcsoModelProto.OCS2016U00QuestionSaveLayoutInfo> listQuestion = request.getQuestionListList();
		List<OcsoModelProto.OCS2016U00LoadDiscussionInfo> listDiscussion = request.getDiscussionListList(); 
		
		if(CollectionUtils.isEmpty(listQuestion) && CollectionUtils.isEmpty(listDiscussion)){
			response.setResult(true);
			return response.build();
		}
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		
		// [CASE 1] ADD NEW QUESTION - ONLY ONE QUESTION IS ADDED FOR EACH TIME SAVE LAYOUT
		if(!CollectionUtils.isEmpty(listQuestion) && DataRowState.ADDED.getValue().equalsIgnoreCase(listQuestion.get(0).getDataRowState())){
			Long ocs0701Id = insertOcs0701(listQuestion.get(0), hospCode, userId);
			if (ocs0701Id == null) {
				response.setResult(false);
				throw new ExecutionException(response.build());
			}

			boolean isSuccess = insertOcs0702(listQuestion.get(0), ocs0701Id, hospCode, userId);
			if (!isSuccess) {
				response.setResult(false);
				throw new ExecutionException(response.build());
			}
			
			response.setResult(true);
			return response.build();
		}
		
		// [CASE 2] FINISH DISCUSSION/DELETE QUESTION
		for (OcsoModelProto.OCS2016U00QuestionSaveLayoutInfo item : listQuestion) {
			if("Y".equalsIgnoreCase(item.getFinishYn())){
				ocs0701Repository.finishDiscusOCS2016U00(userId, CommonUtils.parseLong(item.getGrpQuestionId()));
			}
			
			if(DataRowState.DELETED.getValue().equalsIgnoreCase(item.getDataRowState())){
				ocs0701Repository.deleteOCS2016U00(userId, CommonUtils.parseLong(item.getGrpQuestionId()));
			}
		}
		
		// [CASE 3] UPDATE QUESTION STATUS, ADD/EDIT CONTENT
		for (OcsoModelProto.OCS2016U00LoadDiscussionInfo item : listDiscussion) {
			if(DataRowState.ADDED.getValue().equalsIgnoreCase(item.getDataRowState())){
				if(StringUtils.isEmpty(item.getGrpQuestionId())){
					response.setResult(false);
					return response.build();
				}
				
				insertOcs0702(item, CommonUtils.parseLong(item.getGrpQuestionId()), hospCode, userId);
				
				Ocs0701 ocs0701 = ocs0701Repository.findOne(CommonUtils.parseLong(item.getGrpQuestionId()));
				if(ocs0701 != null){
					if(ocs0701.getReqDoctor().equals(item.getDoctor())){
						ocs0701.setStatus(new BigDecimal(CommonEnum.QUESTION_STATUS_REQUEST_DOCTOR_REPLIED.getValue()));
					}else{
						ocs0701.setStatus(new BigDecimal(CommonEnum.QUESTION_STATUS_ANSWERED.getValue()));
					}
					ocs0701.setUpdated(new Date());
					ocs0701Repository.save(ocs0701);
				}
			} else if(DataRowState.MODIFIED.getValue().equalsIgnoreCase(item.getDataRowState())){
				/*BigDecimal status = new BigDecimal(0);
				if(request.getQuestionType().equalsIgnoreCase(CommonEnum.QUESTION_SENT.getValue())){
					status = new BigDecimal(2);
				}else if(request.getQuestionType().equalsIgnoreCase(CommonEnum.QUESTION_RECEIVED.getValue())){
					status = new BigDecimal(3);
				}*/
				// Do not change status in case edit reply
				// ocs0701Repository.updateOCS2016U00(status, userId, CommonUtils.parseLong(item.getGrpQuestionId()));
				
				ocs0702Repository.updateOCS2016U00(item.getContent(), userId, CommonUtils.parseLong(item.getDiscussionId()));
			}
		}
		
		response.setResult(true);
		return response.build();
	}
	
	private Long insertOcs0701(OcsoModelProto.OCS2016U00QuestionSaveLayoutInfo info, String hospCode, String userId){
		Ocs0701 ocs0701 = new Ocs0701();
		ocs0701.setReqDate(DateUtil.toTimestamp(info.getReqDate(), DateUtil.PATTERN_YYMMDD));
		ocs0701.setReqGwa(info.getReqGwa());
		ocs0701.setReqDoctor(userId);
		ocs0701.setConsultGwa(info.getConsultGwa());
		ocs0701.setConsultDoctor(info.getConsultDoctor());
		ocs0701.setConsultHospCode(info.getConsultHospCode());
		ocs0701.setBunho(info.getBunho());
		ocs0701.setStatus(new BigDecimal(1));
		ocs0701.setSysId(userId);
		ocs0701.setUpdId(userId);
		ocs0701.setActiveFlg(new BigDecimal(CommonEnum.QUESTION_STATUS_NEW.getValue()));
		ocs0701.setHospCode(hospCode);
		ocs0701.setFinishFlg("N");
		ocs0701Repository.save(ocs0701);
		
		if(ocs0701 != null && ocs0701.getId() != null){
			return ocs0701.getId();
		}
		
		return null;
	}
	
	// insert content for new question
	private Boolean insertOcs0702(OcsoModelProto.OCS2016U00QuestionSaveLayoutInfo info, Long ocs0701Id, String hospCode, String userId){
		Ocs0702 ocs0702 = new Ocs0702();
		ocs0702.setGrpQuestionId(ocs0701Id);
		ocs0702.setContent(info.getContent());
		ocs0702.setDoctor(userId);
		ocs0702.setSysId(userId);
		ocs0702.setUpdId(userId);
		ocs0702.setActiveFlg(new BigDecimal(1));
		ocs0702.setHospCode(hospCode);
		ocs0702.setEditedFlg(new BigDecimal(0));
		ocs0702Repository.save(ocs0702);
		return ocs0702 != null && ocs0702.getId() != null;
	}
	
	// insert reply, comment
	private Boolean insertOcs0702(OcsoModelProto.OCS2016U00LoadDiscussionInfo info, Long ocs0701Id, String hospCode, String userId){
		Ocs0702 ocs0702 = new Ocs0702();
		ocs0702.setGrpQuestionId(ocs0701Id);
		ocs0702.setContent(info.getContent());
		ocs0702.setDoctor(userId);
		ocs0702.setSysId(userId);
		ocs0702.setUpdId(userId);
		ocs0702.setActiveFlg(new BigDecimal(1));
		ocs0702.setHospCode(hospCode);
		ocs0702.setEditedFlg(new BigDecimal(0));
		ocs0702Repository.save(ocs0702);
		return ocs0702 != null && ocs0702.getId() != null;
	}

}
