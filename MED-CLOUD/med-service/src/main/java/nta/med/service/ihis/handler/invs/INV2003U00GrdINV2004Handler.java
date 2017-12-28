package nta.med.service.ihis.handler.invs;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inv.Inv2004Repository;
import nta.med.data.model.ihis.invs.INV2003U00GrdINV2004Info;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class INV2003U00GrdINV2004Handler extends ScreenHandler<InvsServiceProto.INV2003U00GrdINV2004Request, InvsServiceProto.INV2003U00GrdINV2004Response> {
    private static final Log LOGGER = LogFactory.getLog(INV2003U00GrdINV2004Handler.class);

    @Resource
    private Inv2004Repository inv2004Repository;

    @Override
    @Transactional(readOnly = true)
    public InvsServiceProto.INV2003U00GrdINV2004Response handle(Vertx vertx, String clientId,
                                                                String sessionId, long contextId,
                                                                InvsServiceProto.INV2003U00GrdINV2004Request request) throws Exception {
        InvsServiceProto.INV2003U00GrdINV2004Response.Builder response = InvsServiceProto.INV2003U00GrdINV2004Response.newBuilder();
        List<INV2003U00GrdINV2004Info> inv2003U00GrdINV2004Infos = inv2004Repository.getGridINV2004Info(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getFkinv2003()), getLanguage(vertx, sessionId));

        for (INV2003U00GrdINV2004Info item : inv2003U00GrdINV2004Infos) {
            InvsModelProto.INV2003U00GrdINV2004Info.Builder itemBuilder = InvsModelProto.INV2003U00GrdINV2004Info.newBuilder();
            BeanUtils.copyProperties(item, itemBuilder, getLanguage(vertx, sessionId));
            response.addListInfo(itemBuilder);
        }

        return response.build();
    }
}
