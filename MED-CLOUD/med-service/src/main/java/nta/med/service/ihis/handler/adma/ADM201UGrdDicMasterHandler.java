package nta.med.service.ihis.handler.adma;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm1100Repository;
import nta.med.data.model.ihis.adma.ADM201UGrdDicMasterListItemInfo;
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
public class ADM201UGrdDicMasterHandler extends ScreenHandler<AdmaServiceProto.ADM201UGrdDicMasterRequest, AdmaServiceProto.ADM201UGrdDicMasterResponse> {

    private static final Log LOGGER = LogFactory.getLog(ADM201UGrdDicMasterHandler.class);
    @Resource
    private Adm1100Repository adm1100Repository;

    @Override
    @Transactional(readOnly = true)
    public AdmaServiceProto.ADM201UGrdDicMasterResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM201UGrdDicMasterRequest request) throws Exception {
        AdmaServiceProto.ADM201UGrdDicMasterResponse.Builder response = AdmaServiceProto.ADM201UGrdDicMasterResponse.newBuilder();
        String offset = request.getOffset();
  	   	Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
        List<ADM201UGrdDicMasterListItemInfo> list = adm1100Repository.getADM201UGrdDicMasterListItemInfo(request.getColId(), request.getColNm(), startNum, CommonUtils.parseInteger(offset));
        if (!CollectionUtils.isEmpty(list)) {
            for (ADM201UGrdDicMasterListItemInfo item : list) {
                AdmaModelProto.ADM201UGrdDicMasterItemInfo.Builder info = AdmaModelProto.ADM201UGrdDicMasterItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdDicMasterItemInfo(info);
            }
        }
        return response.build();
    }
}
