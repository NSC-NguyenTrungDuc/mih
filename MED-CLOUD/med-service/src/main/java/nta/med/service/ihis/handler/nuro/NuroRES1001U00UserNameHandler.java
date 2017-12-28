package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm3200Repository;
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
public class NuroRES1001U00UserNameHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00UserNameRequest, NuroServiceProto.NuroRES1001U00UserNameResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroRES1001U00UserNameHandler.class);
	@Resource
	private Adm3200Repository adm3200Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES1001U00UserNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00UserNameRequest request) throws Exception {
		NuroServiceProto.NuroRES1001U00UserNameResponse.Builder response = NuroServiceProto.NuroRES1001U00UserNameResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = request.getHospCodeLink();
		}
		List<String> listObject = adm3200Repository.getUserNameByUserId(hospCode, request.getUserId());
         if (listObject != null && !listObject.isEmpty()) {
             for (String obj : listObject) {
                 response.setUserName(StringUtils.isEmpty(obj) ? "" : obj);
             }
         }
		return response.build();
	}
}
