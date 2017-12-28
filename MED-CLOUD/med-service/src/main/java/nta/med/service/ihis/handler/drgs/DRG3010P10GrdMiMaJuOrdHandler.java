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
import nta.med.data.model.ihis.drgs.DRG3010P10GrdMagamPaQueryInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdMiMaJuOrdInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdMagamPaQueryRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdMagamPaQueryResponse;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdMiMaJuOrdRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdMiMaJuOrdResponse;

@Service
@Scope("prototype")
public class DRG3010P10GrdMiMaJuOrdHandler extends
		ScreenHandler<DrgsServiceProto.DRG3010P10GrdMiMaJuOrdRequest, DrgsServiceProto.DRG3010P10GrdMiMaJuOrdResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0102U01GrdDetailCheckHandler.class);
    @Resource
    private Drg3010Repository drg3010Repository;

    @Override
    @Transactional(readOnly = true)
    public DRG3010P10GrdMiMaJuOrdResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DRG3010P10GrdMiMaJuOrdRequest request) throws Exception {
    	
        DrgsServiceProto.DRG3010P10GrdMiMaJuOrdResponse.Builder response = DrgsServiceProto.DRG3010P10GrdMiMaJuOrdResponse.newBuilder();

        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        
        String orderDate = request.getOrderDate();
        String bunho = request.getBunho();
        String hopeDate = request.getHopeDate();
        String hoDong = request.getHoDong();
        String doctor = request.getDoctor();
        String magamGubun = request.getMagamGubun();
        String magamBunryu = request.getMagamBunryu();
        String pageNumber = request.getPageNumber();
        String offset = request.getOffset();
        
        List<DRG3010P10GrdMiMaJuOrdInfo> listInfo = drg3010Repository.getDRG3010P10GrdMiMaJuOrdInfo(hospCode, language, orderDate, bunho, hopeDate,
        		hoDong, doctor, magamGubun, magamBunryu, pageNumber, offset);
        if (!CollectionUtils.isEmpty(listInfo)) {
            for (DRG3010P10GrdMiMaJuOrdInfo item : listInfo) {
                DrgsModelProto.DRG3010P10GrdMiMaJuOrdInfo.Builder info = DrgsModelProto.DRG3010P10GrdMiMaJuOrdInfo.newBuilder();
                BeanUtils.copyProperties(item, info, language);
                response.addGrdList(info);
            }
        }
        return response.build();
    }
}
