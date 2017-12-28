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

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdDrgBunhoInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdMagamJusaOrdInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdDrgBunhoRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdDrgBunhoResponse;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdMagamJusaOrdRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdMagamJusaOrdResponse;

@Service
@Scope("prototype")
public class DRG3010P10GrdMagamJusaOrdHandler extends ScreenHandler<DrgsServiceProto.DRG3010P10GrdMagamJusaOrdRequest, DrgsServiceProto.DRG3010P10GrdMagamJusaOrdResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0102U01GrdDetailCheckHandler.class);
    @Resource
    private Drg3010Repository drg3010Repository;

    @Override
    @Transactional(readOnly = true)
    public DRG3010P10GrdMagamJusaOrdResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DRG3010P10GrdMagamJusaOrdRequest request) throws Exception {
    	
        DrgsServiceProto.DRG3010P10GrdMagamJusaOrdResponse.Builder response = DrgsServiceProto.DRG3010P10GrdMagamJusaOrdResponse.newBuilder();

        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        
        String jubsuDate = request.getJubsuDate();
        String drgBunho = request.getDrgBunho();
        
        List<DRG3010P10GrdMagamJusaOrdInfo> listInfo = drg3010Repository.getDRG3010P10GrdMagamJusaOrdInfo(hospCode, language, jubsuDate, drgBunho);
        if (!CollectionUtils.isEmpty(listInfo)) {
            for (DRG3010P10GrdMagamJusaOrdInfo item : listInfo) {
                DrgsModelProto.DRG3010P10GrdMagamJusaOrdInfo.Builder info = DrgsModelProto.DRG3010P10GrdMagamJusaOrdInfo.newBuilder();
                BeanUtils.copyProperties(item, info, language);
                response.addGrdList(info);
            }
        }
        return response.build();
    }
}