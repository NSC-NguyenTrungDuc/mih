package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01BongtuInfo;
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
public class DrgsDRG5100P01BongtuInfoHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01BongtuInfoRequest, DrgsServiceProto.DrgsDRG5100P01BongtuInfoResponse> {
    private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01BongtuInfoHandler.class);
    @Resource
    private Drg0120Repository drg0120Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DrgsDRG5100P01BongtuInfoRequest request, Vertx vertx, String clientId, String sessionId) {
        if(!StringUtils.isEmpty(request.getJubsuDate()) && DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) == null){
            return false;
        } else if(!StringUtils.isEmpty(request.getActDate()) && DateUtil.toDate(request.getActDate(), DateUtil.PATTERN_YYMMDD) == null){
            return false;
        }
        return true;
    }

    @Override
    @Transactional
    public DrgsServiceProto.DrgsDRG5100P01BongtuInfoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01BongtuInfoRequest request) throws Exception {
        DrgsDRG5100P01BongtuInfo resultObject = drg0120Repository.getDrgsDRG5100P01BongtuInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
                request.getJubsuDate(), request.getActDate(), request.getBogyongCode(), request.getFkocs1003());
        DrgsServiceProto.DrgsDRG5100P01BongtuInfoResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01BongtuInfoResponse.newBuilder();
        if (!StringUtils.isEmpty(resultObject.getJubsuDateWareki())) {
            response.setJubsuDateWareki(resultObject.getJubsuDateWareki());
        }
        if (!StringUtils.isEmpty(resultObject.getActDateWareki())) {
            response.setActDateWareki(resultObject.getActDateWareki());
        }
        if (!StringUtils.isEmpty(resultObject.getDonbokYn())) {
            response.setDonbokYn(resultObject.getDonbokYn());
        }
        if (!StringUtils.isEmpty(resultObject.getPattern())) {
            response.setPattern(resultObject.getPattern());
        }
        return response.build();
    }
}
