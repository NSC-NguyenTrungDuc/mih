package nta.med.service.ihis.handler.ocso;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsoOCS1003P01OutOrderEndTempHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01OutOrderEndTempRequest, OcsoServiceProto.OcsoOCS1003P01OutOrderEndTempResponse> {
	 static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01OutOrderEndTempHandler.class);
	
	@Resource
	private Ocs1003Repository ocs1003Repository;
	
	@Override
	public boolean isValid(OcsoServiceProto.OcsoOCS1003P01OutOrderEndTempRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional
	public OcsoServiceProto.OcsoOCS1003P01OutOrderEndTempResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01OutOrderEndTempRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01OutOrderEndTempResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01OutOrderEndTempResponse.newBuilder();
		Double fkout1001 = CommonUtils.parseDouble(request.getFkout1001());
        Date orderDate = DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD);
        String result = ocs1003Repository.callOcsoOCS1003P01OutOrderEndTemp(getHospitalCode(vertx, sessionId), fkout1001, orderDate);
        if(!StringUtils.isEmpty(result)){
        	response.setIoFlagResult(result);
        }
		return response.build();
	}
}
