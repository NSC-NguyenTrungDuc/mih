package nta.med.service.ihis.handler.system;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.model.ihis.system.PrOcsLoadIpwonReserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.PrOcsLoadIpwonReserInfoRequest;
import nta.med.service.ihis.proto.SystemServiceProto.PrOcsLoadIpwonReserInfoResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class PrOcsLoadIpwonReserInfoHandler extends ScreenHandler <SystemServiceProto.PrOcsLoadIpwonReserInfoRequest, SystemServiceProto.PrOcsLoadIpwonReserInfoResponse> {
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Override
	public PrOcsLoadIpwonReserInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PrOcsLoadIpwonReserInfoRequest request) throws Exception {
		SystemServiceProto.PrOcsLoadIpwonReserInfoResponse.Builder response = SystemServiceProto.PrOcsLoadIpwonReserInfoResponse.newBuilder();
		Date reserDate = DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD);
		Double naewonKey = CommonUtils.parseDouble(request.getNaewonKey());
		PrOcsLoadIpwonReserInfo info = inp1003Repository.getPrOcsLoadIpwonReserInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), reserDate, naewonKey);
		if(info != null){
			SystemModelProto.PrOcsLoadIpwonReserInfo.Builder builder = SystemModelProto.PrOcsLoadIpwonReserInfo.newBuilder();
			BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
			response.addReserInfoItem(builder);
		}
		return response.build();
	}
}
