package nta.med.service.ihis.handler.ocsi;

import java.util.Date;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.system.LoadHangmogInfo;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00PROcsLoadHangmogInfoRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00PROcsLoadHangmogInfoResponse;

@Service
@Scope("prototype")
@Transactional
public class OCS1024U00PROcsLoadHangmogInfoHandler extends ScreenHandler<OcsiServiceProto.OCS1024U00PROcsLoadHangmogInfoRequest , OcsiServiceProto.OCS1024U00PROcsLoadHangmogInfoResponse>{
	@Resource
	private Ocs0103Repository ocs0103Repository;

	@Override
	public OCS1024U00PROcsLoadHangmogInfoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS1024U00PROcsLoadHangmogInfoRequest request) throws Exception {
		OcsiServiceProto.OCS1024U00PROcsLoadHangmogInfoResponse.Builder response = OcsiServiceProto.OCS1024U00PROcsLoadHangmogInfoResponse.newBuilder();
		Date appDate = DateUtil.toDate(request.getAppDate(), DateUtil.PATTERN_YYMMDD);
		 LoadHangmogInfo hangmogInfo = ocs0103Repository.callPrOcsLoadHangmogInfo(getHospitalCode(vertx, sessionId), appDate, request.getInputPart(),
				 request.getInputGwa(), request.getHangmogCode(), request.getInputTab());
		 if(hangmogInfo != null){
			 //TODO check with client using LoadHangmogInfo or DataStringListItemInfo 
		 }
		return response.build();
	}
}
