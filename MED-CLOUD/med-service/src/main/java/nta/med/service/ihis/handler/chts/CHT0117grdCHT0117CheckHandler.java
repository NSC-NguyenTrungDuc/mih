package nta.med.service.ihis.handler.chts;

import nta.med.data.dao.medi.cht.Cht0117Repository;
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
public class CHT0117grdCHT0117CheckHandler extends ScreenHandler<ChtsServiceProto.CHT0117grdCHT0117CheckRequest, ChtsServiceProto.CHT0117grdCHT0117CheckResponse> {
    private static final Log LOGGER = LogFactory.getLog(CHT0117grdCHT0117CheckHandler.class);
    @Resource
    private Cht0117Repository cht0117Repository;

    @Override
    @Transactional(readOnly = true)
    public ChtsServiceProto.CHT0117grdCHT0117CheckResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, ChtsServiceProto.CHT0117grdCHT0117CheckRequest request) throws Exception {
        ChtsServiceProto.CHT0117grdCHT0117CheckResponse.Builder response = ChtsServiceProto.CHT0117grdCHT0117CheckResponse.newBuilder();
        String result = cht0117Repository.getCHT0117grdCHT0117Check(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBuwi());
        if (!StringUtils.isEmpty(result)) {
            response.setChkResult(result);
        }
        return response.build();
    }
}