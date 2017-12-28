package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdPaInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdPaRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdPaResponse;

@Service
@Scope("prototype")
public class DRG3010P10GrdPaHandler
		extends ScreenHandler<DrgsServiceProto.DRG3010P10GrdPaRequest, DrgsServiceProto.DRG3010P10GrdPaResponse> {
	
    @Resource
    private Drg3010Repository drg3010Repository;

    @Override
    @Transactional(readOnly = true)
    public DRG3010P10GrdPaResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DRG3010P10GrdPaRequest request) throws Exception {
    	
        DrgsServiceProto.DRG3010P10GrdPaResponse.Builder response = DrgsServiceProto.DRG3010P10GrdPaResponse.newBuilder();

        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        
        String fromDate = request.getFromDate();
        String toDate = request.getToDate();
        String bunho = request.getBunho();
        String hoDong = request.getHoDong();
        String magamGubun = request.getMagamGubun();
        String magamBunryu = request.getMagamBunryu();
        
        List<DRG3010P10GrdPaInfo> listInfo = drg3010Repository.getDRG3010P10GrdPaInfo(hospCode, language, fromDate, toDate, bunho, hoDong, magamGubun, magamBunryu);
        if (!CollectionUtils.isEmpty(listInfo)) {
            for (DRG3010P10GrdPaInfo item : listInfo) {
                DrgsModelProto.DRG3010P10GrdPaInfo.Builder info = DrgsModelProto.DRG3010P10GrdPaInfo.newBuilder();
                BeanUtils.copyProperties(item, info, language);
                response.addGrdList(info);
            }
        }
        return response.build();
    }

}
