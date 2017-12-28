package nta.med.service.ihis.handler.invs;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inv.Inv2003Repository;
import nta.med.data.model.ihis.invs.INV2003U00GrdINV2003Info;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.Date;
import java.util.List;

@Service
@Scope("prototype")
public class INV2003U00GrdINV2003Handler extends ScreenHandler<InvsServiceProto.INV2003U00GrdINV2003Request, InvsServiceProto.INV2003U00GrdINV2003Response> {
    private static final Log LOGGER = LogFactory.getLog(INV2003U00GrdINV2003Handler.class);

    @Resource
    private Inv2003Repository inv2003Repository;

    @Override
    @Transactional(readOnly = true)
    public InvsServiceProto.INV2003U00GrdINV2003Response handle(Vertx vertx, String clientId,
                                                                String sessionId, long contextId,
                                                                InvsServiceProto.INV2003U00GrdINV2003Request request) throws Exception {
        InvsServiceProto.INV2003U00GrdINV2003Response.Builder response = InvsServiceProto.INV2003U00GrdINV2003Response.newBuilder();
        
        Date fromDate = DateUtil.toDate(request.getFromDate() + " 00:00:00", DateUtil.PATTERN_SLASH_YYYYMMDD_HH_COLON_MM_SS);
        Date toDate = DateUtil.toDate(request.getToDate() + " 23:59:59", DateUtil.PATTERN_SLASH_YYYYMMDD_HH_COLON_MM_SS);
        
        List<INV2003U00GrdINV2003Info> inv2003U00GrdINV2003Infos = inv2003Repository.getGridINV2003Info(getHospitalCode(vertx, sessionId), fromDate, toDate, request.getChulgoType());

        for (INV2003U00GrdINV2003Info obj : inv2003U00GrdINV2003Infos) {
            InvsModelProto.INV2003U00GrdINV2003Info.Builder itemBuilder = InvsModelProto.INV2003U00GrdINV2003Info.newBuilder();
            BeanUtils.copyProperties(obj, itemBuilder, getLanguage(vertx, sessionId));
            response.addListInfo(itemBuilder);
        }
        
        return response.build();
    }
}
