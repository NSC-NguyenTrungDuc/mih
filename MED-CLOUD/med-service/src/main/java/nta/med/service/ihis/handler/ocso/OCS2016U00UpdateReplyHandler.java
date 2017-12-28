package nta.med.service.ihis.handler.ocso;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ocs.Ocs0701;
import nta.med.core.domain.ocs.Ocs0702;
import nta.med.core.glossary.CommonEnum;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0701Repository;
import nta.med.data.dao.medi.ocs.Ocs0702Repository;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCS2016U00UpdateReplyRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS2016U00UpdateReplyHandler extends ScreenHandler<OcsoServiceProto.OCS2016U00UpdateReplyRequest, SystemServiceProto.UpdateResponse>{
	
	@Resource
	private Ocs0701Repository ocs0701Repository;

	@Resource
	private Ocs0702Repository ocs0702Repository;

	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2016U00UpdateReplyRequest request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<OcsoModelProto.OCS2016U00LoadDiscussionInfo> listInfo = request.getDiscussionListList();
		for (OcsoModelProto.OCS2016U00LoadDiscussionInfo info : listInfo) {
			if(DataRowState.ADDED.getValue().equalsIgnoreCase(info.getDataRowState())){
				
				Ocs0701 ocs0701 = ocs0701Repository.findOne(CommonUtils.parseLong(info.getGrpQuestionId()));
				if(ocs0701.getReqDoctor().equals(info.getDoctor())){
					ocs0701.setStatus(new BigDecimal(CommonEnum.QUESTION_STATUS_REQUEST_DOCTOR_REPLIED.getValue()));
				}else{
					ocs0701.setStatus(new BigDecimal(CommonEnum.QUESTION_STATUS_ANSWERED.getValue()));
				}
				ocs0701.setUpdId(getUserId(vertx, sessionId));
				ocs0701.setConsultDate(new Date());
				ocs0701.setUpdated(new Date());
				ocs0701Repository.save(ocs0701);
				
				Ocs0702 ocs0702 = new Ocs0702();
				ocs0702.setGrpQuestionId(CommonUtils.parseLong(info.getGrpQuestionId()));
				ocs0702.setContent(info.getContent());
				ocs0702.setDoctor(getUserId(vertx, sessionId));
				ocs0702.setSysId(getUserId(vertx, sessionId));
				ocs0702.setUpdId(getUserId(vertx, sessionId));
				ocs0702.setActiveFlg(new BigDecimal(1));
				ocs0702.setHospCode(getHospitalCode(vertx, sessionId));
				ocs0702.setEditedFlg(new BigDecimal(0));
				ocs0702Repository.save(ocs0702);
				
			} else if(DataRowState.MODIFIED.getValue().equalsIgnoreCase(info.getDataRowState())){
				
				Ocs0701 ocs0701 = ocs0701Repository.findOne(CommonUtils.parseLong(info.getGrpQuestionId()));
				ocs0701.setUpdId(getUserId(vertx, sessionId));
				ocs0701.setConsultDate(new Date());
				ocs0701Repository.save(ocs0701);
				
				ocs0702Repository.updateOCS2016U00(info.getContent(), getUserId(vertx, sessionId), CommonUtils.parseLong(info.getDiscussionId()));
				
			} else{
				response.setResult(false);
				return response.build();
			}
		}
		
		response.setResult(true);
		return response.build();
	}
	
	
}
