package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg9041Repository;
import nta.med.data.model.ihis.drgs.DRG9040U01LayPaCommentInfo;
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
public class DRG9040U01LayPaCommentHandler extends ScreenHandler<DrgsServiceProto.DRG9040U01LayPaCommentRequest, DrgsServiceProto.DRG9040U01LayPaCommentResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG9040U01LayPaCommentHandler.class);
    @Resource
    private Drg9041Repository drg9041Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG9040U01LayPaCommentResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG9040U01LayPaCommentRequest request) throws Exception {
        DrgsServiceProto.DRG9040U01LayPaCommentResponse.Builder response = DrgsServiceProto.DRG9040U01LayPaCommentResponse.newBuilder();
        List<DRG9040U01LayPaCommentInfo> list = drg9041Repository.getDRG9040U01LayPaCommentInfo(getHospitalCode(vertx, sessionId), request.getBunho());
        if (!CollectionUtils.isEmpty(list)) {
            for (DRG9040U01LayPaCommentInfo item : list) {
                DrgsModelProto.DRG9040U01LayPaCommentInfo.Builder info = DrgsModelProto.DRG9040U01LayPaCommentInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addLayPaComment(info);
            }
        }
        return response.build();
    }
}
