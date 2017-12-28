package nta.med.service.ihis.handler.xrts;

import nta.med.data.dao.medi.xrt.Xrt0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
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
public class XRT0001U00MakeFindWorkerHandler extends ScreenHandler<XrtsServiceProto.XRT0001U00MakeFindWorkerRequest, SystemServiceProto.ComboResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0001U00MakeFindWorkerHandler.class);
    @Resource
    private Xrt0102Repository xrt0102Repository;

    @Override
    @Transactional(readOnly = true)
    public SystemServiceProto.ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0001U00MakeFindWorkerRequest request) throws Exception {
        SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        List<ComboListItemInfo> listCombo = null;
        switch (request.getCtrName()) {
            case "fbxXrayGubun1":
            case "fbxXrayGubun2":
                listCombo = xrt0102Repository.getXRT0001U00MakeFindWorker(hospitalCode, language, "X1", request.getFind1(), "SEQ");
                break;
            case "fbxXrayRoom1":
            case "fbxXrayRoom2":
                listCombo = xrt0102Repository.getXRT0001U00MakeFindWorker(hospitalCode, language, "X6", request.getFind1(), "CODE");
                break;
            case "fbxModality1":
            case "fbxModality2":
                listCombo = xrt0102Repository.getXRT0001U00MakeFindWorker(hospitalCode, language, "MO", request.getFind1(), "CODE");
                break;
            case "fbxReserType1":
            case "fbxReserType2":
                listCombo = xrt0102Repository.getXRT0001U00MakeFindWorker(hospitalCode, language, "Y", request.getFind1(), "CODE");
                break;
            default:
                break;
        }
        if (!CollectionUtils.isEmpty(listCombo)) {
            for (ComboListItemInfo item : listCombo) {
                CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getCode())) {
                    info.setCode(item.getCode());
                }
                if (!StringUtils.isEmpty(item.getCodeName())) {
                    info.setCodeName(item.getCodeName());
                }
                response.addComboItem(info);
            }
        }
        return response.build();
    }
}