package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.dao.medi.xrt.Xrt0102Repository;
import nta.med.data.model.ihis.xrts.XRT0000Q00LayMakeTabPageListItemInfo;
import nta.med.data.model.ihis.xrts.XRT0000Q00LayOrderListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsModelProto;
import nta.med.service.ihis.proto.XrtsServiceProto;
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

@Transactional
@Service
@Scope("prototype")
public class XRT0000Q00InitializeHandler extends ScreenHandler<XrtsServiceProto.XRT0000Q00InitializeRequest, XrtsServiceProto.XRT0000Q00InitializeResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0000Q00InitializeHandler.class);
    @Resource
    private Xrt0102Repository xrt0102Repository;
    @Resource
    private Ocs0103Repository ocs0103Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0000Q00InitializeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0000Q00InitializeRequest request) throws Exception {
        XrtsServiceProto.XRT0000Q00InitializeResponse.Builder response = XrtsServiceProto.XRT0000Q00InitializeResponse.newBuilder();
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        //get list make page list
        List<XRT0000Q00LayMakeTabPageListItemInfo> listLayMakeTab = xrt0102Repository.getXRT0000Q00LayMakeTabPage(hospitalCode, language);
        if (!CollectionUtils.isEmpty(listLayMakeTab)) {
            for (XRT0000Q00LayMakeTabPageListItemInfo item : listLayMakeTab) {
                XrtsModelProto.XRT0000Q00LayMakeTabPageListItemInfo.Builder info = XrtsModelProto.XRT0000Q00LayMakeTabPageListItemInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getCode())) {
                    info.setCode(item.getCode());
                }
                if (!StringUtils.isEmpty(item.getCodeName())) {
                    info.setCodeName(item.getCodeName());
                }
                if (item.getSeq() != null) {
                    info.setSeq(String.format("%.0f", item.getSeq()));
                }
                response.addLayMakeTabPageList(info);
            }
            //get list  XRT0000Q00LayOrderListItemInfo
            List<XRT0000Q00LayOrderListItemInfo> listLayOrder = ocs0103Repository.getXRT0000Q00LayOrderList(hospitalCode, language, request.getBunhoLayOrder(), request.getJundalPartLayOrder(), request.getSortLayOrder());
            if (listLayOrder != null && !listLayOrder.isEmpty()) {
                for (XRT0000Q00LayOrderListItemInfo item : listLayOrder) {
                    XrtsModelProto.XRT0000Q00LayOrderListItemInfo.Builder info = XrtsModelProto.XRT0000Q00LayOrderListItemInfo.newBuilder();
                    BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                    response.addLayOrderList(info);
                }
            }
        }
        return response.build();
    }
}
