package nta.med.service.ihis.handler.injs;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inj.Inj1002Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class InjsINJ1001U01UpdateHandler extends ScreenHandler<InjsServiceProto.InjsINJ1001U01UpdateRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(InjsINJ1001U01UpdateHandler.class);
	@Resource
	private Inj1002Repository inj1002Repository;
	
	@Override
	public boolean isValid(InjsServiceProto.InjsINJ1001U01UpdateRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getActingDate()) && DateUtil.toDate(request.getActingDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.InjsINJ1001U01UpdateRequest request) throws Exception {
		 String hospitalCode = getHospitalCode(vertx, sessionId);
		 SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
         Date actingDate = DateUtil.toDate(request.getActingDate(), DateUtil.PATTERN_YYMMDD);
         Double pkinj1002 = CommonUtils.parseDouble(request.getPkinj1002());
         Integer resultUpdate = inj1002Repository.updateINJ1001U01(request.getActingFlag(), actingDate, DateUtil.toString(new Date(), DateUtil.PATTERN_HHMM),
					request.getTonggyeCode(), request.getMixGroup(), request.getUpdId(), new Date(), request.getJujongja(), request.getSilsiRemark(), hospitalCode, pkinj1002);
         response.setResult(resultUpdate != null && resultUpdate > 0);
		 return response.build();
	}
}
