package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.service.ihis.proto.SystemModelProto.GetEnablePostApproveInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetEnablePostApproveRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetEnablePostApproveResponse;

@Service
@Scope("prototype")
public class GetEnablePostApproveHandler extends ScreenHandler<SystemServiceProto.GetEnablePostApproveRequest, SystemServiceProto.GetEnablePostApproveResponse> {
	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional(readOnly = true)
	public GetEnablePostApproveResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			GetEnablePostApproveRequest request) throws Exception {
		SystemServiceProto.GetEnablePostApproveResponse.Builder response = SystemServiceProto.GetEnablePostApproveResponse.newBuilder();
		GetEnablePostApproveInfo enbaleInfo = request.getAproveInfo();
		 String enablePost = adm3200Repository.getEnablePostApprove(getHospitalCode(vertx, sessionId), enbaleInfo.getApproveDoctor());
		 if(!StringUtils.isEmpty(enablePost)){
			 response.setPosTapproveYn(enablePost);
		 }
		return response.build();
	}

}
