package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.ocsa.OCS0131U00GrdOCS0132Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0131U00GrdOCS0132Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0131U00GrdOCS0132Response;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OCS0131U00GrdOCS0132Handler
	extends ScreenHandler<OcsaServiceProto.OCS0131U00GrdOCS0132Request, OcsaServiceProto.OCS0131U00GrdOCS0132Response> {
	private static final Log LOG = LogFactory.getLog(OCS0131U00GrdOCS0132Handler.class);
	
	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS0131U00GrdOCS0132Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0131U00GrdOCS0132Request request) throws Exception {
        OcsaServiceProto.OCS0131U00GrdOCS0132Response.Builder response = OcsaServiceProto.OCS0131U00GrdOCS0132Response.newBuilder();
    	List<OCS0131U00GrdOCS0132Info> listItem = ocs0132Repository.getOCS0131U00GrdOCS0132Info(getHospitalCode(vertx, sessionId), request.getCodeType());
    	if(listItem !=null && !listItem.isEmpty()){
			for(OCS0131U00GrdOCS0132Info item : listItem){
				OcsaModelProto.OCS0131U00GrdOCS0132Info.Builder info = OcsaModelProto.OCS0131U00GrdOCS0132Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdOcs0132Info(info);
			}
    	}
    	return response.build();
	}

}
