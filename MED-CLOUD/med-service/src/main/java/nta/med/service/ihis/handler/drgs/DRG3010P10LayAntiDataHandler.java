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
import nta.med.data.dao.medi.drg.Drg1000Repository;
import nta.med.data.model.ihis.drgs.DRG3010P10LayAntiDataInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10LayAntiDataRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10LayAntiDataResponse;

@Service
@Scope("prototype")
public class DRG3010P10LayAntiDataHandler extends
		ScreenHandler<DrgsServiceProto.DRG3010P10LayAntiDataRequest, DrgsServiceProto.DRG3010P10LayAntiDataResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0102U01GrdDetailCheckHandler.class);
    @Resource
    private Drg1000Repository drg1000Repository;

    @Override
    @Transactional(readOnly = true)
    public DRG3010P10LayAntiDataResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DRG3010P10LayAntiDataRequest request) throws Exception {
    	
        DrgsServiceProto.DRG3010P10LayAntiDataResponse.Builder response = DrgsServiceProto.DRG3010P10LayAntiDataResponse.newBuilder();

        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        
        String fkocs = request.getFkocs();
        
        List<DRG3010P10LayAntiDataInfo> listInfo = drg1000Repository.getDRG3010P10LayAntiDataInfo(hospCode, fkocs);
        if (!CollectionUtils.isEmpty(listInfo)) {
            for (DRG3010P10LayAntiDataInfo item : listInfo) {
                DrgsModelProto.DRG3010P10LayAntiDataInfo.Builder info = DrgsModelProto.DRG3010P10LayAntiDataInfo.newBuilder();
                BeanUtils.copyProperties(item, info, language);
                response.addGrdList(info);
            }
        }
        return response.build();
    }

}
