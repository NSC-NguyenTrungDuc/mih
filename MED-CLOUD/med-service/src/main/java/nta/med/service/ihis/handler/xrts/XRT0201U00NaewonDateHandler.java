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
public class XRT0201U00NaewonDateHandler extends ScreenHandler<XrtsServiceProto.XRT0201U00NaewonDateRequest, XrtsServiceProto.XRT0201U00NaewonDateResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0201U00NaewonDateHandler.class);
    @Resource
    private Out1001Repository out1001Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0201U00NaewonDateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0201U00NaewonDateRequest request) throws Exception {
        XrtsServiceProto.XRT0201U00NaewonDateResponse.Builder response = XrtsServiceProto.XRT0201U00NaewonDateResponse.newBuilder();
        List<String> list = out1001Repository.getnaewonDateByPkout1001(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getNaewonKey()));
        if (!CollectionUtils.isEmpty(list)) {
            response.setNaewonDate(list.get(0));
        }
        return response.build();
    }
}