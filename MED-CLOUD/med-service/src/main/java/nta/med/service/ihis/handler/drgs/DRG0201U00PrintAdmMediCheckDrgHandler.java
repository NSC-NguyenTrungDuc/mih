package nta.med.service.ihis.handler.drgs;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.dao.medi.drg.Drg5010Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.service.CommonHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@Service
@Scope("prototype")
@Transactional
public class DRG0201U00PrintAdmMediCheckDrgHandler extends CommonHandler<DrgsServiceProto.DRG0201U00PrintAdmMediCheckDrgRequest, DrgsServiceProto.DRG0201U00PrintAdmMediCheckResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0201U00PrintAdmMediCheckDrgHandler.class);
    @Resource
    private Ocs1003Repository ocs1003Repository;
    @Resource
    private Drg5010Repository drg5010Repository;
    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DRG0201U00PrintAdmMediCheckDrgRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getJubsuDate()) && DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) == null) {
            return true;
        }
        return true;
    }

    @Override
    public DrgsServiceProto.DRG0201U00PrintAdmMediCheckResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0201U00PrintAdmMediCheckDrgRequest request) throws Exception {
        DrgsServiceProto.DRG0201U00PrintAdmMediCheckResponse.Builder response = DrgsServiceProto.DRG0201U00PrintAdmMediCheckResponse.newBuilder();
        String hospitalCode = getHospitalCode(vertx, sessionId);
        List<String> listObject = ocs1003Repository.validatePrintAdmMediRequest(hospitalCode, request.getJubsuDate(), request.getDrgBunho(), request.getBunho(), "");
        String oErr = "";
        String relVal = null;
        Double pkdrg5010 = null;
        if (!CollectionUtils.isEmpty(listObject)) {
            String item = listObject.get(0);
            if ("C".equalsIgnoreCase(item) || "D".equalsIgnoreCase(item)) {
                //Double ret1 =drg5010Repository.callPrJihDrgDrg5010Insert(hospitalCode, jubsuDate, drgBunho, dataDubun, inOutGubun, bunho, fk);
                Date jubsuDate = DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD);
                pkdrg5010 = drg5010Repository.callPrJihDrgDrg5010Insert(hospitalCode,
                        jubsuDate, request.getDrgBunho(), request.getDataDubun(), request.getInOutGubun(),
                        request.getBunho(), CommonUtils.parseInteger(request.getFk()));
                if (pkdrg5010 == null || pkdrg5010.equals(new Double(-1))) {
                    response.setMsgResult("1");
                    response.setErrMsg("R_JIH_DRG_DRG5010_INSERT result is null or -1");
                    throw new ExecutionException(response.build());
                } else {
                    List<String> bunryu1 = new ArrayList<String>();
                    bunryu1.add("1");
                    bunryu1.add("6");
                    Integer updateDrg2010 = drg2010Repository.updateDRG0201U00ProcAtcInterface(pkdrg5010, hospitalCode, jubsuDate, CommonUtils.parseDouble(request.getDrgBunho()), request.getBunho(), bunryu1);
                    LOGGER.info("updateDRG0201U00ProcAtcInterface result is " + updateDrg2010);
                    if (updateDrg2010 > 0) {
                        oErr = prJihDrgIfsProc(hospitalCode, "O", pkdrg5010, request.getUserId());
                        if (oErr.equalsIgnoreCase("1")) {
                            response.setMsgResult("3");
                            response.setErrMsg("prJihDrgIfsProc result is null or -1");
                            throw new ExecutionException(response.build());
                        } else {
                            relVal = oErr;
                        }
                        LOGGER.info("prJihDrgIfsProc oErr= " + oErr);
                    } else {
                        response.setMsgResult("2");
                        response.setErrMsg("updateDRG0201U00ProcAtcInterface result is null or -1");
                        throw new ExecutionException(response.build());
                    }
                }
            }
        }
        if (!StringUtils.isEmpty(relVal)) {
            response.setRetVal(relVal);
        }
        if (pkdrg5010 != null) {
            response.setPkdrg(Double.toString(pkdrg5010));
        }
        return response.build();
    }
}