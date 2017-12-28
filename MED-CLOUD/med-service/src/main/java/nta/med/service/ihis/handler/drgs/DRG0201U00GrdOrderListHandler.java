package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.drgs.DRG0201U00GrdOrderListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class DRG0201U00GrdOrderListHandler extends ScreenHandler<DrgsServiceProto.DRG0201U00GrdOrderListRequest, DrgsServiceProto.DRG0201U00GrdOrderListResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0201U00GrdOrderListHandler.class);
    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG0201U00GrdOrderListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0201U00GrdOrderListRequest request) throws Exception {
        DrgsServiceProto.DRG0201U00GrdOrderListResponse.Builder response = DrgsServiceProto.DRG0201U00GrdOrderListResponse.newBuilder();
        List<DRG0201U00GrdOrderListInfo> listGrd = drg2010Repository.getDRG0201U00GrdOrderListInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getJubsuDate(), request.getDrgBunho());
        if (!CollectionUtils.isEmpty(listGrd)) {
            for (DRG0201U00GrdOrderListInfo item : listGrd) {
                DrgsModelProto.DRG0201U00GrdOrderListInfo.Builder info = DrgsModelProto.DRG0201U00GrdOrderListInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                if (item.getDrgBunho() != null) {
                    info.setDrgBunho(String.format("%.0f", item.getDrgBunho()));
                }
                if (item.getGroupSer() != null) {
                    info.setGroupSer(String.format("%.0f", item.getGroupSer()));
                }
                if (item.getNalsu() != null) {
                    info.setNalsu(String.format("%.0f", item.getNalsu()));
                }
                if (item.getOrdSuryang() != null) {
                    info.setOrdSuryang(String.format("%.0f", item.getOrdSuryang()));
                }
                if (item.getOrderSuryang() != null) {
                    info.setOrderSuryang(String.format("%.0f", item.getOrderSuryang()));
                }
                if (item.getDv() != null) {
                    info.setDv(String.format("%.0f", item.getDv()));
                }
                if (item.getSourceFkocs1003() != null) {
                    info.setSourceFkocs1003(String.format("%.0f", item.getSourceFkocs1003()));
                }
                if (item.getFkocs1003() != null) {
                    info.setFkocs1003(String.format("%.0f", item.getFkocs1003()));
                }
                if (item.getSubulSuryang() != null) {
                    info.setSubulSuryang(String.format("%.0f", item.getSubulSuryang()));
                }
                if (item.getSunabNalsu() != null) {
                    info.setSunabNalsu(String.format("%.0f", item.getSunabNalsu()));
                }
                response.addGrdOrderListItem(info);
            }
        }
        return response.build();
    }
}