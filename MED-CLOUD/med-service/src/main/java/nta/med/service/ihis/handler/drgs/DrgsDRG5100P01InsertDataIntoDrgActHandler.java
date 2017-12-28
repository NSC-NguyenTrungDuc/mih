package nta.med.service.ihis.handler.drgs;

import nta.med.core.domain.drg.DrgAtc;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.DrgAtcRepository;
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

@Service
@Scope("prototype")
public class DrgsDRG5100P01InsertDataIntoDrgActHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01InsertDataIntoDrgActRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01InsertDataIntoDrgActHandler.class);
    @Resource
    private DrgAtcRepository drgAtcRepository;

    @Override
    @Transactional
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01InsertDataIntoDrgActRequest request) throws Exception {
        boolean result = insertDrgAtc(request, getHospitalCode(vertx, sessionId));
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        response.setResult(result);
        return response.build();
    }

    @Override
    public boolean isValid(DrgsServiceProto.DrgsDRG5100P01InsertDataIntoDrgActRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getJubsuDate())&& DateUtil.toDate(request.getJubsuDate(),DateUtil.PATTERN_YYMMDD) == null) {
            return false;
        }
        return true;
    }

    private boolean insertDrgAtc(DrgsServiceProto.DrgsDRG5100P01InsertDataIntoDrgActRequest request, String hospitalCode) throws Exception {
        try {
            DrgAtc drgAtc = new DrgAtc();
            drgAtc.setSysDate(new Date());
            if (!StringUtils.isEmpty(request.getUserId())) {
                drgAtc.setUpdId(request.getUserId());
            }
            drgAtc.setUpdDate(new Date());
            if (!StringUtils.isEmpty(request.getJubsuDate())) {
                drgAtc.setJubsuDate(DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD));
            }
            if (!StringUtils.isEmpty(request.getDrgBunho())) {
                Double drgBunho = CommonUtils.parseDouble(request.getDrgBunho());
                drgAtc.setDrgBunho(drgBunho);
            }
            if (!StringUtils.isEmpty(request.getInOutGubun())) {
                drgAtc.setInOutGubun(request.getInOutGubun());
            }
            if (!StringUtils.isEmpty(request.getSeq())) {
                Double seq = CommonUtils.parseDouble(request.getSeq());
                drgAtc.setSeq(seq);
            } else {
                drgAtc.setSeq(1D);
            }
//			drgAtc.setInputDate(DateUtil.getDateTime(new Date(), DateUtil.PATTERN_YYMMDD));
//			drgAtc.setInputTime(DateUtil.getCurrentHH24MI());
            drgAtc.setEndFlag("N");
            drgAtc.setHospCode(hospitalCode);
            drgAtcRepository.save(drgAtc);
            return true;
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return false;
        }
    }
}
