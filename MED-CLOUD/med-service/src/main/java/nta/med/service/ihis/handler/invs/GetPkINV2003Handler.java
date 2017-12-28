package nta.med.service.ihis.handler.invs;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.service.ihis.proto.InvsServiceProto;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
@Transactional
public class GetPkINV2003Handler extends ScreenHandler<InvsServiceProto.GetPkINV2003Request, InvsServiceProto.GetPkINV2003Response> {

    @Resource
    private CommonRepository commonRepository;
    @Override
    public InvsServiceProto.GetPkINV2003Response handle(Vertx vertx, String clientId, String sessionId, long contextId, InvsServiceProto.GetPkINV2003Request request) throws Exception {
        InvsServiceProto.GetPkINV2003Response.Builder response =  InvsServiceProto.GetPkINV2003Response.newBuilder();
        String result = commonRepository.getNextVal("INV2003_SEQ");
        if(!StringUtils.isEmpty(result)){
            response.setPkinv2003(result);
        }
        return response.build();
    }
}
