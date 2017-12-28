package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.dao.medi.ocs.Ocs0313Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.ocso.OCSACTDefaultJearyoInfo;
import nta.med.data.model.ihis.xrts.XRT0201U00GrdJaeryoItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
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
public class XRT0201U00GrdOrderRowFocusChangedHandler extends ScreenHandler<XrtsServiceProto.XRT0201U00GrdOrderRowFocusChangedRequest, XrtsServiceProto.XRT0201U00GrdOrderRowFocusChangedResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0201U00GrdOrderRowFocusChangedHandler.class);
    @Resource
    private Ocs0103Repository ocs0103Repository;
    @Resource
    private OutsangRepository outsangRepository;
    @Resource
    private Ocs0313Repository ocs0313Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0201U00GrdOrderRowFocusChangedResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0201U00GrdOrderRowFocusChangedRequest request) throws Exception {
        XrtsServiceProto.XRT0201U00GrdOrderRowFocusChangedResponse.Builder response = XrtsServiceProto.XRT0201U00GrdOrderRowFocusChangedResponse.newBuilder();
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        //grdJaeryo
        List<XRT0201U00GrdJaeryoItemInfo> listDrdJaeryo = ocs0103Repository.getXRT0201U00GrdJaeryoItem(request.getBunho(),
                request.getOrderDate(), request.getIoGubun(), request.getJundalPart(), CommonUtils.parseDouble(request.getFkocs()), hospitalCode, language);
        if (!CollectionUtils.isEmpty(listDrdJaeryo)) {
            for (XRT0201U00GrdJaeryoItemInfo item : listDrdJaeryo) {
                XrtsModelProto.XRT0201U00GrdJaeryoItemInfo.Builder info = XrtsModelProto.XRT0201U00GrdJaeryoItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdJaeryoItemInfo(info);
            }
        }

        //grdSangByung
        List<String> listGrdSangByung = outsangRepository.getOCSACTGrdSangByungInfo(hospitalCode, request.getBunho(), DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD));
        if (!CollectionUtils.isEmpty(listGrdSangByung)) {
            for (String item : listGrdSangByung) {
                CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
                info.setDataValue(item);
                response.addSangName(info);
            }
        }

        //defaultJearyo
        if (Integer.parseInt(request.getGrdOrderRowCount()) > 0 && listDrdJaeryo.size() > 0) {
            List<OCSACTDefaultJearyoInfo> listDefaultJearyo = ocs0313Repository.getOCSACTDefaultJearyoInfo(hospitalCode, language, request.getHangmogCode());
            if (!CollectionUtils.isEmpty(listDefaultJearyo)) {
                for (OCSACTDefaultJearyoInfo item : listDefaultJearyo) {
                    XrtsModelProto.XRT0201U00DefaultJearyoItemInfo.Builder info = XrtsModelProto.XRT0201U00DefaultJearyoItemInfo.newBuilder();
                    BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                    response.addDefaultJearyoItemInfo(info);
                }
            }
        }
        return response.build();
    }
}