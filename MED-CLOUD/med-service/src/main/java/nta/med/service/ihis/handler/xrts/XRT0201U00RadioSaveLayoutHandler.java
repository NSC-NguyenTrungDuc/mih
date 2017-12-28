package nta.med.service.ihis.handler.xrts;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.xrt.Xrt0202Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.XrtsModelProto.XRT0201U00GrdRadioListItemInfo;
import nta.med.service.ihis.proto.XrtsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class XRT0201U00RadioSaveLayoutHandler extends ScreenHandler<XrtsServiceProto.XRT0201U00RadioSaveLayoutRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0201U00RadioSaveLayoutHandler.class);
    @Resource
    private Xrt0202Repository xrt0202Repository;

    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0201U00RadioSaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        Integer result = null;
        for (XRT0201U00GrdRadioListItemInfo info : request.getGrdRadioListItemInfoList()) {
            if (DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
                Double fkxrt0201 = CommonUtils.parseDouble(info.getFkxrt0201());
                result = xrt0202Repository.updateXRT0201U00RadioSaveLayout(getHospitalCode(vertx, sessionId), request.getUserId(),
                        info.getTubeVol(), info.getTubeCur(), info.getXrayTime(), info.getTubeCurTime(),
                        info.getIrradiationTime(), info.getXrayDistance(), fkxrt0201, info.getXrayCodeIdx());
            }
        }
        response.setResult(result != null && result > 0);
        return response.build();
    }
}