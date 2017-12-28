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
import nta.med.data.model.ihis.drgs.DRG3010P10GrdMagamOrdInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdMagamOrdRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdMagamOrdResponse;

@Service
@Scope("prototype")
public class DRG3010P10GrdMagamOrdHandler extends
		ScreenHandler<DrgsServiceProto.DRG3010P10GrdMagamOrdRequest, DrgsServiceProto.DRG3010P10GrdMagamOrdResponse> {
	
    @Resource
    private Drg3010Repository drg3010Repository;

    @Override
    @Transactional(readOnly = true)
    public DRG3010P10GrdMagamOrdResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DRG3010P10GrdMagamOrdRequest request) throws Exception {
    	
        DrgsServiceProto.DRG3010P10GrdMagamOrdResponse.Builder response = DrgsServiceProto.DRG3010P10GrdMagamOrdResponse.newBuilder();

        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        
        String jubsuDate = request.getJubsuDate();
        String drgBunho = request.getDrgBunho();
        
        List<DRG3010P10GrdMagamOrdInfo> listInfo = drg3010Repository.getDRG3010P10GrdMagamOrdInfo(hospCode, language, jubsuDate, drgBunho);
        if (!CollectionUtils.isEmpty(listInfo)) {
            for (DRG3010P10GrdMagamOrdInfo item : listInfo) {
                DrgsModelProto.DRG3010P10GrdMagamOrdInfo.Builder info = DrgsModelProto.DRG3010P10GrdMagamOrdInfo.newBuilder();
                BeanUtils.copyProperties(item, info, language);
                response.addGrdList(info);
            }
        }
        return response.build();
    }
}
