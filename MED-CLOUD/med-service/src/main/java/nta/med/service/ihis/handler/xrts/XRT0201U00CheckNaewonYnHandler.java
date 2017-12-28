package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
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
public class XRT0201U00CheckNaewonYnHandler extends ScreenHandler<XrtsServiceProto.XRT0201U00CheckNaewonYnRequest, XrtsServiceProto.XRT0201U00CheckNaewonYnResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0201U00CheckNaewonYnHandler.class);
    @Resource
    private Out1001Repository out1001Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0201U00CheckNaewonYnResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0201U00CheckNaewonYnRequest request) throws Exception {
        XrtsServiceProto.XRT0201U00CheckNaewonYnResponse.Builder response = XrtsServiceProto.XRT0201U00CheckNaewonYnResponse.newBuilder();
        String result = "N";
        List<String> list = out1001Repository.OcsaOCS0503U00GetNaewonYn(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getPkout1001()));
        if (!CollectionUtils.isEmpty(list)) {
            if (list.get(0).equals("E")) {
                result = "Y";
            }
        }
        response.setResult(result);
        return response.build();
    }
}