package nta.med.service.ihis.handler.injs;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inv.Inv0110Repository;
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
public class InjsINJ1001U01ChkbStateHandler extends ScreenHandler<InjsServiceProto.InjsINJ1001U01ChkbStateRequest, InjsServiceProto.InjsINJ1001U01ChkbStateResponse> {
	private static final Log LOG = LogFactory.getLog(InjsINJ1001U01ChkbStateHandler.class);
	@Resource
	private Inv0110Repository inv0110Repository;

	@Override
	public boolean isValid(InjsServiceProto.InjsINJ1001U01ChkbStateRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getReserDate()) && DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.InjsINJ1001U01ChkbStateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.InjsINJ1001U01ChkbStateRequest request) throws Exception {
		InjsServiceProto.InjsINJ1001U01ChkbStateResponse.Builder response = InjsServiceProto.InjsINJ1001U01ChkbStateResponse.newBuilder();
		String result = inv0110Repository.getInjsINJ1001U01ChkbState(getHospitalCode(vertx, sessionId), 
        		DateUtil.toDate(request.getReserDate(),DateUtil.PATTERN_YYMMDD), request.getActingFlag(), request.getBunho(), request.getDoctor());
        if(!StringUtils.isEmpty(result)){
        	response.setResult(result);
        }
		return response.build();
	}
}
