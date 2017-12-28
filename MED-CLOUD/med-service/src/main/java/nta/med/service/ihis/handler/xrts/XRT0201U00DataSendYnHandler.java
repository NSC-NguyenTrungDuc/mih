package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsServiceProto;
import nta.med.service.ihis.proto.XrtsServiceProto.XRT0201U00DataSendYnResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.ArrayList;
import java.util.List;

@Service
@Scope("prototype")
public class XRT0201U00DataSendYnHandler extends ScreenHandler<XrtsServiceProto.XRT0201U00DataSendYnRequest, XRT0201U00DataSendYnResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0201U00DataSendYnHandler.class);
    @Resource
    private Ocs1003Repository ocs1003Repository;
    @Resource
    private Ocs2003Repository ocs2003Repository;

    @Override
    @Transactional(readOnly = true)
    public XRT0201U00DataSendYnResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0201U00DataSendYnRequest request) throws Exception {
        XRT0201U00DataSendYnResponse.Builder response = XRT0201U00DataSendYnResponse.newBuilder();
        List<String> list = new ArrayList<String>();
        if (request.getInOutGubun().equalsIgnoreCase("O")) {
            list = ocs1003Repository.getIfDataSendYnOCS1003(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getPkocs()));

        } else {
            list = ocs2003Repository.getIfDataSendYnOCS2003(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getPkocs()));
        }
        if (!CollectionUtils.isEmpty(list)) {
            response.setResult(list.get(0) == null ? "N" : list.get(0));
        } else {
            response.setResult("N");
        }
        return response.build();
    }
}