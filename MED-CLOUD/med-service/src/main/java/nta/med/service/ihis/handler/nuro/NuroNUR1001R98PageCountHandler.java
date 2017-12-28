package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroNUR1001R98PageCountHandler extends ScreenHandler<NuroServiceProto.NuroNUR1001R98PageCountRequest, NuroServiceProto.NuroNUR1001R98PageCountResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroNUR1001R98PageCountHandler.class);
	
	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroNUR1001R98PageCountResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroNUR1001R98PageCountRequest request) throws Exception {
		NuroServiceProto.NuroNUR1001R98PageCountResponse.Builder response= NuroServiceProto.NuroNUR1001R98PageCountResponse.newBuilder();
		List<String> listOrder = ocs0132Repository.getCodeNameByCodeAndCodeType(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeType(), request.getCode());
        if(listOrder != null && listOrder.size() > 0) {
            for (String item : listOrder) {
                response.setCount(StringUtils.isEmpty(item) ? "" : item);
            }
        }
		return response.build();
	}
}
