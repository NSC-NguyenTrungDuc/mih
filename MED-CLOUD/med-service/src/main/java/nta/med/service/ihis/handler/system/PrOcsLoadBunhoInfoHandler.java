package nta.med.service.ihis.handler.system;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.system.LoadPatientBaseInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.PrOcsLoadBunhoInfoRequest;
import nta.med.service.ihis.proto.SystemServiceProto.PrOcsLoadBunhoInfoResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class PrOcsLoadBunhoInfoHandler extends ScreenHandler<SystemServiceProto.PrOcsLoadBunhoInfoRequest, SystemServiceProto.PrOcsLoadBunhoInfoResponse> {

	@Resource
	private Out0101Repository out0101Repository;
	
	@Override
	public PrOcsLoadBunhoInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PrOcsLoadBunhoInfoRequest request)
			throws Exception {
		SystemServiceProto.PrOcsLoadBunhoInfoResponse.Builder response = SystemServiceProto.PrOcsLoadBunhoInfoResponse.newBuilder();
		Date naewonDate = DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
		LoadPatientBaseInfo info = out0101Repository.callPrOcsLoadBunhoInfo(getHospitalCode(vertx, sessionId), naewonDate, request.getBunho());
		if(info != null){
			SystemModelProto.LoadPatientBaseInfo.Builder builder = SystemModelProto.LoadPatientBaseInfo.newBuilder();
			BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
			response.addPatientBaseInfo(builder);
		}
		return response.build();
	}
}
