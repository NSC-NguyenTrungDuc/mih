package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0304Repository;
import nta.med.data.model.ihis.ocsa.OCS0304Q00layOCS0304Info;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0304Q00layOCS0304Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0304Q00layOCS0304Response;

@Service
@Scope("prototype")
public class OCS0304Q00layOCS0304Handler extends ScreenHandler<OcsaServiceProto.OCS0304Q00layOCS0304Request, OcsaServiceProto.OCS0304Q00layOCS0304Response>{
	private static final Log LOGGER = LogFactory.getLog(OCS0304Q00layOCS0304Handler.class);
	@Resource
	private Ocs0304Repository ocs0304Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS0304Q00layOCS0304Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS0304Q00layOCS0304Request request) throws Exception {
		OcsaServiceProto.OCS0304Q00layOCS0304Response.Builder response = OcsaServiceProto.OCS0304Q00layOCS0304Response.newBuilder();
		List<OCS0304Q00layOCS0304Info> list = ocs0304Repository.getOCS0304Q00layOCS0304Info(getHospitalCode(vertx, sessionId), request.getMemb());
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS0304Q00layOCS0304Info item : list) {
				OcsaModelProto.OCS0304Q00layOCS0304Info.Builder info = OcsaModelProto.OCS0304Q00layOCS0304Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayItem(info);
			}
		}
		return response.build();
	}

}
