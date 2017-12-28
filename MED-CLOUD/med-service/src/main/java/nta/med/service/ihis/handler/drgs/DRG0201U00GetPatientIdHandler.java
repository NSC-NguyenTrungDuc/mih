package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
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
public class DRG0201U00GetPatientIdHandler extends ScreenHandler<DrgsServiceProto.DRG0201U00GetPatientIdRequest, DrgsServiceProto.DRG0201U00GetPatientIdResponse> {
    private static final Log LOG = LogFactory.getLog(DRG0201U00GetPatientIdHandler.class);
    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DRG0201U00GetPatientIdRequest request, Vertx vertx, String clientId, String sessionId) {
        if(!StringUtils.isEmpty(request.getJubsuDate()) && DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) == null){
            return false;
        }
        return true;
    }

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG0201U00GetPatientIdResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0201U00GetPatientIdRequest request) throws Exception {
        DrgsServiceProto.DRG0201U00GetPatientIdResponse.Builder response = DrgsServiceProto.DRG0201U00GetPatientIdResponse.newBuilder();
        List<String> listObject = drg2010Repository.getDRG0201U00GetPatientId(CommonUtils.parseDouble(request.getDrgBunho()), request.getJubsuDate(), getHospitalCode(vertx, sessionId));
        if (!CollectionUtils.isEmpty(listObject)) {
            for (String patientCode : listObject) {
                if (patientCode != null) {
                    response.addBunho(patientCode);
                }
            }
        }
        return response.build();
    }
}
