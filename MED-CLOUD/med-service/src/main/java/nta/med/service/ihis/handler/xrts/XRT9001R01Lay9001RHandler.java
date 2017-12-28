package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.xrt.Xrt0001Repository;
import nta.med.data.model.ihis.xrts.XRT9001R01Lay9001RListItemInfo;
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

@Transactional
@Service
@Scope("prototype")
public class XRT9001R01Lay9001RHandler extends ScreenHandler<XrtsServiceProto.XRT9001R01Lay9001RRequest, XrtsServiceProto.XRT9001R01Lay9001RResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT9001R01Lay9001RHandler.class);
    @Resource
    private Xrt0001Repository xrt0001Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT9001R01Lay9001RResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT9001R01Lay9001RRequest request) throws Exception {
        XrtsServiceProto.XRT9001R01Lay9001RResponse.Builder response = XrtsServiceProto.XRT9001R01Lay9001RResponse.newBuilder();
        List<XRT9001R01Lay9001RListItemInfo> listLay9001 = xrt0001Repository.getXRT9001R01Lay9001RListItemInfo(getHospitalCode(vertx, sessionId), request.getDate());
        if (listLay9001 != null && !listLay9001.isEmpty()) {
            for (XRT9001R01Lay9001RListItemInfo item : listLay9001) {
                XrtsModelProto.XRT9001R01Lay9001RListItemInfo.Builder info = XrtsModelProto.XRT9001R01Lay9001RListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                if (item.getCrCntN() != null) {
                    info.setCrCntN(String.format("%.0f", item.getCrCntN()));
                }
                if (item.getCrCntY() != null) {
                    info.setCrCntY(String.format("%.0f", item.getCrCntY()));
                }
                if (item.getDrCntN() != null) {
                    info.setDrCntN(String.format("%.0f", item.getDrCntN()));
                }
                if (item.getDrCntY() != null) {
                    info.setDrCntY(String.format("%.0f", item.getDrCntY()));
                }
                if (item.getCtCntN() != null) {
                    info.setCtCntN(String.format("%.0f", item.getCtCntN()));
                }
                if (item.getCtCntY() != null) {
                    info.setCtCntY(String.format("%.0f", item.getCtCntY()));
                }
                if (item.getMriCntN() != null) {
                    info.setMriCntN(String.format("%.0f", item.getMriCntN()));
                }
                if (item.getMriCntY() != null) {
                    info.setMriCntY(String.format("%.0f", item.getMriCntY()));
                }
                if (item.getTotalCnt() != null) {
                    info.setTotalCnt(String.format("%.0f", item.getTotalCnt()));
                }
                response.addLay9001RList(info);
            }
        }
        return response.build();
    }
}
