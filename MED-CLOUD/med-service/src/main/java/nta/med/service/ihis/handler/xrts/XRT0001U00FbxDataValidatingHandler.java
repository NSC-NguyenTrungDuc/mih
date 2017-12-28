package nta.med.service.ihis.handler.xrts;

import nta.med.data.dao.medi.xrt.Xrt0102Repository;
import nta.med.data.dao.medi.xrt.Xrt0122Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Service
@Scope("prototype")
public class XRT0001U00FbxDataValidatingHandler extends ScreenHandler<XrtsServiceProto.XRT0001U00FbxDataValidatingRequest, XrtsServiceProto.XRT0001U00FbxDataValidatingResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0001U00FbxDataValidatingHandler.class);
    @Resource
    private Xrt0102Repository xrt0102Repository;
    @Resource
    private Xrt0122Repository xrt0122Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0001U00FbxDataValidatingResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0001U00FbxDataValidatingRequest request) throws Exception {
        XrtsServiceProto.XRT0001U00FbxDataValidatingResponse.Builder response = XrtsServiceProto.XRT0001U00FbxDataValidatingResponse.newBuilder();
        String codeName = null;
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        switch (request.getFbName()) {
            case "fbxXrayGubun1":
                codeName = xrt0102Repository.getXRT0001U00FbxDataValidatingSelectXRT0102(hospitalCode, language, "X1", request.getCode());
                break;
            case "fbxXrayRoom1":
                codeName = xrt0102Repository.getXRT0001U00FbxDataValidatingSelectXRT0102(hospitalCode, language, "X6", request.getCode());
                break;
            case "fbxXrayBuwi1":
                codeName = xrt0122Repository.getXRT0001U00FbxDataValidatingSelectXRT0122(hospitalCode, language, request.getCode(), "N");
                break;
            case "fbxModality1":
                codeName = xrt0102Repository.getXRT0001U00FbxDataValidatingSelectXRT0102(hospitalCode, language, "MO", request.getCode());
                break;
            case "fbxReserType1":
                codeName = xrt0102Repository.getXRT0001U00FbxDataValidatingSelectXRT0102(hospitalCode, language, "Y", request.getCode());
                break;
            default:
                break;
        }
        if (!StringUtils.isEmpty(codeName)) {
            response.setCodeName(codeName);
        }
        return response.build();
    }
}