package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.xrt.Xrt0002Repository;
import nta.med.data.model.ihis.xrts.XRT0001U00GrdRadioListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsModelProto;
import nta.med.service.ihis.proto.XrtsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.List;

@Service
@Scope("prototype")
public class XRT0001U00GrdRadioListHandler extends ScreenHandler<XrtsServiceProto.XRT0001U00GrdRadioListRequest, XrtsServiceProto.XRT0001U00GrdRadioListResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0001U00GrdRadioListHandler.class);
    @Resource
    private Xrt0002Repository xrt0002Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0001U00GrdRadioListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0001U00GrdRadioListRequest request) throws Exception {
        XrtsServiceProto.XRT0001U00GrdRadioListResponse.Builder response = XrtsServiceProto.XRT0001U00GrdRadioListResponse.newBuilder();
        //get grdRadio_list
        List<XRT0001U00GrdRadioListInfo> listGrdRadio = xrt0002Repository.getXRT0001U00GrdRadioListItemInfo(getHospitalCode(vertx, sessionId), request.getXrayCode());
        if (listGrdRadio != null && !listGrdRadio.isEmpty()) {
            for (XRT0001U00GrdRadioListInfo item : listGrdRadio) {
                XrtsModelProto.XRT0001U00GrdRadioListInfo.Builder info = XrtsModelProto.XRT0001U00GrdRadioListInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdRadioItem(info);
            }
        }
        return response.build();
    }
}