package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out0106Repository;
import nta.med.data.model.ihis.system.DetailPaInfoFormGridCommentInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.DetailPaInfoFormGridCommentRequest;
import nta.med.service.ihis.proto.SystemServiceProto.DetailPaInfoFormGridCommentResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class DetailPaInfoFormGridCommentHandler
	extends ScreenHandler<SystemServiceProto.DetailPaInfoFormGridCommentRequest, SystemServiceProto.DetailPaInfoFormGridCommentResponse>{
	@Resource
	private Out0106Repository out0106Repository;
	
	@Override
	@Transactional(readOnly = true)
	public DetailPaInfoFormGridCommentResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			DetailPaInfoFormGridCommentRequest request) throws Exception {
		String hospCode = getHospitalCode(vertx, sessionId);
        List<DetailPaInfoFormGridCommentInfo> listDetailPaInfoFormGridCommentInfo = out0106Repository.getDetailPaInfoFormGridComment(hospCode, request.getPatientCode());
        SystemServiceProto.DetailPaInfoFormGridCommentResponse.Builder response = SystemServiceProto.DetailPaInfoFormGridCommentResponse.newBuilder();
        if (listDetailPaInfoFormGridCommentInfo != null && !listDetailPaInfoFormGridCommentInfo.isEmpty()) {
            for (DetailPaInfoFormGridCommentInfo obj : listDetailPaInfoFormGridCommentInfo) {
            	SystemModelProto.DetailPaInfoFormGridCommentInfo.Builder builder = SystemModelProto.DetailPaInfoFormGridCommentInfo.newBuilder();
                if(!StringUtils.isEmpty(obj.getComment())) {
                	builder.setComment(obj.getComment());
                }
                response.addCommentItem(builder);
            }
        }
        return response.build();
	}
}
