package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.Date;

@Transactional
@Service
@Scope("prototype")
public class DrgsDRG5100P01UpdateFkdrg4010InDRG2010Handler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01UpdateFkdrg4010InDRG2010Request, SystemServiceProto.UpdateResponse> {
    private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01UpdateFkdrg4010InDRG2010Handler.class);
    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DrgsDRG5100P01UpdateFkdrg4010InDRG2010Request request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getJubsuDate()) && DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) == null) {
            return false;
        }
        return true;
    }

    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01UpdateFkdrg4010InDRG2010Request request) throws Exception {

        boolean result = updateDrgsDRG5100P01UpdateFkdrg4010InDRG2010(request, getHospitalCode(vertx, sessionId));
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        response.setResult(result);
        return response.build();
    }

    private boolean updateDrgsDRG5100P01UpdateFkdrg4010InDRG2010(DrgsServiceProto.DrgsDRG5100P01UpdateFkdrg4010InDRG2010Request request, String hospitalCode) throws Exception {
        try {
            Double fkdrg4010 = CommonUtils.parseDouble(request.getPkdrg4010());
            Date jubsuDate = DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD);
            Double drgBunho = CommonUtils.parseDouble(request.getDrgBunho());
            if (drg2010Repository.updateDrgsDRG5100P01UpdateFkdrg4010InDRG2010(fkdrg4010, hospitalCode, jubsuDate, drgBunho, request.getBunho()) > 0)
                return true;
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return false;
        }
        return false;
    }
}
