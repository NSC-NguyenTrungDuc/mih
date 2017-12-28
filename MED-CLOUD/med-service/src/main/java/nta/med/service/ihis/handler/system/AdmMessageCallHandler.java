package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.system.PrAdmMessageCallOutputInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.AdmMessageCallRequest;
import nta.med.service.ihis.proto.SystemServiceProto.AdmMessageCallResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class AdmMessageCallHandler
	extends ScreenHandler<SystemServiceProto.AdmMessageCallRequest, SystemServiceProto.AdmMessageCallResponse> {
	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	public AdmMessageCallResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, AdmMessageCallRequest request)
			throws Exception {
		SystemServiceProto.AdmMessageCallResponse.Builder response = SystemServiceProto.AdmMessageCallResponse.newBuilder();
		PrAdmMessageCallOutputInfo info = adm3200Repository.callPrAdmMessageCall(getHospitalCode(vertx, sessionId), 
				getLanguage(vertx, sessionId), request.getUserId(), "", request.getSenderId(), 
				request.getTitle(), request.getData(), "N", request.getRecieverGubun(), request.getRecieverId());
		if(info != null){
			SystemModelProto.LoadPatientBaseInfo.Builder builder = SystemModelProto.LoadPatientBaseInfo.newBuilder();
			BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
			response.setErrFlag(info.getErrFlag());
			response.setSendSeq(info.gettSendSeq().toString());
		}
		return response.build();
	}
}
