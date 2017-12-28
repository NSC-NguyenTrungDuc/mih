package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg1000Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class DrgsDRG5100P01FkocListHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01FkocListRequest, DrgsServiceProto.DrgsDRG5100P01FkocListResponse> {
    private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01FkocListHandler.class);
    @Resource
    private Drg1000Repository drg1000Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DrgsDRG5100P01FkocListRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getJubsuDate()) && DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) == null) {
            return false;
        }
        return true;
    }

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DrgsDRG5100P01FkocListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01FkocListRequest request) throws Exception {
        List<String> listResult = drg1000Repository.getDrgsDRG5100P01FkocList(getHospitalCode(vertx, sessionId), request.getJubsuDate(), request.getDrgBunho());
        DrgsServiceProto.DrgsDRG5100P01FkocListResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01FkocListResponse.newBuilder();
        if (!CollectionUtils.isEmpty(listResult)) {
            for (String item : listResult) {
                DrgsModelProto.DrgsDRG5100P01FkocListItemInfo.Builder info = DrgsModelProto.DrgsDRG5100P01FkocListItemInfo.newBuilder();
                if (!StringUtils.isEmpty(item)) {
                    info.setFkoc(item);
                }
                response.addFkocList(info);
            }
        }
        return response.build();
    }
}
