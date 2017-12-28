package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs0306Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0304Q00PkOCS2005Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0304Q00PkOCS2005Response;

@Service
@Scope("prototype")
public class OCS0304Q00PkOCS2005Handler extends ScreenHandler<OcsaServiceProto.OCS0304Q00PkOCS2005Request, OcsaServiceProto.OCS0304Q00PkOCS2005Response>{
	private static final Log LOGGER = LogFactory.getLog(OCS0304Q00PkOCS2005Handler.class);
	@Resource
	private Ocs0306Repository ocs0306Repository;
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	@Transactional
	public OCS0304Q00PkOCS2005Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS0304Q00PkOCS2005Request request) throws Exception {
		OcsaServiceProto.OCS0304Q00PkOCS2005Response.Builder response = OcsaServiceProto.OCS0304Q00PkOCS2005Response.newBuilder();
		String result = commonRepository.getNextVal("OCS2005_SEQ");
		if (!StringUtils.isEmpty(result)){
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(result);
			response.setPkItem(info);
		} 
		return response.build();
	}

}
