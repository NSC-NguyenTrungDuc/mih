package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0131Repository;
import nta.med.data.model.ihis.ocsa.OCS0131U00GrdOCS0131Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0131U00GrdOCS0131Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0131U00GrdOCS0131Response;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OCS0131U00GrdOCS0131Handler
	extends ScreenHandler<OcsaServiceProto.OCS0131U00GrdOCS0131Request, OcsaServiceProto.OCS0131U00GrdOCS0131Response> {
	private static final Log LOG = LogFactory.getLog(OCS0131U00GrdOCS0131Handler.class);
	
	@Resource
	private Ocs0131Repository ocs0131Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS0131U00GrdOCS0131Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0131U00GrdOCS0131Request request) throws Exception {
        OcsaServiceProto.OCS0131U00GrdOCS0131Response.Builder response = OcsaServiceProto.OCS0131U00GrdOCS0131Response.newBuilder();
    	List<OCS0131U00GrdOCS0131Info> listItem = ocs0131Repository.getOCS0131U00GrdOCS0131Info(request.getCodeType(), getLanguage(vertx, sessionId));
    	if(listItem !=null && !listItem.isEmpty()){
			for(OCS0131U00GrdOCS0131Info item : listItem){
				OcsaModelProto.OCS0131U00GrdOCS0131Info.Builder info = OcsaModelProto.OCS0131U00GrdOCS0131Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdOcs0131Info(info);
			}
    	}
    	return response.build();
	}

}
