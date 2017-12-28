package nta.med.service.ihis.handler.chts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cht.Cht0118Repository;
import nta.med.data.model.ihis.chts.CHT0117Q00GrdCHT0118Info;
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
public class CHT0117Q00GrdCHT0118Handler extends ScreenHandler<ChtsServiceProto.CHT0117Q00GrdCHT0118Request, ChtsServiceProto.CHT0117Q00GrdCHT0118Response> {
    private static final Log LOGGER = LogFactory.getLog(CHT0117Q00GrdCHT0118Handler.class);
    @Resource
    private Cht0118Repository cht0118Repository;

    @Override
    @Transactional(readOnly = true)
    public ChtsServiceProto.CHT0117Q00GrdCHT0118Response handle(Vertx vertx, String clientId, String sessionId, long contextId, ChtsServiceProto.CHT0117Q00GrdCHT0118Request request) throws Exception {
        ChtsServiceProto.CHT0117Q00GrdCHT0118Response.Builder response = ChtsServiceProto.CHT0117Q00GrdCHT0118Response.newBuilder();
        List<CHT0117Q00GrdCHT0118Info> listGrd = cht0118Repository.getCHT0117Q00GrdCHT0118Request(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
        		request.getGubun(), request.getBuwi(), request.getBuwiName());
        if (!CollectionUtils.isEmpty(listGrd)) {
            for (CHT0117Q00GrdCHT0118Info item : listGrd) {
                ChtsModelProto.CHT0117Q00GrdCHT0118Info.Builder info = ChtsModelProto.CHT0117Q00GrdCHT0118Info.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrd0118Info(info);
            }
        }
        return response.build();
    }
}
