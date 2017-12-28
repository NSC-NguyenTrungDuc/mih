package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0313Repository;
import nta.med.data.model.ihis.ocso.OCSACTGrdJaeryoGridColumnChangedInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsModelProto;
import nta.med.service.ihis.proto.XrtsServiceProto;

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
public class XRT0201U00GrdJaeryoColumnChangedHandler extends ScreenHandler<XrtsServiceProto.XRT0201U00GrdJaeryoColumnChangedRequest, XrtsServiceProto.XRT0201U00GrdJaeryoColumnChangedResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0201U00GrdJaeryoColumnChangedHandler.class);
    @Resource
    private Ocs0313Repository ocs0313Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0201U00GrdJaeryoColumnChangedResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0201U00GrdJaeryoColumnChangedRequest request) throws Exception {
        XrtsServiceProto.XRT0201U00GrdJaeryoColumnChangedResponse.Builder response = XrtsServiceProto.XRT0201U00GrdJaeryoColumnChangedResponse.newBuilder();
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        List<OCSACTGrdJaeryoGridColumnChangedInfo> list = ocs0313Repository.getOCSACTGrdJaeryoGridColumnChangedInfo(hospitalCode, language,
                request.getHangmogCode(), request.getSHangmogCode(), true);
        if (CollectionUtils.isEmpty(list)) {
            list = ocs0313Repository.getOCSACTGrdJaeryoGridColumnChangedInfoCaseElse(hospitalCode, language, request.getSHangmogCode(), true);
        }
        if (!CollectionUtils.isEmpty(list)) {
            for (OCSACTGrdJaeryoGridColumnChangedInfo item : list) {
                XrtsModelProto.XRT0201U00GrdJaeryoColumnChangedItemInfo.Builder info = XrtsModelProto.XRT0201U00GrdJaeryoColumnChangedItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdJaeryoItemInfo(info);
            }
        }
        return response.build();
    }
}