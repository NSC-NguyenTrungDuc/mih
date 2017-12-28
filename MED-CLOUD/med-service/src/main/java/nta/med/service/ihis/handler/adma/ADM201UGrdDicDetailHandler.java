package nta.med.service.ihis.handler.adma;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm1110Repository;
import nta.med.data.model.ihis.adma.ADM201UGrdDicDetailOderListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;

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
public class ADM201UGrdDicDetailHandler extends ScreenHandler<AdmaServiceProto.ADM201UGrdDicDetailRequest, AdmaServiceProto.ADM201UGrdDicDetailResponse> {

    private static final Log LOGGER = LogFactory.getLog(ADM201UGrdDicDetailHandler.class);
    @Resource
    private Adm1110Repository adm1110Repository;

    @Override
    @Transactional(readOnly = true)
    public AdmaServiceProto.ADM201UGrdDicDetailResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM201UGrdDicDetailRequest request) throws Exception {
        AdmaServiceProto.ADM201UGrdDicDetailResponse.Builder response = AdmaServiceProto.ADM201UGrdDicDetailResponse.newBuilder();
        String offset = request.getOffset();
  	   	Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
        List<ADM201UGrdDicDetailOderListItemInfo> list = adm1110Repository.getADM201UGrdDicDetailOderListItemInfo(request.getColId(), startNum, CommonUtils.parseInteger(offset), getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(list)) {
            for (ADM201UGrdDicDetailOderListItemInfo item : list) {
                AdmaModelProto.ADM201UGrdDicDetailItemInfo.Builder info = AdmaModelProto.ADM201UGrdDicDetailItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdDicDetailItemInfo(info);
            }
        }
        return response.build();
    }
}
