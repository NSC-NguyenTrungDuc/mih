package nta.med.service.ihis.handler.drgs;

import nta.med.data.dao.medi.drg.Drg9043Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class DRG0201U00LockChkHandler extends ScreenHandler<DrgsServiceProto.DRG0201U00LockChkRequest, DrgsServiceProto.DRG0201U00LockChkResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0201U00LockChkHandler.class);
    @Resource
    private Drg9043Repository drg9043Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG0201U00LockChkResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0201U00LockChkRequest request) throws Exception {
        DrgsServiceProto.DRG0201U00LockChkResponse.Builder response = DrgsServiceProto.DRG0201U00LockChkResponse.newBuilder();
        List<String> lockStr = drg9043Repository.validateLock(getHospitalCode(vertx, sessionId));
        if (!CollectionUtils.isEmpty(lockStr)) {
            String lockChk = lockStr.get(0);
            if (!StringUtils.isEmpty(lockStr)) {
                response.setResult(lockChk);
            }
        }
        return response.build();
    }
}