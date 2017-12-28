package nta.med.service.ihis.handler.chts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cht.Cht0117Repository;
import nta.med.data.model.ihis.chts.CHT0117Q00DloCHT0117Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ChtsModelProto;
import nta.med.service.ihis.proto.ChtsServiceProto;
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
public class CHT0117Q00DloCHT0117Handler extends ScreenHandler<ChtsServiceProto.CHT0117Q00DloCHT0117Request, ChtsServiceProto.CHT0117Q00DloCHT0117Response> {
    private static final Log LOGGER = LogFactory.getLog(CHT0117Q00DloCHT0117Handler.class);
    @Resource
    private Cht0117Repository cht0117Repository;

    @Override
    @Transactional(readOnly = true)
    public ChtsServiceProto.CHT0117Q00DloCHT0117Response handle(Vertx vertx, String clientId, String sessionId, long contextId, ChtsServiceProto.CHT0117Q00DloCHT0117Request request) throws Exception {
        ChtsServiceProto.CHT0117Q00DloCHT0117Response.Builder response = ChtsServiceProto.CHT0117Q00DloCHT0117Response.newBuilder();
        List<CHT0117Q00DloCHT0117Info> listGrd = cht0117Repository.getCHT0117Q00DloCHT0117Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(listGrd)) {
            for (CHT0117Q00DloCHT0117Info item : listGrd) {
                ChtsModelProto.CHT0117Q00DloCHT0117Info.Builder info = ChtsModelProto.CHT0117Q00DloCHT0117Info.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addCht0117Info(info);
            }
        }
        return response.build();
    }
}
