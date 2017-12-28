package nta.med.service.ihis.handler.cpls;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.cpl.Cplreq1;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cplreq1Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto.CPL3010U01IsFileWriteInfo;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01IsFileWriteRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01IsFileWriteResponse;
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
public class CPL3010U01IsFileWriteHandler extends ScreenHandler<CplsServiceProto.CPL3010U01IsFileWriteRequest, CplsServiceProto.CPL3010U01IsFileWriteResponse> {
    @Resource
    private Cplreq1Repository cplreq1Repository;

    @Override
    public CPL3010U01IsFileWriteResponse handle(Vertx vertx, String clientId,
                                                String sessionId, long contextId,
                                                CPL3010U01IsFileWriteRequest request) throws Exception {
        CplsServiceProto.CPL3010U01IsFileWriteResponse.Builder response = CplsServiceProto.CPL3010U01IsFileWriteResponse.newBuilder();
        Integer totalPa = CommonUtils.parseInteger(request.getTotalPa());
        response.setResult(true);
        try{
            if (totalPa > 0) {
                cplreq1Repository.updateCPL3010U01IsWriteFileUpdateNoParam();
            }
            for (CPL3010U01IsFileWriteInfo info : request.getFileWriteLstList()) {
                List<String> getVal = cplreq1Repository.getYValue(info.getRequestKey());
                if (!CollectionUtils.isEmpty(getVal) && "Y".equals(getVal.get(0))) {
                    cplreq1Repository.updateCPL3010U01IsWriteFileSelectOrUpdate(request.getUserId(), info.getBunho(), info.getJubsuDate(),
                            info.getJubsuTime(), info.getHangmogCnt(), info.getUrine(), info.getSendYn(), info.getRequestKey());
                } else {
                    insertCplreq1(info, request.getUserId());
                }
            }
            return response.build();
        } catch (Exception e){
            response.setResult(false);
            throw new ExecutionException(response.build());
        }
    }


    public void insertCplreq1(CPL3010U01IsFileWriteInfo info, String userId) {
        Cplreq1 cplreq1 = new Cplreq1();
        cplreq1.setSysDate(new Date());
        cplreq1.setSysId(userId);
        cplreq1.setUpdDate(new Date());
        cplreq1.setUpdId(userId);
        cplreq1.setRequestKey(info.getRequestKey());
        cplreq1.setRequestDate(new Date());
        cplreq1.setRequestId(userId);
        cplreq1.setBunho(info.getBunho());
        cplreq1.setJubsuDate(info.getJubsuDate());
        cplreq1.setJubsuTime(info.getJubsuTime());
        cplreq1.setHangmogCnt(info.getHangmogCnt());
        cplreq1.setUrine(info.getUrine());
        cplreq1.setSendYn(info.getSendYn());
        cplreq1.setCurSendYn(info.getSendYn());
        cplreq1Repository.save(cplreq1);
    }
}