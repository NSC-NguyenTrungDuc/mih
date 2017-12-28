package nta.med.service.ihis.handler.chts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ChtsServiceProto;
import nta.med.service.ihis.proto.CommonModelProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class CHT0115Q00LayoutCommonHandler extends ScreenHandler<ChtsServiceProto.CHT0115Q00LayoutCommonRequest, ChtsServiceProto.CHT0115Q00LayoutCommonResponse> {
    private static final Log LOGGER = LogFactory.getLog(CHT0115Q00LayoutCommonHandler.class);
    @Resource
    private Bas0102Repository bas0102Repository;

    @Override
    @Transactional(readOnly = true)
    public ChtsServiceProto.CHT0115Q00LayoutCommonResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, ChtsServiceProto.CHT0115Q00LayoutCommonRequest request) throws Exception {
        ChtsServiceProto.CHT0115Q00LayoutCommonResponse.Builder response = ChtsServiceProto.CHT0115Q00LayoutCommonResponse.newBuilder();
        List<ComboListItemInfo> listLayout = bas0102Repository.getCHT0115Q00LayoutCommon(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(listLayout)) {
            for (ComboListItemInfo item : listLayout) {
                CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addLayoutCommonInfo(info);
            }
        }
        return response.build();
    }
}