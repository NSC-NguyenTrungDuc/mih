package nta.med.service.ihis.handler.chts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cht.Cht0115Repository;
import nta.med.data.model.ihis.chts.CHT0115Q00SusikCodeInfo;
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
public class CHT0115Q00SusikCodeHandler extends ScreenHandler<ChtsServiceProto.CHT0115Q00SusikCodeRequest, ChtsServiceProto.CHT0115Q00SusikCodeResponse> {
    private static final Log LOGGER = LogFactory.getLog(CHT0115Q00SusikCodeHandler.class);
    @Resource
    private Cht0115Repository cht0115Repository;

    @Override
    @Transactional(readOnly = true)
    public ChtsServiceProto.CHT0115Q00SusikCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, ChtsServiceProto.CHT0115Q00SusikCodeRequest request) throws Exception {
        ChtsServiceProto.CHT0115Q00SusikCodeResponse.Builder response = ChtsServiceProto.CHT0115Q00SusikCodeResponse.newBuilder();
        List<CHT0115Q00SusikCodeInfo> listSusik = cht0115Repository.getCHT0115Q00SusikCodeInfo(getHospitalCode(vertx, sessionId), request.getSusikCode());
        if (!CollectionUtils.isEmpty(listSusik)) {
            for (CHT0115Q00SusikCodeInfo item : listSusik) {
                ChtsModelProto.CHT0115Q00SusikCodeInfo.Builder info = ChtsModelProto.CHT0115Q00SusikCodeInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addSusikCodeInfo(info);
            }
        }
        return response.build();
    }
}