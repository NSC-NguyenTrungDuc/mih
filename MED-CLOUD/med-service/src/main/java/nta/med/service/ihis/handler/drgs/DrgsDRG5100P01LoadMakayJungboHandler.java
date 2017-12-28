package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01LoadMakayJungboInfo;
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

import java.util.Date;

@Service
@Scope("prototype")
public class DrgsDRG5100P01LoadMakayJungboHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01LoadMakayJungboRequest, DrgsServiceProto.DrgsDRG5100P01LoadMakayJungboResponse> {
    private static final Log LOGGER = LogFactory.getLog(DrgsDRG5100P01LoadMakayJungboHandler.class);

    @Resource
    private Out0101Repository out0101Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DrgsDRG5100P01LoadMakayJungboRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getJubsuDate())&& DateUtil.toDate(request.getJubsuDate(),DateUtil.PATTERN_YYMMDD) == null) {
            return false;
        }
        return true;
    }

    @Override
    @Transactional
    public DrgsServiceProto.DrgsDRG5100P01LoadMakayJungboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01LoadMakayJungboRequest request) throws Exception {
        Double drgBunho = CommonUtils.parseDouble(request.getDrgBunho());
        Date jubsuDate = DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD);
        DrgsDRG5100P01LoadMakayJungboInfo info = out0101Repository.getDrgsDRG5100P01LoadMakayJungboInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
                request.getIoGobun(), jubsuDate, drgBunho);

        DrgsServiceProto.DrgsDRG5100P01LoadMakayJungboResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01LoadMakayJungboResponse.newBuilder();
        if (info != null) {
            if (!StringUtils.isEmpty(info.getOMayakDoctor())) {
                response.setOMayakDoctor(info.getOMayakDoctor());
            }
            if (!StringUtils.isEmpty(info.getOMayakLicense())) {
                response.setOMayakLicense(info.getOMayakLicense());
            }
            if (!StringUtils.isEmpty(info.getOMayakAddress1())) {
                response.setOMayakAddress1(info.getOMayakAddress1());
            }
            if (!StringUtils.isEmpty(info.getOMayakAddress2())) {
                response.setOMayakAddress2(info.getOMayakAddress2());
            }
        }
        return response.build();
    }
}
