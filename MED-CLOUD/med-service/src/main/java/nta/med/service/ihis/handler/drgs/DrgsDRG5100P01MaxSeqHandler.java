package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.DrgAtcRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;

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
public class DrgsDRG5100P01MaxSeqHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01MaxSeqRequest, DrgsServiceProto.DrgsDRG5100P01MaxSeqResponse> {
    private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01MaxSeqHandler.class);
    @Resource
    private DrgAtcRepository drgAtcRepository;

    @Override
    public boolean isValid(DrgsServiceProto.DrgsDRG5100P01MaxSeqRequest request, Vertx vertx, String clientId, String sessionId) {
        if(!StringUtils.isEmpty(request.getJubsuDate()) && DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) == null){
            return false;
        }
        return true;
    }

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DrgsDRG5100P01MaxSeqResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01MaxSeqRequest request) throws Exception {
        Double drgBunho = CommonUtils.parseDouble(request.getDrgBunho());
        String result = drgAtcRepository.getDrgsDRG5100P01MaxSeq(getHospitalCode(vertx, sessionId), DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD),
                drgBunho, request.getInOutGubun());
        DrgsServiceProto.DrgsDRG5100P01MaxSeqResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01MaxSeqResponse.newBuilder();
        if (!StringUtils.isEmpty(result)) {
            response.setSeq(result);
        }
        return response.build();
    }
}
