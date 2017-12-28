package nta.med.service.ihis.handler.chts;

import nta.med.data.dao.medi.cht.Cht0110Repository;
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
public class CHT0110U00GetCodeNameHandler extends ScreenHandler<ChtsServiceProto.CHT0110U00GetCodeNameRequest, ChtsServiceProto.CHT0110U00GetCodeNameResponse> {
    private static final Log LOGGER = LogFactory.getLog(CHT0110U00GetCodeNameHandler.class);
    @Resource
    private Cht0110Repository cht0110Repository;

    @Override
    @Transactional(readOnly = true)
    public ChtsServiceProto.CHT0110U00GetCodeNameResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, ChtsServiceProto.CHT0110U00GetCodeNameRequest request) throws Exception {
        String hospitalCode = getHospitalCode(vertx, sessionId);
        ChtsServiceProto.CHT0110U00GetCodeNameResponse.Builder response = ChtsServiceProto.CHT0110U00GetCodeNameResponse.newBuilder();
        String codeName = "";
        switch (request.getCodeMode()) {
            case "sang_code":
                codeName = cht0110Repository.getCHT0110U00GetCodeName(hospitalCode, request.getCode());
                break;
            case "suga_sang_code":
                codeName = cht0110Repository.getCHT0110U00GetCodeName(hospitalCode, request.getCode());
                break;
            default:
                break;
        }
        if (!StringUtils.isEmpty(codeName)) {
            response.setCodeName(codeName);
        }
        return response.build();
    }
}