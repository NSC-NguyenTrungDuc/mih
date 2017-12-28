package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GridCommentInfo;
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
public class NuroOUT0101U02GridCommentHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02GridCommentRequest, NuroServiceProto.NuroOUT0101U02GridCommentResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroOUT0101U02GridCommentHandler.class);
	@Resource
	private Out0101Repository out0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOUT0101U02GridCommentResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02GridCommentRequest request) throws Exception {
		NuroServiceProto.NuroOUT0101U02GridCommentResponse.Builder response = NuroServiceProto.NuroOUT0101U02GridCommentResponse.newBuilder();
		List<NuroOUT0101U02GridCommentInfo> listOUT0101U02GridCommentInfo = out0101Repository.getOUT0101U02GridCommentInfo(getHospitalCode(vertx, sessionId), request.getPatientCode());
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
