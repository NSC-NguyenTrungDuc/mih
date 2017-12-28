package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0204Repository;
import nta.med.data.model.ihis.ocsa.OcsaOCS0204U00GrdOCS0204ListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0204U00GrdOCS0204ListRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0204U00GrdOCS0204ListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsaOCS0204U00GrdOCS0204ListHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0204U00GrdOCS0204ListRequest, OcsaServiceProto.OcsaOCS0204U00GrdOCS0204ListResponse> {
	
    @Resource
    private Ocs0204Repository ocs0204Repository;
    
    @Override
    @Transactional(readOnly = true)
    public OcsaOCS0204U00GrdOCS0204ListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OcsaOCS0204U00GrdOCS0204ListRequest request) throws Exception {
        OcsaServiceProto.OcsaOCS0204U00GrdOCS0204ListResponse.Builder response = OcsaServiceProto.OcsaOCS0204U00GrdOCS0204ListResponse.newBuilder();
    	List<OcsaOCS0204U00GrdOCS0204ListInfo> listItem = ocs0204Repository.getOcsaOCS0204U00GrdOCS0204List(getHospitalCode(vertx, sessionId), request.getFMemb(), getLanguage(vertx, sessionId));
    	if (!CollectionUtils.isEmpty(listItem)) {
            for (OcsaOCS0204U00GrdOCS0204ListInfo item : listItem) {
            	OcsaModelProto.OcsaOCS0204U00GrdOCS0204ListInfo.Builder info = OcsaModelProto.OcsaOCS0204U00GrdOCS0204ListInfo.newBuilder();
            	if (!StringUtils.isEmpty(item.getMemb())) {
            		info.setMemb(item.getMemb());
            	}
            	if (item.getfSeq() != null) {
            		info.setFSeq(item.getfSeq().toString());
            	}
            	if (!StringUtils.isEmpty(item.getSangGubun())) {
            		info.setSangGubun(item.getSangGubun());
            	}
            	if (!StringUtils.isEmpty(item.getSangGubunName())) {
            		info.setSangGubunName(item.getSangGubunName());
            	}
                response.addGrd0204Item(info);
            }
        }
    	return response.build();
    }

}
