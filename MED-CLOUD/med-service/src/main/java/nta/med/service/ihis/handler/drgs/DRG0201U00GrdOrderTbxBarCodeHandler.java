package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.drgs.DRG0201U00GrdOrderInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto;
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
public class DRG0201U00GrdOrderTbxBarCodeHandler extends ScreenHandler<DrgsServiceProto.DRG0201U00GrdOrderTbxBarCodeRequest, DrgsServiceProto.DRG0201U00GrdOrderTbxBarCodeResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0201U00GrdOrderTbxBarCodeHandler.class);
    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DRG0201U00GrdOrderTbxBarCodeRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getOrerDate()) && DateUtil.toDate(request.getOrerDate(), DateUtil.PATTERN_YYMMDD_BLANK) == null) {
            return false;
        }
        return true;
    }

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG0201U00GrdOrderTbxBarCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0201U00GrdOrderTbxBarCodeRequest request) throws Exception {
        DrgsServiceProto.DRG0201U00GrdOrderTbxBarCodeResponse.Builder response = DrgsServiceProto.DRG0201U00GrdOrderTbxBarCodeResponse.newBuilder();
        // 1.Get Act
        String actChk = null;
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String checkActing = drg2010Repository.checkActing(hospitalCode, request.getOrerDate(), CommonUtils.parseDouble(request.getDrgBunho()));
        if (StringUtils.isEmpty(checkActing)) {
            actChk = "Y";
        } else {
            actChk = checkActing;
        }
        String checkJubsuIlsi = drg2010Repository.checkJubsuIlsi(hospitalCode, request.getOrerDate(), CommonUtils.parseDouble(request.getDrgBunho()));
        if (!StringUtils.isEmpty(checkJubsuIlsi)) {
            actChk = checkJubsuIlsi;
        }
        response.setActYn(actChk);

        //2 Get Grd
        String language = getLanguage(vertx, sessionId);
        List<DRG0201U00GrdOrderInfo> listObject = drg2010Repository.getDRG0201U00DetailServerCallInfo(hospitalCode, language, request.getOrerDate(), null, request.getDrgBunho(), null);
        if (!CollectionUtils.isEmpty(listObject)) {
            for (DRG0201U00GrdOrderInfo item : listObject) {
                DrgsModelProto.DRG0201U00GrdOrderInfo.Builder info = DrgsModelProto.DRG0201U00GrdOrderInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdOrderItem(info);
            }
        }

        return response.build();
    }
}