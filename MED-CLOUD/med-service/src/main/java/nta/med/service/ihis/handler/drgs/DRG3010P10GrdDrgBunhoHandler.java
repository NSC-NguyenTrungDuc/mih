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
import nta.med.data.model.ihis.drgs.DRG3010P10GrdDrgBunhoInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdDrgBunhoRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdDrgBunhoResponse;

@Service
@Scope("prototype")
public class DRG3010P10GrdDrgBunhoHandler extends ScreenHandler<DrgsServiceProto.DRG3010P10GrdDrgBunhoRequest, DrgsServiceProto.DRG3010P10GrdDrgBunhoResponse> {
	
    @Resource
    private Drg3010Repository drg3010Repository;

    @Override
    @Transactional(readOnly = true)
    public DRG3010P10GrdDrgBunhoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DRG3010P10GrdDrgBunhoRequest request) throws Exception {
    	
        DrgsServiceProto.DRG3010P10GrdDrgBunhoResponse.Builder response = DrgsServiceProto.DRG3010P10GrdDrgBunhoResponse.newBuilder();

        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        
        String magamDate = request.getMagamDate();
        String magamSer = request.getMagamSer();
        String magamGubun = request.getMagamGubun();
        String magamBunryu = request.getMagamBunryu();
        String hoDong = request.getHoDong();
        
        List<DRG3010P10GrdDrgBunhoInfo> listInfo = drg3010Repository.getDRG3010P10GrdDrgBunhoInfo(hospCode, language, magamDate, magamSer, magamGubun, hoDong, magamBunryu);
        if (!CollectionUtils.isEmpty(listInfo)) {
            for (DRG3010P10GrdDrgBunhoInfo item : listInfo) {
                DrgsModelProto.DRG3010P10GrdDrgBunhoInfo.Builder info = DrgsModelProto.DRG3010P10GrdDrgBunhoInfo.newBuilder();
                BeanUtils.copyProperties(item, info, language);
                response.addGrdList(info);
            }
        }
        return response.build();
    }
}
