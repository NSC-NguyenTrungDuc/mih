package nta.med.service.ihis.handler.ocso;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0150Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CommonModelProto.GetOrderCountInfo;
import nta.med.service.ihis.proto.OcsoServiceProto;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS1003P01GetUserOptionAndOrderCountHandler extends ScreenHandler<OcsoServiceProto.OCS1003P01GetUserOptionAndOrderCountRequest, OcsoServiceProto.OCS1003P01GetUserOptionAndOrderCountResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS1003P01GetUserOptionAndOrderCountHandler.class);
	@Resource                                                                                                       
	private Ocs0150Repository ocs0150Repository;                                                                    
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCS1003P01GetUserOptionAndOrderCountResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OcsoServiceProto.OCS1003P01GetUserOptionAndOrderCountRequest request)throws Exception {
		OcsoServiceProto.OCS1003P01GetUserOptionAndOrderCountResponse.Builder response = OcsoServiceProto.OCS1003P01GetUserOptionAndOrderCountResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		CommonModelProto.GetUserOptionInfo userOption = request.getUserOption();
		String userOpt = ocs0150Repository.getOcsOrderBizGetUserOptionInfo(hospCode, userOption.getDoctor(), userOption.getGwa(), userOption.getKeyword(), userOption.getIoGubun());
		if (!StringUtils.isEmpty(userOpt)) {
			response.setUserOptionValue(userOpt);
		}
		GetOrderCountInfo info = request.getOrderCount();
		Date orderDate = DateUtil.toDate(info.getOrderDate(),DateUtil.PATTERN_YYMMDD);
		Integer result = ocs1003Repository.getOrderCount(hospCode, info.getIoGubun(), info.getBunho(), orderDate);
		if (result != null) {
			response.setOrderCountValue(result.toString());
		}
		return response.build();
	}
}