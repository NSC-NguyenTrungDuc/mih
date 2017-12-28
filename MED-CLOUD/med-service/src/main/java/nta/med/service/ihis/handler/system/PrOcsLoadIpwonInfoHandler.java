package nta.med.service.ihis.handler.system;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.system.PrOcsLoadIpwonInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.PrOcsLoadIpwonInfoRequest;
import nta.med.service.ihis.proto.SystemServiceProto.PrOcsLoadIpwonInfoResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class PrOcsLoadIpwonInfoHandler extends ScreenHandler <SystemServiceProto.PrOcsLoadIpwonInfoRequest, SystemServiceProto.PrOcsLoadIpwonInfoResponse>{
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	public PrOcsLoadIpwonInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PrOcsLoadIpwonInfoRequest request)
			throws Exception  {
		SystemServiceProto.PrOcsLoadIpwonInfoResponse.Builder response = SystemServiceProto.PrOcsLoadIpwonInfoResponse.newBuilder();
		Date naewonDate = DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
		Integer fkinp1001 = CommonUtils.parseInteger(request.getNaewonKey());
		PrOcsLoadIpwonInfo info = inp1001Repository.callPrOcsLoadIpwonInfo(getHospitalCode(vertx, sessionId), naewonDate, fkinp1001, request.getJaewonFlag());
		if(info != null){
			SystemModelProto.PrOcsLoadIpwonInfo.Builder builder = SystemModelProto.PrOcsLoadIpwonInfo.newBuilder();
			BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
			response.addIpwonInfoItem(builder);
		}
		return response.build();
	}
}
