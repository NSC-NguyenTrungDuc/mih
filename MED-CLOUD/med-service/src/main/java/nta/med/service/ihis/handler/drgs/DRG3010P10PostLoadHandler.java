package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.data.model.ihis.drgs.DRG3010P10PostLoadInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10PostLoadRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10PostLoadResponse;

@Service
@Scope("prototype")
public class DRG3010P10PostLoadHandler
		extends ScreenHandler<DrgsServiceProto.DRG3010P10PostLoadRequest, DrgsServiceProto.DRG3010P10PostLoadResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0102U01GrdDetailCheckHandler.class);
    @Resource
    private Inv0102Repository inv0102Repository;

    @Override
    @Transactional(readOnly = true)
    public DRG3010P10PostLoadResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DRG3010P10PostLoadRequest request) throws Exception {
    	
        DrgsServiceProto.DRG3010P10PostLoadResponse.Builder response = DrgsServiceProto.DRG3010P10PostLoadResponse.newBuilder();

        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        
        List<DRG3010P10PostLoadInfo> listInfo = inv0102Repository.getDRG3010P10PostLoadInfo(hospCode);
        if (!CollectionUtils.isEmpty(listInfo)) {
            for (DRG3010P10PostLoadInfo item : listInfo) {
                DrgsModelProto.DRG3010P10PostLoadInfo.Builder info = DrgsModelProto.DRG3010P10PostLoadInfo.newBuilder();
                BeanUtils.copyProperties(item, info, language);
                response.addInfoList(info);
            }
        }
        return response.build();
    }

}
