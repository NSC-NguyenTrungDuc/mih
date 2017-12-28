package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0205Repository;
import nta.med.data.model.ihis.ocsa.OcsaOCS0204U00GrdOCS0205ListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0204U00GrdOCS0205ListRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0204U00GrdOCS0205ListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsaOCS0204U00GrdOCS0205ListHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0204U00GrdOCS0205ListRequest, OcsaServiceProto.OcsaOCS0204U00GrdOCS0205ListResponse>{
	
    @Resource
    private Ocs0205Repository ocs0205Repository;
    
    @Override
    @Transactional(readOnly = true)
    public OcsaOCS0204U00GrdOCS0205ListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OcsaOCS0204U00GrdOCS0205ListRequest request) throws Exception {
        OcsaServiceProto.OcsaOCS0204U00GrdOCS0205ListResponse.Builder response = OcsaServiceProto.OcsaOCS0204U00GrdOCS0205ListResponse.newBuilder();
    	List<OcsaOCS0204U00GrdOCS0205ListInfo> listItem = ocs0205Repository.getOcsaOCS0204U00GrdOCS0205List(getHospitalCode(vertx, sessionId), request.getFMemb(), request.getSangGubun());
    	if (!CollectionUtils.isEmpty(listItem)) {
            for (OcsaOCS0204U00GrdOCS0205ListInfo item : listItem) {
            	OcsaModelProto.OcsaOCS0204U00GrdOCS0205ListInfo.Builder info = OcsaModelProto.OcsaOCS0204U00GrdOCS0205ListInfo.newBuilder();
            	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrd0205Item(info);
            }
        }
    	return response.build();
    }
}
