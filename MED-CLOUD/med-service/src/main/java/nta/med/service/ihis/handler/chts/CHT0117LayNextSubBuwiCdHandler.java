package nta.med.service.ihis.handler.chts;

import nta.med.data.dao.medi.cht.Cht0118Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ChtsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Service
@Scope("prototype")
public class CHT0117LayNextSubBuwiCdHandler extends ScreenHandler<ChtsServiceProto.CHT0117LayNextSubBuwiCdRequest, ChtsServiceProto.CHT0117LayNextSubBuwiCdResponse> {
    private static final Log LOGGER = LogFactory.getLog(CHT0117LayNextSubBuwiCdHandler.class);
    @Resource
    private Cht0118Repository cht0118Repository;

    @Override
    @Transactional(readOnly = true)
    public ChtsServiceProto.CHT0117LayNextSubBuwiCdResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, ChtsServiceProto.CHT0117LayNextSubBuwiCdRequest request) throws Exception {
        ChtsServiceProto.CHT0117LayNextSubBuwiCdResponse.Builder response = ChtsServiceProto.CHT0117LayNextSubBuwiCdResponse.newBuilder();
        String result = cht0118Repository.getCHT0117LayNextSubBuwiCd(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
        if (!StringUtils.isEmpty(result)) {
            response.setSubBuwi(result);
        }
        return response.build();
    }
}