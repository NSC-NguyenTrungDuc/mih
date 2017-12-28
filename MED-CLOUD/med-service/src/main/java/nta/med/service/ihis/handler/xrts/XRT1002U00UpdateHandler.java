package nta.med.service.ihis.handler.xrts;

import nta.med.core.domain.ocs.Ocs1801;
import nta.med.core.domain.xrt.Xrt1002;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1801Repository;
import nta.med.data.dao.medi.xrt.Xrt1002Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.XrtsModelProto.XRT1002U00GrdPaStatusInfo;
import nta.med.service.ihis.proto.XrtsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;
import java.util.Date;
import java.util.List;

@Service
@Scope("prototype")
@Transactional
public class XRT1002U00UpdateHandler extends ScreenHandler<XrtsServiceProto.XRT1002U00UpdateRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT1002U00UpdateHandler.class);
    @Resource
    private Xrt1002Repository xrt1002Repository;
    @Resource
    private Ocs1801Repository ocs1801Repository;

    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT1002U00UpdateRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        Integer result = null;
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        // INSERT/UPDATE XRT1002_IU
        Double fkocs = CommonUtils.parseDouble(request.getFkocs());
        List<String> getCheckYXrt1002 = xrt1002Repository.getCheckY(hospitalCode, fkocs);
        if (!CollectionUtils.isEmpty(getCheckYXrt1002)) {
            if ("Y".equalsIgnoreCase(getCheckYXrt1002.get(0))) {
                result = xrt1002Repository.updateXrt1002(hospitalCode, request.getUpdId(), request.getInOutGubun(), request.getHangmogCode(), request.getBunho(),
                        request.getGumsaMokjuk(), request.getXrayMethod(), request.getPandokRequestYn(), fkocs);
            }
        } else {
            insertXrt1002(request, hospitalCode);
            result = 1;
        }
        // INSERT/UPDATE OCS1801_IU
        for (XRT1002U00GrdPaStatusInfo info : request.getGrdPaItemList()) {
            List<String> getCheckYOcs1801 = ocs1801Repository.getCheckY(hospitalCode, info.getPatStatus(), request.getBunho());
            if (!CollectionUtils.isEmpty(getCheckYOcs1801)) {
                if ("Y".equals(getCheckYOcs1801.get(0))) {
                    Double seq = CommonUtils.parseDouble(info.getSeq());
                    result = ocs1801Repository.updateOcs1801(hospitalCode, request.getUpdId(), info.getPatStatus(), info.getPatStatusCode(), info.getMent(), seq, request.getBunho());
                }
            } else {
                insertOcs1801(info, request.getUpdId(), request.getBunho(), hospitalCode);
                result = 1;
            }
        }
        response.setResult(result != null && result > 0);
        return response.build();
    }

    private void insertXrt1002(XrtsServiceProto.XRT1002U00UpdateRequest request, String hospitalCode) {
        Xrt1002 xrt1002 = new Xrt1002();
        Double fkOcs = CommonUtils.parseDouble(request.getFkocs());
        xrt1002.setSysDate(new Date());
        xrt1002.setUpdId(request.getUpdId());
        xrt1002.setUpdDate(new Date());
        xrt1002.setInOutGubun(request.getInOutGubun());
        xrt1002.setHangmogCode(request.getHangmogCode());
        xrt1002.setBunho(request.getBunho());
        xrt1002.setGumsaMokjuk(request.getGumsaMokjuk());
        xrt1002.setXrayMethod(request.getXrayMethod());
        xrt1002.setPandokRequestYn(request.getPandokRequestYn());
        xrt1002.setFkocs(fkOcs);
        xrt1002.setHospCode(hospitalCode);
        xrt1002Repository.save(xrt1002);
    }

    private void insertOcs1801(XRT1002U00GrdPaStatusInfo info, String userId, String bunho, String hospitalCode) {
        Ocs1801 ocs1801 = new Ocs1801();
        Double seq = CommonUtils.parseDouble(info.getSeq());
        ocs1801.setSysDate(new Date());
        ocs1801.setUpdId(userId);
        ocs1801.setUpdDate(new Date());
        ocs1801.setBunho(bunho);
        ocs1801.setPatStatus(info.getPatStatus());
        ocs1801.setPatStatusCode(info.getPatStatusCode());
        ocs1801.setMent(info.getMent());
        ocs1801.setSeq(seq);
        ocs1801.setHospCode(hospitalCode);
        ocs1801Repository.save(ocs1801);
    }
}