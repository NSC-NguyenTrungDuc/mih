package nta.med.service.ihis.handler.injs;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class InjsINJ1001U01CplOrderStatusHandler extends ScreenHandler<InjsServiceProto.InjsINJ1001U01CplOrderStatusRequest, InjsServiceProto.InjsINJ1001U01CplOrderStatusResponse> {
	private static final Log LOG = LogFactory.getLog(InjsINJ1001U01CplOrderStatusHandler.class);
	@Resource
	private Ocs1003Repository ocs1003Repository;

	@Override
	public boolean isValid(InjsServiceProto.InjsINJ1001U01CplOrderStatusRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getDate()) && DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.InjsINJ1001U01CplOrderStatusResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.InjsINJ1001U01CplOrderStatusRequest request) throws Exception {
		InjsServiceProto.InjsINJ1001U01CplOrderStatusResponse.Builder response = InjsServiceProto.InjsINJ1001U01CplOrderStatusResponse.newBuilder();
		String result = ocs1003Repository.getInjsINJ1001U01CplOrderStatus(getHospitalCode(vertx, sessionId), request.getGubun(), request.getBunho(), DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD), request.getJundalPart());
		if(!StringUtils.isEmpty(result)){
			response.setResult(result);
		}
		return response.build();
	}
}
