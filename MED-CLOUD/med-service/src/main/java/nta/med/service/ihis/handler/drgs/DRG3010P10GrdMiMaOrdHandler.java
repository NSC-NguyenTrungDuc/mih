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
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdMiMaOrdInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdMiMaOrdRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdMiMaOrdResponse;

@Service
@Scope("prototype")
public class DRG3010P10GrdMiMaOrdHandler extends
		ScreenHandler<DrgsServiceProto.DRG3010P10GrdMiMaOrdRequest, DrgsServiceProto.DRG3010P10GrdMiMaOrdResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0102U01GrdDetailCheckHandler.class);
    @Resource
    private Drg3010Repository drg3010Repository;

    @Override
    @Transactional(readOnly = true)
    public DRG3010P10GrdMiMaOrdResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DRG3010P10GrdMiMaOrdRequest request) throws Exception {
    	
        DrgsServiceProto.DRG3010P10GrdMiMaOrdResponse.Builder response = DrgsServiceProto.DRG3010P10GrdMiMaOrdResponse.newBuilder();

        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        
        String orderDate = request.getOrderDate();
        String bunho = request.getBunho();
        String hopeDate = request.getHopeDate();
        String hoDong = request.getHoDong();
        String doctor = request.getDoctor();
        String magamGubun = request.getMagamGubun();
        String magamBunryu = request.getMagamBunryu();
        
        List<DRG3010P10GrdMiMaOrdInfo> listInfo = drg3010Repository.getDRG3010P10GrdMiMaOrdInfo(hospCode, language, orderDate, bunho, hopeDate, hoDong, doctor, magamGubun, magamBunryu);
        if (!CollectionUtils.isEmpty(listInfo)) {
            for (DRG3010P10GrdMiMaOrdInfo item : listInfo) {
                DrgsModelProto.DRG3010P10GrdMiMaOrdInfo.Builder info = DrgsModelProto.DRG3010P10GrdMiMaOrdInfo.newBuilder();
                BeanUtils.copyProperties(item, info, language);
                response.addGrdList(info);
            }
        }
        return response.build();
    }
}
