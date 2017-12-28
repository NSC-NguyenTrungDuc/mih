package nta.med.service.ihis.handler.xrts;

import nta.med.core.domain.xrt.Xrt0123;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.xrt.Xrt0123Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsModelProto;
import nta.med.service.ihis.proto.XrtsServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
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
public class XRT1002U00LayXRT0123Handler extends ScreenHandler<XrtsServiceProto.XRT1002U00LayXRT0123Request, XrtsServiceProto.XRT1002U00LayXRT0123Response> {
    private static final Log LOGGER = LogFactory.getLog(XRT1002U00LayXRT0123Handler.class);
    @Resource
    private Xrt0123Repository xrt0123Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT1002U00LayXRT0123Response handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT1002U00LayXRT0123Request request) throws Exception {
        XrtsServiceProto.XRT1002U00LayXRT0123Response.Builder response = XrtsServiceProto.XRT1002U00LayXRT0123Response.newBuilder();
        Double age = CommonUtils.parseDouble(request.getAge());
        List<Xrt0123> listItem = xrt0123Repository.getXRT1002U00LayXRT0123Info(getHospitalCode(vertx, sessionId), request.getBuwiCode(), age, request.getXrayGubun());
        if (!CollectionUtils.isEmpty(listItem)) {
            for (Xrt0123 itemXrt0123 : listItem) {
                XrtsModelProto.XRT1002U00LayXRT0123Info.Builder info = XrtsModelProto.XRT1002U00LayXRT0123Info.newBuilder();
                if (itemXrt0123.getValtage() != null) {
                    info.setValtage(itemXrt0123.getValtage().toString());
                }
                if (itemXrt0123.getCurElectric() != null) {
                    info.setCurElectric(itemXrt0123.getCurElectric().toString());
                }
                if (itemXrt0123.getTime() != null) {
                    info.setTime(itemXrt0123.getTime().toString());
                }
                if (itemXrt0123.getDistance() != null) {
                    info.setDistance(itemXrt0123.getDistance().toString());
                }
                if (!StringUtils.isEmpty(itemXrt0123.getGrid())) {
                    info.setGrid(itemXrt0123.getGrid());
                }
                if (!StringUtils.isEmpty(itemXrt0123.getNote())) {
                    info.setNote(itemXrt0123.getNote());
                }
                if (itemXrt0123.getMasVal() != null) {
                    info.setMasVal(itemXrt0123.getMasVal().toString());
                }
                response.addLayXrtItem(info);
            }
        }
        return response.build();
    }
}