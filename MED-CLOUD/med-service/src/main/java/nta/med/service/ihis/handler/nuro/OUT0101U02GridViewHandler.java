package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GridBoheomInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GridCommentInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GridGongbiListInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GridPatientInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OUT0101U02GridViewHandler extends ScreenHandler<NuroServiceProto.OUT0101U02GridViewRequest, NuroServiceProto.OUT0101U02GridViewResponse> {
	private static final Log LOG = LogFactory.getLog(OUT0101U02GridViewHandler.class);
	
	@Resource
	private Out0101Repository out0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OUT0101U02GridViewResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT0101U02GridViewRequest request) throws Exception {
		NuroServiceProto.OUT0101U02GridViewResponse.Builder response = NuroServiceProto.OUT0101U02GridViewResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<NuroOUT0101U02GridPatientInfo> listNuroOUT0101U02GridPatientInfo = out0101Repository.getNuroOUT0101U02GridPatientInfo(hospCode, request.getPatientCode(), language);
    	if(listNuroOUT0101U02GridPatientInfo != null && !listNuroOUT0101U02GridPatientInfo.isEmpty()){
			for(NuroOUT0101U02GridPatientInfo item : listNuroOUT0101U02GridPatientInfo){
				NuroModelProto.NuroOUT0101U02GridPatientInfo.Builder nuroGridPatientInfo = NuroModelProto.NuroOUT0101U02GridPatientInfo.newBuilder();
				BeanUtils.copyProperties(item, nuroGridPatientInfo, getLanguage(vertx, sessionId));
				response.addGridPationItem(nuroGridPatientInfo);
			}
		}
    	
    	List<NuroOUT0101U02GridBoheomInfo> listNuroOUT0101U02GridBoheomInfo = out0101Repository.getNuroOUT0101U02GridBoheomInfo(language, hospCode, request.getPatientCode());
    	if(listNuroOUT0101U02GridBoheomInfo != null && !listNuroOUT0101U02GridBoheomInfo.isEmpty()){
			for(NuroOUT0101U02GridBoheomInfo item : listNuroOUT0101U02GridBoheomInfo){
				NuroModelProto.NuroOUT0101U02GridBoheomInfo.Builder nuroOUT0101U02GridBoheomInfo = NuroModelProto.NuroOUT0101U02GridBoheomInfo.newBuilder();	
				BeanUtils.copyProperties(item, nuroOUT0101U02GridBoheomInfo, getLanguage(vertx, sessionId));
				response.addGridBoheomItem(nuroOUT0101U02GridBoheomInfo);
			}
		}
    	
    	List<NuroOUT0101U02GridGongbiListInfo> listNuroOUT0101U02GridGongbiListInfo = out0101Repository.getNuroOUT0101U02GridGongbiListInfo(hospCode, request.getPatientCode(), language);
    	if(listNuroOUT0101U02GridGongbiListInfo != null && !listNuroOUT0101U02GridGongbiListInfo.isEmpty()){
			for(NuroOUT0101U02GridGongbiListInfo item : listNuroOUT0101U02GridGongbiListInfo){
				NuroModelProto.NuroOUT0101U02GridGongbiListInfo.Builder nuroGridGongbiListInfo = NuroModelProto.NuroOUT0101U02GridGongbiListInfo.newBuilder();
				BeanUtils.copyProperties(item, nuroGridGongbiListInfo, getLanguage(vertx, sessionId));
				response.addGridGongbiListItem(nuroGridGongbiListInfo);
			}	
		}
    	
    	List<NuroOUT0101U02GridCommentInfo> listOUT0101U02GridCommentInfo = out0101Repository.getOUT0101U02GridCommentInfo(hospCode, request.getPatientCode());
		if(listOUT0101U02GridCommentInfo != null && !listOUT0101U02GridCommentInfo.isEmpty()){
			for(NuroOUT0101U02GridCommentInfo item : listOUT0101U02GridCommentInfo){
				NuroModelProto.NuroOUT0101U02GridCommentInfo.Builder out0101U02GridCommentInfo = NuroModelProto.NuroOUT0101U02GridCommentInfo.newBuilder();
				
				if(item.getSer() != null){
					out0101U02GridCommentInfo.setSer(item.getSer().toString());
				}
				if(item.getComment() != null){
					out0101U02GridCommentInfo.setComment(item.getComment());
				}
				if(item.getPatientCode() != null){
					out0101U02GridCommentInfo.setPatientCode(item.getPatientCode());
				}
				
				response.addGridCommentItem(out0101U02GridCommentInfo);
			}
		}
		return response.build();
	}
}
