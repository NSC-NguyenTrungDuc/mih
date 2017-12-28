package nta.med.service.ihis.handler.chts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cht.Cht0115Repository;
import nta.med.data.model.ihis.chts.CHT0115Q00GrdScInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ChtsModelProto;
import nta.med.service.ihis.proto.ChtsServiceProto;
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
public class CHT0115Q00GrdScPostHandler extends ScreenHandler<ChtsServiceProto.CHT0115Q00GrdScPostRequest, ChtsServiceProto.CHT0115Q00GrdScPostResponse> {
    private static final Log LOGGER = LogFactory.getLog(CHT0115Q00GrdScPostHandler.class);
    @Resource
    private Cht0115Repository cht0115Repository;

    @Override
    @Transactional(readOnly = true)
    public ChtsServiceProto.CHT0115Q00GrdScPostResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, ChtsServiceProto.CHT0115Q00GrdScPostRequest request) throws Exception {
        ChtsServiceProto.CHT0115Q00GrdScPostResponse.Builder response = ChtsServiceProto.CHT0115Q00GrdScPostResponse.newBuilder();
        List<CHT0115Q00GrdScInfo> listGrd = cht0115Repository.getCHT0115Q00GrdScPost(getHospitalCode(vertx, sessionId), request.getSusikDetailGubun(), request.getSusikName());
        if (!CollectionUtils.isEmpty(listGrd)) {
            for (CHT0115Q00GrdScInfo item : listGrd) {
                ChtsModelProto.CHT0115Q00GrdScInfo.Builder info = ChtsModelProto.CHT0115Q00GrdScInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdscPostInfo(info);
            }
        }
        return response.build();
    }
}