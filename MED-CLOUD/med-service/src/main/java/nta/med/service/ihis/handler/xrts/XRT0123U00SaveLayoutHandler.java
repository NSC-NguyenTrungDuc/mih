package nta.med.service.ihis.handler.xrts;

import nta.med.core.domain.xrt.Xrt0123;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.xrt.Xrt0123Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.XrtsModelProto.XRT0123U00GrdDCodeItemInfo;
import nta.med.service.ihis.proto.XrtsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;
import java.util.Date;

@Service
@Scope("prototype")
@Transactional
public class XRT0123U00SaveLayoutHandler extends ScreenHandler<XrtsServiceProto.XRT0123U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0123U00SaveLayoutHandler.class);
    @Resource
    private Xrt0123Repository xrt0123Repository;

    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0123U00SaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String hospitalCode = getHospitalCode(vertx, sessionId);
        Integer result = null;
        for (XRT0123U00GrdDCodeItemInfo info : request.getInputListList()) {
            if (DataRowState.ADDED.getValue().equals(info.getRowState())) {
                insertXrt0123(info, request.getUserId(), hospitalCode);
                result = 1;
            } else if (DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
                result = xrt0123Repository.updateXrt0123(request.getUserId(), new Date(), CommonUtils.parseDouble(info.getValtage()),
                        CommonUtils.parseDouble(info.getCurElectric()), CommonUtils.parseDouble(info.getTime()),
                        CommonUtils.parseDouble(info.getDistance()), info.getGrid(), info.getNote(),
                        CommonUtils.parseDouble(info.getFromAge()), CommonUtils.parseDouble(info.getToAge()), CommonUtils.parseDouble(info.getMasVal()),
                        hospitalCode, info.getXrayGubun(), info.getBuwiCode());
                if (result <= 0) {
                    insertXrt0123(info, request.getUserId(), hospitalCode);
                    result = 1;
                }
            } else if (DataRowState.DELETED.getValue().equals(info.getRowState())) {
                result = xrt0123Repository.deleteXrt0123(hospitalCode, info.getXrayGubun(), info.getBuwiCode());
            }
        }
        response.setResult(result != null && result > 0);
        return response.build();
    }

    private void insertXrt0123(XRT0123U00GrdDCodeItemInfo request, String userId, String hospitalCode) {
        Xrt0123 xrt0123 = new Xrt0123();
        xrt0123.setSysDate(new Date());
        xrt0123.setSysId(userId);
        xrt0123.setUpdDate(new Date());
        xrt0123.setUpdId(userId);
        xrt0123.setHospCode(hospitalCode);
        xrt0123.setXrayGubun(request.getXrayGubun());
        xrt0123.setBuwiCode(request.getBuwiCode());
        xrt0123.setValtage(CommonUtils.parseDouble(request.getValtage()));
        xrt0123.setCurElectric(CommonUtils.parseDouble(request.getCurElectric()));
        xrt0123.setTime(CommonUtils.parseDouble(request.getTime()));
        xrt0123.setDistance(CommonUtils.parseDouble(request.getDistance()));
        xrt0123.setGrid(request.getGrid());
        xrt0123.setNote(request.getNote());
        xrt0123.setFromAge(CommonUtils.parseDouble(request.getFromAge()));
        xrt0123.setToAge(CommonUtils.parseDouble(request.getToAge()));
        xrt0123.setMasVal(CommonUtils.parseDouble(request.getMasVal()));
        xrt0123Repository.save(xrt0123);
    }
}