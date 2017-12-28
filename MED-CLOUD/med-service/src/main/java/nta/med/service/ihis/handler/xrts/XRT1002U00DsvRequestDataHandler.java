package nta.med.service.ihis.handler.xrts;

import nta.med.core.domain.xrt.Xrt1002;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.xrt.Xrt1002Repository;
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

@Service
@Scope("prototype")
public class XRT1002U00DsvRequestDataHandler extends ScreenHandler<XrtsServiceProto.XRT1002U00DsvRequestDataRequest, XrtsServiceProto.XRT1002U00DsvRequestDataResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT1002U00DsvRequestDataHandler.class);
    @Resource
    private Xrt1002Repository xrt1002Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT1002U00DsvRequestDataResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT1002U00DsvRequestDataRequest request) throws Exception {
        XrtsServiceProto.XRT1002U00DsvRequestDataResponse.Builder response = XrtsServiceProto.XRT1002U00DsvRequestDataResponse.newBuilder();
        List<Xrt1002> list = xrt1002Repository.getByFkOcs(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getFkocs()));
        if (!CollectionUtils.isEmpty(list)) {
            for (Xrt1002 item : list) {
                XrtsModelProto.XRT1002U00DsvRequestDataInfo.Builder info = XrtsModelProto.XRT1002U00DsvRequestDataInfo.newBuilder();
                if (item.getFkocs() != null) {
                    info.setFkocs(item.getFkocs() + "");
                }
                if (!StringUtils.isEmpty(item.getInOutGubun())) {
                    info.setInOutGubun(item.getInOutGubun());
                }
                if (!StringUtils.isEmpty(item.getHangmogCode())) {
                    info.setHangmogCode(item.getHangmogCode());
                }
                if (!StringUtils.isEmpty(item.getGumsaMokjuk())) {
                    info.setGumsaMokjuk(item.getGumsaMokjuk());
                }
                if (!StringUtils.isEmpty(item.getXrayMethod())) {
                    info.setXrayMethod(item.getXrayMethod());
                }
                if (!StringUtils.isEmpty(item.getPandokRequestYn())) {
                    info.setPandokRequestYn(item.getPandokRequestYn());
                }
                if (!StringUtils.isEmpty(item.getBuhaGubun())) {
                    info.setBuhaGubun(item.getBuhaGubun());
                }
                response.addDsvReqDataItem(info);
            }
        }
        return response.build();
    }
}