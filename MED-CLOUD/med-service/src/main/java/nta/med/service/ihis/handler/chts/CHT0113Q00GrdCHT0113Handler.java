package nta.med.service.ihis.handler.chts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cht.Cht0113Repository;
import nta.med.data.model.ihis.chts.CHT0113Q00GrdCHT0113Info;
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
public class CHT0113Q00GrdCHT0113Handler extends ScreenHandler<ChtsServiceProto.CHT0113Q00GrdCHT0113Request, ChtsServiceProto.CHT0113Q00GrdCHT0113Response> {
    private static final Log LOGGER = LogFactory.getLog(CHT0113Q00GrdCHT0113Handler.class);
    @Resource
    private Cht0113Repository cht0113Repository;

    @Override
    @Transactional(readOnly = true)
    public ChtsServiceProto.CHT0113Q00GrdCHT0113Response handle(Vertx vertx, String clientId, String sessionId, long contextId, ChtsServiceProto.CHT0113Q00GrdCHT0113Request request) throws Exception {
        ChtsServiceProto.CHT0113Q00GrdCHT0113Response.Builder response = ChtsServiceProto.CHT0113Q00GrdCHT0113Response.newBuilder();
        List<CHT0113Q00GrdCHT0113Info> list = cht0113Repository.getCHT0113Q00GrdCHT0113Info(request.getDisabilityName(), request.getDate());
        if (!CollectionUtils.isEmpty(list)) {
            for (CHT0113Q00GrdCHT0113Info item : list) {
                ChtsModelProto.CHT0113Q00GrdCHT0113Info.Builder info = ChtsModelProto.CHT0113Q00GrdCHT0113Info.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdCHT0113Info(info);
            }
        }
        return response.build();
    }
}