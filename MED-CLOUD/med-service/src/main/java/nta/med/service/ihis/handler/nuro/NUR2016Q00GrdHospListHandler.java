package nta.med.service.ihis.handler.nuro;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.nuro.NUR2016Q00GrdHospListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
public class NUR2016Q00GrdHospListHandler extends ScreenHandler<NuroServiceProto.NUR2016Q00GrdHospListRequest, NuroServiceProto.NUR2016Q00GrdHospListResponse> {

    @Resource
    Bas0001Repository bas0001Repository;
    
    @Override
    @Transactional(readOnly = true)
    public NuroServiceProto.NUR2016Q00GrdHospListResponse handle(Vertx vertx, String clientId, String sessionId,
                                                                 long contextId, NuroServiceProto.NUR2016Q00GrdHospListRequest request) throws Exception {
        NuroServiceProto.NUR2016Q00GrdHospListResponse.Builder response = NuroServiceProto.NUR2016Q00GrdHospListResponse.newBuilder();
        String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
        List<NUR2016Q00GrdHospListInfo> nur2016Q00GrdHospListInfos = bas0001Repository.getNUR2016Q00GrdHospListInfo(request.getHospCode(), getLanguage(vertx, sessionId),
                request.getYoyangName(), request.getAddress(), startNum, CommonUtils.parseInteger(offset));

        if (!CollectionUtils.isEmpty(nur2016Q00GrdHospListInfos)) {
            for (NUR2016Q00GrdHospListInfo item : nur2016Q00GrdHospListInfos) {
                NuroModelProto.NUR2016Q00GrdHospListInfo.Builder info = NuroModelProto.NUR2016Q00GrdHospListInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addHospListItem(info);
            }
        }
        return response.build();
    }
}
