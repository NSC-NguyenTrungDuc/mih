package nta.med.service.ihis.handler.drgs;

import nta.med.data.dao.medi.res.Res0101Repository;
import nta.med.data.model.ihis.drgs.DRG9001GetLay9001Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class DRG9001R01Lay9001Handler extends ScreenHandler<DrgsServiceProto.DRG9001R01Lay9001Request, DrgsServiceProto.DRG9001R01Lay9001Response> {
    private static final Log LOGGER = LogFactory.getLog(DRG9001R01Lay9001Handler.class);
    @Resource
    private Res0101Repository res0101Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG9001R01Lay9001Response handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG9001R01Lay9001Request request) throws Exception {
        DrgsServiceProto.DRG9001R01Lay9001Response.Builder response = DrgsServiceProto.DRG9001R01Lay9001Response.newBuilder();
        List<DRG9001GetLay9001Info> listLay = res0101Repository.getDRG9001R01GetLay9001Info(getHospitalCode(vertx, sessionId), request.getDate());
        if (!CollectionUtils.isEmpty(listLay)) {
            for (DRG9001GetLay9001Info item : listLay) {
                DrgsModelProto.DRG9001R02Lay9001Info.Builder info = DrgsModelProto.DRG9001R02Lay9001Info.newBuilder();
                if (!StringUtils.isEmpty(item.getHoliDay())) {
                    info.setHoliDay(item.getHoliDay());
                }
                if (item.getDrgCnt() != null) {
                    info.setDrgCnt(item.getDrgCnt().toString());
                }
                if (item.getDrgGroupCnt() != null) {
                    info.setDrgGroupCnt(item.getDrgGroupCnt().toString());
                }
                if (item.getDrgHangmogCnt() != null) {
                    info.setDrgHangmogCnt(item.getDrgHangmogCnt().toString());
                }
                if (item.getInjCnt() != null) {
                    info.setInjCnt(item.getInjCnt().toString());
                }
                if (item.getInjGroupCnt() != null) {
                    info.setInjGroupCnt(item.getInjGroupCnt().toString());
                }
                if (item.getInjHangmogCnt() != null) {
                    info.setInjHangmogCnt(item.getInjHangmogCnt().toString());
                }
                if (item.getDrgInjCnt() != null) {
                    info.setDrgInjCnt(item.getDrgInjCnt().toString());
                }
                if (item.getDrgInjGroupCnt() != null) {
                    info.setDrgInjGroupCnt(item.getDrgInjGroupCnt().toString());
                }
                if (item.getDrgInjHangmogCnt() != null) {
                    info.setDrgInjHangmogCnt(item.getDrgInjHangmogCnt().toString());
                }
                response.addLay9001Item(info);
            }
        }
        return response.build();
    }
}