package nta.med.service.ihis.handler.drgs;

import nta.med.core.domain.ocs.Ocs5010;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.dao.medi.ocs.Ocs5010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import java.util.Date;

@Service
@Scope("prototype")
@Transactional
public class DrgsDRG5100P01CheckDsvBoRyuHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01CheckDsvBoRyuRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01CheckDsvBoRyuHandler.class);
    @Resource
    private Drg2010Repository drg2010Repository;
    @Resource
    private Ocs5010Repository ocs5010Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DrgsDRG5100P01CheckDsvBoRyuRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) == null) {
            return false;
        } else {
            try {
                CommonUtils.parseDouble(request.getDrgBunho());
            } catch (NumberFormatException e) {
                return false;
            }
        }
        return true;
    }

    private void insertOcs5010(DrgsServiceProto.DrgsDRG5100P01CheckDsvBoRyuRequest request, String hospitalCode) {
        Ocs5010 ocs5010 = new Ocs5010();
        ocs5010.setSysDate(new Date());
        ocs5010.setSysId(request.getUserId());
        ocs5010.setUpdDate(new Date());
        ocs5010.setDoctor(request.getDoctor());
        ocs5010.setBunho(request.getBunho());
        ocs5010.setJundalTable("DRG");
        ocs5010.setResultDate(DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD));
        ocs5010.setConfirmYn(request.getBoryuYn());
        ocs5010.setHospCode(hospitalCode);
        ocs5010Repository.save(ocs5010);
    }

    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01CheckDsvBoRyuRequest request) throws Exception {
        Double drgBunho = !StringUtils.isEmpty(request.getDrgBunho()) ? new Double(request.getDrgBunho()) : null;
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String hospitalCode = getHospitalCode(vertx, sessionId);
        drg2010Repository.updateBoryuYn(request.getBoryuYn(), hospitalCode, drgBunho, request.getGwa(), request.getDoctor(), request.getBunho(), request.getOrderDate());
        Integer result = ocs5010Repository.updateOcs5010(request.getUserId(), new Date(), request.getBoryuYn(), DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD), hospitalCode, request.getDoctor(), request.getBunho());

        if (result <= 0) {
            insertOcs5010(request, hospitalCode);
        }
        response.setResult(true);
        return response.build();
    }
}
