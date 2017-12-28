package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0503Repository;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503Q01ListDataInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0503Q01ListDataRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0503Q01ListDataResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsaOCS0503Q01ListDataHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0503Q01ListDataRequest, OcsaServiceProto.OcsaOCS0503Q01ListDataResponse> {
	
    @Resource
    private Ocs0503Repository ocs0503Repository;
    
    @Override
    @Transactional(readOnly = true)
    public OcsaOCS0503Q01ListDataResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsaOCS0503Q01ListDataRequest request) throws Exception {
		List<OcsaOCS0503Q01ListDataInfo> listItem = ocs0503Repository.getOcsaOCS0503Q01ListDataInfo(getHospitalCode(vertx, sessionId),getLanguage(vertx, sessionId),request.getBunho(),
        		 request.getFromDate(),request.getToDate());
         OcsaServiceProto.OcsaOCS0503Q01ListDataResponse.Builder response = OcsaServiceProto.OcsaOCS0503Q01ListDataResponse.newBuilder();
         if (listItem != null && !listItem.isEmpty()) {
             for (OcsaOCS0503Q01ListDataInfo item : listItem) {
            	OcsaModelProto.OcsaOCS0503Q01ListDataInfo.Builder info = OcsaModelProto.OcsaOCS0503Q01ListDataInfo.newBuilder();
            	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
            	response.addListItem(info);
             }
         }
         return response.build();
    }

}
