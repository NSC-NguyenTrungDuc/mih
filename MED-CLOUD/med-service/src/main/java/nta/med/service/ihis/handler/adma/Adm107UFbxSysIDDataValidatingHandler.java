package nta.med.service.ihis.handler.adma;

import nta.med.data.dao.medi.adm.Adm0200Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.CommonModelProto;

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
public class Adm107UFbxSysIDDataValidatingHandler extends ScreenHandler<AdmaServiceProto.Adm107UFbxSysIDDataValidatingRequest, AdmaServiceProto.Adm107UFbxSysIDDataValidatingResponse> {
    private static final Log LOGGER = LogFactory.getLog(Adm107UFbxSysIDDataValidatingHandler.class);
    @Resource
    private Adm0200Repository adm0200Repository;

    @Override
    @Transactional(readOnly = true)
    public AdmaServiceProto.Adm107UFbxSysIDDataValidatingResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.Adm107UFbxSysIDDataValidatingRequest request) throws Exception {
        AdmaServiceProto.Adm107UFbxSysIDDataValidatingResponse.Builder response = AdmaServiceProto.Adm107UFbxSysIDDataValidatingResponse.newBuilder();
        List<String> listFbx = adm0200Repository.findSysNm(getLanguage(vertx, sessionId), request.getUserId());
        if (!CollectionUtils.isEmpty(listFbx)) {
            for (String item : listFbx) {
                CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
                if (!StringUtils.isEmpty(item)) {
                    info.setDataValue(item);
                }
                response.addFbxSytemItem(info);
            }
        }
        return response.build();
    }
}