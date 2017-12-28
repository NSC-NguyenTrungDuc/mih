package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.NuroPatientCommentInfo;
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
public class NuroPatientCommentListHandler extends ScreenHandler<NuroServiceProto.NuroPatientCommentListRequest, NuroServiceProto.NuroPatientCommentListResponse>{
	private static final Log logger = LogFactory.getLog(NuroPatientCommentListHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroPatientCommentListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroPatientCommentListRequest request) throws Exception {
		List<NuroPatientCommentInfo> listNuroPatientCommentInfo = out1001Repository.getNuroPatientCommentListItemInfo(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId), request.getPatientCode());
		NuroServiceProto.NuroPatientCommentListResponse.Builder response = NuroServiceProto.NuroPatientCommentListResponse.newBuilder();
		if(listNuroPatientCommentInfo != null && !listNuroPatientCommentInfo.isEmpty()){
			for(NuroPatientCommentInfo item: listNuroPatientCommentInfo){
				NuroModelProto.NuroPatientCommentListItemInfo.Builder nuroPatientCommentListinfo = NuroModelProto.NuroPatientCommentListItemInfo.newBuilder();
				
				if(item.getComment() != null){
					nuroPatientCommentListinfo.setComment(item.getComment());
				}
				if(item.getSer() != null){
					nuroPatientCommentListinfo.setSer(item.getSer().toString());
				}
				if(item.getPatientCode() != null){
					nuroPatientCommentListinfo.setPatientCode(item.getPatientCode());
				}
				if(item.getContKey() != null){
					nuroPatientCommentListinfo.setContKey(item.getContKey());
				}
				response.addPatientCommentListItem(nuroPatientCommentListinfo);
			}
		}
		return response.build();
	}

}
