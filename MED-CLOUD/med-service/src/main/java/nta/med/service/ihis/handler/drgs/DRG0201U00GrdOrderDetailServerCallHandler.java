package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.drgs.DRG0201U00GrdOrderInfo;
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
public class DRG0201U00GrdOrderDetailServerCallHandler extends ScreenHandler<DrgsServiceProto.DRG0201U00GrdOrderDetailServerCallRequest, DrgsServiceProto.DRG0201U00GrdOrderDetailServerCallResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0201U00GrdOrderDetailServerCallHandler.class);
    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DRG0201U00GrdOrderDetailServerCallRequest request, Vertx vertx, String clientId, String sessionId) {
        if(!StringUtils.isEmpty(request.getJubsuDate()) && DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD_BLANK) == null){
            return false;
        }
        return true;
    }

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG0201U00GrdOrderDetailServerCallResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0201U00GrdOrderDetailServerCallRequest request) throws Exception {
        DrgsServiceProto.DRG0201U00GrdOrderDetailServerCallResponse.Builder response = DrgsServiceProto.DRG0201U00GrdOrderDetailServerCallResponse.newBuilder();
        List<DRG0201U00GrdOrderInfo> listObject = drg2010Repository.getDRG0201U00DetailServerCallInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getJubsuDate(), request.getBunho(), request.getDrgBunho(), "");
        if (!CollectionUtils.isEmpty(listObject)) {
            for (DRG0201U00GrdOrderInfo item : listObject) {
                DrgsModelProto.DRG0201U00GrdOrderInfo.Builder info = DrgsModelProto.DRG0201U00GrdOrderInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                if (item.getDrgBunho() != null) {
                    info.setDrgBunho(String.format("%.0f", item.getDrgBunho()));
                }
                if (item.getFkout1001() != null) {
                    info.setFkout1001(String.format("%.0f", item.getFkout1001()));
                }
                response.addGrdOrderItem(info);
            }
        }

        return response.build();
    }
}