package nta.med.service.ihis.handler.xrts;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.xrt.Xrt0001Repository;
import nta.med.data.model.ihis.xrts.XRT9001R05lay9005RInfo;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.service.ihis.proto.XrtsModelProto;
import nta.med.service.ihis.proto.XrtsServiceProto;
import nta.med.service.ihis.proto.XrtsServiceProto.XRT9001R05lay9005RResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class XRT9001R05lay9005RHandler extends ScreenHandler<XrtsServiceProto.XRT9001R05lay9005RRequest, XrtsServiceProto.XRT9001R05lay9005RResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT9001R05lay9005RHandler.class);
    @Resource
    private Xrt0001Repository xrt0001repository;

    @Override
    @Transactional(readOnly = true)
    public XRT9001R05lay9005RResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT9001R05lay9005RRequest request) throws Exception {
        XrtsServiceProto.XRT9001R05lay9005RResponse.Builder response = XrtsServiceProto.XRT9001R05lay9005RResponse.newBuilder();
        
        String hospCode = getHospitalCode(vertx, sessionId);
        String date = request.getDate();
        
        List<XRT9001R05lay9005RInfo> listInfo = xrt0001repository.getXRT9001R05lay9005RInfo(hospCode, date);
		if (!CollectionUtils.isEmpty(listInfo)) {
			for (XRT9001R05lay9005RInfo item : listInfo) {
				XrtsModelProto.XRT9001R05lay9005RInfo.Builder info = XrtsModelProto.XRT9001R05lay9005RInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addItems(info);
			}
		}
		return response.build();
    }
}
