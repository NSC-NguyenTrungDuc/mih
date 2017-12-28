package nta.med.service.ihis.handler.adma;

import nta.med.data.dao.medi.adm.Adm3100Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;

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
public class ADM104UFindBoxHandler extends ScreenHandler<AdmaServiceProto.ADM104UFindBoxRequest, SystemServiceProto.ComboResponse> {
    private static final Log LOGGER = LogFactory.getLog(ADM104UFindBoxHandler.class);
    @Resource
    private Adm3100Repository adm3100Repository;

    @Override
    @Transactional(readOnly = true)
    public SystemServiceProto.ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM104UFindBoxRequest request) throws Exception {
        SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
        switch (request.getControlName()) {
            case "fbxUserGroup":
                List<ComboListItemInfo> listResult = adm3100Repository.getComboUserGroup(request.getHospCode(), getLanguage(vertx, sessionId), false);
                if (listResult != null && !listResult.isEmpty()) {
                    for (ComboListItemInfo item : listResult) {
                        CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                        if (!StringUtils.isEmpty(item.getCode())) {
                            info.setCode(item.getCode());
                        }
                        if (!StringUtils.isEmpty(item.getCodeName())) {
                            info.setCodeName(item.getCodeName());
                        }
                        response.addComboItem(info);
                    }
                }
                break;

            default:
                break;
        }
        return response.build();
    }
}
